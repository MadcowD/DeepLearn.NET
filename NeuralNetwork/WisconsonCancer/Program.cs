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
            Console.Write(cancerTrainer.Train(100000, 177.58, 0.08, 0.1));

            while (true)
            {
                Console.WriteLine("Enter sum shit");
                double[] ins = new double[nn.Input.Length];
                for (int i = 0; i < nn.Input.Length; i++)
                {
                    ins[i] = double.Parse(Console.ReadLine());
                    nn.FeedForward(ins);
                }

                Console.WriteLine(String.Join(",", nn.Output));
            }
            Console.ReadKey();

            
        }
    }
}
