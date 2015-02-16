namespace NeuralLibrary.NeuralNetwork
{
    /// <summary>
    /// The base unit of the neural network.
    /// Contains pertinent information to neural nodes and feedforward propagation thereof.
    /// </summary>
    public class Neuron
    {
        public Neuron()
        {
            Net = 0;
            Output = 0;
            Error = 0;
        }

        /// <summary>
        /// Resets the given neuron to its initial state.
        /// </summary>
        public void Reset()
        {
            Net = 0;
            Error = 0;
            Output = 0;
        }

        #region Properties

        /// <summary>
        /// The net input to the sigmoid function of the neuron.
        /// </summary>
        public double Net { set; get; }

        public virtual double Output { get; protected set; }

        /// <summary>
        /// Updates the output of the neuron.
        /// </summary>
        /// <param name="activation">The activation function with which the output is calculated.</param>
        /// <returns></returns>
        public virtual void UpdateOutput(Sigmoid activation)
        {
            Output = activation.Function(Net);
        }

        public double Error { get; protected set; }

        /// <summary>
        /// Updates the error of the neuron based on some activation function and some error coefficient (subject to change in Output Neurons).
        /// </summary>
        /// <param name="activation">The activation function with which the error will be calculated.</param>
        /// <param name="errorCoefficient">The standard coefficient of error for neurons.
        /// SUM (for I in Posterior Neurons) Error_i * W_ij. Where j is this neuron.</param>
        /// <returns>The neural error of the neuron.</returns>
        public virtual void UpdateError(Sigmoid activation, double errorCoefficient)
        {
            Error = activation.Derivative(Net) * errorCoefficient;
        }

        #endregion Properties

        public int GetID(Network network)
        {
            foreach (Neuron[] n in network.Neurons)
                for (int i = 0; i < n.Length; i++)
                    if (n[i].Equals(this))
                        return i;
            return -1;
        }
    }
}