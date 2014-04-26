using NeuralLibrary.NeuralNetwork;
using NeuralLibrary.NeuralNetwork.Connections;
using NeuralLibrary.NeuralNetwork.Connections.RPROP;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XOR
{
    internal class Program
    {
        private static void Main(string[] args)
        {
<<<<<<< HEAD
            Network nn =  Network.Load(typeof(BPROPConnection), @"C:\temp\a");
            DataSet ds = new XORDataSet();
=======
            XORDataSet ds = new XORDataSet();
>>>>>>> fbe26bd8d6cb266d49f8e924fd7ffd514d398d7b
            ds.Load();
            Network nn = new Network(typeof(ALRConnection), 2, 3, 1);
            Trainer xorTrainer = new Trainer(nn, ds, false);

            xorTrainer.Train(1000000, 0.01, false, 0.02, 0.1);

            Console.ReadKey();
        }
    }
}