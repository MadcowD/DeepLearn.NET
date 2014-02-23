using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imaging
{
    public class HaarWavelet
    {
        public static void FWT(double[] data)
        {
            double[] temp = new double[data.Length];

            int h = data.Length;//half of data.Length
            int i = 0;
            for (int x = 0; x < h; x+=2)
            {
                
                int k = i << 1;
                if(x>0)
                    temp[x-1] = Math.Abs(data[k-1] * w0 - data[k] * w1);
                temp[x] = Math.Abs(data[k] * s0 - data[k + 1] * s1);
                i++;
            }

            for (int j = 0; j < data.Length; j++)
                data[j] = temp[j];
        } 
        public static void FWT(double[,] data, int iterations)
        {
            int rows = data.GetLength(0);
            int cols = data.GetLength(1);

            double[] row = new double[cols];
            double num = 2;//standardized all values for easy modification
            s0 = num;
            s1 = num;
            w0 = num;
            w1 = num;
            for (int k = 0; k <iterations; k++)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < row.Length; j++)
                        row[j] = data[i, j];

                    FWT(row);

                    for (int j = 0; j < row.Length; j++)
                        data[i, j] = row[j];
                }
            }
        }
       
        public static void IWT(double[] data)
        {
            double[] temp = new double[data.Length];

            int h = data.Length >> 1;
            for (int i = 0; i < h; i++)
            {
                int k = (i << 1);
                temp[k] = (data[i] * s0 + data[i + h] * w0) / w0;
                temp[k + 1] = (data[i] * s1 + data[i + h] * w1) / s0;
            }

            for (int i = 0; i < data.Length; i++)
                data[i] = temp[i];
        }
        public static void IWT(double[,] data, int iterations)
        {
            int rows = data.GetLength(0);
            int cols = data.GetLength(1);

            double[] col = new double[rows];
            double[] row = new double[cols];

            for (int l = 0; l < iterations; l++)
            {
                for (int j = 0; j < cols; j++)
                {
                    for (int i = 0; i < row.Length; i++)
                        col[i] = data[i, j];

                    IWT(col);

                    for (int i = 0; i < col.Length; i++)
                        data[i, j] = col[i];
                }

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < row.Length; j++)
                        row[j] = data[i, j];

                    IWT(row);

                    for (int j = 0; j < row.Length; j++)
                        data[i, j] = row[j];
                }
            }
        }

        static double s0;
        static double s1;
        static double w0;
        static double w1;
    }
}
