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
        /// Initializes the learning rate experiment
        /// </summary>
        /// <param name="training">The set on which the learning rate will train on.</param>
        /// <param name="testing">The set of testing experiment</param>
        public StepExperiment(CancerData training, CancerData testing) :
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

            //TRAIN USING DIFFERENT LEARNING RATES
            for (double sf = 0; sf < 1; sf += 0.1)
            {
                string subdirectory = sf + @"\";
                for (int i = 0; i < 10; i++)
                {
                    Network nn = new Network(false, NETWORK_SIZE);
                    Trainer trainer = new Trainer(nn, this.trainingSet, testingSet);
                    
                    trainer.Train(NETWORK_EPOCHS, NETWORK_ERROR, NETWORK_LEARNING_RATE, NETWORK_MOMENTUM, NETWORK_NUDGING, sf);
                    this.Analyze(subdirectory + i + "\\", trainer, nn, sf);
                }
            }
        }

        #region Fields
        List<string> testingError = new List<string>();
        #endregion

        /// <summary>
        /// Essentially the sub-directory in which the persistent store data will be held.
        /// </summary>
        public override string PERSIST
        {
            get { return @"LR\"; }
        }
    }
}
