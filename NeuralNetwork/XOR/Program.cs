using NeuralLibrary;
using System;

namespace XOR
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Network nn = new Network(false, 2, 2, 1);
            Trainer xorTrainer = new Trainer(nn, new XORDataSet());
            if (xorTrainer.Train(1000000, 0.01, 0.2, 0.95))
                Console.WriteLine("yes");

            Console.ReadKey();
        }
    }
}