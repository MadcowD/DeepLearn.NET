using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imaging
{
    class DWT2D
    {
        public int[,] input;
        public int[,] finaloutput;
        //constructor
        public DWT2D(int[,] tempinput) //tempinput length should be a power of 2
        {
            input = tempinput;
            finaloutput = new int[tempinput.GetLength(0), tempinput.GetLength(1)];
        }

        public int[,] Transform(int[,] tempinput)
        {
            //1/4 of the original image size
            int[,] output = new int[tempinput.GetLength(0)/2, tempinput.GetLength(1)/2];
            for (int w = 0; w < tempinput.GetLength(0) / 2; w++)
            {
                for (int h = 0; h < tempinput.GetLength(1) / 2; h++)
                {
                    //prepares the image for the next step (recursion)
                    output[w, h] = (tempinput[w * 2, h * 2] + tempinput[w * 2 + 1, h * 2]
                                     + tempinput[w * 2, h * 2 + 1] + tempinput[w * 2 + 1, h * 2 + 1]) / 4;
                    //Proceess output onto a final image
                    finaloutput[w, h] = (tempinput[w * 2, h * 2] + tempinput[w * 2 + 1, h * 2]
                                     + tempinput[w * 2, h * 2 + 1] + tempinput[w * 2 + 1, h * 2 + 1]) / 4;
                    finaloutput[w + tempinput.GetLength(0) / 2, h]
                        = tempinput[w * 2 + 1, h * 2];
                    finaloutput[w, h + tempinput.GetLength(1) / 2]
                        = tempinput[w * 2 + 1, h * 2 + 1];
                    finaloutput[w + tempinput.GetLength(0) / 2, h + tempinput.GetLength(1) / 2]
                        = tempinput[w * 2 + 1, h * 2 + 1];
                    
                    //Console.WriteLine(w + "   " + h);
                }
            }
            if (tempinput.GetLength(0) > 2 || tempinput.GetLength(1) > 2) //how large the final image is
                return Transform(output);// recursive function to continue reducing the image
            else
                return finaloutput;
        }
    }
}