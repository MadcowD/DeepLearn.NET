using NeuralLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalExperiment.Experiments
{
    public class LearningRateExperiment : Experiment
    {
        /// <summary>
        /// Initializes the learning rate experiment
        /// </summary>
        /// <param name="training">The set on which the learning rate will train on.</param>
        /// <param name="testing">The set of testing experiment</param>
        public LearningRateExperiment(CancerData training, CancerData testing, int i) : 
            base(training, testing)
        {
            this.i = i;
        }

        /// <summary>
        /// Runs the learning rate experiment. Erdös Erdös Erdös Erdös Erdös Erdös
        /// The experiment will consist of the following steps.
        /// 1. Train the network at a given learning rate (0-1) n=0.05 on the traning set until convergence
        /// 2. Once converged get the net error over the testing set (which is consitent, random) add to a learning rate error dataset.
        /// 3. Save all converged net errors for a given experiment.
        /// </summary>
        public override void Run()
        {
            double lowestLR = 0;
            double lowestError = 100000;

            List<string> summary = new List<string>();


                //TRAIN USING DIFFERENT LEARNING RATES
                for (double lr = 0.00015625*(i-1); lr < 0.00015625*i; lr += 0.000015625)
                {
                    string subdirectory = lr + @"\";

                    double avgError = 0;


                    for(int n = 0; n < 10; n++)
                    {
                        Network nn = Network.Load(DATASTORE + @"CONTROL\" + n + "\\initial.nn");
                        Trainer trainer = new Trainer(nn, this.trainingSet);

                        trainer.Train(NETWORK_EPOCHS, NETWORK_ERROR, lr, NETWORK_MOMENTUM, NETWORK_NUDGING);
                        this.Analyze(subdirectory + n +"\\", trainer, nn);
                        avgError += testingSet.CalculateError(nn);
                    }
                    avgError /= 10;

                    summary.Add(lr.ToString() + " " + avgError);
                    if (avgError < lowestError)
                    {
                        lowestError = avgError;
                        lowestLR = lr;
                    }

                }

                //Finish summary
                summary.Insert(0, "Lowest Error: " + lowestError);
                summary.Insert(0, "Lowest LR: " + lowestLR);

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
            get { return @"LR_SMALLEST[0-0.000625]\"; }
        }
    }
}
