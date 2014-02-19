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
        public LearningRateExperiment(DataSet training, DataSet testing) : 
            base(training, testing)
        {
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
            Network nn = new Network(false, NETWORK_SIZE);
            Trainer trainer = new Trainer(nn, this.trainingSet);

            //TRAIN USING DIFFERENT LEARNING RATES
            for (double lr = 0; lr < 1; lr += 0.05)
            {
                trainer.Train(NETWORK_EPOCHS, 10, lr, NETWORK_MOMENTUM, NETWORK_NUDGING);


            }
        }

        #region Fields
        string PERSIST = @"LR\";
        List<string> testingError = new List<string>();
        #endregion
    }
}
