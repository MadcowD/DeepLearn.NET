using NeuralLibrary.NeuralNetwork;
using NeuralLibrary.NeuralNetwork.Connections;
using System;

namespace XOR
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Network nn = new Network(2,4,1);
            DataSet ds = new XORDataSet();
            ds.Load();
            Trainer xorTrainer = new Trainer(nn, ds);
            xorTrainer.Train(100000, 0.1, 0.1, 0.9);

            Console.ReadKey();
        }
    }
}