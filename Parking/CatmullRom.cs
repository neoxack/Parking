using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splines
{
    //сплайн Катмулл-Рома
    public class CatmullRom
    {
        private Vector2[] points; //массив точек сплайна
        private float deltaT;

        public CatmullRom()
        {
        }

        public void SetPoints(Vector2 [] points)
        {
            this.points = points;
            deltaT = 1.0f / points.Length;
        }

        //вычисление координаты по 4 точкам и параметру t
        private static Vector2 CatmullRomEq(Vector2 p0, Vector2 p1, Vector2 p2,  Vector2 p3, double t)
        {
            Vector2 ret;
            double t2 = t * t;
            double t3 = t2 * t;
            ret.X = (float)(0.5 * ((2.0 * p1.X) + (-p0.X + p2.X) * t +
                            (2.0 * p0.X - 5.0 * p1.X + 4 * p2.X - p3.X) * t2 +
                            (-p0.X + 3.0 * p1.X - 3.0 * p2.X + p3.X) * t3));
            ret.Y = (float)(0.5f * ((2.0 * p1.Y) + (-p0.Y + p2.Y) * t +
                            (2.0 * p0.Y - 5.0 * p1.Y + 4 * p2.Y - p3.Y) * t2 +
                            (-p0.Y + 3.0 * p1.Y - 3.0 * p2.Y + p3.Y) * t3));
            return ret;
        }

        private int Bounds(int pp)
        {
            if (pp < 0) pp = 0;
            else 
                if (pp > points.Length-1) pp = points.Length - 1;
            return pp;
        }

        //вычисление координаты в зависимости от параметра сплайна - t
        public Vector2 GetCoords(double t)
        {
            // Find out in which interval we are on the spline
            int p = (int)(t / deltaT);

            int p0 = p - 1;     p0 = Bounds(p0);
            int p1 = p;         p1 = Bounds(p1);
            int p2 = p + 1;     p2 = Bounds(p2);
            int p3 = p + 2;     p3 = Bounds(p3);
            // Relative (local) time 
            double lt = (t / deltaT) - (double)p;
            // Interpolate

            return CatmullRomEq(points[p0], points[p1], points[p2], points[p3], lt);
        }
    }
}
