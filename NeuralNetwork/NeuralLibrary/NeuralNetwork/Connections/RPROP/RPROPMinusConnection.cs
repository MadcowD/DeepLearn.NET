using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralLibrary.NeuralNetwork.Connections.RPROP
{
    /// <summary>
    /// The RPROP Minus algorithm
    /// </summary>
    public class RPROPMinusConnection : Connection
    {
        public RPROPMinusConnection(Neuron anteriorNeuron, Neuron posteriorNeuron)
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
            double gradentialScalar = learningParameters != null && learningParameters.Length >= 1
                ? learningParameters[0]
                : Gradient == 0 ? 0 : 1/Math.Abs(Gradient);

            if (lastGradient * Gradient > 0)
            {
                step = Math.Min(lastStep * stepIncrease, stepMax);
                deltaWeight = -Gradient* gradentialScalar * step;
                Weight += deltaWeight;
                lastGradient = Gradient;
            }
            else if (lastGradient * Gradient < 0)
            {
                step = Math.Max(lastStep * stepDecrease, stepMin);
                lastGradient = 0;
            }
            else if(lastGradient * Gradient == 0)
            {
                deltaWeight = -Gradient*gradentialScalar * step;
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
