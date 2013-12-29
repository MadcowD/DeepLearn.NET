using System;
using System.IO;

namespace NeuralNetwork
{
    public class Program
    {
        private static void Main(string[] args)
        {
            

            Network nn = new Network(new int[] {2,4,1}, new Sigmoid[] { Sigmoid.None, Sigmoid.Logistic, Sigmoid.Linear});


            //XNOR
            double[][] input, desired;
            input = new double[][] {
                new double [] { 0, 0 },
                new double[]  { 1, 0 },
                new double[]  { 0, 1 },
                new double[]  { 1, 1 } };

            desired = new double[][]{
                new double [] {1},
                new double [] {0},
                new double [] {0},
                new double [] {1}};

            double error = 0;
            int maxCount = 100000, count = 0;

            do
            {
                count++;
                error = 0;
                for (int i = 0; i < 4; i++)
                    error += nn.Train(input[i], desired[i], 1, 0.0);

                    Console.WriteLine("EPOCH {0}: Error {1:0.000}", count, error);

            } while (error > 0.0001 && count <= maxCount);
            //Console.WriteLine("EPOCH {0}: Error {1:0.000}", count, error);

            for (int i = 0; i < 4; i++)
            {
                nn.FeedForward(input[i]);
                Console.WriteLine(String.Join(",", nn.Input) + " -> " + String.Join(",", desired[i]));
                Console.WriteLine(String.Join(",", nn.Output));
            }

            //Save error history
            string[] filedata = new string[nn.ErrorHistory.Length];
            for (int i = 0; i < filedata.Length; i++)
                filedata[i] = i.ToString() + " " + nn.ErrorHistory[i].ToString();

            File.WriteAllLines(@"C:\temp\XOR.txt", filedata);

            Console.ReadKey();

        }
    }
}