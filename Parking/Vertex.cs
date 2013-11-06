using Splines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class Vertex
    {
        public Vector2 Position { get; private set; }
        public ParkingPlace Place { get; set; }

        public Vertex(Vector2 pos)
        {
            Position = pos;
            Place = null;
        }

    }
}
