using NeuralLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisconsonCancer
{
    class Program
    {
        static void Main(string[] args)
        {
            Network nn = new Network(9, 36, 6, 2);
            Trainer cancerTrainer = new Trainer(nn, new CancerSet());
            Console.WriteLine(cancerTrainer.Train(10000, 210, 1, 1, true));
            Console.ReadKey();
        }
    }
}
