using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;


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
            for(int x = 0; x < bmp.Height; x++)
            {
                for(int y = 0; y < bmp.Width; y++)
                {
                    map[x, y] = System.Convert.ToDouble(bmp.GetPixel(x, y).GetBrightness());
                }
            }
            Console.Write(map);
            HaarWavelet.FWT(map,2);
            for(int x = 0; x < bmp.Height; x++)
            {
                for(int y = 0; y < bmp.Width; y++)
                {
                    int val = 255 * (int)(map[x,y] / 255);
                    oot.SetPixel(x, y, Color.FromArgb(val,val,val));
                }
            }
            oot.Save(@"C:\temp\out.png");
            
        }
    }
}
