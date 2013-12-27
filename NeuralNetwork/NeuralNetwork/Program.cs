using System;
namespace NeuralNetwork
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Network nn = new Network(Sigmoid.HyperbolicTangent, 1, 2, 1, 2);
            Console.ReadKey();
            nn.FeedForward(new double[]{1,0});
            Console.ReadKey();
        }
    }
}