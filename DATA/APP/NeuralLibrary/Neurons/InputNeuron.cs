namespace NeuralLibrary.Neurons
{
    /// <summary>
    /// Type specific implementation of the neuron class for input neurons.
    /// </summary>
    public class InputNeuron : Neuron
    {
        /// <summary>
        /// Updates the inactivated net for output.
        /// </summary>
        public override void UpdateOutput(Sigmoid activation)
        {
        }

        public override double Output
        {
            get
            {
                return Net;
            }
        }
    }
}