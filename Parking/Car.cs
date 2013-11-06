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
    public class Car : ISceneObject
    {
        public enum TypeOfCar
        {
            Lorry, 
            Automobile
        }

        public double Speed { get; set; }
        public bool IsMoves { get; set; }
        public TypeOfCar Type { get; private set; }

        public IEnumerable<Edge<Vertex>> Path 
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
                spline.SetPoints(points.ToArray());
                Speed = Speed / (points.Count);
                t = 0.0f;
            } 
        }

        private static Brush brush1 = new SolidBrush(Color.Red);
        private static Brush brush2 = new SolidBrush(Color.Green);
        private CatmullRom spline = new CatmullRom();
        private IEnumerable<Edge<Vertex>> path;
        private double t;
        private Vector2 coords;
        private Vector2 newcoords;
        private double distance = 1.0;


        public Car(TypeOfCar type)
        {
            Type = type;
        }

        private bool firstStep = true;
        public void Update(double deltaTime)
        {
            if (t < 1.0f)
            {
                double speed = Speed;/// distance;
                t += (speed * deltaTime);
                newcoords = spline.GetCoords(t);
                if (firstStep) 
                    distance = 1.0;
                else
                    distance = Vector2.Distance(coords, newcoords);
                coords = newcoords;
                firstStep = false;
            }
        }

        public void Render(Graphics g)
        {
            if(Type == TypeOfCar.Automobile)
                g.FillRectangle(brush1, coords.X - 10, coords.Y - 10, 20, 20);
            else
                g.FillRectangle(brush2, coords.X - 10, coords.Y - 10, 20, 20);
        }
    }
}
