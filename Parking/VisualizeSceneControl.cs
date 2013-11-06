using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Parking
{
    public partial class VisualizeSceneControl : UserControl
    {
        public IScene Scene { get; set; }
        public bool IsStarted { get; private set; }
        private Stopwatch stopwatch = new Stopwatch();
        private double deltaTime = 0;
        public float FPS { get; private set; }

        public VisualizeSceneControl()
        {
            IsStarted = false;
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque | ControlStyles.OptimizedDoubleBuffer, true);
        }

        public void Start(IScene scene)
        {
            this.Scene = scene;
            IsStarted = true;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            e.Graphics.Clear(this.BackColor);
            if (IsStarted)
            {
                Scene.Render(e.Graphics);
                deltaTime = stopwatch.Elapsed.TotalSeconds;
                Scene.Update(deltaTime);
                stopwatch.Restart();
                FPS = (float)(1.0 / deltaTime);
                Thread.Sleep(1);
                Application.DoEvents();
                this.Invalidate();

            }

        }


    }
}
