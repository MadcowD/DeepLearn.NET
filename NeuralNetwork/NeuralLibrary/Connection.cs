using NeuralLibrary.Neurons;
using System;
namespace NeuralLibrary
{
    /// <summary>
    /// The connection held between two neurons with a given weight.
    /// </summary>
    public class Connection
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
        public void NudgeWeight(){
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

        /// <summary>
        /// The last delta weight (used for momentum)
        /// </summary>
        protected double lastDeltaWeight = 0;

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
        /// Updates the weight of the connection using the weight update rule. dW = ERROR_posterior * OUTPUT_anterior
        /// </summary>
        public virtual void UpdateWeight(double learningRate, double momentum)
        {
            double deltaWeight = -(Gradient * learningRate) + momentum * lastDeltaWeight;
            Weight += deltaWeight;
            lastDeltaWeight = deltaWeight;
        }

        /// <summary>
        /// Gets the gradient of the connection,
        /// </summary>
        public double Gradient
        { 
            get
            {
                double output = 0;
                if (AnteriorNeuron is BiasNeuron)
                    output = (AnteriorNeuron as BiasNeuron).Output;
                else if(AnteriorNeuron is InputNeuron)
                    output = (AnteriorNeuron as InputNeuron).Output;
                else
                    output = AnteriorNeuron.Output;

                //if (PosteriorNeuron.Error * output == 0)
                //    Console.WriteLine("SHIT");
                return PosteriorNeuron.Error * output;

            }
        }

        /// <summary>
        /// The weight associated with a connection.
        /// </summary>
        public double Weight { protected set; get; }

        #endregion Properties
    }
}