using NeuralLibrary;
using NumericalExperiment.Experiments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalExperiment
{
    class Program
    {
        static void Main(string[] args)
        {
            CancerData testing = new CancerData("testing.dat");
            CancerData training = new CancerData("training.dat");

            var e1 = new MomentumExperiment(training, testing, 1);
            var e2 = new MomentumExperiment(training, testing, 2);
            var e3 = new MomentumExperiment(training, testing, 3);
            var e4 = new MomentumExperiment(training, testing, 4);

            e1.RunAsThread();
            e2.RunAsThread();
            e3.RunAsThread();
            e4.RunAsThread();
         


            Console.ReadKey();
            

        }
    }
}
