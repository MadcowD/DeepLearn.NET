﻿using System;
using System.Collections;
using System.Collections.Generic;
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
            this.ErrorHistory = new List<double>();
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
            ErrorHistory.Clear();
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

                //trainingSet.Shuffle();
                foreach (DataPoint dp in trainingSet)
                    error += network.Train(dp.Input, dp.Desired, learningRate, momentum);

                this.ErrorHistory.Add(error);

                //TODO: REMOVE
                if (error > 375)
                {
                    ErrorHistory.Clear();
                    network.NudgeWeights();
                }

                //PERFORM NUDGING
                if (nudging && epoch % 10 == 0)
                {
                    //push error along the stack
                    error0 = error1;
                    error1 = error;

                    if ((Math.Abs(error1 - error0) < 0.05))
                    {
                        ErrorHistory.Clear();
                        network.NudgeWeights();
                    }
                }




#if DEBUG
                Console.WriteLine("Epoch {0}: Error = {1}", epoch, error);
#endif
            }
            while (epoch < epochs && error > minimumError);

            return (error <= minimumError);
        }

        #region Properties

        /// <summary>
        /// The error history for a given training session (nn);
        /// </summary>
        public List<double> ErrorHistory { private set; get; }

        #endregion

        #region Fields

        private Network network;
        private DataSet trainingSet;

        #endregion Fields
    }
}