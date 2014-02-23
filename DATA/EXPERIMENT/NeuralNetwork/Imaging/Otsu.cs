using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace Imaging
{
    public class Otsu
    {
        ////coppied from some page. so confused
        //public Otsu(String fileLoc)
        //{
        //    Bitmap bmp = new Bitmap(Image.FromFile(@"C:\temp\image.png"));
        //    byte t = 0;
        //    float[] vet = new float[256];
        //    int[] hist = new int[256];
        //    vet.Initialize();

        //    float p1, p2, p12;
        //    int k;

        //    BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
        //    ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
        //    unsafe
        //    {
        //        byte* p = (byte*)(void*)bmData.Scan0.ToPointer();

        //        getHistogram(p, bmp.Width, bmp.Height, bmData.Stride, hist);


        //        for (k = 1; k != 255; k++)
        //        {
        //            p1 = Px(0, k, hist);
        //            p2 = Px(k + 1, 255, hist);
        //            p12 = p1 * p2;
        //            if (p12 == 0)
        //                p12 = 1;
        //            float diff = (Mx(0, k, hist) * p2) - (Mx(k + 1, 255, hist) * p1);
        //            vet[k] = (float)diff * diff / p12;

        //        }
        //    }
        //    bmp.UnlockBits(bmData);

        //    t = (byte)findMax(vet, 256);

        //    return t;
        //}
        
    }
}
