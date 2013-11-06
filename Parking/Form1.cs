using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parking
{
    public partial class Form1 : Form
    {
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();


        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            label3.Text = visualizeSceneControl1.FPS.ToString();
        }


        public Form1()
        {
            InitializeComponent();
        }

        IScene scene;
        private void button1_Click(object sender, EventArgs e)
        {
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = 200;
            myTimer.Start();

            scene = new ParkingScene();
            visualizeSceneControl1.BackColor = Color.Gray;
            visualizeSceneControl1.Start(scene);
        }
    }
}
