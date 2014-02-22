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
        /// Initializes the learning rate experiment
        /// </summary>
        /// <param name="training">The set on which the learning rate will train on.</param>
        /// <param name="testing">The set of testing experiment</param>
        public MomentumExperiment(CancerData training, CancerData testing) : 
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
                for (double mm = 0; mm < 1; mm += 0.05) //usually set at .9 - found online research
                {
                    string subdirectory = mm + @"\";
                    for(int i = 0; i < 10; i++)
                    {
                        Network nn = new Network(false, NETWORK_SIZE);
                        Trainer trainer = new Trainer(nn, this.trainingSet);

                        trainer.Train(NETWORK_EPOCHS, NETWORK_ERROR, NETWORK_LEARNINGRATE, mm, NETWORK_NUDGING);
                        this.Analyze(subdirectory + i +"\\", trainer, nn);
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
