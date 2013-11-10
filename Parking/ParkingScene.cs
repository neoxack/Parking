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
        private ParkingPlace[] parkingPlaces;     //массив парковочных мест
        private AdjacencyGraph<Vertex, Edge<Vertex>> graph = new AdjacencyGraph<Vertex, Edge<Vertex>>(); //граф парковки
        private Timer addCarTimer = new Timer(); //таймер добавления машин
        private Timer checkParkingPlaceTimer = new Timer(); //таймер проверки, не пора ли освобождать парковочное место

        public float ParkingTariffAutomobile { get; set; } //тариф за автомобиль
        public float ParkingTariffLorry { get; set; }      //тариф за грузовик
        public float MoneyInCash { get; set; }             //денег в кассе

        //метод добавления ребра на граф
        private void AddEdge(Vertex v1, Vertex v2) 
        {
            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddEdge(new Edge<Vertex>(v1, v2));
        }

        private Vertex startVertex; //начальная вершина графа
        private Vertex endVertex;   //конечная вершина графа

        //конструктор сцены
        public ParkingScene()
        {
            MoneyInCash = 0.0f;

            //создаём вершины графа
            Vertex v1 = new Vertex(1, new Vector2(850, 525));
            Vertex v2 = new Vertex(2, new Vector2(580, 525));
            Vertex v3 = new Vertex(3, new Vector2(580, 400));
            Vertex v4 = new Vertex(4, new Vector2(450, 400));
            Vertex v5 = new Vertex(5, new Vector2(700, 400));

            Vertex v6 = new Vertex(6, new Vector2(580, 300));
            Vertex v7 = new Vertex(7, new Vector2(450, 300));
            Vertex v8 = new Vertex(8, new Vector2(700, 300));

            Vertex v9 = new Vertex(9, new Vector2(580, 200));
            Vertex v10 = new Vertex(10, new Vector2(450, 200));
            Vertex v11 = new Vertex(11, new Vector2(700, 200));

            Vertex v12 = new Vertex(12, new Vector2(580, 100));
            Vertex v13 = new Vertex(13, new Vector2(450, 100));
            Vertex v14 = new Vertex(14, new Vector2(700, 100));

            Vertex v15 = new Vertex(15, new Vector2(540, 30));
            Vertex v16 = new Vertex(16, new Vector2(450, 30));
            Vertex v17 = new Vertex(17, new Vector2(300, 30));

            Vertex v18 = new Vertex(18, new Vector2(300, 100));
            Vertex v19 = new Vertex(19, new Vector2(125, 100));

            Vertex v20 = new Vertex(20, new Vector2(300, 200));
            Vertex v21 = new Vertex(21, new Vector2(125, 200));

            Vertex v22 = new Vertex(22, new Vector2(300, 300));
            Vertex v23 = new Vertex(23, new Vector2(125, 300));

            Vertex v24 = new Vertex(24, new Vector2(300, 400));
            Vertex v25 = new Vertex(25, new Vector2(125, 400));
            Vertex v26 = new Vertex(26, new Vector2(300, 525));
            Vertex v27 = new Vertex(27, new Vector2(125, 525));
            Vertex v28 = new Vertex(28, new Vector2(-50, 525));

            Vertex v29 = new Vertex(29, new Vector2(450, 525));

            //добавляем рёбра графа
            AddEdge(v1, v2);
            AddEdge(v2, v3);
            AddEdge(v3, v4);
            AddEdge(v3, v5);
            AddEdge(v3, v6);
            AddEdge(v6, v7);
            AddEdge(v6, v8);
            AddEdge(v6, v9);
            AddEdge(v9, v10);
            AddEdge(v9, v11);
            AddEdge(v9, v12);
            AddEdge(v12, v13);
            AddEdge(v12, v14);
            AddEdge(v12, v15);
            AddEdge(v15, v16);
            AddEdge(v16, v17);
            AddEdge(v17, v18);
            AddEdge(v18, v19);
            AddEdge(v18, v20);
            AddEdge(v20, v21);
            AddEdge(v20, v22);
            AddEdge(v22, v23);
            AddEdge(v22, v24);
            AddEdge(v24, v25);
            AddEdge(v24, v26);
            AddEdge(v26, v27);
            AddEdge(v27, v28);

            AddEdge(v2, v29);
            AddEdge(v29, v26);

            AddEdge(v4, v3);
            AddEdge(v5, v3);
            AddEdge(v7, v6);
            AddEdge(v8, v6);
            AddEdge(v10, v9);
            AddEdge(v11, v9);
            AddEdge(v13, v12);
            AddEdge(v14, v12);

            AddEdge(v19, v18);
            AddEdge(v21, v20);
            AddEdge(v23, v22);
            AddEdge(v25, v24);

            //создаём парковочные места
            ParkingPlace p1 = new ParkingPlace(1, v4, Car.TypeOfCar.Automobile);
            ParkingPlace p2 = new ParkingPlace(2, v7, Car.TypeOfCar.Automobile);
            ParkingPlace p3 = new ParkingPlace(3, v10, Car.TypeOfCar.Automobile);
            ParkingPlace p4 = new ParkingPlace(4, v13, Car.TypeOfCar.Automobile);

            ParkingPlace p5 = new ParkingPlace(5, v5, Car.TypeOfCar.Automobile);
            ParkingPlace p6 = new ParkingPlace(6, v8, Car.TypeOfCar.Automobile);
            ParkingPlace p7 = new ParkingPlace(7, v11, Car.TypeOfCar.Automobile);
            ParkingPlace p8 = new ParkingPlace(8, v14, Car.TypeOfCar.Automobile);

            ParkingPlace p1L = new ParkingPlace(1, v25, Car.TypeOfCar.Lorry);
            ParkingPlace p2L = new ParkingPlace(2, v23, Car.TypeOfCar.Lorry);
            ParkingPlace p3L = new ParkingPlace(3, v21, Car.TypeOfCar.Lorry);
            ParkingPlace p4L = new ParkingPlace(4, v19, Car.TypeOfCar.Lorry);


            parkingPlaces = new[] { p1, p2, p3, p4, p5, p6, p7, p8, p1L, p2L, p3L, p4L };
            startVertex = v1;
            endVertex = v28;

            //настраиваем и запускаем таймер добавления машин
            addCarTimer.Tick += new EventHandler(AddCarsOnScene);
            addCarTimer.Interval = 3000;
            addCarTimer.Start();

            //настраиваем и запускаем таймер проверки, не пора ли освобождать парковочное место
            checkParkingPlaceTimer.Tick += new EventHandler(CheckParkingPlace);
            checkParkingPlaceTimer.Interval = 1000;
            checkParkingPlaceTimer.Start();
        }

        //метод поиска ближайшего к въезду в парковку парковочного места
        private ParkingPlace FindParkingPlace(Car.TypeOfCar type)
        {
            ParkingPlace res = parkingPlaces.OrderBy(pp => Vector2.Distance(startVertex.Position, pp.VertexOnGraph.Position)).FirstOrDefault(pp => pp.Type == type && pp.IsEmpty);
            return res;
        }

        //метод таймера проверки, не пора ли освобождать парковочное место
        private void CheckParkingPlace(Object myObject, EventArgs myEventArgs)
        {
            TryFunc<Vertex, IEnumerable<Edge<Vertex>>> tryGetPath; //метод поиска пути
            IEnumerable<Edge<Vertex>> path; //путь

            foreach (ParkingPlace place in parkingPlaces)
            {
                if (!place.IsEmpty)
                {
                    if (DateTime.Now - place.ParkingTime >= place.ParkingPeriod)
                    {
                        tryGetPath = graph.ShortestPathsDijkstra(e => 1, place.VertexOnGraph); // ищем кратчайший путь от 
                        if (tryGetPath(endVertex, out path))                                   // текущего места к конечной вершине грфа (Алгоритм Дейкстры)
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
                tryGetPath = graph.ShortestPathsDijkstra(e => { if (e.Target.Number == 29) return 999; else return 1; }, startVertex); // метод поиска кратчайшего пути от начальной вершины графа к парковочному месту (Алгоритм Дейкстры)
                ParkingPlace place = FindParkingPlace(typeOfCar);                                                                      
                if (place == null)
                    finishVertex = endVertex;
                else
                {
                    finishVertex = place.VertexOnGraph;
                    place.Take(car, new TimeSpan(0, 0, parkingPeriod));
                    MoneyInCash += tarif * parkingPeriod;
                }
            }
            else
            {
                tryGetPath = graph.ShortestPathsDijkstra(e => 1, startVertex); // метод поиска кратчайшего пути от начальной вершины графа к конечной вершине (Алгоритм Дейкстры)
                finishVertex = endVertex;
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

        private Pen pen = new Pen(Color.White, 4);

        //метод отрисовки окружения
        private void RenderEnvironment(Graphics g)
        {
            g.DrawLine(pen, 0, 480, 220, 480);
            g.DrawLine(pen, 360, 480, 510, 480);
            g.DrawLine(pen, 640, 480, 800, 480);
        }

        //метод отрисовки сцены
        public void Render(Graphics g)
        {
            RenderEnvironment(g);
            foreach (ParkingPlace place in parkingPlaces)
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
                pen.Dispose();
                addCarTimer.Dispose();
                checkParkingPlaceTimer.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }
}
