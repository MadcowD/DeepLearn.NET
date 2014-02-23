using NeuralLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalExperiment.Experiments
{
    public class HiddenLayers : Experiment
    {
        /// <summary>
        /// Initializes the hidden layers
        /// </summary>
        /// <param name="training">The set of data on which the networks will train on.</param>
        /// <param name="testing">The set of data for testing experiments</param>
        public HiddenLayers(CancerData training, CancerData testing) : 
            base(training, testing)
        {
        }

        /// <summary>
        /// Runs the hidden layers experiment
        /// The experiment will consist of the following steps.
        /// 1. Train the network at a given number of hidden layers
        /// 2. Find the error over for a network for a given number of layers
        /// 3. Find the average error over 10 networks
        /// </summary>
        public override void Run()
        {
                //TRAIN USING DIFFERENT Number of hidden layers
                for (int hl = 0; hl < 10; hl += 1) 
                {
                    string subdirectory = hl + @"\";
                    for(int i = 0; i < 10; i++)
                    {
                        int [] hiddenlayers = new int[hl+2];
                        hiddenlayers[0] = NETWORK_SIZE[0];
                        hiddenlayers[hiddenlayers.Length - 1] = 1;
                        for(int j = 1; j < hiddenlayers.Length-1; j++)
                        {
                            hiddenlayers[j] = NETWORK_SIZE[1];
                        }
                        Network nn = new Network(false, hiddenlayers);
                        Trainer trainer = new Trainer(nn, this.trainingSet);

                        trainer.Train(NETWORK_EPOCHS, NETWORK_ERROR, NETWORK_LEARNING_RATE, NETWORK_MOMENTUM, NETWORK_NUDGING);
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
            get { return @"HL\"; }
        }
    }
}
