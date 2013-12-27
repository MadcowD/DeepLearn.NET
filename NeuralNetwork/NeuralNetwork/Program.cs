using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Program
    {
        static void Main(string[] args)
        {
            Network nn = new Network(Sigmoid.HyperbolicTangent, 2, 2, 2);
        }
    }
}
