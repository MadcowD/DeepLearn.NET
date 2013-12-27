using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Neurons
{
    /// <summary>
    /// Type specific implementation of the neuron class for output neurons.
    /// </summary>
    public class OutputNeuron : Neuron
    {
        #region Properties

        /// <summary>
        /// Gets the error of the output neuron based on some desired output and a sigmoid activation function.
        /// </summary>
        /// <param name="activation">The activation with which the output will be calculated/</param>
        /// <param name="desired">The desired output of this neuron for a given training set.</param>
        /// <returns>The neural error of the output neuron.</returns>
        public override double GetError(Sigmoid activation, double desired)
        {
            return desired - activation.Function(Net);
        }
        #endregion
    }
}
