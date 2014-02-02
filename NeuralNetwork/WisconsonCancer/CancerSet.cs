using NeuralLibrary;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace WisconsonCancer
{
    class CancerSet : DataSet
    {
        public override void Load()
        {
            //Console.WriteLine("Loading dataset.");
                using (StreamReader sr = new StreamReader("breast-cancerWisconson.data"))
                {
                    while (true)
                    {
                        String line = sr.ReadLine();

                        if (line == null)
                            break;

                        double[] inputs = new double[9];
                        string[] s = line.Split(',');


                        for (int i = 2; i < 10; i++)
                        {
                            if (s[i] == null)
                                Console.WriteLine("shit");
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
        }
    }
}
