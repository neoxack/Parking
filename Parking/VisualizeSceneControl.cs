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
        public VisualizeState State { get; set; }
        private Stopwatch stopwatch = new Stopwatch();
        private double deltaTime = 0;
        public float FPS { get; private set; }

        public VisualizeSceneControl()
        {
            State = VisualizeState.Stopped;
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque | ControlStyles.OptimizedDoubleBuffer, true);
        }

        public enum VisualizeState
        {
            Started,
            Stopped,
            Paused
        }

        public void Start()
        {
            State = VisualizeState.Started;
            this.Invalidate();
        }

        public void Stop()
        {
            State = VisualizeState.Stopped;
            this.Invalidate();
        }

        public void Pause()
        {
            State = VisualizeState.Paused;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            e.Graphics.Clear(this.BackColor);
            if (State == VisualizeState.Started)
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
            else if(State == VisualizeState.Paused)
            {
                stopwatch.Stop();
                Scene.Render(e.Graphics);
                Thread.Sleep(1);
                Application.DoEvents();
                this.Invalidate();
            }

        }


    }
}
