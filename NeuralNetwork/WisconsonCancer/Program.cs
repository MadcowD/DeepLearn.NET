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

            
            Network nn = new Network(new int[] {9, 12, 2},
                new Sigmoid[] {Sigmoid.None, Sigmoid.HyperbolicTangent,
                 Sigmoid.HyperbolicTangent});
            Trainer cancerTrainer = new Trainer(nn, new CancerSet());
            Console.Write(cancerTrainer.Train(100000, 0.01, 0.1, 0.1));
            Console.ReadKey();
        }
    }
}
