using NeuralLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalExperiment
{
    /// <summary>
    /// Loads (or creates) a fataset for testing or training with regards to the wisconson-5
    /// </summary>
    public class CancerData : DataSet
    {
        /// <summary>
        /// Creates a new cancer dataset based on a file name.
        /// </summary>
        /// <param name="fileName"></param>
        public CancerData(string fileName)
        {
            this.fileName = fileName;
            this.Load();
        }

        /// <summary>
        /// Loads the cancer dataset using a given file in the constructor.
        /// </summary>
        public override void Load()
        {
            this.AddRange(CancerData.ParseFile(System.IO.File.ReadAllLines(DATASTORE + fileName)));

        }

        /// <summary>
        /// Parses a file and gives a dataset in return.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataPoint[] ParseFile(string[] data)
        {
            List<DataPoint> dataset = new List<DataPoint>();
            //Perform parsing here.
            foreach (string line in data)
            {
                string[] dp = line.Split(',');
                double[] input = dp
                    .Skip(2)
                    .Select(x => double.Parse(x))
                    .ToArray(); //GOD I LOVE LINQ <--
                //Output is 0 if malignant and 1 if otherwise
                double[] desired = new double[1] { dp[0].Equals("M") ? 0 : 1 };

                dataset.Add(new DataPoint(input, desired));
            }

            return dataset.ToArray();
        }

        /// <summary>
        /// Generates the training and testing datasets respectively.
        /// </summary>
        public static void GenerateDataSet(string fileName, int testingCount)
        {
            List<string> training = new List<string>(System.IO.File.ReadAllLines(DATASTORE + fileName));
            List<string> testing = new List<string>();

            for (int i = 0; i < testingCount; i++)
            {
                int index = r.Next(0, training.Count()-1);
                testing.Add(training.ElementAt(index));
                training.RemoveAt(index);
            }

            //WRITE TO FILES
            System.IO.File.WriteAllLines(DATASTORE + "training.dat", training.ToArray());
            System.IO.File.WriteAllLines(DATASTORE + "testing.dat", testing.ToArray());

        }

        #region Fields

        string fileName;
        public static string DATASTORE = @"..\..\..\..\DATASET\";

        #endregion Fields
    }
}
