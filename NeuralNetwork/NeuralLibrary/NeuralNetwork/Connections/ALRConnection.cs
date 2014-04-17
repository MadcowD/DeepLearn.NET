using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralLibrary.NeuralNetwork.Connections
{
    /// <summary>
    /// The accelerative learning rate connection.
    /// </summary>
    public class ALRConnection : Connection
    {
        public ALRConnection(Neuron anteriorNeuron, Neuron posteriorNeuron)
            : base(anteriorNeuron, posteriorNeuron)
        { }

        #region Fields

        double velocity = 0;
        double lastGradient = 0;
        double lastDeltaWeight = 0;

        #endregion

        /// <summary>
        /// Updates weights following our own accelerative learning algorithm.
        /// </summary>
        /// <param name="learningParameters"></param>
        protected override void UpdateWeight(params double[] learningParameters)
        {
            double acceleration = learningParameters[0];
            double frictionCoefficient = learningParameters[1];

            if (lastGradient * Gradient > 0)
            {
                velocity += acceleration;
            }
            else if (lastGradient * Gradient < 0)
                velocity = 0;
            else
                velocity = acceleration;


            double deltaWeight =
                -(Gradient*velocity) + frictionCoefficient * lastDeltaWeight; //TODO: Add a normalizing term to the gradient.
            Weight += deltaWeight;

            lastDeltaWeight = deltaWeight;
            lastGradient = Gradient;
        }

        /// <summary>
        /// This algorithm takes in a velocity step size and a coefficient of friction.
        /// </summary>
        protected override uint LearningParameterCount
        {
            get { return 2; }
        }
    }
}
