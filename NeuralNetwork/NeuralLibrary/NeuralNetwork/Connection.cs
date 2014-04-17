using NeuralLibrary.NeuralNetwork.Neurons;
using System;

namespace NeuralLibrary.NeuralNetwork
{
    /// <summary>
    /// The connection held between two neurons with a given weight.
    /// </summary>
    public abstract class Connection
    {
        /// <summary>
        /// Initializes the connection.
        /// </summary>
        /// <param name="weightInitial">The initial weight of the connection. Bound from -1, 1</param>
        /// <param name="anteriorNeuron">The neuron on the anterior side of the connection.</param>
        /// <param name="posteriorNeuron">The neuron on the posterior side of the connection.</param>
        public Connection(double weightInitial, Neuron anteriorNeuron, Neuron posteriorNeuron)
        {
            this.Weight = weightInitial;
            this.AnteriorNeuron = anteriorNeuron;
            this.PosteriorNeuron = posteriorNeuron;
        }

        /// <summary>
        /// Initializes the connection with a random weight between -1 and 1
        /// </summary>
        /// <param name="anteriorNeuron">The neuron on the anterior side of the connection.</param>
        /// <param name="posteriorNeuron">The neuron on the posterior side of the connection.</param>
        public Connection(Neuron anteriorNeuron, Neuron posteriorNeuron)
            : this(Gaussian.GetRandomGaussian(), anteriorNeuron, posteriorNeuron)
        {
        }

        /// <summary>
        /// Nudges the weights.
        /// </summary>
        public void NudgeWeight()
        {
            this.Weight = Gaussian.GetRandomGaussian();
        }

        /// <summary>
        /// Feeds the product of output from the anterior neuron  and the weight of the connection forward to the anterior neuron.
        /// </summary>
        public void FeedForward()
        {
            PosteriorNeuron.Net += AnteriorNeuron.Output * Weight;
        }

        #region Fields



        #endregion Fields

        #region Properties

        /// <summary>
        /// The anterior neuron within the connection.
        /// </summary>
        public Neuron AnteriorNeuron { protected set; get; }

        /// <summary>
        /// The posterior neuron within the connection.
        /// </summary>
        public Neuron PosteriorNeuron { protected set; get; }

        /// <summary>
        /// Establishes the amount of learning parameters an algorithm takes.
        /// </summary>
        protected abstract uint LearningParameterCount { get; }

        /// <summary>
        /// Attempts to update the weight of a given connection.
        /// </summary>
        /// <param name="learningParameters"></param>
        public  void TryUpdateWeight(params double[] learningParameters) 
        {
            if (LearningParameterCount > 0)
                if (!(learningParameters != null && learningParameters.Length >= LearningParameterCount))
                    throw new ArgumentNullException("No--or uneven-- learning parameters given.");

            UpdateWeight(learningParameters);
            
        }

        /// <summary>
        /// Updates the weight of the connection using the weight update rule. dW = ERROR_posterior * OUTPUT_anterior
        /// </summary>
        protected abstract void UpdateWeight(params double[] learningParameters);

        #region Gradient

        private double gradient = 0;
        private double finalizedGradient = 0;

        internal void UpdateGradient()
        {
            double output = 0;
            if (AnteriorNeuron is BiasNeuron)
                output = (AnteriorNeuron as BiasNeuron).Output;
            else if (AnteriorNeuron is InputNeuron)
                output = (AnteriorNeuron as InputNeuron).Output;
            else
                output = AnteriorNeuron.Output;

            gradient += PosteriorNeuron.Error * output;
        }

        /// <summary>
        /// Finalizes the gradient. Must be called after batch training.
        /// </summary>
        internal void FinalizeGradient()
        {
            finalizedGradient = gradient;
            gradient = 0;
        }


        /// <summary>
        /// Gets the gradient of the connection.
        /// </summary>
        public double Gradient
        {
            get
            {
                return finalizedGradient;
            }
        }

        #endregion

        internal Network Network {  set; get; }

        /// <summary>
        /// The weight associated with a connection.
        /// </summary>
        public double Weight { set; get; }

        #endregion Properties
    }
}