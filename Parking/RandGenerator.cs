﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class RandGenerator
    {
        private static Random r = new Random();

        public static int Rand(int min, int max)
        {
            return r.Next(min, max + 1);
        }

        public static float GaussRand(float MO, float sko)
        {
            float sum = 0, x;

            for (int i = 0; i < 25; i++)
                sum += 1.0f * (float)r.NextDouble();
            x = (float)((Math.Sqrt(2.0) * (sko) * (sum - 12.5)) / 1.99661 + MO);

            return x;
        }

        public static float ExpRand(float lambda, int min, int max)
        {
            double res = r.NextDouble();
            res = min + (-1.0 / lambda) * Math.Log(res) * (max - min);
            return (float)res;
        }


    }
}
