using NeuralLibrary;
using System;
using System.Collections.Generic;
using System.IO;

namespace WisconsonCancer
{
    internal class WDBCSet : DataSet
    {

        public override void Load()
        {
            using (StreamReader sr = new StreamReader(Program.fileTest+"\\wdbc.dat"))
            {
                while (true)
                {
                    String line = sr.ReadLine();
                    if (line == null)
                        break;
                    /*Array to store the value of the inputs where x values are the different categories
                     and 0-2 are the different inputs (Mean, Standard Error, and "Worst"*/
                    double[,] inputsRaw = new double[10, 3];
                    double[] inputs = new double[10];
                    string[] s = line.Split(',');

                    for (int i = 2; i <= 11; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            inputsRaw[i - 2, j] = double.Parse(s[i + j]);
                            if ((i - 2 + j) % 3 == 0)
                                inputs[(i - 2 + j) / 3] = double.Parse(s[i + j]);
                        }
                    }

                    double[] desired = new double[1] { 0 };
                    if (s[1].Equals("M"))
                    {
                        desired[0] = 1;
                    }
                    else if (s[1].Equals("B"))
                    {
                        desired[0] = 0;
                    }
                    else
                    {
                        throw new System.ArgumentException("Data doesn't fit model", "original");
                    }
                    this.Add(new DataPoint(inputs, desired));
                }
            }
        }
    }
}
                
            
        
    

