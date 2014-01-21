using NeuralLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOR
{
    class Program
    {
        static void Main(string[] args)
        {
            Network nn = new Network(2, 4, 1);
            Trainer xorTrainer = new Trainer(nn, new XORDataSet());

            Console.Write(xorTrainer.Train(10000, 0.01, 1, 0.6));
            Console.ReadKey();
        }
    }
}
