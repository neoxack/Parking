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
            List<ParkingMap> maps = new List<ParkingMap>();
            maps.Add(ParkingMap.CreateLittleMap());
            maps.Add(ParkingMap.CreateBigMap());

            mapSizeBox.DataSource = maps;
            mapSizeBox.DisplayMember = "Name";
            mapSizeBox.SelectedIndex = 0;

            //настраиваем и запускаем таймер обновления статистики(fps и кол-ва денег в кассе)
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = 500;
            myTimer.Start();   
        }

        ParkingScene scene; //сцена парковки
        ParkingSceneSettings settings = new ParkingSceneSettings(); //класс настроек
        //метод создания сцены
        private void CreateScene()
        {
            if(scene != null) scene.Dispose();
            scene = new ParkingScene((ParkingMap)mapSizeBox.SelectedItem, settings);
            visualizeSceneControl1.Scene = scene;
            scene.ParkingTariffAutomobile = 10; //тариф для легковых машин
            scene.ParkingTariffLorry = 20;      //тариф для грузовых машин
            visualizeSceneControl1.BackColor = Color.Gray;
        }

        //запуск визуализации сцены
        private void start_Click(object sender, EventArgs e)
        {
            mapSizeBox.Enabled = false;
            CreateScene();      
            visualizeSceneControl1.Start();
        }

        //остановка сцены
        private void stop_Click(object sender, EventArgs e)
        {
            visualizeSceneControl1.Stop();
            mapSizeBox.Enabled = true;
        }

        private void pause_Click(object sender, EventArgs e)
        {
            visualizeSceneControl1.Pause();
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings(settings);
            settingsForm.ShowDialog(this);
        }
    }
}
