using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imaging
{
    class DWT1D
    {
        int[] input;
        public DWT1D(int[] tempinput) //tempinput length should be a power of 2
        {
            input = tempinput;
        }

        public int[] Transform()
        {
            int length = input.Length;
            int[] output = new int[length];

            for (int i = length / 2; i >= 1; i /= 2)
            {
                for (int j = 0; j < i; j++)
                {
                    int sum = (input[j * 2] + input[j * 2 + 1])/2;
                    int difference = input[j * 2] - sum;
                    output[j] = sum;
                    output[i + j] = difference;
                }
                for (int copy = 0; copy < i*2; copy++)
                {
                    input[copy] = output[copy];
                }
            }
            return input;
        }
    }
}
