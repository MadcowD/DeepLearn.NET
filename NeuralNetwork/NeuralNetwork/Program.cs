using System;

namespace NeuralNetwork
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Network nn = new Network(Sigmoid.Logistic, 1, 1, 2);
            while (true)
            {
                nn.FeedForward(new double[] { 1 });
                nn.BackPropagate(new double[] { 0.5 });
                nn.UpdateWeights();

                Console.WriteLine(nn.GlobalError + "\n");
                Console.ReadKey();

            }


        }
    }
}