using NeuralLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalExperiment
{
    class traintestseperate
    {
        static void Main(string[] args)
        {
			using (StreamReader sr = new StreamReader(@"\..\..\..\..\DATASET\original.dat"))
            {
                int counter = 0;
                while (true)
                {
                    /*
                    String line = sr.ReadLine();

                    if (line == null)
                        break;

                    double[] inputs = new double[30];
                    string[] s = line.Split(',');

                    for (int i = 2; i < 32; i++)
                    {
                        inputs[i - 2] = double.Parse(s[i]);
                    }

                    double[] desired = new double[1] { 0 };

                    //Switch inputs
                    if ((s[1]) == 'B')
                        desired[0] = 0;
                    else
                        desired[0] = 1;

                    this.Add(new DataPoint(inputs, desired));*/
                }
            }
        }
    }
}