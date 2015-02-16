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
            Network nn = new Network(typeof(BPROPConnection), new int[] { 2, 2, 1 });
            XORDataSet ds = new XORDataSet();
            ds.Load();
            Trainer xorTrainer = new Trainer(nn, ds, false);

            xorTrainer.Train(1000000, 0.01, false, 0.19900, 0.1);

            Console.ReadKey();

            nn.Save(@"F:\temp\xor.nn");

        } 
   
    }
}