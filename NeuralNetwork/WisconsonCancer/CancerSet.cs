using NeuralLibrary;
using System;
using System.Collections.Generic;
using System.IO;

namespace WisconsonCancer
{
    internal class CancerSet : DataSet
    {
        public override void Load()
        {
            //Console.WriteLine("Loading dataset.");
            using (StreamReader sr = new StreamReader(Program.fileTest + "\\training.dat"))
            {
                while (true)
                {
                    String line = sr.ReadLine();

                    if (line == null)
                        break;

                    double[] inputs = new double[9];
                    string[] s = line.Split(',');

                    for (int i = 1; i < 10; i++)
                    {
                        inputs[i - 1] = double.Parse(s[i]);
                    }

                    double[] desired = new double[1] { 0 };

                    //Switch inputs
                    if (double.Parse(s[s.Length - 1]) == 2)
                        desired[0] = 0;
                    else
                        desired[0] = 1;

                    this.Add(new DataPoint(inputs, desired));
                }
            }

            ////Seperate data
            //List<DataPoint> testing = new List<DataPoint>();
            //for (int i = 0; i < 68; i++)
            //{
            //    int index = r.Next(0, this.Count - 1);
            //    testing.Add(this[index]);
            //    this.RemoveAt(index);
            //}

            ////Write datasets to file

            //List<string> file = new List<string>();
            //foreach (DataPoint test in testing)
            //    file.Add(r.Next(0, 10000).ToString() + test.ToString());

            //System.IO.File.WriteAllLines(Program.fileTest + "\\testing.dat", file.ToArray());
            //file.Clear();

            //foreach (DataPoint training in this)
            //    file.Add(r.Next(0, 10000).ToString() + training.ToString());
            //System.IO.File.WriteAllLines(Program.fileTest + "\\training.dat", file.ToArray());

        }
    }
}