using System;
namespace NeuralNetwork
{
    public class Network
    {
        public Network(Sigmoid activation, double learningRate, int inputSize, int outputSize, params int[] hiddenLayers)
        {
            this.activation = activation;

            //Initialize the neural layers. These layers will be static and therefore will be contained within an array.
        }

        #region Fields

        private Sigmoid activation;

        /// <summary>
        /// The neurons and their respective layers (self contained within the network).
        /// These neurons along with their respective layers  will be constant during runtime, therefore an array is used.
        /// </summary>
        private Neuron[][] neurons;

        #endregion Fields

        #region Helpers

        /// <summary>
        /// Generates random numbers associated with the neural network.
        /// </summary>
        public static Random R = new Random();

        #endregion
    }
}