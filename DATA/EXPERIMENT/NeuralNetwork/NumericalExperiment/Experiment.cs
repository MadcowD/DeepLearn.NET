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
        public Experiment(DataSet trainingSet, DataSet testingSet)
        {
            this.trainingSet = trainingSet;
            this.testingSet = testingSet;
            this.data = new List<string>();
        }

        /// <summary>
        /// Runs the experiment
        /// <returns>The results of the experiment.</returns>
        /// </summary>
        public virtual void Run()
        {
            this.data.Clear();
        }

        /// <summary>
        /// Runs the experiment as a thread.
        /// </summary>
        /// <returns></returns>
        public sealed bool RunAsThread()
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
        public void SaveData(string fileLocation)
        {
            System.IO.File.WriteAllLines(fileLocation, data.ToArray());
            data.Clear();
        }

        #region Properties

        /// <summary>
        /// The data for a given experiment.
        /// </summary>
        protected List<String> data;


        /// <summary>
        /// The datastore location
        /// </summary>
        public static string DATASTORE = @"..\..\..\..\..\OUTPUT\";

        #endregion

        #region Fields
        Thread worker;
        protected DataSet trainingSet;
        protected DataSet testingSet;
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