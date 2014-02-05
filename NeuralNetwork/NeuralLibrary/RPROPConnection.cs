using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralLibrary
{
    public class RPROPConnection : Connection
    {

        public static double STEP_POSITIVE = 1.2;
        public static double STEP_NEGATIVE = 0.5;
        public static double DELTA_MAX = 10;
        public static double DELTA_MIN = 1*Math.Exp(-6);
        
        public RPROPConnection(Neuron anteriorNeuron, Neuron posteriorNeuron)
            : base(anteriorNeuron, posteriorNeuron)
        {
        }

        #region Fields

        protected double lastGradient = 0;
        protected double lastDelta = 0.1;
        protected double delta = 0.1;


        #endregion
        /// <summary>
        /// UPDATES THE WEIGHT USING RPOP ALGORITHM
        /// </summary>
        /// <param name="learningRate"></param>
        /// <param name="momentum"></param>
        public override void UpdateWeight(double learningRate, double momentum)
        {
            double c = Math.Sign(Gradient * lastGradient);
            double deltaWeight = 0;


            if (c > 0)
            {
                delta = Math.Min(lastDelta*STEP_POSITIVE, DELTA_MAX);
                deltaWeight = -Math.Sign(Gradient) * delta;
                this.lastGradient = Gradient;
            }
            else if (c < 0)
            {
                delta = Math.Max(lastDelta * STEP_NEGATIVE, DELTA_MIN);
                this.lastGradient = 0;
            }
            else
            {
                deltaWeight = -Math.Sign(Gradient) * delta;
                this.lastGradient = Gradient;
            }
            lastDelta = delta;
            lastDeltaWeight = deltaWeight;
            Weight += deltaWeight;
            
        }
    }
}
