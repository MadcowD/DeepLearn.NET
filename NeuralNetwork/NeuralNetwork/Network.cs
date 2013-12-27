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
    }
}
