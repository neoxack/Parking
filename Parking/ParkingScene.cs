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
        private ParkingMap map; //карта
        private ParkingSceneSettings settings;//настройки сцены
        public float MoneyInCash { get; set; }             //денег в кассе

        //конструктор сцены
        public ParkingScene(ParkingMap map, ParkingSceneSettings settings)
        {
            this.settings = settings;
            this.map = map;
            MoneyInCash = 0.0f;
            map.Clear();      
        }

        public void Start()
        {
            //настраиваем и запускаем таймер добавления машин
            addCarTimer = new Timer();
            addCarTimer.Tick += new EventHandler(AddCarsOnScene);
            addCarTimer.Interval = settings.Interval;
            addCarTimer.Start();

            //настраиваем и запускаем таймер проверки, не пора ли освобождать парковочное место
            checkParkingPlaceTimer = new Timer();
            checkParkingPlaceTimer.Tick += new EventHandler(CheckParkingPlace);
            checkParkingPlaceTimer.Interval = 1000;
            checkParkingPlaceTimer.Start();
        }

        //метод поиска ближайшего к въезду в парковку парковочного места
        private ParkingPlace FindParkingPlace(TypeOfCar type)
        {
            ParkingPlace res = map.ParkingPlaces.OrderBy(pp => Vector2.Distance(map.EntranceVertex.Position, pp.VertexOnGraph.Position)).FirstOrDefault(pp => pp.Type == type && pp.IsEmpty);
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

        private int GetInterval()
        {
            int result = 5000;
            if (settings.Method == Method.Determined)
            {
                result = settings.Interval * 1000;
            }
            else
            {
                if (settings.DistributionLaw == DistributionLaw.Normal)
                {
                    result = (int)(RandGenerator.GaussRand(settings.M, settings.Sigma) * 1000);
                }
                else if (settings.DistributionLaw == DistributionLaw.Uniform)
                {
                    result = RandGenerator.Rand(settings.UniformA, settings.UniformB) * 1000;
                }
                else
                {
                    result = (int)(RandGenerator.ExpRand(settings.Lambda, settings.ExpA, settings.ExpB) * 1000);
                }
            }
            return result;
        }

        //метод таймера добавления машин на сцену
        private void AddCarsOnScene(Object myObject, EventArgs myEventArgs)
        {     
            addCarTimer.Stop();
            addCarTimer.Interval = GetInterval();
            
            TryFunc<Vertex, IEnumerable<Edge<Vertex>>> tryGetPath;
            Random rnd = new Random();
            
            int needParking = rnd.Next(3);
            int type = rnd.Next(4);
            int parkingPeriod = rnd.Next(5, 20) * 4;
            float tarif;
            TypeOfCar typeOfCar;
            if (type != 1)
            {
                typeOfCar = TypeOfCar.Automobile;
                tarif = settings.TarifAuto;
            }
            else
            {
                typeOfCar = TypeOfCar.Lorry;
                tarif = settings.TarifLorry;
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
            addCarTimer.Start();
        }

        private bool BelongsArea(Car c, Rectangle r)
        {
            if (c.coords.X >= r.Left && c.coords.X <= r.Right && c.coords.Y >= r.Top && c.coords.Y <= r.Bottom)
                return true;
            return false;

        }

        //метод обновления сцены
        public void Update(double deltaTime)
        {
            foreach (Car c in cars)
            {
                c.Update(deltaTime);
                foreach (Car c2 in cars)
                {
                    if (c != c2)
                    {
                        if (Vector2.Distance(c.coords, c2.coords) < 120)
                        {
                            if (c.coords.Y <= 450 && c2.coords.Y > 450)
                            {
                                c.Speed = 0.1 * c2.Speed;
                            }
                        }
                        else
                        {
                            c.Speed = 1.0;
                            c2.Speed = 1.0;
                        }
                    }
                }
            }


            cars.RemoveAll(c => c.coords.Equals(map.EndVertex.Position));
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
                if (addCarTimer != null) addCarTimer.Dispose();
                if (checkParkingPlaceTimer != null) checkParkingPlaceTimer.Dispose();
                if (checkParkingPlaceTimer != null) checkParkingPlaceTimer.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }
}
