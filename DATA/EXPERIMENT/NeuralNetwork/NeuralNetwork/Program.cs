using NeuralLibrary;
using System;

namespace TicTacToe
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Network nn = new Network(new int[] { 9, 8, 8, 8, 2 }, new Sigmoid[] { Sigmoid.None, Sigmoid.Logistic, Sigmoid.Logistic, Sigmoid.Logistic, Sigmoid.Logistic });

            //XNOR
            double[][] input, desired;
            input = new double[][] {
                new double [] { 1, 1, 1, 0, 0, 0, 0, 0, 0},
                new double [] { 0, 0, 0, 1, 1, 1, 0, 0, 0},
                new double [] { 0, 0, 0, 0, 0, 0, 1, 1, 1},
                new double [] { 1, 0, 0, 1, 0, 0, 1, 0, 0},
                new double [] { 0, 1, 0, 0, 1, 0, 0, 1, 0},
                new double [] { 0, 0, 1, 0, 0, 1, 0, 0, 1},
                new double [] { 0, 0, 1, 0, 1, 0, 1, 0, 0},
                new double [] { 1, 0, 0, 0, 1, 0, 0, 0, 1},

                new double [] { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                new double [] { 1, 1, 0, 0, 0, 1, 0, 0, 1},
                new double [] { 1, 0, 1, 0, 0, 0, 1, 0, 1},
                new double [] { 0, 1, 0, 0, 0, 0, 0, 1, 0},
                new double [] { 0, 0, 0, 1, 0, 1, 0, 0, 0},
                new double [] { 1, 0, 0, 1, 0, 0, 0, 1, 1}
            };

            desired = new double[][]{
                new double [] {1, 0},
                new double [] {1, 0},
                new double [] {1, 0},
                new double [] {1, 0},
                new double [] {1, 0},
                new double [] {1, 0},
                new double [] {1, 0},
                new double [] {1, 0},
                new double [] {0, 1},
                new double [] {0, 1},
                new double [] {0, 1},
                new double [] {0, 1},
                new double [] {0, 1},
                new double [] {0, 1}
            };

            double error = 0;
            int maxCount = 100000, count = 0;

            do
            {
                count++;
                error = 0;
                for (int i = 0; i < desired.Length; i++)
                    error += nn.Train(input[i], desired[i], 8.6, 0.3);

                {
                    Console.WriteLine("EPOCH {0}: Error {1:0.000}", count, error);
                }
            } while (error > 0.001 && count <= maxCount);

            ////Save error history
            //string[] filedata = new string[nn.ErrorHistory.Length];
            //for (int i = 0; i < filedata.Length; i++)
            //    filedata[i] = i.ToString() + "\t" + nn.ErrorHistory[i].ToString();

            //File.WriteAllLines(@"C:\temp\XOR.txt", filedata);

            while (true)
            {
                Console.WriteLine("Enter sum shit");
                double[] ins = new double[input[0].Length];
                for (int i = 0; i < input[0].Length; i++)
                {
                    ins[i] = double.Parse(Console.ReadLine());
                    nn.FeedForward(ins);
                }

                Console.WriteLine(String.Join(",", nn.Output));
            }

            Console.ReadKey();
        }
    }
}