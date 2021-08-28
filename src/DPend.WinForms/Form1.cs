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
        readonly Model.Simulator Sim = new(180, 10);
        readonly public List<PointF> History = new();

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
            Render();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cbRun.Checked)
            {
                Sim.Step(.001, (int)nudSpeed.Value);
                Render();
            }
        }

        public void Render()
        {
            float pxPerMeter = 50;

            Bitmap bmp = (Bitmap)pictureBox1.Image;
            using Graphics gfx = Graphics.FromImage(bmp);
            gfx.Clear(Color.White);
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            PointF pt1 = new(bmp.Width / 2, bmp.Height / 2);
            PointF pt2 = new(pt1.X + (float)Sim.Pendulum1.DeltaX * pxPerMeter, pt1.Y + (float)Sim.Pendulum1.DeltaY * pxPerMeter);
            PointF pt3 = new(pt2.X + (float)Sim.Pendulum2.DeltaX * pxPerMeter, pt2.Y + (float)Sim.Pendulum2.DeltaY * pxPerMeter);
            History.Add(pt3);

            using Pen pen1 = new(Color.Green, 5) { EndCap = System.Drawing.Drawing2D.LineCap.Round };
            using Pen pen2 = new(Color.Magenta, 5) { EndCap = System.Drawing.Drawing2D.LineCap.Round };
            gfx.DrawLine(pen1, pt1, pt2);
            gfx.DrawLine(pen2, pt2, pt3);

            using Pen historyPen = new(Color.FromArgb(50, Color.Black), 2);
            if (History.Count > 1)
                gfx.DrawLines(historyPen, History.TakeLast(500).ToArray());

            pictureBox1.Invalidate();
        }

        private void nudLengthP1_ValueChanged(object sender, EventArgs e) => Sim.Pendulum1.Length = (double)nudLengthP1.Value;

        private void nudMassP1_ValueChanged(object sender, EventArgs e) => Sim.Pendulum1.Mass = (double)nudMassP1.Value;

        private void nudLengthP2_ValueChanged(object sender, EventArgs e) => Sim.Pendulum2.Length = (double)nudLengthP2.Value;

        private void nudMassP2_ValueChanged(object sender, EventArgs e) => Sim.Pendulum2.Mass = (double)nudMassP2.Value;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            History.Clear();
            Random rand = new();
            Sim.Reset(rand.NextDouble() * 360, rand.NextDouble() * 360);
            Render();
        }
    }
}
