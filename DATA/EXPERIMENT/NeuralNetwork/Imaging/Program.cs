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
            Bitmap bmp = new Bitmap(Image.FromFile(@"..\..\..\..\DATASET\image2.png"));
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