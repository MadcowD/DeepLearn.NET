using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
