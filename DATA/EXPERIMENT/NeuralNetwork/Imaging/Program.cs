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
            Bitmap bmp = new Bitmap(Image.FromFile(@"..\..\..\..\DATASET\Pictures\Normal\mdb140N.png"));
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
            bmp.Save(@"..\..\..\..\DATASET\Pictures\Normal\OUTmdb140N.png");

            Bitmap sbmp = new Bitmap(4, 4);
            string[] numout = new string[4 * 4];
            for (int x = 3; x < 7; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    sbmp.SetPixel(x-3, y, Color.FromArgb(imageProcess[x, y], imageProcess[x, y], imageProcess[x, y]));
                    numout[4 * (x - 3) + y] = imageProcess[x, y].ToString();
                }
            }
            sbmp.Save(@"..\..\..\..\DATASET\Pictures\Normal\OUTSMALLmdb140N.png");
            System.IO.File.WriteAllLines(@"..\..\..\..\DATASET\Pictures\Normal\OUTSMALLNUMmdb140N.txt", numout);

        }
    }
}