using NeuralNetwork.Neurons;
using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    public class Network
    {
        #region Constructors
        /// <summary>
        /// Creates a network with default 
        /// </summary>
        /// <param name="layers"></param>
        public Network(params int[] layers)
        {
            if (layers == null)
                throw new ArgumentNullException("layers");

            Sigmoid[] funcs  = new Sigmoid[layers.Length];
            
            //Standard activations [0] = none, [1] = sigmoid, [output] = linear
            funcs[0] = Sigmoid.None;
            funcs[funcs.Length - 1] = Sigmoid.Linear;
            for (int i = 0; i < funcs.Length; i++)
                if (i != 0 && i != funcs.Length - 1)
                    funcs[i] = Sigmoid.Logistic;
        }

        /// <summary>
        /// Constructs a neural network with full control over activations.
        /// </summary>
        /// <param name="layers"></param>
        /// <param name="activations"></param>
        public Network(int[] layers, Sigmoid[] activations)
        {
            if (layers.Length < 2)
                throw new ArgumentException("Not enough layers specified", "layers");
            if (activations.Length != layers.Length)
                throw new ArgumentException("Uneven layer to activation match up (see length)");


            this.activations = activations;
            this.Bias = new BiasNeuron();

            //Initialize the neural layers. These layers will be static and therefore will be contained within an array.
            int layerCount = layers.Length;

            #region Neuron Initialization

            neurons = new Neuron[layerCount][];
            for (int layer = 0; layer < layerCount; layer++)
            {
                //Count is equal to the respective size of the layers.
                int count = layers[layer];

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

        #endregion

        /// <summary>
        /// Trains the neural network using a given input and desired output set.
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="desired">The desired output of the neural network</param>
        /// <param name="learningRate">The rate at which weights will change</param>
        /// <param name="momentum">The momentum with which weight change occurs.</param>
        /// <returns></returns>
        public double Train(double[] input, double[] desired, double learningRate, double momentum)
        {
            FeedForward(input);
            BackPropagate(desired);
            UpdateWeights(learningRate, momentum);

            //DEBUG INFO
            //Console.WriteLine("\tInput ({0}) Output ({1}) Error {2:0.000}" , String.Join(", ", GetInput()), String.Join(", ", GetOutput()), this.GlobalError);
            return GlobalError;
        }

        #region Network Functions
        /// <summary>
        /// Feeds the network forward achieving an output for a given set of inputs.
        /// </summary>
        /// <param name="input">The set of inputs to be given to the input neurons.</param>
        public void FeedForward(double[] inputs)
        {
            //Make sure input is same length.
            if (inputs.Length != neurons[0].Length)
                throw new ArgumentException("Input not same count as neural input layer");


            //Reset neurons
            foreach (Neuron[] layer in neurons)
                foreach (Neuron n in layer)
                    n.Reset();

            //Set the inputs
            for (int i = 0; i < inputs.Length; i++)
                neurons[0][i].Net = inputs[i];

            //Feed Forward
            for (int layer = 0; layer < neurons.Length; layer++)
            {
                //Update the output
                foreach (Neuron neuron in neurons[layer])
                {
                    if (layer == 0)
                        (neuron as InputNeuron).UpdateOutput(this.activations[layer]);
                    else if (neuron is BiasNeuron)
                        (neuron as BiasNeuron).UpdateOutput(this.activations[layer]);
                    else
                        neuron.UpdateOutput(this.activations[layer]);
                }

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

            GlobalError = 0;
            //Calculate global sum squared error
            for(int i = 0; i < desired.Length; i++){
                (neurons[neurons.Length-1][i] as OutputNeuron).UpdateError(this.activations[neurons.Length-1], desired[i]);
                GlobalError += Math.Pow(neurons[neurons.Length - 1][i].Output - desired[i],2);
            }

            errorHistory.Add(GlobalError);

            //Propagate the error backwards
            for (int layer = neurons.Length - 2; layer >= 0; layer--)
                foreach (Neuron n in neurons[layer])
                {
                    double errorCoefficient = 0;
                    //Take the sum of Posterior Error * weight
                    foreach (Connection con in connections[layer])
                        if (con.PosteriorNeuron.Equals(n))
                            errorCoefficient += con.AnteriorNeuron.Error * con.Weight;

                    //Update the error with the derivative of the network's sigmoid 
                    n.UpdateError(this.activations[layer], errorCoefficient);
                }
        }


        /// <summary>
        /// Updates all of the weights in the neural network based on neural error.
        /// </summary>
        public void UpdateWeights(double learningRate, double momentum)
        {
            //Update the weights of every connection.
            foreach (Connection[] layer in connections)
                foreach (Connection connection in layer)
                    connection.UpdateWeight(learningRate, momentum);
        }
        #endregion

        #region Fields

        private Sigmoid[] activations;

        /// <summary>
        /// The neurons and their respective layers (self contained within the network).
        /// These neurons along with their respective layers  will be constant during runtime, therefore an array is used.
        /// </summary>
        private Neuron[][] neurons;

        /// <summary>
        /// The array of connections on every layer. The first connection is always the bias.
        /// </summary>
        private Connection[][] connections;

        /// <summary>
        /// The error history for a given training set.
        /// </summary>
        /// <returns></returns>
        private List<double> errorHistory = new List<double>();

        #endregion Fields

        #region Properties

        /// <summary>
        /// The neural network's bias.
        /// </summary>
        public BiasNeuron Bias { private set; get; }

        /// <summary>
        /// Gets the input of the neural network.
        /// </summary>
        /// <returns>An array of input values for the neural network.</returns>
        public double[] Input
        {
            get
            {
                double[] input = new double[neurons[0].Length];
                for (int i = 0; i < neurons[0].Length; i++)
                    input[i] = neurons[0][i].Net;

                return input;
            }
        }

        /// <summary>
        /// Gets the output of the neural network.
        /// </summary>
        public double[] Output
        {
            get
            {
                double[] output = new double[neurons[neurons.Length - 1].Length];
                for (int i = 0; i < neurons[neurons.Length - 1].Length; i++)
                    output[i] = neurons[neurons.Length - 1][i].Output;

                return output;
            }
        }

        /// <summary>
        /// The global error of the network using some squared error.
        /// </summary>
        public double GlobalError {private set; get; }

        /// <summary>
        /// Gets an array of the error history
        /// </summary>
        public double[] ErrorHistory
        {
            get
            {
                return errorHistory.ToArray();
            }
        }
        
        #endregion Properties
    }
}