using System;
using System.Collections.Generic;

namespace NeuralLibrary
{
    /// <summary>
    /// Holds an abstract dataset.
    /// </summary>
    public abstract class DataSet : List<DataPoint>
    {
        /// <summary>
        /// Load dataset into the list.
        /// </summary>
        public abstract void Load();

        /// <summary>
        /// Random used for the dataset extension (shuffle)
        /// </summary>
        public static Random r = new Random();

        /// <summary>
        /// An extension for all ILists and dataset which shuffles the order.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public DataSet Shuffle()
        {
            int n = this.Count;
            while (n > 1)
            {
                n--;
                int k = r.Next(n + 1);
                DataPoint value = this[k];
                this[k] = this[n];
                this[n] = value;
            }

            return this;
        }
    }
}