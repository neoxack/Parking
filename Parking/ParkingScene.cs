using QuickGraph;
using QuickGraph.Algorithms;
using Splines;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Parking
{
    //основной класс сцены
    public class ParkingScene : IScene, IDisposable
    {
        private List<Car> cars = new List<Car>(); //список машин

        private Timer addCarTimer; //таймер добавления машин
        private Timer checkParkingPlaceTimer; //таймер проверки, не пора ли освобождать парковочное место
        private ParkingMap map;

        public float ParkingTariffAutomobile { get; set; } //тариф за автомобиль
        public float ParkingTariffLorry { get; set; }      //тариф за грузовик
        public float MoneyInCash { get; set; }             //денег в кассе

        //конструктор сцены
        public ParkingScene(ParkingMap map)
        {
            MoneyInCash = 0.0f;
            this.map = map;
            map.Clear();
            //настраиваем и запускаем таймер добавления машин
            addCarTimer = new Timer();
            addCarTimer.Tick += new EventHandler(AddCarsOnScene);
            addCarTimer.Interval = 3000;
            addCarTimer.Start();

            //настраиваем и запускаем таймер проверки, не пора ли освобождать парковочное место
            checkParkingPlaceTimer = new Timer();
            checkParkingPlaceTimer.Tick += new EventHandler(CheckParkingPlace);
            checkParkingPlaceTimer.Interval = 1000;
            checkParkingPlaceTimer.Start();
        }

        //метод поиска ближайшего к въезду в парковку парковочного места
        private ParkingPlace FindParkingPlace(Car.TypeOfCar type)
        {
            ParkingPlace res = map.ParkingPlaces.OrderBy(pp => Vector2.Distance(map.StartVertex.Position, pp.VertexOnGraph.Position)).FirstOrDefault(pp => pp.Type == type && pp.IsEmpty);
            return res;
        }

        //метод таймера проверки, не пора ли освобождать парковочное место
        private void CheckParkingPlace(Object myObject, EventArgs myEventArgs)
        {
            TryFunc<Vertex, IEnumerable<Edge<Vertex>>> tryGetPath; //метод поиска пути
            IEnumerable<Edge<Vertex>> path; //путь

            foreach (ParkingPlace place in map.ParkingPlaces)
            {
                if (!place.IsEmpty)
                {
                    if (DateTime.Now - place.ParkingTime >= place.ParkingPeriod)
                    {
                        tryGetPath = map.Graph.ShortestPathsDijkstra(e => 1, place.VertexOnGraph); // ищем кратчайший путь от 
                        if (tryGetPath(map.EndVertex, out path))                                   // текущего места к конечной вершине грфа (Алгоритм Дейкстры)
                        {
                            place.Car.Path = path;
                            place.Car = null;
                        }
                    }

                }
            }
        }

        //метод таймера добавления машин на сцену
        private void AddCarsOnScene(Object myObject, EventArgs myEventArgs)
        {
            TryFunc<Vertex, IEnumerable<Edge<Vertex>>> tryGetPath;
            Random rnd = new Random();
            
            int needParking = rnd.Next(3);
            int type = rnd.Next(4);
            int parkingPeriod = rnd.Next(5, 20) * 4;
            float tarif;
            Car.TypeOfCar typeOfCar;
            if (type != 1)
            {
                typeOfCar = Car.TypeOfCar.Automobile;
                tarif = ParkingTariffAutomobile;
            }
            else
            {
                typeOfCar = Car.TypeOfCar.Lorry;
                tarif = ParkingTariffLorry;
            }

            Car car = new Car(typeOfCar, 1.0f);
            Vertex finishVertex;
            IEnumerable<Edge<Vertex>> path;
            if (needParking == 1)
            {
                tryGetPath = map.Graph.ShortestPathsDijkstra(e => { if (e.Target == map.EntranceVertex) return 999; else return 1; }, map.StartVertex); // метод поиска кратчайшего пути от начальной вершины графа к парковочному месту (Алгоритм Дейкстры)
                ParkingPlace place = FindParkingPlace(typeOfCar);                                                                      
                if (place == null)
                    finishVertex = map.EndVertex;
                else
                {
                    finishVertex = place.VertexOnGraph;
                    place.Take(car, new TimeSpan(0, 0, parkingPeriod));
                    MoneyInCash += tarif * parkingPeriod;
                }
            }
            else
            {
                tryGetPath = map.Graph.ShortestPathsDijkstra(e => 1, map.StartVertex); // метод поиска кратчайшего пути от начальной вершины графа к конечной вершине (Алгоритм Дейкстры)
                finishVertex = map.EndVertex;
            }
            if (tryGetPath(finishVertex, out path))
            {
                car.Path = path;
            }
            cars.Add(car);
        }

        //метод обновления сцены
        public void Update(double deltaTime)
        {
            foreach (Car c in cars)
            {
                c.Update(deltaTime);
            }
        }

       

        //метод отрисовки окружения
        private void RenderEnvironment(Graphics g)
        {
            map.Render(g);
        }

        //метод отрисовки сцены
        public void Render(Graphics g)
        {
            RenderEnvironment(g);
            foreach (ParkingPlace place in map.ParkingPlaces)
            {
                place.Render(g);
            }
            foreach (Car car in cars)
            {
                car.Render(g);
            }
        }

        //метод освобождения ресурсов
        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                addCarTimer.Dispose();
                checkParkingPlaceTimer.Dispose();
                
                addCarTimer.Dispose();
                checkParkingPlaceTimer.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }
}
