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

            new CovarianceExperiment(training, testing, 1).RunAsThread();
            new CovarianceExperiment(training, testing, 2).RunAsThread();
            new CovarianceExperiment(training, testing, 3).RunAsThread();
            new CovarianceExperiment(training, testing, 4).RunAsThread();

         


            Console.ReadKey();
            

        }
    }
}
