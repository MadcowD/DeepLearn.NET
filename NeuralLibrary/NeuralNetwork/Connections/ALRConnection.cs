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


        #region Parameters
        const double stepMin = 0.0000016;
        const double stepMax = 50;
        const double stepInitial = 0.1;
        const double stepIncrease = 1.2;
        const double stepDecrease = 0.5;
        #endregion Parameters

        #region Fields

        double lastGradient = 0;
        double lastStep = 0;
        double deltaWeight = 0;
        double step = stepInitial;

        #endregion

        /// <summary>
        /// Updates the weight using the RPROP- algorithm
        /// http://www.inf.fu-berlin.de/lehre/WS06/Musterererkennung/Paper/rprop.pdf
        /// </summary>
        /// <param name="learningParameters"></param>
        protected override void UpdateWeight(params double[] learningParameters)
        {
            if (lastGradient * Gradient > 0)
            {
                step = Math.Min(lastStep * (Math.Min(Math.Abs(Gradient), 50) * 0.01 + 1.2), stepMax);
                deltaWeight = -Math.Sign(Gradient) * step;
                Weight += deltaWeight;
                lastGradient = Gradient;
            }
            else if (lastGradient * Gradient < 0)
            {
                step = Math.Max(lastStep  * stepDecrease, stepMin);
                lastGradient = 0;
            }
            else if (lastGradient * Gradient == 0)
            {
                deltaWeight = -Math.Sign(Gradient) * step;
                Weight += deltaWeight;
                lastGradient = Gradient;
            }
            lastStep = step;
        }

        /// <summary>
        /// The learning parameter count.
        /// </summary>
        protected override uint LearningParameterCount
        {
            get { return 0; }
        }
    }
}
