using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public enum Method
    {
        Determined,
        Random
    }

    public enum DistributionLaw
    {
        Exponential, Uniform, Normal
    }

    public class ParkingSceneSettings
    {
        public ParkingSceneSettings()
        {
            Method = Parking.Method.Determined;
            Interval = 5;
            CarSpeed = 5;
            TarifLorry = 20;
            TarifAuto = 10;
            ExpA = 5;
            ExpB = 40;
        }

        public Method Method { get; set; }
        public DistributionLaw DistributionLaw { get; set; }
        public int Interval { get; set; }
        public int CarSpeed { get; set; }
        public int M { get; set; }
        public int Sigma { get; set; }
        public float Lambda { get; set; }
        public int ExpA { get; set; }
        public int ExpB { get; set; }
        public int UniformA { get; set; }
        public int UniformB { get; set; }
        public int TarifLorry { get; set; }
        public int TarifAuto { get; set; }
    }
}
