using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace Imaging
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap bmp = new Bitmap(Image.FromFile(@"..\..\..\..\DATASET\image1.png"));
            int[,] imageC = new int[bmp.Width, bmp.Height];
            int[,] imageProcess = new int[bmp.Width, bmp.Height];
            for (int x = 0; x < bmp.Width; x++)
                for (int y = 0; y < bmp.Height; y++)
                    imageC[x,y] = (int)(bmp.GetPixel(x,y).GetBrightness()*255);
            
            DWT2D d = new DWT2D(imageC);
            imageProcess = d.Transform(imageC);
            
           

            for (int x = 0; x < bmp.Width; x++)
                for (int y = 0; y < bmp.Height; y++)
                    bmp.SetPixel(x, y, Color.FromArgb(imageProcess[x, y], imageProcess[x, y], imageProcess[x, y]));

            bmp.Save(@"..\..\..\..\DATASET\output.png");
            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}

/*
 * Bitmap bmp = new Bitmap(Image.FromFile(@"..\..\..\..\DATASET\image.png"));
            int[] dimension = adjustSize(bmp.Width, bmp.Height);
            
            Bitmap oot = new Bitmap(dimension[0], dimension[1]);
            //Otsu os = new Otsu("C:\\temp\\cancer.png");
            double[,] map = new double[dimension[0], dimension[1]];
            for (int x = 0; x < dimension[0]; x++)
                for (int y = 0; y < dimension[1]; y++)
                    map[x, y] = 0;
            Console.Write(bmp.GetPixel(0,0));
            String[] temp = new String[map.Length+1];
            for(int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    double d = System.Convert.ToDouble(bmp.GetPixel(x, y).GetBrightness());
                    map[x, y] = d;
                }
            }
           
            //for (int x = 0; x < bmp.Width; x++)
            //{
            //    for (int y = 0; y < bmp.Height; y++)
            //    {
            //        temp[x + y] = "(" + x + "," + y + "): " + map[x, y];
            //    }
            //}
            HaarWavelet.FWT(map,2);
            for(int x = 0; x < bmp.Width; x++)
            {
                for(int y = 0; y < bmp.Height; y++)
                {
                    int val =255 -((int)(map[x, y] * 255)) % 256;
                    oot.SetPixel(x, y, Color.FromArgb(val,val,val));
                    //temp[x + y] = "(" + x + "," + y + "): " + map[x, y];
                }
            }
            oot.Save(@"..\..\..\DATASET\ot.png");
        }
        //adjusts dimensions to be powers of 2 so Haar algorithm can process
        static int[] adjustSize(int width, int height)
        {
            int[] newDim = new int[2];
            int cur = 1;
            while (cur < width)
                cur <<= 1;
            newDim[0] = cur;
            cur = 1;
            while (cur < height)
                cur <<= 1;
            newDim[1] = cur;
            return newDim;
 */
