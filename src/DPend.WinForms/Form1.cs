using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DPend.WinForms
{
    public partial class Form1 : Form
    {
        readonly Model.Simulator Sim = new(90, -10);

        public Form1()
        {
            InitializeComponent();
            Sim.Pendulum1.Length = 2;
        }

        private void Form1_Load(object sender, EventArgs e) => pictureBox1_SizeChanged(null, null);

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            Image oldImage = pictureBox1.Image;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            oldImage?.Dispose();
            RenderNow();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Sim.Step(.001, (int)nudSpeed.Value);
            RenderNow();
        }

        private void RenderNow()
        {
            Render((Bitmap)pictureBox1.Image, Sim);
            pictureBox1.Invalidate();
        }

        public static void Render(Bitmap bmp, Model.Simulator sim)
        {
            float pxPerMeter = 50;

            using Graphics gfx = Graphics.FromImage(bmp);
            gfx.Clear(Color.White);
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // frame text
            Font font = new(FontFamily.GenericMonospace, 12, FontStyle.Regular);
            gfx.DrawString($"{sim.Iterations}", font, Brushes.Black, 10, 10);

            // object at the center
            gfx.TranslateTransform(bmp.Width / 2, bmp.Height / 2);
            float r1 = 10;
            RectangleF rect1 = new(-r1, -r1, r1 * 2, r1 * 2);
            gfx.DrawEllipse(Pens.Black, rect1);

            // draw the first pendulum
            gfx.RotateTransform((float)sim.Pendulum1.ThetaDegrees);
            gfx.DrawLine(Pens.Black, 0, 0, 0, (float)sim.Pendulum1.Length * pxPerMeter);
            gfx.TranslateTransform(0, (float)sim.Pendulum1.Length * pxPerMeter);
            float r2 = 10;
            RectangleF rect2 = new(-r2, -r2, r2 * 2, r2 * 2);
            gfx.FillEllipse(Brushes.Blue, rect2);

            // draw the second pendulum
            gfx.RotateTransform((float)sim.Pendulum2.ThetaDegrees);
            gfx.DrawLine(Pens.Black, 0, 0, 0, (float)sim.Pendulum2.Length * pxPerMeter);
            gfx.TranslateTransform(0, (float)sim.Pendulum2.Length * pxPerMeter);
            float r3 = 10;
            RectangleF rect3 = new(-r3, -r3, r3 * 2, r3 * 2);
            gfx.FillEllipse(Brushes.Red, rect3);
        }

        private void nudLengthP1_ValueChanged(object sender, EventArgs e) => Sim.Pendulum1.Length = (double)nudLengthP1.Value;

        private void nudMassP1_ValueChanged(object sender, EventArgs e) => Sim.Pendulum1.Mass = (double)nudMassP1.Value;

        private void nudLengthP2_ValueChanged(object sender, EventArgs e) => Sim.Pendulum2.Length = (double)nudLengthP2.Value;

        private void nudMassP2_ValueChanged(object sender, EventArgs e) => Sim.Pendulum2.Mass = (double)nudMassP2.Value;
    }
}
