using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace SPSpsPSP1
{
    public partial class Form1 : Form
    {
        Color CurrentColor = Color.Black; //Default color
        Point CurrentPoint; //Current Position
        Point PrevPoint; //Previous Position
        bool isPressed;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

         void button1_Click(object sender, EventArgs e)
        {
            DialogResult D = colorDialog1.ShowDialog();
            if (D == System.Windows.Forms.DialogResult.OK)
                CurrentColor = colorDialog1.Color;
        }

        void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
            CurrentPoint = e.Location;
        }

         void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPressed)
            {
                PrevPoint = CurrentPoint;
                CurrentPoint = e.Location;
                paint_simple();
            }
        }

        void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
        }

         void paint_simple()
        {
            Pen p = new Pen(CurrentColor);
            g.DrawLine(p, PrevPoint, CurrentPoint);
        }

         void button2_Click_1(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        void button3_Click(object sender, EventArgs e)
        {
            
             Bitmap bitmap = new Bitmap(panel1.Width, panel1.Height);
             panel1.DrawToBitmap(bitmap, panel1.ClientRectangle);
            bitmap.Save(@"C:\Users\35-9\Pictures\panel1.png", System.Drawing.Imaging.ImageFormat.Png);
            
        }
    }
}
