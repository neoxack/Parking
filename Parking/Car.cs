using QuickGraph;
using Splines;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parking
{
    //класс машин
    public class Car : ISceneObject
    {
        // перечисление типа машин
        public enum TypeOfCar 
        {
            Lorry, //грузовая
            Automobile //легковая
        }

        public double Speed { get; set; } //скорость
        public TypeOfCar Type { get; private set; } //тип машины

        private int pathLength = 1; //кол-во вершин в текущем пути передвижения машины
        public IEnumerable<Edge<Vertex>> Path  //путь передвижения (перечисление рёбер графа)
        {
            get { return path; }
            set
            { 
                path = value; 
                List<Vector2> points = new List<Vector2>();
                foreach(Edge<Vertex> edge in path)
                {
                    points.Add(edge.Source.Position);
                }
                points.Add(path.Last().Target.Position);
                spline.SetPoints(points.ToArray()); //задаём точки для сплайна
                pathLength = points.Count;          //узнаём кол-во вершин в текущем пути передвижения машины
                t = 0.0f;
            } 
        }

        private static Brush brush1 = new SolidBrush(Color.Red);   //кисть для рисования легковой машины
        private static Brush brush2 = new SolidBrush(Color.Green); //кисть для рисования грузовой машины
        private CatmullRom spline = new CatmullRom();              //сплайн катмулл-рома
        private IEnumerable<Edge<Vertex>> path;                    //путь передвижения (перечисление рёбер графа)
        private double t;                                          //параметр сплайна (от 0 до 1) - в зависимости от него получаем текущую координату машины
        private Vector2 coords;                                    //текущие координаты машины

        //конструктор машины
        public Car(TypeOfCar type, float speed)
        {
            Type = type;
            Speed = speed;
        }

        //метод обновления (deltaTime - время, прошеднее с момента последнего обновления)
        public void Update(double deltaTime)
        {
            if (t < 1.0f)
            {
                t += (Speed * deltaTime) / pathLength;
                coords = spline.GetCoords(t);
            }
        }

        //метод отрисовки машины
        public void Render(Graphics g)
        {
            if(Type == TypeOfCar.Automobile)
                g.FillRectangle(brush1, coords.X - 10, coords.Y - 10, 20, 20);
            else
                g.FillRectangle(brush2, coords.X - 10, coords.Y - 10, 20, 20);
        }
    }
}
