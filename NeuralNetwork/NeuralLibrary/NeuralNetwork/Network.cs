using NeuralLibrary.NeuralNetwork.Connections;
using NeuralLibrary.NeuralNetwork.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralLibrary.NeuralNetwork
{
    public class Network
    {
        #region Constructors

        /// <summary>
        /// Creates a network with default
        /// </summary>
        /// <param name="layers"></param>
        public Network(params int[] layers)
            : this(typeof(BPROPConnection), layers, GenerateSigmoids(layers))
        {
        }

        /// <summary>
        /// Creates a network with default layers but different error correction algorithm
        /// </summary>
        /// <param name="connectionType"></param>
        /// <param name="layers"></param>
        public Network(Type connectionType, params int[] layers)
            : this(connectionType, layers, GenerateSigmoids(layers))
        {
        }

        /// <summary>
        /// Constructs a neural network with full control over activations.
        /// </summary>
        /// <param name="layers"></param>
        /// <param name="activations"></param>
        public Network(Type connectionType, int[] layers, Sigmoid[] activations)
        {
            if (layers.Length < 2)
                throw new ArgumentException("Not enough layers specified", "layers");
            if (activations.Length != layers.Length)
                throw new ArgumentException("Uneven layer to activation match up (see length)");

            this.Activations = activations;
            this.Bias = new BiasNeuron();

            //Initialize the neural layers. These layers will be static and therefore will be contained within an array.
            int layerCount = layers.Length;

            #region Neuron Initialization

            Neurons = new Neuron[layerCount][];
            for (int layer = 0; layer < layerCount; layer++)
            {
                //Count is equal to the respective size of the layers.
                int count = layers[layer];

                Neurons[layer] = new Neuron[count];

                //Fill the layer with neurons.
                for (int k = 0; k < count; k++)
                {
                    if (layer == 0) //Input
                        Neurons[layer][k] = new InputNeuron();
                    else if (layer == layerCount - 1) //Output
                        Neurons[layer][k] = new OutputNeuron();
                    else //Hidden
                        Neurons[layer][k] = new Neuron();
                }
            }

            #endregion Neuron Initialization

            #region Connection Initialization

            Connections = new Connection[layerCount - 1][];

            for (int layer = 0; layer < layerCount - 1; layer++)
            {
                //Count is equal to the the amount of possible permutations between the layers + the bias and the layer.
                int count = (Neurons[layer].Length + 1) * Neurons[layer + 1].Length; //(n_l + n_b)n_(l+1)
                Connections[layer] = new Connection[count];

                //Fill the connections for the layers.
                for (int j = 0; j < Neurons[layer].Length + 1; j++)
                    for (int i = 0; i < Neurons[layer + 1].Length; i++)
                    {
                        int con = i + j * Neurons[layer + 1].Length;

                        if (j == 0) //If the bias
                            Connections[layer][con] = (Connection)Activator.CreateInstance(connectionType, Bias, Neurons[layer + 1][i]);
                        else //If normal
                            Connections[layer][con] = (Connection)Activator.CreateInstance(connectionType, Neurons[layer][j - 1], Neurons[layer + 1][i]);

                        Connections[layer][con].Network = this;
                    }
            }

            #endregion Connection Initialization
        }

        #endregion Constructors

        /// <summary>
        /// Trains the neural network using a given input and desired output set.
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="desired">The desired output of the neural network</param>
        /// <param name="learningRate">The rate at which weights will change</param>
        /// <param name="momentum">The momentum with which weight change occurs.</param>
        /// <returns></returns>
        public double Train(DataPoint dp, params double[] learningParameters)
        {
            FeedForward(dp.Input);
            BackPropagate(dp.Desired);
            UpdateWeights(learningParameters);


            return GlobalError;
        }

        /// <summary>
        /// Trains using batch training.
        /// </summary>
        /// <param name="ds">The dataset over which to train.</param>
        /// <param name="learningParameters"></param>
        /// <returns></returns>
        public double Train(DataSet ds, params double[] learningParameters)
        {
            //Accumulate the gradient in the every connection
            double setError =
                ds.Select(dp =>
                    {
                        FeedForward(dp.Input);
                        BackPropagate(dp.Desired);
                        return GlobalError;
                    }).Sum();

            //After batch gradient determined, finalize gradients and TryUpdate weights.
            UpdateWeights(learningParameters);

            return setError;
        }

        #region Read/Write

        public void Save(string fileName)
        {
            List<string> contents = new List<string>();
            contents.Add(Neurons.Length.ToString());
            foreach(Neuron[] n in Neurons)
                contents.Add(n.Length.ToString());
            
            contents.Add(Connections.Length.ToString());
            foreach (Connection[] cs in Connections)
            {
                contents.Add(cs.Length.ToString());
                foreach (Connection c in cs)
                    contents.Add("(" + c.AnteriorNeuron.GetID(this).ToString() + ","
                        + c.PosteriorNeuron.GetID(this).ToString() + ") " + c.Weight.ToString());
            }

            


            System.IO.File.WriteAllLines(fileName, contents);                                                                                                                                                     
        }

        /// <summary>
        /// Loads a neural network from a file.
        /// </summary>
        /// <param name="fileName">The name of the file from which the network will be loaded.</param>
        /// <returns></returns>
        public static Network Load(Type connectionType, string fileName)
        {
            string[] file = System.IO.File.ReadAllLines(fileName);

            int ln = 0; //lineNumber
            

            //Info to extract
            int[] neurons;
            int[] connections;
            Network loadWork;

            //layerCount
            neurons = new int[int.Parse(file[ln])];
            ln++;

            //Neuron size
            for (int i = 0; i < neurons.Length; ln++, i++)
                neurons[i] = int.Parse(file[ln]); 

            //Create network
            loadWork = new Network(connectionType, neurons);

            //Loadweights
            connections = new int[int.Parse(file[ln])];
            ln++;

            //Load individual weights
            for (int i = 0; i < connections.Length; i++)
            {
                connections[i] = int.Parse(file[ln]);
                ln++;
                for (int j = 0; j < connections[i]; ln++, j++)
                {
                    //Process and modify weights
                    string[] line = file[ln].Split('(', ')', ',', ' ').Where(x => x != "").ToArray();
                    int anteriorNeuron = int.Parse(line[0]);
                    int posteriorNeuron = int.Parse(line[1]);
                    double weight = double.Parse(line[2]);

                    loadWork.GetConnection(i, anteriorNeuron, posteriorNeuron).Weight = weight;

                }
                    
            }


            //Return the loadWOrk
            return loadWork;
        }

        #endregion Read/Write

        #region Network Functions
        /// <summary>
        /// Nudges all of the weights in the network
        /// </summary>
        public void NudgeWeights()
        {
            foreach (Connection[] layer in this.Connections)
                foreach (Connection connection in layer)
                    connection.NudgeWeight();
        }

        /// <summary>
        /// Feeds the network forward achieving an output for a given set of inputs.
        /// </summary>
        /// <param name="input">The set of inputs to be given to the input neurons.</param>
        public void FeedForward(double[] inputs)
        {
            //Make sure input is same length.
            if (inputs.Length != Neurons[0].Length)
                throw new ArgumentException("Input not same count as neural input layer");

            //Reset neurons
            foreach (Neuron[] layer in Neurons)
                foreach (Neuron n in layer)
                    n.Reset();

            //Set the inputs
            for (int i = 0; i < inputs.Length; i++)
                Neurons[0][i].Net = inputs[i];

            //Establish the bias
            Bias.UpdateOutput(Sigmoid.HyperbolicTangent);

            //Feed Forward
            for (int layer = 0; layer < Neurons.Length; layer++)
            {
                //Update the output
                foreach (Neuron neuron in Neurons[layer])
                {
                    if (layer == 0)
                        (neuron as InputNeuron).UpdateOutput(this.Activations[layer]);
                    else
                        neuron.UpdateOutput(this.Activations[layer]);
                }

                //Feed the connections forward unless on the last layer.
                if (layer != Neurons.Length - 1)
                    foreach (Connection connection in Connections[layer])
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
            if (desired.Length != Neurons[Neurons.Length - 1].Length)
                throw new ArgumentException("Desired set not of proper length to match output layer size");

            GlobalError = 0;

            //Calculate global sum squared error
            for (int i = 0; i < desired.Length; i++)
            {
                (Neurons[Neurons.Length - 1][i] as OutputNeuron).UpdateError(this.Activations[Neurons.Length - 1], desired[i]);
                GlobalError += Math.Abs(Neurons[Neurons.Length - 1][i].Output - desired[i]);
            }

            //Propagate the error backwards
            for (int layer = Neurons.Length - 2; layer >= 0; layer--)
                foreach (Neuron n in Neurons[layer])
                {
                    double errorCoefficient = 0;

                    //Update the bias gradient.
                    foreach (Connection bias in Connections[layer]
                        .Where(c => c.AnteriorNeuron.Equals(Bias)))
                    {
                        bias.UpdateGradient();
                    }
                        

                    //Take the sum of Posterior Error * weight
                    foreach (Connection con in Connections[layer])
                        if (con.AnteriorNeuron.Equals(n))
                        {
                            errorCoefficient += con.PosteriorNeuron.Error * con.Weight;

                            //Update the gradient using relative errors
                            //In the case of batch training,
                            //this may be called many times before
                            //the gradient is finalized
                            con.UpdateGradient();
                           
                        }

                    //Update the error with the derivative of the network's sigmoid
                    n.UpdateError(this.Activations[layer], errorCoefficient);
                }
        }

        /// <summary>
        /// Updates all of the weights in the neural network based on neural error.
        /// </summary>
        public void UpdateWeights(params double[] learningParameters)
        {
            //Update the weights of every connection.
            foreach (Connection[] layer in Connections)
                foreach (Connection connection in layer)
                {
                    //Finalize the gradient.
                    connection.FinalizeGradient();
                    connection.TryUpdateWeight(learningParameters);
                }
        }

        /// <summary>
        /// Generates the sigmoid functions for the neural construct
        /// </summary>
        /// <param name="layers">THe number of layers inb the network.</param>
        /// <returns></returns>
        private static Sigmoid[] GenerateSigmoids(int[] layers)
        {
            Sigmoid[] funcs = new Sigmoid[layers.Length];

            //Standard activations [0] = none, [1] = sigmoid, [output] = linear
            funcs[0] = Sigmoid.None;
            funcs[funcs.Length - 1] = Sigmoid.HyperbolicTangent;
            for (int i = 0; i < funcs.Length; i++)
                if (i != 0 && i != funcs.Length - 1)
                    funcs[i] = Sigmoid.HyperbolicTangent;

            return funcs;
        }

        #endregion Network Functions

        #region Fields

        internal Sigmoid[] Activations;

        /// <summary>
        /// The neurons and their respective layers (self contained within the network).
        /// These neurons along with their respective layers  will be constant during runtime, therefore an array is used.
        /// </summary>
        internal Neuron[][] Neurons;

        /// <summary>
        /// The array of connections on every layer. The first connection is always the bias.
        /// </summary>
        internal Connection[][] Connections;

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
                double[] input = new double[Neurons[0].Length];
                for (int i = 0; i < Neurons[0].Length; i++)
                    input[i] = Neurons[0][i].Net;

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
                double[] output = new double[Neurons[Neurons.Length - 1].Length];
                for (int i = 0; i < Neurons[Neurons.Length - 1].Length; i++)
                    output[i] = Neurons[Neurons.Length - 1][i].Output;

                return output;
            }
        }

        /// <summary>
        /// The global error of the network using some squared error.
        /// </summary>
        public double GlobalError { private set; get; }

        /// <summary>
        /// Gets a connection on a given layer with a given anterior and posterior neuron
        /// </summary>
        /// <param name="layer">The layer on which hthe connection lies</param>
        /// <param name="anteriorNeuron">The anterior neuron ID</param>
        /// <param name="posteriorNeuron">The posterior neuron ID</param>
        /// <returns></returns>
        public Connection GetConnection(int layer, int anteriorNeuron, int posteriorNeuron)
        {
            return Connections[layer].First(x =>
                x.AnteriorNeuron.GetID(this) == anteriorNeuron
                && x.PosteriorNeuron.GetID(this) == posteriorNeuron);
        }


        /// <summary>
        /// Gets an array of the ewights in the nwetwork.
        /// </summary>
        /// <returns></returns>
        public double[] GetWeights()
        {
            List<double> weights = new List<double>();
            foreach (Connection[] layer in Connections)
                foreach (Connection c in layer)
                    weights.Add(c.Weight);

            return weights.ToArray();
        }

        #endregion Properties
    }
}