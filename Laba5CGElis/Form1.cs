// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Form1.cs" company="">
//   
// </copyright>
// <summary>
//   The form 1.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Laba5
{
    /// <summary>
    /// The form 1.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The i.
        /// </summary>
        private int i = 0;

        /// <summary>
        /// The j.
        /// </summary>
        private int j = 0;

        /// <summary>
        /// The h.
        /// </summary>
        private int h = 0;

        /// <summary>
        /// The k.
        /// </summary>
        private int K = 50;

        /// <summary>
        /// The setka.
        /// </summary>
        private int setka = 30;

        private static bool isGtime = false;

        private static int Gtime = 0;
        
        private static bool isRolling = false;
        
        private Graphics g;
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            g = this.CreateGraphics();
            K = trackBar1.Value * 20 + 20;

            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            this.DoubleBuffered = true;
        }

        /// <summary>
        /// The form 1_ key press.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        /// <summary>
        /// The button 1_ click_1.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!isRolling)
            {
                timer1.Start();
                var ds = new DrawObj(this, K, -50, 50, 50);
                ds.DrawIsometricView(g, i, j, Color.Black, setka);
                panel1.Invalidate();
                //i += 10;
                //j += 10;
                isRolling = true;
                button1.Text = "Stop";
            }
            else
            {
                isRolling = false;
                timer1.Stop();
                button1.Text = "Rotate";
            }
        }

        /// <summary>
        /// The track bar 1_ scroll.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            K = trackBar1.Value * 20 + 20;
            this.Invalidate();
        }

        /// <summary>
        /// The timer 1_ tick.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
            if (isGtime) i += 1;
            else j += 1;
            Gtime++;
            if (Gtime % 180 == 0) isGtime = !isGtime;
        }
        
        /// <summary>
        /// The track bar 2_ scroll.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            setka = 5 + (int)(trackBar2.Value * 2.5);
            this.Invalidate();
        }

        private void Panel1Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var ds = new DrawObj(this, K, -50, 50, 50);
            ds.DrawIsometricView(e.Graphics, i, j, Color.Black, setka);
        }
    }
}