using NeuralNetwork.Neurons;
using System;

namespace NeuralNetwork
{
    public class Network
    {
        public Network(Sigmoid activation, double learningRate, int inputSize, int outputSize, params int[] hiddenLayers)
        {
            this.activation = activation;
            this.Bias = new BiasNeuron();

            #region Layer Initialization
            //Initialize the neural layers. These layers will be static and therefore will be contained within an array.
            int layerCount = 2 + ((hiddenLayers == null) ? 0 : hiddenLayers.Length);
            neurons = new Neuron[layerCount][];

            //Initialize the layers and connections thereof.
            for(int layer = 0; layer < layerCount; layer++)
            {
                //Count is equal to the respective size of the layers.
                int count = (layer == 0) ? inputSize :
                    (layer == layerCount -1) ? outputSize
                        : hiddenLayers[layer -1];

                neurons[layer] = new Neuron[count];

                //Fill the layer with neurons.
                for (int k = 0; k < count; k++){
                    if (layer == 0) //Input
                        neurons[layer][k] = new InputNeuron();
                    else if (layer == layerCount - 1) //Output
                        neurons[layer][k] = new OutputNeuron();
                    else //Hidden
                        neurons[layer][k] = new HiddenNeuron();
                }
            }
            #endregion Layer Initialization


        }

        #region Fields

        private Sigmoid activation;

        /// <summary>
        /// The neurons and their respective layers (self contained within the network).
        /// These neurons along with their respective layers  will be constant during runtime, therefore an array is used.
        /// </summary>
        private Neuron[][] neurons;

        /// <summary>
        /// The array of connections on every layer. The first connection is always the bias.
        /// </summary>
        private Connection[][] connections;

        #endregion Fields

        #region Properties

        /// <summary>
        /// The neural network's bias.
        /// </summary>
        public BiasNeuron Bias { private set; get; }

        #endregion

        #region Helpers

        /// <summary>
        /// Generates random numbers associated with the neural network.
        /// </summary>
        public static Random R = new Random();

        #endregion Helpers
    }
}