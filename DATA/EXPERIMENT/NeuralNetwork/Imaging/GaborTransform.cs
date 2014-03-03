using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imaging
{
    class GaborTransform
    {
        public double sigma_x, sigma_y, theta, lambda, psi, gamma;

        public GaborTransform(double sigma, double temptheta, double templambda, double temppsi, double tempgamma) //wtf is gamma?
        {
            sigma_x = sigma;
            sigma_y = sigma / gamma;
            lambda = templambda;
            psi = temppsi;
            gamma = tempgamma;
        }
        public double[,] Transform()
        {
            //Bounding box
            int nstds = 3;
            double xmax = Math.Max(Math.Abs(nstds*sigma_x*Math.Cos(theta)), Math.Abs(nstds*sigma_x*Math.Sin(theta)));
            xmax = Math.Ceiling(Math.Max(1, xmax));

            double ymax = Math.Max(Math.Abs(nstds * sigma_x * Math.Sin(theta)), Math.Abs(nstds * sigma_x * Math.Cos(theta)));
            ymax = Math.Ceiling(Math.Max(1, xmax));

            double xmin = -xmax;
            double ymin = -ymax;

            int[,,] grid = new int[2,(int)xmax*2,(int)ymax*2];
            double[,] gb = new double[(int)xmax * 2, (int)ymax * 2];
            
            for (int i = (int)xmin; i <= (int)xmax; i++)
            {
                for (int j = (int)ymin; j <= (int)ymax; j++)
                {
                    double x_theta = 0;
                    double y_theta = 0;
                    for(int dim = 0; dim < 2; dim++)
                    {
                        //Rotation
                        if (dim == 0)
                        {
                            grid[dim, i, j] = i;
                            x_theta = grid[dim, i, j] * Math.Sin(theta);
                        }
                        else
                        {
                            grid[dim, i, j] = j;
                            y_theta = grid[dim, i, j] * Math.Cos(theta);
                        }
                    }
                    gb[i,j] = Math.Pow(Math.E, -.5*(Math.Pow(x_theta,2)/Math.Pow(sigma_x,2) + Math.Pow(y_theta,2)/Math.Pow(sigma_y,2))
                        *Math.Cos(2*Math.PI/(lambda*x_theta + psi)));
                }
            }

            return gb;
        }
    }
}
