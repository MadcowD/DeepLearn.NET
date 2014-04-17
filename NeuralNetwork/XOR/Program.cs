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
            ConcurrentBag<double> RPROPN = new ConcurrentBag<double>();
            ConcurrentBag<double> RPROPALR = new ConcurrentBag<double>();
            ConcurrentBag<double> ALR = new ConcurrentBag<double>();
            ConcurrentBag<double> BPROP = new ConcurrentBag<double>();

            ParallelOptions c = new ParallelOptions();
            c.MaxDegreeOfParallelism = 8;




            for (double e = 0.2; e >= 0.05; e -= 0.025)
            {
                RPROPN = new ConcurrentBag<double>();
                ALR = new ConcurrentBag<double>();
                Console.WriteLine(e);

                Parallel.For(0, 4000, c,
                    (i) =>
                    {
                       
                        Network nn = new Network(typeof(RPROPMinusConnection), 2, 4, 1);
                        nn.Save(@"C:\temp\test" + i.ToString());
                        DataSet ds = new XORDataSet();
                        ds.Load();

                        Trainer xorTrainer = new Trainer(nn, ds, false);
                        double ep = (xorTrainer.Train(10000, e, false));
                        RPROPN.Add(ep);


                        //nn = Network.Load(typeof(RPROPMinusConnection), @"C:\temp\test" + i.ToString());

                        //xorTrainer = new Trainer(nn, ds, false);
                        //ep = (xorTrainer.Train(10000, 0.1, false, 0.02));

                        RPROPALR.Add(1000);

                        nn = Network.Load(typeof(ALRConnection), @"C:\temp\test" + i.ToString());

                        xorTrainer = new Trainer(nn, ds, false);
                        ep = (xorTrainer.Train(10000, e, false, 0.02, 0));

                        ALR.Add(ep);

                        //nn = Network.Load(typeof(BPROPConnection), @"C:\temp\test" + i.ToString());
                        //xorTrainer = new Trainer(nn, ds, true);
                        //ep = (xorTrainer.Train(10000, 0.1, false, 0.08, 0.1));

                        BPROP.Add(10000);
                    });

                Console.Write("\nMilp: {0}\tNilp: {1}\tOilp: {2}, BP: {3}\n", RPROPN.Average(), RPROPALR.Average(), ALR.Average(), BPROP.Average());
                Console.Write("Milp: {0}\tNilp: {1}\tOilp: {2}, BP: {3}\n\nf", RPROPN.StdDev(), RPROPALR.StdDev(), ALR.StdDev(), BPROP.StdDev());
            }



            Console.ReadKey();
        }
    }
}