using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    //парковочное место
    public class ParkingPlace : ISceneObject
    {
        public Vertex VertexOnGraph { get; private set; } //вершина графа, соответствующая месту
        public TypeOfCar Type { get; private set; }   //для каких типов машин предназначено место
        
        //машина, занявшая это парковочное место
        public Car Car
        {
            get { return car; }
            set
            {
                car = value;
                ParkingTime = DateTime.Now;
            }
        }
        
        public bool IsEmpty {get {return (this.Car == null);} } //пусто ли место?
        public int Number { get; private set; }                 //номер места
        public DateTime ParkingTime { get; private set; }       //время занятия машиной данного парковочного места
        public TimeSpan ParkingPeriod { get; private set; }     //период, на который машина заняла место

        private Car car; //машина, занявшая это место
        private static Pen pen = new Pen(Color.White, 2);         //карандаш для рисования свободного места
        private static Brush brush = new SolidBrush(Color.White); //кисть для рисования занятого места
        private Rectangle rect = new Rectangle(); 

        //занять место на заданный период времени
        public void Take(Car car, TimeSpan period)
        {
            Car = car;
            ParkingPeriod = period;
        }

        //конструктор места
        public ParkingPlace(int number, Vertex graphVertex, TypeOfCar type)
        {
            VertexOnGraph = graphVertex;
            Type = type;
            Number = number;
            if (type == TypeOfCar.Automobile)
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

        //метод отрисовки места
        public void Render(Graphics g)
        {
            rect.Location = new Point((int)VertexOnGraph.Position.X - rect.Width/2, (int)VertexOnGraph.Position.Y -  rect.Height/2);

            if (!IsEmpty)
                g.FillRectangle(brush, rect);
            else
            {
                g.DrawRectangle(pen, rect);
            }
        }

    }
}
