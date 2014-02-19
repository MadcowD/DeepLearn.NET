using NeuralLibrary;
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
            //Test loading
            CancerData data = new CancerData("training.dat");
            foreach (DataPoint dp in data)
                Console.WriteLine(string.Join(",", dp.Input));

            

        }
    }
}
