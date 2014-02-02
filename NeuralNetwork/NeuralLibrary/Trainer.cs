﻿using System;
using System.Collections;
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
        /// <param name="nudging">Enables nudging of the neural network during training.</param> 
        /// <returns>Whether or not the network was sucessful in learning.</returns>
        public bool Train(int epochs, double minimumError, double learningRate, double momentum, bool nudging = true)
        {
            int epoch = 0;
            double error = 0;

            //nudging
            double error0 = -1;
            double error1 = -1;

            trainingSet.Load();

            do
            {
                error = 0;
                epoch++;

                foreach (DataPoint dp in trainingSet)
                    error += network.Train(dp.Input, dp.Desired, learningRate, momentum);

                //PERFORM NUDGING
                if (nudging && epoch % 10 == 0)
                {
                    //push error along the stack
                    error0 = error1;
                    error1 = error;

                    if ((Math.Abs(error1 - error0) < 0.0001))
                        network.NudgeWeights();
                }




#if DEBUG
                Console.WriteLine("Epoch {0}: Error = {1}", epoch, error);
#endif
            }
            while (epoch < epochs && error > minimumError);

            return (error <= minimumError);
        }

        #region Fields

        private Network network;
        private DataSet trainingSet;

        #endregion Fields
    }
}