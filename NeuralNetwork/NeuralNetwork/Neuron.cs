using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetwork
{
    /// <summary>
    /// The base unit of the neural network.
    /// Contains pertinent information to neural nodes and feedforward propagation thereof.
    /// </summary>
    public abstract class Neuron
    {
        public Neuron()
        {
            Net = 0;
        }
        
        /// <summary>
        /// Resets the given neuron to its initial state.
        /// </summary>
        public void Reset()
        {
            Net = 0;
        }

        #region Properties
        /// <summary>
        /// The net input to the sigmoid function of the neuron.
        /// </summary>
        public double Net { set; get; }

        /// <summary>
        /// Gets the output of the neuron.
        /// </summary>
        /// <param name="activation">The activation function with which the output is calculated.</param>
        /// <returns></returns>
        public virtual double GetOutput(Sigmoid activation){
            return activation.Function(Net);
        }

        /// <summary>
        /// Gets the error of the neuron based on some activation function and some error coefficient (subject to change in Output Neurons).
        /// </summary>
        /// <param name="activation">The activation function with which the error will be calculated.</param>
        /// <param name="errorCoefficient">The standard coefficient of error for neurons.
        /// SUM (for I in Posterior Neurons) Error_i * W_ij. Where j is this neuron.</param>
        /// <returns>The neural error of the neuron.</returns>
        public virtual double GetError(Sigmoid activation, double errorCoefficient)
        {
            return activation.Derivative(Net) * errorCoefficient;
        }

        #endregion Properties
    }
}
