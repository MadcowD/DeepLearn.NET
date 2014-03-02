using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace NucleiDetection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Load");

            
            //Load imag
            for(int x = 0; x < i.Width; x++)
                for(int y = 0; y < i.Height; y++)
                    imageC[x][y] = i.GetPixel(x,y);

            double[][] image = new double[i.Width][];
            for(int j = 0; j < image.Length; j++)
                image[j] = new double[i.Height];
            
            double[][] pixelenergy = new double[i.Width][];
            for(int j = 0; j < pixelenergy.Length; j++)
                pixelenergy[j] = new double[i.Height];

            for(int x = 0; x < i.Width; x++)
                for(int y = 0; y < i.Height; y++)
                    image[x][y] = imageC[x][y].GetBrightness();

            double xenergy = 0, yenergy = 0;
            double max = -1;
            double min = 1000;


            Console.WriteLine("ENERGY");
            for(int x = 0; x < i.Width; x++)
            {
                for(int y = 0; y < i.Height; y++)
                {
                    if(x == 0)
                        xenergy = Math.Pow((image[x+1][y] - image[i.Width-1][y]),2);
                    else if (x == i.Width-1)
                        xenergy = Math.Pow((image[0][y] - image[x-1][y]),2);
                    else
                        xenergy = Math.Pow((image[x-1][y] - image[x+1][y]),2);
                
                    if(y == 0)
                        yenergy = Math.Pow((image[x][y+1] - image[x][i.Height-1]),2);
                    else if (y == i.Height-1)
                        yenergy = Math.Pow((image[x][0] - image[x][y-1]),2);
                    else
                        yenergy = Math.Pow((image[x][y-1] - image[x][y+1]),2);

                    pixelenergy[x][y] = (xenergy + yenergy);
                    
                    if (pixelenergy[x][y] > max)
                    {
                        max = pixelenergy[x][y];
                        Console.WriteLine(max);
                    }
                    if (pixelenergy[x][y] < min)
                        min = pixelenergy[x][y];
                }
            }

            Console.WriteLine("OUTPUT");

            Bitmap b = new Bitmap(i.Width, i.Height);
            for (int x = 0; x < i.Width; x++)
                for (int y = 0; y < i.Height; y++)
                {
                    int val = 255 - (int)(pixelenergy[x][y] * 255 / (max));
                    b.SetPixel(x, y, Color.FromArgb(val,val,val));
                }
            b.Save(@"..\..\..\DATASET\out.png");
        }
    }
}
