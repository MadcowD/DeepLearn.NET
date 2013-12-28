using System;

namespace NeuralNetwork
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Network nn = new Network(Sigmoid.HyperbolicTangent,1.1, 2, 1, 4);
            while (true)
            {
                nn.FeedForward(new double[] { 1, 0 });
                nn.BackPropagate(new double[] { 1 });
                nn.UpdateWeights();
                Console.WriteLine(nn.GlobalError);

                nn.FeedForward(new double[] { 0, 1 });
                nn.BackPropagate(new double[] { 1 });
                nn.UpdateWeights();
                Console.WriteLine(nn.GlobalError);

                nn.FeedForward(new double[] { 0, 0 });
                nn.BackPropagate(new double[] { 0 });
                nn.UpdateWeights();
                Console.WriteLine(nn.GlobalError);

                nn.FeedForward(new double[] { 1, 1 });
                nn.BackPropagate(new double[] { 0 });
                nn.UpdateWeights();
                Console.WriteLine(nn.GlobalError + "\n");
                Console.ReadKey();
            }


        }
    }
}