using NeuralLibrary;
using System;
using System.Collections.Generic;
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
        public virtual void Run()
        {
        }

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
        /// Writes data to a file and then clears the data.
        /// </summary>
        /// <param name="fileLocation"></param>
        public void SaveData(string fileLocation, List<string> data)
        {
            System.IO.File.WriteAllLines(DATASTORE + PERSIST + fileLocation, data.ToArray());
            data.Clear();
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
        public static int[] NETWORK_SIZE = new int[] { 10, 30, 20, 1 };
        public static double NETWORK_MOMENTUM = 0.1;
        public static double NETWORK_LEARNING_RATE = 0.01;
        public static int NETWORK_EPOCHS = 100000;
        public static bool NETWORK_NUDGING = false;

        #endregion CONTROLS
    }
}