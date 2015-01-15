using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Laba5
{
    public partial class Form1 : Form
    {
        private int i = 0, j = 0, h = 0, K = 50, setka = 30;

        public Form1()
        {

            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            // panel1.Paint +=
            //  new PaintEventHandler(panel1Paint);
        }



        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
            Graphics g = this.CreateGraphics();
            g.Clear(Color.Gray);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float radius = K;


            DrawObj ds = new DrawObj(this, radius, -50, 50, 50);
            ds.DrawIsometricView(g, i, j, Color.Goldenrod, setka);
            i += 10;
            j += 10;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            K = trackBar1.Value * 20 + 20;
            Graphics g = this.CreateGraphics();
            g.Clear(Color.Gray);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float radius = K;


            DrawObj ds = new DrawObj(this, radius, -50, 50, 50);
            ds.DrawIsometricView(g, i, j, Color.Goldenrod, setka);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.Gray);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float radius = K;


            DrawObj ds = new DrawObj(this, radius, -50, 50, 50);
            ds.DrawIsometricView(g, i, j, Color.Goldenrod, setka);
            i += 10;
            j += 10;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            setka = 5 + (int)(trackBar2.Value * 2.5);
            Graphics g = this.CreateGraphics();
            g.Clear(Color.Gray);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float radius = K;


            DrawObj ds = new DrawObj(this, radius, -50, 50, 50);
            ds.DrawIsometricView(g, i, j, Color.Goldenrod, setka);
        }
    }
}