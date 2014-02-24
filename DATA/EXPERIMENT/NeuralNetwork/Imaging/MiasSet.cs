using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using NeuralLibrary;

namespace Imaging
{
    public class MiasSet:DataSet
    {
        private static ColorPalette grayScale;
        public static Bitmap convertBitmap(String location)
        {
            using (FileStream fs = new FileStream(location, FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader (fs, Encoding.ASCII))
                {
                    if(reader.ReadChar () == 'P' && reader.ReadChar() =='5')
                    {
                        reader.ReadChar();
                        int width = 0;
                        int height = 0;
                        int level = 0;
                        bool two = false;
                        StringBuilder sb = new StringBuilder();
                        width = ReadNumber (reader, sb);
                        height = ReadNumber(reader, sb);
                        level = ReadNumber(reader,sb);
                        two = (level > 255); 

                        Bitmap bmp = new Bitmap (width, height, PixelFormat.Format8bppIndexed); 
                        if (grayScale == null) 
                        { 
                            grayScale = bmp.Palette; 
                            for (int i = 0; i < 256; i++) 
                            { 
                                grayScale.Entries [i] = Color.FromArgb (i, i, i); 
                            } 
                        } 
                        bmp.Palette = grayScale; 
                        BitmapData dt = bmp.LockBits (new Rectangle (0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed); 
                        int offset = dt.Stride - dt.Width; 
                        unsafe 
                        { 
                            byte * ptr = (byte *) dt.Scan0; 

                            for (int i =   0; i <height; i++) 
                            { 
                                for (int j =   0; j <width; j++) 
                                { 
                                    byte v; 
                                    if (two) 
                                    { 
                                        v = (byte) (((double) ((reader.ReadByte () <<   8) + reader.ReadByte ()) / level) *   255.0); 
                                    } 
                                    else 
                                    { 
                                        v = reader.ReadByte (); 
                                    } 
                                    * ptr = v; 
                                    ptr++; 
                                }
                                ptr+=offset; 
                            }
                        } 

                        bmp.UnlockBits (dt); 
                        return bmp; 
                        } 
                        else 
                        { 
                            throw new InvalidOperationException ("target file is not a PGM file"); 
                        } 
                    } 
                } 
            } 

            public static void SaveAsBitmap(string src, string dest) 
            { 
                convertBitmap(src).Save(dest, ImageFormat.Png); 
            } 

            private   static   int ReadNumber (BinaryReader reader, StringBuilder sb) 
            { 
                char c = '\0'; 
                sb.Length = 0; 
                while (Char.IsDigit(c = reader.ReadChar())) 
                { 
                    sb.Append(c); 
                } 
                return int.Parse(sb.ToString()); 
            }
            public override void Load()
            {
                throw new NotImplementedException();
            }
    } 
} 
