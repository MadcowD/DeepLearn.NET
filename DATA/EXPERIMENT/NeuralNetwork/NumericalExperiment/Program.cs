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
            CancerData testing = new CancerData("testingImages.dat");
            CancerData training = new CancerData("trainingImages.dat");

            var e1 = new ImageExperiment(training, testing);
            e1.Run();
         


            Console.ReadKey();
            

        }
    }
}
