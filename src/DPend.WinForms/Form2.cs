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
    public partial class Form2 : Form
    {
        readonly Model.Simulator[] Sims;
        readonly Color[] Colors;

        public Form2()
        {
            InitializeComponent();

            const int simCount = 1000;
            Sims = new Model.Simulator[simCount];
            Colors = new Color[simCount];
            Initialize();
        }

        private void Form2_Load(object sender, EventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e) => Initialize();

        private void Initialize()
        {
            for (int i = 0; i < Sims.Length; i++)
            {
                Sims[i] = new Model.Simulator(180, 181 + (double)i / Sims.Length);
                Colors[i] = Colormap.Turbo((double)i / Sims.Length);
            }
            pictureBox1_SizeChanged(null, null);
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            Image oldImage = pictureBox1.Image;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            oldImage?.Dispose();
            Render();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var sim in Sims)
                sim.Step(.001, 10);
            Render();
        }

        private void Render(float pxPerMeter = 100)
        {
            if (pictureBox1.Image is null)
                return;

            Bitmap bmp = (Bitmap)pictureBox1.Image;
            using Graphics gfx = Graphics.FromImage(bmp);
            using Pen pen = new(Color.Magenta, 2);
            gfx.Clear(Color.Black);
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            for (int i = 0; i < Sims.Length; i++)
            {
                Model.Simulator sim = Sims[i];
                pen.Color = Color.FromArgb(100, Colors[i]);
                PointF pt1 = new(bmp.Width / 2, bmp.Height / 2);
                PointF pt2 = new(pt1.X + (float)sim.Pendulum1.DeltaX * pxPerMeter, pt1.Y + (float)sim.Pendulum1.DeltaY * pxPerMeter);
                PointF pt3 = new(pt2.X + (float)sim.Pendulum2.DeltaX * pxPerMeter, pt2.Y + (float)sim.Pendulum2.DeltaY * pxPerMeter);
                gfx.DrawLines(pen, new PointF[] { pt1, pt2, pt3 });
            }

            pictureBox1.Invalidate();
        }
    }
}
