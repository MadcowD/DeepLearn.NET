using NeuralLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalExperiment.Experiments
{
    class CovarianceExperiment : Experiment
    {

         /// <summary>
        /// Initializes the learning rate experiment
        /// </summary>
        /// <param name="training">The set on which the learning rate will train on.</param>
        /// <param name="testing">The set of testing experiment</param>
        public CovarianceExperiment(CancerData training, CancerData testing, int i) : 
            base(training, testing)
        {
            this.i = i;
        }

        /// <summary>
        /// </summary>
        public override void Run()
        {
            double lowestLR = 0;
            double lowestMM = 0;
            double lowestError = 100000;

            List<string> summary = new List<string>();

            for (double mm = 0.25 * (i - 1); mm < 0.25 * i; mm += 0.0125)
            {
                //TRAIN USING DIFFERENT LEARNING RATES
                for (double lr = 0.00015625 * (i - 1); lr < 0.00015625 * i; lr += 0.000015625)
                {
                    string subdirectory = mm + "_" + lr + @"\";

                    double avgError = 0;


                    for (int n = 0; n < 10; n++)
                    {
                        Network nn = Network.Load(DATASTORE + @"CONTROL\" + n + "\\initial.nn");
                        Trainer trainer = new Trainer(nn, this.trainingSet);

                        trainer.Train(NETWORK_EPOCHS, 20, lr, mm, NETWORK_NUDGING);
                        this.Analyze(subdirectory + n + "\\", trainer, nn);
                        avgError += testingSet.CalculateError(nn);
                    }
                    avgError /= 10;

                    summary.Add(mm.ToString() + " " + lr.ToString() + " " + avgError);
                    if (avgError < lowestError)
                    {
                        lowestError = avgError;
                        lowestLR = lr;
                        lowestMM = mm;
                    }

                }

            }

            //Finish summary
            summary.Insert(0, "Lowest Error: " + lowestError);
            summary.Insert(0, "Lowest LR, MM: " + lowestLR + ", " + lowestMM);

            SaveData(DATASTORE + PERSIST + "summary" + i + ".txt", summary.ToArray());
        }

        #region Fields

        int i = 0;

        #endregion

        public override string PERSIST
        {
            get { return @"COVARIANCE_NO_BOTTOM\"; }
        }
    }
}
