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
            Network nn =  Network.Load(typeof(BPROPConnection), @"C:\temp\a");
            DataSet ds = new XORDataSet();
            ds.Load();
           

            Trainer xorTrainer = new Trainer(nn, ds, false);
            xorTrainer.Train(100000, 0.1, false, 0.01, 0.9);
            Console.ReadKey();
        }
    }
}