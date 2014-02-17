using NeuralLibrary;
using System;

namespace XOR
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Network nn = Network.Load(@"C:\temp\weigths.txt");
            Trainer xorTrainer = new Trainer(nn, new XORDataSet());

            Console.ReadKey();
        }
    }
}