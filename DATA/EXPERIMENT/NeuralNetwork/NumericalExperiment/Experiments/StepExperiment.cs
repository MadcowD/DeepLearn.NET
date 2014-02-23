using NeuralLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalExperiment.Experiments
{
    public class StepExperiment : Experiment
    {
        /// <summary>
        /// Initializes the step experiment
        /// </summary>
        /// <param name="training">The set on which the neural networks will train on.</param>
        /// <param name="testing">The set of testing data for experiments</param>
        public StepExperiment(CancerData training, CancerData testing) :
            base(training, testing)
        {
        }

        /// <summary>
        /// Runs the step experiment
        /// The experiment will consist of the following steps.
        /// 1. Train the network using a step function
        /// 2. Determine the network error while implementing a stepping function for the output
        /// 3. Determine the error over 10 networks
        /// </summary>
        public override void Run()
        {
            double lowestSF = 0;
            double lowestError = 100000;

            List<string> summary = new List<string>();
            //Train using different step function values
            for (double sf = 0; sf < 1; sf += 0.1)
            {
                double avgError = 0;
                Console.WriteLine("SF -- " + sf);
                string subdirectory = sf + @"\";
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("\tNETWORK: " + i);
                    Network nn = Network.Load(DATASTORE + @"CONTROL\" + i + "\\weights.nn");
                    Trainer trainer = new Trainer(nn, this.trainingSet);
                    avgError += testingSet.CalculateError(nn, sf);
                }

                avgError/=10;

                summary.Add(sf.ToString() + " " + avgError);
                if (avgError< lowestError)
                {
                    lowestError = avgError;
                    lowestSF = sf;
                }
            }

            //Finish summary
            summary.Insert(0, "Lowest Error: " + lowestError);
            summary.Insert(0, "Lowest SF: " + lowestSF);

            SaveData(DATASTORE + PERSIST + "summary.txt", summary.ToArray());
        }

        #region Fields
        List<string> testingError = new List<string>();
        #endregion

        /// <summary>
        /// Essentially the sub-directory in which the persistent store data will be held.
        /// </summary>
        public override string PERSIST
        {
            get { return @"STEP\"; }
        }
    }
}
