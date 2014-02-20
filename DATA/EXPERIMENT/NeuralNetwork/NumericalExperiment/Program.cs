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
            ControlExperiment Control = 
                new ControlExperiment(training, testing);
            Control.Run();
            Console.ReadKey();

            Console.WriteLine(string.Join(", ", testing.Select(x => x.Desired[0])));
            Console.ReadKey();
            

        }
    }
}
