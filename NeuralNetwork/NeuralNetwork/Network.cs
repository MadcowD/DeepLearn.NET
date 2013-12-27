using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetwork
{
    class Network
    {
        private int p1;
        private int p2;
        private int p3;

        public Network(Sigmoid sigmoid, int p1, int p2, int p3)
        {
            // TODO: Complete member initialization
            this.sigmoid = sigmoid;
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }

        #region Sigmoids
        /// <summary>
        /// The hyperbolic tangent activation function.
        /// </summary>
        public static Sigmoid HyperbolicTangent =
            new Sigmoid(x => Math.Tanh(x), x => 1 - Math.Pow(Math.Tanh(x), 2));

        public static Sigmoid Logistic =
            new Sigmoid(x => 1/(1+Math.Exp(-x)), x => Math.Exp(x)/Math.Pow(1 + Math.Exp(x),2));

        public static Sigmoid Linear =
            new Sigmoid(x => x, x => 1);

        #endregion Sigmoids
    }
}
