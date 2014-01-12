using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralLibrary
{
    /// <summary>
    /// Trains the a neural network given a DataSet
    /// </summary>
    public class Trainer
    {
        public Trainer(Network network, DataSet trainingSet)
        {
            this.trainingSet = trainingSet;
            this.network = network;
        }


        /// <summary>
        /// Treains the neural network over a given number of epochs using backpropagation.
        /// </summary>
        /// <param name="epochs">THe number of iterations to which the neural network will train before failing.</param>
        /// <param name="minimumError">The minimum error which the network must reach to </param>
        /// <param name="learningRate">The learning rate at which the network will begin to learn.</param>
        /// <param name="momentum">The momentum at which the network will begin to learn.</param>
        /// <returns>Whether or not the network was sucessful in learning.</returns>
        public bool Train(int epochs, double minimumError, double learningRate, double momentum)
        {   
            int epoch = 0;
            double error = 0;
            
            do 
            {
                error = 0;

                foreach(DataPoint dp in trainingSet)
                    error += network.Train(dp.Input, dp.Desired, learningRate, momentum);
            }
            while (epoch < epochs && error > minimumError);

            return (error <= minimumError);
        }

        #region Fields
        private Network network;
        private DataSet trainingSet;
        #endregion
    }
}
