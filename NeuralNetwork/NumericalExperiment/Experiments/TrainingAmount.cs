using NeuralLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalExperiment.Experiments
{
    public class TrainingAmount : Experiment
    {
        /// <summary>
        /// Initializes the training amount experiment
        /// </summary>
        /// <param name="training">The set on which the network will train on.</param>
        /// <param name="testing">The set for the testing experiment</param>
        public TrainingAmount(CancerData training, CancerData testing) : 
            base(training, testing)
        {
        }

        /// <summary>
        /// Runs the training amount experiment
        /// The experiment will consist of the following steps.
        /// 1. Train the network at over a given number of epochs
        /// 2. Repeat 10 Times
        /// 3. Test the testing data 
        /// 4. Analyze the error produced over all 10 networks for a given training amount
        /// </summary>
        public override void Run()
        {

                //TRAIN USING DIFFERENT AMOUNT OF EPOCHS
                for (int ta = 0; ta < 500; ta += 50)
                {
                    string subdirectory = ta + @"\";
                    for(int i = 0; i < 10; i++)
                    {
                        Network nn = new Network(false, NETWORK_SIZE);
                        Trainer trainer = new Trainer(nn, this.trainingSet);

                        trainer.Train(ta, NETWORK_ERROR, NETWORK_LEARNING_RATE, NETWORK_MOMENTUM, NETWORK_NUDGING);
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
            get { return @"TA\"; }
        }
    }
}
