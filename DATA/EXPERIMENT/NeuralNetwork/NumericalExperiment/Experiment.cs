using NeuralLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NumericalExperiment
{
    public abstract class Experiment
    {
        public Experiment(CancerData trainingSet, CancerData testingSet)
        {
            this.trainingSet = trainingSet;
            this.testingSet = testingSet;
        }

        /// <summary>
        /// Runs the experiment
        /// <returns>The results of the experiment.</returns>
        /// </summary>
        public abstract void Run();

        /// <summary>
        /// Runs the experiment as a thread.
        /// </summary>
        /// <returns></returns>
        public bool RunAsThread()
        {
            if (worker == null)
            {
                worker = new Thread(new ThreadStart(this.Run));
                worker.Start();
            }
            else
            {
                if (worker.IsAlive)
                    return false;
                else
                    worker.Start();
            }
            return true;
        }

        /// <summary>
        /// Anylizes the current experiment data and saves an anakysis within a sub directory of (ID)
        /// </summary>
        public void Analyze(string id, Trainer trainer, Network nn, double step = -1)
        {
            (new FileInfo(DATASTORE + PERSIST + id)).Directory.Create();
            nn.Save(DATASTORE + PERSIST + id + "weights.nn"); //Save weights
            SaveData(DATASTORE + PERSIST + id + "convergence.dat",
                trainer.ErrorHistory.Select((x,i) => i.ToString() + " " + x.ToString()).ToArray()); //Save convergence

            //Collect the error for each testing point
            double[] testingError = testingSet.CalculateErrors(nn, step);
            SaveData(DATASTORE + PERSIST + id + "testingError.dat",
                testingError.Select((x, i) => i.ToString() + " " + x.ToString()).ToArray());


            List<string> analysis = new List<string>();
            analysis.Add("Converged: " + (testingError.Sum()/(testingSet.Count()*2) < NETWORK_ERROR/(trainingSet.Count()*2)).ToString());
            analysis.Add("Error: " + testingError.Sum());
            analysis.Add("Average Error: " + testingError.Average());
            analysis.Add("Proportional Error: " + testingError.Sum() / (testingSet.Count()*2));
            analysis.Add("Error Standard Deviation: " + testingError.StdDev());
            analysis.Add("Epochs: " + trainer.ErrorHistory.Count());

            SaveData(DATASTORE + PERSIST + id + "analysis.txt", analysis.ToArray());

        }

        /// <summary>
        /// Writes data to a file and then clears the data.
        /// </summary>
        /// <param name="fileLocation"></param>
        protected void SaveData(string fileLocation, string[] data)
        {
            System.IO.File.WriteAllLines(fileLocation, data);
        }

        #region Properties


        /// <summary>
        /// The datastore location
        /// </summary>
        public static string DATASTORE = @"..\..\..\..\OUTPUT\";

        /// <summary>
        /// THE FOLDER IN WHICH THE DATA WILL GO
        /// </summary>
        public abstract string PERSIST { get; }
        #endregion

        #region Fields
        Thread worker;
        protected CancerData trainingSet;
        protected CancerData testingSet;
        #endregion Fields

        #region CONTROLS
        public static int[] NETWORK_SIZE = new int[] { 30, 16, 11, 1 };
        public static double NETWORK_MOMENTUM = 0.2;
        public static double NETWORK_LEARNING_RATE = 0.001;
        public static int NETWORK_EPOCHS = 1000;
        public static bool NETWORK_NUDGING = false;
        public static double NETWORK_ERROR = 25;
        public static double NETWORK_STEP = 0.9;

        #endregion CONTROLS
    }
}