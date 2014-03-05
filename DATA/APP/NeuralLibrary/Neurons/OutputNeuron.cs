namespace NeuralLibrary.Neurons
{
    /// <summary>
    /// Type specific implementation of the neuron class for output neurons.
    /// </summary>
    public class OutputNeuron : Neuron
    {
        #region Properties

        /// <summary>
        /// Updates the error of the output neuron based on some desired output and a sigmoid activation function.
        /// </summary>
        /// <param name="activation">The activation with which the output will be calculated/</param>
        /// <param name="desired">The desired output of this neuron for a given training set.</param>
        public override void UpdateError(Sigmoid activation, double desired)
        {
            Error = (this.Output - desired) * activation.Derivative(this.Net);
        }

        #endregion Properties
    }
}