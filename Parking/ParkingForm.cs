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
    public partial class ParkingForm : Form
    {
        //таймер обновления статистики(fps и кол-ва денег в кассе)
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        //метод таймера
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            fpsLabel.Text = visualizeSceneControl1.FPS.ToString();
            if(scene != null)
                textBox1.Text = scene.MoneyInCash.ToString();
        }


        public ParkingForm()
        {
            InitializeComponent();

            //настраиваем и запускаем таймер обновления статистики(fps и кол-ва денег в кассе)
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = 200;
            myTimer.Start();

            //создаём сцену
            CreateScene();    
        }

        ParkingScene scene; //сцена парковки

        //метод создания сцены
        private void CreateScene()
        {
            scene = new ParkingScene();
            scene.ParkingTariffAutomobile = 10; //тариф для легковых машин
            scene.ParkingTariffLorry = 20;      //тариф для грузовых машин
            visualizeSceneControl1.BackColor = Color.Gray;
        }

        //запуск визуализации сцены
        private void start_Click(object sender, EventArgs e)
        {                   
            visualizeSceneControl1.Scene = scene;
            visualizeSceneControl1.Start();
        }

        //остановка сцены
        private void stop_Click(object sender, EventArgs e)
        {
            visualizeSceneControl1.Stop();
            CreateScene();
        }

        private void pause_Click(object sender, EventArgs e)
        {
            visualizeSceneControl1.Pause();
        }
    }
}
