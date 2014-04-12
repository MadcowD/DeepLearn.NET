using NeuralLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalExperiment.Experiments
{
    public class MomentumExperiment : Experiment
    {
        /// <summary>
        /// Initializes the momentum experiment
        /// </summary>
        /// <param name="training">The set for training the networks.</param>
        /// <param name="testing">The set of testing data for the experimentation</param>
        public MomentumExperiment(CancerData training, CancerData testing, int i ) : 
            base(training, testing)
        {
            this.i = i;
        }

        /// <summary>
        /// Runs the learning rate experiment. 
        /// The experiment will consist of the following steps.
        /// 1. Train the network at a given momentum value (0-1) n=0.05 on the traning set until it converges
        ///         If, convergence doesn't occur, when nudging is supposed to occur, the training will just stop
        /// 2. Determine the error for a single network at a given momentum
        /// 3. Determine the error at a given momentum over all ten networks
        /// </summary>
        public override void Run()
        {

            double lowestMM = 0;
            double lowestError = 100000;

            List<string> summary = new List<string>();

            //Train while altering momentum
            for (double mm = 0.25*(i-1); mm < 0.25*i; mm += 0.0125) //usually set at .9 - found online research
            {
                double avgError = 0;
                string subdirectory = mm + @"\";
                for(int n = 0; n < 10; n++)
                {
                    Network nn = Network.Load(DATASTORE + @"CONTROL\" + n + "\\initial.nn");
                    Trainer trainer = new Trainer(nn, this.trainingSet);

                    trainer.Train(NETWORK_EPOCHS, NETWORK_ERROR, NETWORK_LEARNING_RATE, mm, NETWORK_NUDGING);
                    this.Analyze(subdirectory + n +"\\", trainer, nn);
                    avgError += testingSet.CalculateError(nn);
                }

                avgError /= 10;

                summary.Add(mm.ToString() + " " + avgError);
                if (avgError < lowestError)
                {
                    lowestError = avgError;
                    lowestMM = mm;
                }
            }

            //Finish summary
            summary.Insert(0, "Lowest Error: " + lowestError);
            summary.Insert(0, "Lowest MM: " + lowestMM);

            SaveData(DATASTORE + PERSIST + "summary" + i + ".txt", summary.ToArray());
        }

        #region Fields
        List<string> testingError = new List<string>();
        int i;
        #endregion

        /// <summary>
        /// Essentially the sub-directory in which the persistent store data will be held.
        /// </summary>
        public override string PERSIST
        {
            get { return @"MM\"; }
        }
        
    }
}
