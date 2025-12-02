using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace DEMOApp
{
    public partial class Form1 : Form
    {

        Size _cellSize;
        PictureBox[,] _userCaptcha = new PictureBox[2, 2];
        List<PictureBox> _visiblePictures = new List<PictureBox>();
        PictureBox[,] _succesCaptcha = new PictureBox[2, 2];
        bool _isCaptchaSucces= false;
        bool _isCaptchaEnded = false;

        int _captchaWrongTries = 0;
        public Form1()
        {
            InitializeComponent();
            SplitImageIntoImageList(@".\res\cat.png", 2, 2);
        }

        async private void enterBtn_Click(object sender, EventArgs e)
        {
            if (IsLoginOrPassowordEmpty(loginText.Text,passwordText.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           using(SqlConnection con = ConnectionString.GetConnection())
           {
               con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from Пользователи where логин =@log and пароль=@pas",con))
                {
                    cmd.Parameters.Add("@log",SqlDbType.NVarChar).Value= loginText.Text;
                    cmd.Parameters.Add("@pas", SqlDbType.NVarChar).Value = passwordText.Text;
                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    
                                    string id = reader.GetValue(reader.GetOrdinal("id")).ToString();
                                    bool isBlocked = reader.GetBoolean(reader.GetOrdinal("isBlocked"));
                                    int wrongTriesToLog = reader.GetInt32(reader.GetOrdinal("количество_неправильных_попыток_входа"));
                                    if (!IsBlocked(wrongTriesToLog, isBlocked))
                                    {
                                        bool isCapthcaSucces = await IsCaptchaSucces();
                                        if (!isCapthcaSucces)
                                        {
                                            BlockAccountInDB(con, id);
                                            MessageBox.Show("Аккаунт заблокирован потому что вы 3 раза неправильно собрали каптчу", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                        ChangeLastAuthDate(id, con);
                                        string role = reader.GetString(reader.GetOrdinal("должность"));
                                        MessageBox.Show("Все Норм", "Ура!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        if (role.Equals("Администратор"))
                                        {

                                            string password = reader.GetString(reader.GetOrdinal("пароль"));
                                            ChangePassword changePassword = new ChangePassword();
                                            changePassword.GetUserInfo(id, password);
                                            changePassword.Show();
                                        }
                                    }
                                    else
                                    {
                                        BlockAccountInDB(con, id);
                                        return;
                                    }
                                    
                                    
                                }
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин или пароль", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                WrongTryToLog(con);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Блин", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                }
           }
        }
        private bool IsLoginOrPassowordEmpty(string login,string password)
        {
            if (string.IsNullOrEmpty(login)||string.IsNullOrEmpty(password))
            {
                return true;
            }
            return false;
        }
        private void WrongTryToLog(SqlConnection con)
        {
            using(SqlCommand cmd = new SqlCommand("select * from Пользователи where логин=@log", con))
            {
                cmd.Parameters.Add("@log", SqlDbType.NVarChar).Value = loginText.Text;
                using (SqlDataReader reader2 = cmd.ExecuteReader())
                {
                    if (reader2.HasRows)
                    {
                        while (reader2.Read())
                        {
                            int tries = reader2.GetInt32(reader2.GetOrdinal("количество_неправильных_попыток_входа"));
                            //if (IsBlocked(tries, false)) return;
                        }
                        using (SqlCommand cmd2 = new SqlCommand("update Пользователи set количество_неправильных_попыток_входа +=1 where логин =@log ", con))
                        {
                            reader2.Close();
                            cmd2.Parameters.Add("@log", SqlDbType.NVarChar).Value = loginText.Text;
                            int changedRows = cmd2.ExecuteNonQuery();

                        }
                    }
                }
            }
        }
        private bool IsBlocked(int wrongTries, bool isBlocked)
        {
            if (wrongTries >= 3 || isBlocked)
            {
                MessageBox.Show("Аккаунт заблокирован", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
        private void BlockAccountInDB(SqlConnection con,string id)
        {
            using (SqlCommand cmd = new SqlCommand("update Пользователи set isBlocked = 1 where id=@id", con))
            {
                cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
                int changedRows = cmd.ExecuteNonQuery();
            }
        }
        private bool CheckLastAuth(DateTime date)
        {
            DateTime inDB = date.AddMonths(1);
            if (inDB > DateTime.Now)
            {
                //
            }
            else
            {
                return true;
            }
            return false;
        }
        
        private void ChangeLastAuthDate(string id,SqlConnection con)
        {
            using (SqlCommand cmd = new SqlCommand("update Пользователи set дата_последнего_захода = @date where id=@id", con))
            {
                cmd.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Today;
                cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
                int changedRows = cmd.ExecuteNonQuery();
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
                        WrongTryToLog(ConnectionString.GetConnection());
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
                    
                }
                _captchaWrongTries++;
            }
        }

        private void OffCapthcaButtons()
        {
            checkBtn.Enabled = false;
            clearBtn.Enabled = false;
        }
        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearTable();
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
        async private Task<bool> IsCaptchaSucces()
        {
            MessageBox.Show("Пройдите каптчу","Captcha",MessageBoxButtons.OK,MessageBoxIcon.Information);
            panel1.Visible = true;
            panel2.Enabled = false;
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

            
    }
}
