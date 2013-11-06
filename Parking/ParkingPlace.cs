using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class ParkingPlace : ISceneObject
    {
        public Vertex VertexOnGraph { get; private set; }
        public Parking.Car.TypeOfCar Type { get; private set; }
        public Car Car { get; set; }
        public bool IsTaken {get {return (this.Car != null);} }
        public int Number { get; private set; }

        private static Pen pen = new Pen(Color.White, 2);
        private static Brush brush = new SolidBrush(Color.White);
        private Rectangle rect = new Rectangle();

        public ParkingPlace(int number, Vertex graphVertex, Parking.Car.TypeOfCar type)
        {
            VertexOnGraph = graphVertex;
            Type = type;
            Number = number;
            if (type == Parking.Car.TypeOfCar.Automobile)
            {
                rect.Width = 120;
                rect.Height = 60;
            }
            else
            {
                rect.Width = 150;
                rect.Height = 70;
            }
            graphVertex.Place = this;
            Car = null;
        }

        public void Render(Graphics g)
        {
            rect.Location = new Point((int)VertexOnGraph.Position.X - rect.Width/2, (int)VertexOnGraph.Position.Y -  rect.Height/2);

            if (IsTaken)
                g.FillRectangle(brush, rect);
            else
            {
                g.DrawRectangle(pen, rect);
            }
        }

    }
}
