using Splines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    //вершина графа
    public class Vertex
    {
        public int Number { get; private set; } //номер вершины
        public Vector2 Position { get; private set; } //координаты вершины
        public ParkingPlace Place { get; set; } //парковочное место, соответствующее этой вершине графа, возможно null

        //конструктор вершины
        public Vertex(int num, Vector2 pos)
        {
            Number = num;
            Position = pos;
            Place = null;
        }

    }
}
