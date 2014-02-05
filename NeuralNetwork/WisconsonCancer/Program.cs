using NeuralLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisconsonCancer
{
    class Program
    {
        static void Main(string[] args)
        {
            Network nn = new Network(new int[] {9, 20, 1},
                new Sigmoid[] {Sigmoid.None, Sigmoid.HyperbolicTangent, 
                 Sigmoid.HyperbolicTangent});
            Trainer cancerTrainer = new Trainer(nn, new CancerSet());
            Console.Write(cancerTrainer.Train(40000000, 10, 0.04, 0, true));

            //Save error history
            string[] filedata = new string[cancerTrainer.ErrorHistory.Count];
            for (int i = 0; i < filedata.Length; i++)
                filedata[i] = i.ToString() + "\t" + cancerTrainer.ErrorHistory[i].ToString();

            File.WriteAllLines(@"C:\temp\XOR.txt", filedata);

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
