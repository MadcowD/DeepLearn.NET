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
    public class BiasNeuron : Neuron
    {
        /// <summary>
        /// Gets the output of the bias neuron. Always returns one.
        /// </summary>
        /// <returns>The output of the bias neuron. Always one.</returns>
        public override double GetOutput(Sigmoid activation)
        {
            return 1;
        }
    }
}
