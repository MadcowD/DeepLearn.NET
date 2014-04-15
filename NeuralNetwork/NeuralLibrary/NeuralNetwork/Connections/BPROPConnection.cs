using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralLibrary.NeuralNetwork.Connections
{
    /// <summary>
    /// Represents the standard backpropagtion connection.
    /// </summary>
    public class BPROPConnection : Connection
    {
        public BPROPConnection(Neuron anteriorNeuron, Neuron posteriorNeuron)
            : base(anteriorNeuron, posteriorNeuron)
        { }


        /// <summary>
        /// Updates the weight given some parameters.
        /// Using BPROP this follows:
        /// </summary>
        /// <param name="learningRate">The learning rate</param>
        /// <param name="momentum">The momentum</param>
        public override void UpdateWeight(double learningRate, double momentum)
        {
            double deltaWeight = -Gradient * learningRate + momentum * lastDeltaWeight;
            Weight += deltaWeight;
            lastDeltaWeight = deltaWeight;
        }
        
            #region Fields

            /// <summary>
            /// The last delta weight (used for momentum)
            /// </summary>
            protected double lastDeltaWeight = 0;

            #endregion
    }
    


}
