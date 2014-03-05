using System;

namespace NeuralLibrary
{
    /// <summary>
    /// Defines some generic sigmoid activation function and its derivative.
    /// </summary>
    public class Sigmoid
    {
        /// <summary>
        /// Defines the sigmoid activation function by a function and its derivative.
        /// </summary>
        /// <param name="function"></param>
        /// <param name="derivative"></param>
        public Sigmoid(Func<double, double> function, Func<double, double> derivative)
        {
            this.function = function;
            this.derivative = derivative;
        }

        #region Fields

        private Func<double, double> derivative;
        private Func<double, double> function;

        #endregion Fields

        #region Properties

        /// <summary>
        /// The derivative of this sigmoid activation function.
        /// </summary>
        public Func<double, double> Derivative
        { get { return derivative; } }

        /// <summary>
        /// The definition for this sigmoid activation function.
        /// </summary>
        public Func<double, double> Function
        { get { return function; } }

        #endregion Properties

        #region Sigmoids

        /// <summary>
        /// The hyperbolic tangent activation function.
        /// </summary>
        public static Sigmoid HyperbolicTangent =
            new Sigmoid(x => Math.Tanh(x), x => 1 - Math.Pow(Math.Tanh(x), 2));

        public static Sigmoid HyperbolicStep =
            new Sigmoid(x => Math.Round(HyperbolicTangent.Function(x)),
                x => Math.Round(HyperbolicTangent.Derivative(x)));

        public static Sigmoid Logistic =
            new Sigmoid(x => 1 / (1 + Math.Exp(-x)), x => Math.Exp(x) / Math.Pow(1 + Math.Exp(x), 2));

        public static Sigmoid Linear =
            new Sigmoid(x => x, x => 1);

        public static Sigmoid None =
            new Sigmoid(x => 0, x => 0);

        #endregion Sigmoids
    }
}