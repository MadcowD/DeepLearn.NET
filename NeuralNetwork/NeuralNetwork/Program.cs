using System;

namespace NeuralNetwork
{
    public class Program
    {
        private static void Main(string[] args)
        {
            

            Network nn = new Network(new int[] {1,2,1}, new Sigmoid[] { Sigmoid.Logistic, Sigmoid.Logistic, Sigmoid.Linear});

            //Do a test training for a 1 to 1 in-out network
            for(int i = 0; i < 50; i++){
                double error = nn.Train(new double[] { 0.0 }, new double[] { 2.5 }, 0.12, 0);


                    Console.WriteLine("Iteration {0}:\n\tInput {1:0.000} Output {2:0.000} Error {3:0.000}", i, 0.0, nn.GetOutput()[0], error);

            }

            Console.ReadKey();

        }
    }
}