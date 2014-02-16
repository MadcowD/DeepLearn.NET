using NeuralLibrary;
using System;

namespace XOR
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Network nn = new Network(false, 2,5,1);
            DataSet ds = new XORDataSet();
            ds.Load();
            Trainer xorTrainer = new Trainer(nn, ds);

            xorTrainer.Train(100000, 0.01, 0.1, 0);


            Console.ReadKey();
        }
    }
}