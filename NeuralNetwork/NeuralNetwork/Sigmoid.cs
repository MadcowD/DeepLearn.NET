using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetwork
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

        Func<double, double> derivative;
        Func<double, double> function;

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
    }
}
