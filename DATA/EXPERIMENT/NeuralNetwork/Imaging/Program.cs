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
            Bitmap bmp = new Bitmap(Image.FromFile(@"..\..\..\..\DATASET\Pictures\Not Normal\mdb274.png"));
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
            //bmp.Save(@"..\..\..\..\DATASET\Pictures\Normal\OUTmdb140.png");

            Bitmap sbmp = new Bitmap(8, 8);
            string[] numout = new string[8 * 8];
            for (int x = 7; x < 15; x++)
            {
                for (int y = 8; y < 16; y++)
                {
                    sbmp.SetPixel(x-7, y-8, Color.FromArgb(imageProcess[x, y], imageProcess[x, y], imageProcess[x, y]));
                    numout[8 * (x - 7) + y-8] = imageProcess[x, y].ToString();
                }
            }
            //sbmp.Save(@"..\..\..\..\DATASET\Pictures\Normal\OUTSMALLmdb140.png");
            System.IO.File.WriteAllText(@"..\..\..\..\DATASET\Pictures\Not Normal\OUTSMALLNUMmdb274.txt", string.Join(",", numout), ASCIIEncoding.ASCII);

        }
    }
}