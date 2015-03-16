using NeuralLibrary.NeuralNetwork;
using System.Threading;

namespace NeuralLibrary
{
    public abstract class Experiment
    {
        public Experiment(DataSet trainingSet, DataSet testingSet)
        {
            this.trainingSet = trainingSet;
            this.testingSet = testingSet;
        }

        /// <summary>
        /// Runs the experiment
        /// <returns>The results of the experiment.</returns>
        /// </summary>
        public abstract void Run();

#if Managed
#else
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

#endif

        #region Properties

        /// <summary>
        /// The datastore location
        /// </summary>
        public static string DATASTORE = @"..\..\..\..\OUTPUT\";

        /// <summary>
        /// THE FOLDER IN WHICH THE DATA WILL GO
        /// </summary>
        public abstract string PERSIST { get; }

        #endregion Properties

        #region Fields
#if Managed
#else
        Thread worker;
#endif
        protected DataSet trainingSet;
        protected DataSet testingSet;

        #endregion Fields
    }
}