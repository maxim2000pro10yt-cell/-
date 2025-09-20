using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2D_app
{
    public partial class Form1 : Form
    {
        public int FPS = 60;
        public double Gravity = 1;
        public double VelX = 0;
        public double VelY = 0;
        public int PosY = 0;
        public int PosX = 50;
        public int groundY;
        bool leftHeld = false;
        bool rightHeld = false;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Space && PosY + 100 >= groundY)
                VelY = -20;

            if (e.KeyCode == Keys.A)
                leftHeld = true;

            if (e.KeyCode == Keys.D)
                rightHeld = true;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (e.KeyCode == Keys.A)
                leftHeld = false;

            if (e.KeyCode == Keys.D)
                rightHeld = false;
        }
        public Form1()
        {
            DateTime lastCheck = DateTime.Now;
            this.BackColor = Color.Cyan;
            InitializeComponent();
            this.DoubleBuffered = true;

            Timer timer = new Timer();
            timer.Interval = 1000 / FPS;
            timer.Tick += (s, a) =>
            {
                Invalidate();
            };
            timer.Start();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            base.OnPaint(e);
            Timer timer = new Timer();
            g.Clear(this.BackColor);
            Rectangle Ground = new Rectangle(0, this.ClientSize.Height - 50, 20000, 100);
            g.FillRectangle(Brushes.Green, Ground);
            Rectangle Player = new Rectangle(PosX, PosY, 100, 100);
            g.FillRectangle(Brushes.Red, Player);
            groundY = this.ClientSize.Height - 50;
            VelY += Gravity;
            PosY += Convert.ToInt32(VelY);
            if (leftHeld) VelX -= 3;
            if (rightHeld) VelX += 3;
            VelX *= 0.8;
            PosX += Convert.ToInt32(VelX);
            if (PosY + 100 > Ground.Y)
            {
                PosY = Ground.Y - 100;
                VelY = 0;
            }
        }
    }
}