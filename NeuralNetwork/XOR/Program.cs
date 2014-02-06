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
            Network nn = new Network(false, 2, 4, 4, 1);
            Trainer xorTrainer = new Trainer(nn, new XORDataSet());
            if (xorTrainer.Train(1000000, 0.01, 0.2, 0.95))
                Console.WriteLine("yes");

          

            Console.ReadKey();
        }
    }
}
