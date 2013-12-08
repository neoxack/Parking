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
    public enum TypeOfCar
    {
        Lorry, //грузовая
        Automobile //легковая
    }
    //класс машин
    public class Car : ISceneObject
    {
        // перечисление типа машин
        
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

        //private static Brush brush1 = new SolidBrush(Color.Red);   //кисть для рисования легковой машины
        //private static Brush brush2 = new SolidBrush(Color.Green); //кисть для рисования грузовой машины
        private static Image autoImage = new Bitmap(Image.FromFile("auto.png"));
        private static Image lorryImage = new Bitmap(Image.FromFile("lorry.png"));
        private CatmullRom spline = new CatmullRom();              //сплайн катмулл-рома
        private IEnumerable<Edge<Vertex>> path;                    //путь передвижения (перечисление рёбер графа)
        private double t;                                          //параметр сплайна (от 0 до 1) - в зависимости от него получаем текущую координату машины
        public Vector2 coords { get; set; }                        //текущие координаты машины
        private Vector2 oldCoords;   

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

        public static Bitmap RotateImage(Image image, float angle)
        {

            Bitmap rotatedBmp = new Bitmap(image.Width+20, image.Width+20);
            Graphics g = Graphics.FromImage(rotatedBmp);
            g.TranslateTransform(image.Width / 2 + 10, image.Width / 2 + 10);
            g.RotateTransform(angle);
            g.TranslateTransform(-image.Width / 2 - 10, -image.Width / 2 - 10);
            g.DrawImageUnscaled(image, new Point(0, 0));
            return rotatedBmp;
        }

        //метод отрисовки машины
        public void Render(Graphics g)
        {
            float angle = (float)(Math.Atan2(coords.X - oldCoords.X, coords.Y - oldCoords.Y) / Math.PI * 180)+90;
            if (coords.Equals(oldCoords)) angle = 0;
            if (Type == TypeOfCar.Automobile)
            {
                Image rotatedImg = RotateImage(autoImage, -angle);
                g.DrawImage(rotatedImg, coords.X - 50 , coords.Y-10 );
            }
            else
            {
                Image rotatedImg = RotateImage(lorryImage, -angle);
                g.DrawImage(rotatedImg, coords.X -50, coords.Y -10);
            }
            oldCoords = coords;
        }
    }
}
