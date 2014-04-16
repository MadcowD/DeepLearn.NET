using NeuralLibrary.NeuralNetwork;
using NeuralLibrary.NeuralNetwork.Connections;
using NeuralLibrary.NeuralNetwork.Connections.RPROP;
using System;

namespace XOR
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Network nn = new Network(typeof(RPROPMinusConnection), 2, 4, 1);
            DataSet ds = new XORDataSet();
            ds.Load();
           

            Trainer xorTrainer = new Trainer(nn, ds, false);
            xorTrainer.Train(100000, 0.1, false, 0.01, 1.1);
            Console.ReadKey();
        }
    }
}