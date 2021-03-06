﻿using NeuralLibrary.NeuralNetwork;

namespace XOR
{
    /// <summary>
    /// The XOR DataSet is the standardized truth table for the XOR (^) operation.
    /// </summary>
    internal class XORDataSet : DataSet
    {
        public override void Load()
        {
            this.Add(new DataPoint(new double[] { 0, 0 }, new double[] { 0 }));
            this.Add(new DataPoint(new double[] { 1, 0 }, new double[] { 1 }));
            this.Add(new DataPoint(new double[] { 1, 1 }, new double[] { 0 }));
            this.Add(new DataPoint(new double[] { 0, 1 }, new double[] { 1 }));

        }
    }
}