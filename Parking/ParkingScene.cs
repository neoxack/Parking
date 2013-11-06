using QuickGraph;
using QuickGraph.Algorithms;
using Splines;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Parking
{
    public class ParkingScene : IScene, IDisposable 
    {
        private List<Car> cars = new List<Car>();
        private ParkingPlace[] parkingPlaces;
        private AdjacencyGraph<Vertex, Edge<Vertex>> graph = new AdjacencyGraph<Vertex, Edge<Vertex>>();

        private void AddEdge(Vertex v1, Vertex v2)
        {
            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddEdge(new Edge<Vertex>(v1, v2));
        }

        private Vertex startVertex;

        public ParkingScene()
        {
            Vertex v1 = new Vertex(new Vector2(800, 525));
            Vertex v2 = new Vertex(new Vector2(580, 525));
            Vertex v3 = new Vertex(new Vector2(580, 400));
            Vertex v4 = new Vertex(new Vector2(450, 400));
            Vertex v5 = new Vertex(new Vector2(700, 400));

            Vertex v6 = new Vertex(new Vector2(580, 300));
            Vertex v7 = new Vertex(new Vector2(450, 300));
            Vertex v8 = new Vertex(new Vector2(700, 300));

            Vertex v9 = new Vertex(new Vector2(580, 200));
            Vertex v10 = new Vertex(new Vector2(450, 200));
            Vertex v11 = new Vertex(new Vector2(700, 200));

            Vertex v12 = new Vertex(new Vector2(580, 100));
            Vertex v13 = new Vertex(new Vector2(450, 100));
            Vertex v14 = new Vertex(new Vector2(700, 100));

            Vertex v15 = new Vertex(new Vector2(540, 30));
            Vertex v16 = new Vertex(new Vector2(300, 30));

            Vertex v17 = new Vertex(new Vector2(300, 100));
            Vertex v18 = new Vertex(new Vector2(125, 100));

            Vertex v19 = new Vertex(new Vector2(300, 200));
            Vertex v20 = new Vertex(new Vector2(125, 200));

            Vertex v21 = new Vertex(new Vector2(300, 300));
            Vertex v22 = new Vertex(new Vector2(125, 300));

            Vertex v23 = new Vertex(new Vector2(300, 400));
            Vertex v24 = new Vertex(new Vector2(125, 400));
            Vertex v25 = new Vertex(new Vector2(300, 525));
            Vertex v26 = new Vertex(new Vector2(0, 525));

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
            AddEdge(v17, v19);
            AddEdge(v19, v20);
            AddEdge(v19, v21);
            AddEdge(v21, v22);
            AddEdge(v21, v23);
            AddEdge(v23, v24);
            AddEdge(v23, v25);
            AddEdge(v25, v26);

            ParkingPlace p1 = new ParkingPlace(1, v4, Car.TypeOfCar.Automobile);
            ParkingPlace p2 = new ParkingPlace(2, v7, Car.TypeOfCar.Automobile);
            ParkingPlace p3 = new ParkingPlace(3, v10, Car.TypeOfCar.Automobile);
            ParkingPlace p4 = new ParkingPlace(4, v13, Car.TypeOfCar.Automobile);

            ParkingPlace p5 = new ParkingPlace(5, v5, Car.TypeOfCar.Automobile);
            ParkingPlace p6 = new ParkingPlace(6, v8, Car.TypeOfCar.Automobile);
            ParkingPlace p7 = new ParkingPlace(7, v11, Car.TypeOfCar.Automobile);
            ParkingPlace p8 = new ParkingPlace(8, v14, Car.TypeOfCar.Automobile);

            ParkingPlace p1L = new ParkingPlace(1, v24, Car.TypeOfCar.Lorry);
            ParkingPlace p2L = new ParkingPlace(2, v22, Car.TypeOfCar.Lorry);
            ParkingPlace p3L = new ParkingPlace(3, v20, Car.TypeOfCar.Lorry);
            ParkingPlace p4L = new ParkingPlace(4, v18, Car.TypeOfCar.Lorry);


            parkingPlaces = new[] { p1, p2, p3, p4, p5, p6, p7, p8, p1L, p2L, p3L, p4L };
            startVertex = v1;
            AddCar(1.1, startVertex, v10);
            AddCar(1.1, v9, v26);
        }

        private void AddCar(double speed, Vertex v1, Vertex v2)
        {
            Car car = new Car(Car.TypeOfCar.Automobile);
            TryFunc<Vertex, IEnumerable<Edge<Vertex>>> tryGetPath = graph.ShortestPathsDijkstra(d => 1, v1);
            IEnumerable<Edge<Vertex>> path;

            car.Speed = speed;
            if (tryGetPath(v2, out path))
            {
                car.Path = path;
            }
           
            cars.Add(car);
        }

        public void Update(double deltaTime)
        {
            foreach (Car c in cars)
            {
                c.Update(deltaTime);
            }
        }

        private Pen pen = new Pen(Color.White, 4);

        private void RenderEnvironment(Graphics g)
        {
            g.DrawLine(pen, 0, 480, 220, 480);
            g.DrawLine(pen, 360, 480, 510, 480);
            g.DrawLine(pen, 640, 480, 800, 480);
        }

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

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                pen.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }
}
