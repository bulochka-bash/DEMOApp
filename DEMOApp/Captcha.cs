using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace DEMOApp
{
    public partial class Captcha : Form
    {
        Size _cellSize;
        PictureBox[,] _userCaptcha = new PictureBox[2, 2];
        List<PictureBox> _visiblePictures = new List<PictureBox>();
        PictureBox[,] _succesCaptcha = new PictureBox[2, 2];
        bool _isCaptchaSucces = false;
        bool _isCaptchaEnded = false;

        int _captchaWrongTries = 0;

        public Captcha(int wrongTries)
        {
            InitializeComponent();
            SplitImageIntoImageList(@".\res\cat.png", 2, 2);
            _captchaWrongTries = wrongTries;
        }


        async public Task<bool> IsCaptchaSucces()
        {
            MessageBox.Show("Пройдите каптчу", "Captcha", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Show();
            await WaitForCaptcha();
            OffCapthcaButtons();
            return _isCaptchaSucces;
        }
        async private Task WaitForCaptcha()
        {
            while (!_isCaptchaEnded)
            {
                await Task.Delay(100);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ElementDrag elementDrag = new ElementDrag(pictureBox1);
            ElementDrag elementDrag1 = new ElementDrag(pictureBox2);
            ElementDrag elementDrag2 = new ElementDrag(pictureBox3);
            ElementDrag elementDrag3 = new ElementDrag(pictureBox4);
            _visiblePictures.AddRange(new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4 });
            for (int i = 0; i < _visiblePictures.Count; i++)
            {
                _visiblePictures[i].Image = imageList1.Images[i];
            }
            var arrayToConvert = new PictureBox[4];
            _visiblePictures.CopyTo(arrayToConvert);
            ConvertToDoubleArray(arrayToConvert);
            _cellSize = CalcCellSizeByTableSize();
        }
        private void SplitImageIntoImageList(string imagePath, int rows, int cols)
        {

            // Очищаем существующие изображения
            imageList1.Images.Clear();

            using (var originalImage = new Bitmap(imagePath))
            {
                int pieceWidth = originalImage.Width / cols;
                int pieceHeight = originalImage.Height / rows;

                // Устанавливаем размер изображений в ImageList
                imageList1.ImageSize = new Size(pieceWidth, pieceHeight);

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        // Создаем фрагмент
                        using (var piece = new Bitmap(pieceWidth, pieceHeight))
                        using (var graphics = Graphics.FromImage(piece))
                        {
                            var sourceRect = new Rectangle(
                                col * pieceWidth,
                                row * pieceHeight,
                                pieceWidth,
                                pieceHeight
                            );

                            graphics.DrawImage(originalImage, 0, 0, sourceRect, GraphicsUnit.Pixel);

                            // Добавляем в ImageList (нужно клонировать, т.к. piece будет disposed)
                            imageList1.Images.Add((Bitmap)piece.Clone());
                        }
                    }
                }
            }

        }
        private void ConvertToDoubleArray(PictureBox[] array)
        {
            for (int i = 0, other = 0; i < 2; i++, other++)
            {
                for (int j = 0; j < 2; j++, other++)
                {
                    _succesCaptcha[j, i] = array[other];
                }
                other--;
            }
        }
        private void tableLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void tableLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var pointDrop = tableLayoutPanel1.PointToClient(new Point(e.X, e.Y));
                var cellDrop = GetCellByPoint(pointDrop);
                if (!IsThisCellEmpty(cellDrop.column, cellDrop.row))
                {
                    MessageBox.Show("Эта ячейка уже занята", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _userCaptcha[cellDrop.column, cellDrop.row] = ElementDrag.GetPicture();
                tableLayoutPanel1.Controls.Add(ElementDrag.GetPicture(), cellDrop.column, cellDrop.row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private (int column, int row) GetCellByPoint(Point point)
        {
            for (int col = 0; col < tableLayoutPanel1.ColumnCount; col++)
            {
                for (int row = 0; row < tableLayoutPanel1.RowCount; row++)
                {
                    var cellBounds = GetCellRect(col, row);
                    if (cellBounds.Contains(point))
                    {
                        return (col, row);
                    }
                }
            }
            return (-1, -1);
        }
        private Rectangle GetCellRect(int column, int row)
        {
            var cellPos = GetCellPos(column, row);
            return new Rectangle(cellPos, _cellSize);
        }
        private Point GetCellPos(int column, int row)
        {
            var pos = new Point(column * _cellSize.Width, row * _cellSize.Height);
            return pos;
        }
        private bool IsCaptchaEquals()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (IsImageEqual(_succesCaptcha[j, i], _userCaptcha[j, i]))
                    {

                    }
                    else
                    {

                        Authorization.WrongTryToLog(ConnectionString.GetConnection(),Authorization.login);
                            // gay
                        MessageBox.Show("Каптча собрана неверно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            MessageBox.Show("Каптча собрана верно", "Captcha", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
        private bool IsImageEqual(PictureBox SuccesCaptha, PictureBox UserCaptha)
        {
            string succesName = SuccesCaptha.Name;
            string userName = UserCaptha.Name;
            if (succesName.Equals(userName))
            {
                return true;
            }
            return false;
        }
        private bool IsCaptchaNull()
        {
            if (tableLayoutPanel1.Controls.Count < 4)
            {
                MessageBox.Show("Заполните каптчу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
        private bool IsThisCellEmpty(int col, int row)
        {
            if (_userCaptcha[col, row] == null)
            {
                return true;
            }
            return false;
        }
        private Size CalcCellSizeByTableSize()
        {
            var width = tableLayoutPanel1.Width;
            var height = tableLayoutPanel1.Height;
            var columns = tableLayoutPanel1.ColumnCount;
            var rows = tableLayoutPanel1.RowCount;
            var cellSize = new Size(width / columns, height / rows);
            return cellSize;
        }
        private void ClearTable()
        {
            Array.Clear(_userCaptcha, 0, _userCaptcha.Length);
            TableLayoutControlCollection tableControls = tableLayoutPanel1.Controls;
            for (; tableControls.Count > 0;)
            {
                tableControls[0].Dispose();
            }
            for (int i = 0; i < _visiblePictures.Count; i++)
            {
                _visiblePictures[i].Visible = true;
            }
        }
        
        private void OffCapthcaButtons()
        {
            checkBtn.Enabled = false;
            clearBtn.Enabled = false;
        }
        private void checkBtn_Click(object sender, EventArgs e)
        {
            if (IsCaptchaNull()) return;
            if (IsCaptchaEquals())
            {
                _isCaptchaSucces = true;
                _isCaptchaEnded = true;
            }
            else
            {
                if (_captchaWrongTries >= 3)
                {
                    _isCaptchaSucces = false;
                    _isCaptchaEnded = true;
                    return;
                }
                _captchaWrongTries++;
            }
        }
        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearTable();
        }

    }
}
