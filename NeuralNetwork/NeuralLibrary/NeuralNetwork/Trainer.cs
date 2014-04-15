﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace NeuralLibrary.NeuralNetwork
{
    /// <summary>
    /// Trains the a neural network given a DataSet
    /// </summary>
    public class Trainer
    {

        public Trainer(Network network, DataSet trainingSet) :
            this(network, trainingSet, trainingSet)
        {
        }

        public Trainer(Network network, DataSet trainingSet, DataSet testingSet)
        {
            this.trainingSet = trainingSet;
            this.network = network;
            this.ErrorHistory = new List<double>();
            this.testingSet = testingSet;
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
        public bool Train(int epochs, double minimumError, double learningRate, double momentum, bool nudging = false)
        {
            ErrorHistory.Clear();
            int epoch = 0;
            double error = 0;

            do
            {
                epoch++;
                trainingSet.ForEach(
                    dp => network.Train(dp.Input, dp.Desired, learningRate, momentum));

                error = trainingSet.Select(
                    dp => network.Train(dp.Input, dp.Desired, learningRate, momentum))
                        .Sum();

                this.ErrorHistory.Add(error);

              
                
                //IF NETWORK IS NOT MOVING
                if (nudging && ErrorHistory
                    .SkipWhile( i => i < ErrorHistory.Count()-10)
                    .StdDev() < .00075) 
                {
                    network.NudgeWeights(); //Nudge the weights
                }
                

#if DEBUG
                Console.WriteLine("Epoch {0}: Error = {1};", epoch, error);
                Console.ReadKey();
#endif
            }
            while (epoch < epochs && error > minimumError);

            return (error < minimumError);
        }

        #region Properties

        /// <summary>
        /// The error history for a given training session (nn);
        /// </summary>
        public List<double> ErrorHistory { private set; get; }

        #endregion Properties

        #region Fields

        private Network network;
        private DataSet trainingSet;
        private DataSet testingSet;

        #endregion Fields

        #region Helpers

        /// <summary>
        /// Bounds a double to a range.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public double Bound(double val, double min, double max)
        {
            return val > min && val < max ? val : val < min ? min : max;
        }

        #endregion
    }
}