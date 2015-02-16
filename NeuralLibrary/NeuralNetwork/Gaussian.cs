using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralLibrary.NeuralNetwork
{
    public static class Gaussian
    {
        private static Random R = new Random();

        public static double GetRandomGaussian(double mean, double stddev)
        {
            double u, v, s, t;
            do
            {
                u = 2 * R.NextDouble() - 1;
                v = 2 * R.NextDouble() - 1;
            }
            while (u * u + v * v > 1 || (u == 0 && v == 0));

            s = u * u + v * v;
            t = Math.Sqrt(-2.0 * Math.Log(s) / s);

            return stddev * u * t + mean;
        }

        public static double GetRandomGaussian()
        {
            return GetRandomGaussian(0, 1);
        }

        public static double StdDev(this IEnumerable<double> values)
        {
            double ret = 0;

            int count = values.Count();
            if (count > 1)
            {
                //Compute the Average
                double avg = values.Average();

                //Perform the Sum of (value-avg)^2
                double sum = values.Sum(d => (d - avg) * (d - avg));

                //Put it all together
                ret = Math.Sqrt(sum / count);
            }
            return ret;
        }

        public static double Step(double p, double stepPoint)
        {
            if (stepPoint == -1)
                return p;
            if (p <= stepPoint)
                return 0;
            else
                return 1;
        }
    }
}