using NeuralLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalExperiment.Experiments
{
    public class NumberNetworks : Experiment
    {
        /// <summary>
        /// Initializes the Number of Networks Experiment
        /// </summary>
        /// <param name="training">The set on which the networks will train on.</param>
        /// <param name="testing">The set of testing data for experiments</param>
        public NumberNetworks(CancerData training, CancerData testing) : 
            base(training, testing)
        {
        }

        /// <summary>
        /// Runs the learning rate experiment. 
        /// The experiment will consist of the following steps.
        /// 1. Train the given number of networks
        /// 2. Analyze the error for each network
        /// 3. Take the error over all the networks and determine inconclusivity
        ///     and how the number of networks affect the overall diagnosing error
        /// </summary>
        public override void Run()
        {
            for(int i = 1; i < 21; i++)
            {
                string subdirectory = i + @"\";
                Network nn = new Network(false, NETWORK_SIZE);
                Trainer trainer = new Trainer(nn, this.trainingSet);

                trainer.Train(NETWORK_EPOCHS, NETWORK_ERROR, NETWORK_LEARNING_RATE, NETWORK_MOMENTUM, NETWORK_NUDGING);
                this.Analyze(subdirectory + i +"\\", trainer, nn);
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
            get { return @"NUMNET"; }
        }
    }
}
