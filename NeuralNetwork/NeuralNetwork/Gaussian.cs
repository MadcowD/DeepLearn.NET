using System;

namespace NeuralNetwork
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
    }
}