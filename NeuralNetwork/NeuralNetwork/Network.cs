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

            //Initialize the neural layers. These layers will be static and therefore will be contained within an array.
            int layerCount = 2 + ((hiddenLayers == null) ? 0 : hiddenLayers.Length);

            #region Neuron Initialization

            neurons = new Neuron[layerCount][];
            for (int layer = 0; layer < layerCount; layer++)
            {
                //Count is equal to the respective size of the layers.
                int count = (layer == 0) ? inputSize :
                    (layer == layerCount - 1) ? outputSize
                        : hiddenLayers[layer - 1];

                neurons[layer] = new Neuron[count];

                //Fill the layer with neurons.
                for (int k = 0; k < count; k++)
                {
                    if (layer == 0) //Input
                        neurons[layer][k] = new InputNeuron();
                    else if (layer == layerCount - 1) //Output
                        neurons[layer][k] = new OutputNeuron();
                    else //Hidden
                        neurons[layer][k] = new HiddenNeuron();
                }
            }

            #endregion Neuron Initialization

            #region Connection Initialization

            connections = new Connection[layerCount - 1][];
            for (int layer = 0; layer < layerCount - 1; layer++)
            {
                //Count is equal to the the amount of possible permutations between the layers + the bias and the layer.
                int count = (neurons[layer].Length + 1) * neurons[layer + 1].Length; //(n_l + n_b)n_(l+1)
                connections[layer] = new Connection[count];

                //Fill the connections for the layers.
                for (int j = 0; j < neurons[layer].Length + 1; j++)
                    for (int i = 0; i < neurons[layer + 1].Length; i++)
                    {
                        int con = i + j * neurons[layer + 1].Length;

                        if (j == 0) //If the bias
                            connections[layer][con] = new Connection(Bias, neurons[layer + 1][i]);
                        else //If normal
                            connections[layer][con] = new Connection(neurons[layer][j - 1], neurons[layer + 1][i]);
                    }
            }

            #endregion Connection Initialization
        }

        /// <summary>
        /// Feeds the network forward achieving an output for a given set of inputs.
        /// </summary>
        /// <param name="input">The set of inputs to be given to the input neurons.</param>
        public void FeedForward(double[] inputs)
        {
            //Make sure input is same length.
            if (inputs.Length != neurons[0].Length)
                throw new ArgumentException("Input not same count as neural input layer");

            //Set the inputs
            for (int i = 0; i < inputs.Length; i++)
                neurons[0][i].Net = inputs[i];

            //Feed Forward
            for (int layer = 0; layer < neurons.Length; layer++)
            {
                //Update the output
                foreach (Neuron neuron in neurons[layer])
                    neuron.UpdateOutput(this.activation);

                //Feed the connections forward unless on the last layer.
                if (layer != neurons.Length - 1)
                    foreach (Connection connection in connections[layer])
                        connection.FeedForward();
            }
        }


        /// <summary>
        /// Propagates the global error backwards through the network using the error backpropagation algorithm
        /// </summary>
        /// <param name="desired">The set of desired outputs to which the output neurons will be matched</param>
        public void BackPropagate(double[] desired)
        {
            //Make sure the output layer is the same length as the desired array.
            if(desired.Length != neurons[neurons.Length-1].Length)
                throw new ArgumentException("Desired set not of proper length to match output layer size");

            //Calculate global sum squared error
            for(int i = 0; i < desired.Length; i++){
                neurons[neurons.Length-1][i].UpdateError(this.activation, desired[i]);
                GlobalError += neurons[neurons.Length - 1][i].Error;
            }
            GlobalError = 0.5 * Math.Pow(GlobalError, 2);

            //Propagate the error backwards
            for (int layer = neurons.Length - 2; layer >= 0; layer--)
                foreach (Neuron n in neurons[layer])
                {
                    double errorCoefficient = 0;
                    //Take the sum of Posterior Error * weight
                    foreach (Connection con in connections[layer])
                        if (con.AnteriorNeuron.Equals(n))
                            errorCoefficient += con.PosteriorNeuron.Error * con.Weight;

                    //Update the error with the derivative of the network's sigmoid 
                    n.UpdateError(this.activation, errorCoefficient);
                    Console.WriteLine(n.Error);
                }
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

        /// <summary>
        /// The global error of the network using some squared error.
        /// </summary>
        public double GlobalError {private set; get; }
        
        #endregion Properties

        #region Helpers

        /// <summary>
        /// Generates random numbers associated with the neural network.
        /// </summary>
        public static Random R = new Random();

        #endregion Helpers
    }
}