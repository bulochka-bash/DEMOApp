using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp2
{
    internal class ElementDrag
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private Control dragControl;

        static PictureBox pictureBox = new PictureBox();
        static PictureBox pictureBoxCopy = new PictureBox();
        public ElementDrag(Control element) 
        {
            this.dragControl = element; 
            element.MouseDown += PanelTitle_MouseDown;
            element.MouseMove += PanelTitle_MouseMove;
            element.MouseUp += PanelTitle_MouseUp;
        }

        public static PictureBox GetPicture()
        {
            pictureBox.Visible = false;
            return pictureBoxCopy;          
        }

        private PictureBox CopyPictureBox(PictureBox original)
        {
            PictureBox copy = new PictureBox();

            // Копируем основные свойства
            copy.Name = original.Name;
            copy.Size = original.Size;
            copy.Location = original.Location;
            copy.BackColor = original.BackColor;
            copy.BorderStyle = original.BorderStyle;
            copy.SizeMode = original.SizeMode;
            copy.Visible = original.Visible;
            copy.Enabled = original.Enabled;


            // Копируем изображение (важно создать новую копию)
            if (original.Image != null)
            {
                copy.Image = new Bitmap(original.Image);
            }

            return copy;
        }

        private void PanelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            var dragData = new DataObject();
            dragData.SetData("SourceControl", dragControl);
            dragData.SetData("Text", "nn");
            pictureBox = sender as PictureBox;
            pictureBoxCopy = CopyPictureBox(pictureBox);
            DragDropEffects result = dragControl.DoDragDrop(dragData, DragDropEffects.Move);
            if (result == DragDropEffects.Move) 
            {
            }
            else
            {
                MessageBox.Show("blin");
                return;
            }

                //dragging = true;
                //dragCursorPoint = Cursor.Position;
                //dragFormPoint = this.dragControl.Location;
            
        }
        private void PanelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            //if (dragging)
            //{
            //    Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
            //    this.dragControl.Location = Point.Add(dragFormPoint, new Size(dif));
            //}
        }
        private void PanelTitle_MouseUp(object sender, MouseEventArgs e)
        {
            //dragging = false;
            
        }

    }
}
