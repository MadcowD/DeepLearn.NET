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
            Bitmap bmp = new Bitmap(Image.FromFile(@"C:\temp\image.png"));
            Bitmap oot = new Bitmap(bmp.Height, bmp.Width);
            //Otsu os = new Otsu("C:\\temp\\cancer.png");
            double[,] map = new double[bmp.Height, bmp.Width];
            Console.Write(bmp.GetPixel(0,0));
            String[] temp = new String[map.Length+1];
            for(int x = 0; x < bmp.Height; x++)
            {
                for (int y = 0; y < bmp.Width; y++)
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
            HaarWavelet.FWT(map,1);
            for(int x = 0; x < bmp.Height; x++)
            {
                for(int y = 0; y < bmp.Width; y++)
                {
                    int val = ((int)(map[x, y] * 255)) % 256;
                    oot.SetPixel(x, y, Color.FromArgb(val,val,val));
                    temp[x + y] = "(" + x + "," + y + "): " + map[x, y];
                }
            }
            oot.Save(@"C:\temp\ot.png");
        }
    }
}
