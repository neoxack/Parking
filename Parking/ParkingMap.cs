using QuickGraph;
using Splines;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class ParkingMap
    {
        public string Name { get; private set; }
        public AdjacencyGraph<Vertex, Edge<Vertex>> Graph { get; private set; }
        public Vertex StartVertex { get; private set; }
        public Vertex EndVertex { get; private set; }
        public Vertex EntranceVertex { get; private set; }
        public ParkingPlace[] ParkingPlaces { get; private set; }     //массив парковочных мест
        public int Width { get; private set; }
        public int Height { get; private set; }

        public ParkingMap(string name, int width, int height)
        {
            Name = name;
            Width = width;
            Height = height;
            Graph = new AdjacencyGraph<Vertex, Edge<Vertex>>();
        }

        public void Clear()
        {
            foreach (ParkingPlace place in ParkingPlaces)
            {
                place.Car = null;
            }
        }

        private Pen pen = new Pen(Color.White, 4);
        public void Render(Graphics g)
        {
            g.DrawLine(pen, 0, Height - 120, 220, Height - 120);
            g.DrawLine(pen, 360, Height - 120, 520, Height - 120);
            g.DrawLine(pen, 640, Height - 120, 800, Height - 120);
        }

        //метод добавления ребра на граф
        private void AddEdge(Vertex v1, Vertex v2)
        {
            Graph.AddVertex(v1);
            Graph.AddVertex(v2);
            Graph.AddEdge(new Edge<Vertex>(v1, v2));
        }

        public static ParkingMap CreateLittleMap()
        {
            ParkingMap result = new ParkingMap("Малая карта", 800, 600);
            //создаём вершины графа
            Vertex v1 = new Vertex(1, new Vector2(850, 525));
            Vertex v2 = new Vertex(2, new Vector2(600, 525));
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
            result.AddEdge(v1, v2);
            result.AddEdge(v2, v3);
            result.AddEdge(v3, v4);
            result.AddEdge(v3, v5);
            result.AddEdge(v3, v6);
            result.AddEdge(v6, v7);
            result.AddEdge(v6, v8);
            result.AddEdge(v6, v9);
            result.AddEdge(v9, v10);
            result.AddEdge(v9, v11);
            result.AddEdge(v9, v12);
            result.AddEdge(v12, v13);
            result.AddEdge(v12, v14);
            result.AddEdge(v12, v15);
            result.AddEdge(v15, v16);
            result.AddEdge(v16, v17);
            result.AddEdge(v17, v18);
            result.AddEdge(v18, v19);
            result.AddEdge(v18, v20);
            result.AddEdge(v20, v21);
            result.AddEdge(v20, v22);
            result.AddEdge(v22, v23);
            result.AddEdge(v22, v24);
            result.AddEdge(v24, v25);
            result.AddEdge(v24, v26);
            result.AddEdge(v26, v27);
            result.AddEdge(v27, v28);

            result.AddEdge(v2, v29);
            result.AddEdge(v29, v26);

            result.AddEdge(v4, v3);
            result.AddEdge(v5, v3);
            result.AddEdge(v7, v6);
            result.AddEdge(v8, v6);
            result.AddEdge(v10, v9);
            result.AddEdge(v11, v9);
            result.AddEdge(v13, v12);
            result.AddEdge(v14, v12);

            result.AddEdge(v19, v18);
            result.AddEdge(v21, v20);
            result.AddEdge(v23, v22);
            result.AddEdge(v25, v24);

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


            result.ParkingPlaces = new[] { p1, p2, p3, p4, p5, p6, p7, p8, p1L, p2L, p3L, p4L };
            result.StartVertex = v1;
            result.EndVertex = v28;
            result.EntranceVertex = v29;
            return result;
        }

        public static ParkingMap CreateBigMap()
        {
            ParkingMap result = new ParkingMap("Большая карта", 800, 700);
            //создаём вершины графа
            Vertex v1 = new Vertex(1, new Vector2(850, 625));
            Vertex v2 = new Vertex(2, new Vector2(590, 625));
            Vertex v3 = new Vertex(3, new Vector2(425, 625));
            Vertex v4 = new Vertex(4, new Vector2(275, 625));
            Vertex v5 = new Vertex(5, new Vector2(125, 625));
            Vertex v6 = new Vertex(6, new Vector2(-50, 625));

            Vertex v9 = new Vertex(9, new Vector2(700, 475));
            Vertex v7 = new Vertex(7, new Vector2(575, 475));
            Vertex v8 = new Vertex(8, new Vector2(425, 475));
            Vertex v33 = new Vertex(33, new Vector2(275, 475));
            Vertex v34 = new Vertex(34, new Vector2(125, 475));

            Vertex v11 = new Vertex(11, new Vector2(700, 375));
            Vertex v10 = new Vertex(10, new Vector2(575, 375));
            Vertex v12 = new Vertex(12, new Vector2(425, 375));
            Vertex v31 = new Vertex(31, new Vector2(275, 375));
            Vertex v32 = new Vertex(32, new Vector2(125, 375));

            Vertex v15 = new Vertex(15, new Vector2(700, 275));
            Vertex v13 = new Vertex(13, new Vector2(575, 275));
            Vertex v14 = new Vertex(14, new Vector2(425, 275));
            Vertex v29 = new Vertex(29, new Vector2(275, 275));
            Vertex v30 = new Vertex(30, new Vector2(125, 275));

            Vertex v18 = new Vertex(18, new Vector2(700, 175));
            Vertex v16 = new Vertex(16, new Vector2(575, 175));
            Vertex v17 = new Vertex(17, new Vector2(425, 175));
            Vertex v27 = new Vertex(27, new Vector2(275, 175));
            Vertex v28 = new Vertex(28, new Vector2(125, 175));

            Vertex v21 = new Vertex(21, new Vector2(700, 75));
            Vertex v19 = new Vertex(19, new Vector2(575, 75));
            Vertex v20 = new Vertex(20, new Vector2(425, 75));
            Vertex v25 = new Vertex(25, new Vector2(275, 75));
            Vertex v26 = new Vertex(26, new Vector2(125, 75));

            Vertex v23 = new Vertex(23, new Vector2(425, 15));

            
            result.AddEdge(v1, v2);
            result.AddEdge(v2, v3);
            result.AddEdge(v3, v4);
            result.AddEdge(v4, v5);
            result.AddEdge(v5, v6);

            result.AddEdge(v2, v7);
            result.AddEdge(v7, v8);
            result.AddEdge(v7, v9);

            result.AddEdge(v7, v10);
            result.AddEdge(v10, v12);
            result.AddEdge(v10, v11);

            result.AddEdge(v10, v13);
            result.AddEdge(v13, v14);
            result.AddEdge(v13, v15);

            result.AddEdge(v13, v16);
            result.AddEdge(v16, v17);
            result.AddEdge(v16, v18);

            result.AddEdge(v16, v19);
            result.AddEdge(v19, v20);
            result.AddEdge(v19, v21);
            result.AddEdge(v19, v23);

            result.AddEdge(v23, v25);

            result.AddEdge(v25, v26);
            result.AddEdge(v25, v27);
            result.AddEdge(v27, v28);
            result.AddEdge(v27, v29);
            result.AddEdge(v29, v30);
            result.AddEdge(v29, v31);
            result.AddEdge(v31, v32);
            result.AddEdge(v31, v33);
            result.AddEdge(v33, v34);
            result.AddEdge(v33, v4);

            result.AddEdge(v8, v7);
            result.AddEdge(v9, v7);
            result.AddEdge(v12, v10);
            result.AddEdge(v11, v10);
            result.AddEdge(v14, v13);
            result.AddEdge(v15, v13);
            result.AddEdge(v17, v16);
            result.AddEdge(v18, v16);
            result.AddEdge(v20, v19);
            result.AddEdge(v21, v19);

            result.AddEdge(v26, v25);
            result.AddEdge(v28, v27);
            result.AddEdge(v30, v29);
            result.AddEdge(v32, v31);
            result.AddEdge(v34, v33);

            //создаём парковочные места
            ParkingPlace p1 = new ParkingPlace(1, v8, Car.TypeOfCar.Automobile);
            ParkingPlace p2 = new ParkingPlace(2, v12, Car.TypeOfCar.Automobile);
            ParkingPlace p3 = new ParkingPlace(3, v14, Car.TypeOfCar.Automobile);
            ParkingPlace p4 = new ParkingPlace(4, v17, Car.TypeOfCar.Automobile);
            ParkingPlace p5 = new ParkingPlace(5, v20, Car.TypeOfCar.Automobile);

            ParkingPlace p6 = new ParkingPlace(6, v9, Car.TypeOfCar.Automobile);
            ParkingPlace p7 = new ParkingPlace(7, v11, Car.TypeOfCar.Automobile);
            ParkingPlace p8 = new ParkingPlace(8, v15, Car.TypeOfCar.Automobile);
            ParkingPlace p9 = new ParkingPlace(9, v18, Car.TypeOfCar.Automobile);
            ParkingPlace p10 = new ParkingPlace(20, v21, Car.TypeOfCar.Automobile);

            ParkingPlace p1L = new ParkingPlace(1, v34, Car.TypeOfCar.Lorry);
            ParkingPlace p2L = new ParkingPlace(2, v32, Car.TypeOfCar.Lorry);
            ParkingPlace p3L = new ParkingPlace(3, v30, Car.TypeOfCar.Lorry);
            ParkingPlace p4L = new ParkingPlace(4, v28, Car.TypeOfCar.Lorry);
            ParkingPlace p5L = new ParkingPlace(4, v26, Car.TypeOfCar.Lorry);


            result.ParkingPlaces = new[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p1L, p2L, p3L, p4L, p5L };
            result.StartVertex = v1;
            result.EndVertex = v6;
            result.EntranceVertex = v2;
            return result;
        }


    }
}
