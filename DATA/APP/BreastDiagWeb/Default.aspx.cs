using Imaging;
using NeuralLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BreastDiagWeb
{
    public partial class Default : System.Web.UI.Page
    {
        Network[] proportional = new Network[10];
        TextBox[] proportionInputs = new TextBox[9];

        Network[] imgnet = new Network[1];

        Network[] detail = new Network[10];
        TextBox[] detailInputs;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Proportional
            //LOAD THE PROPORTIONAL NETWORKS
            for (int i = 0; i < 10; i++)
                proportional[i] = Network.Load(Server.MapPath(@"data\proportional\nn" + i + ".nn"));

            proportionInputs[0] = proportion1;
            proportionInputs[1] = proportion2;
            proportionInputs[2] = proportion3;
            proportionInputs[3] = proportion4;
            proportionInputs[4] = proportion5;
            proportionInputs[5] = proportion6;
            proportionInputs[6] = proportion7;
            proportionInputs[7] = proportion8;
            proportionInputs[8] = proportion9;

            #endregion

            #region Detail
            //LOAD THE PROPORTIONAL NETWORKS
            for (int i = 0; i < 10; i++)
                detail[i] = Network.Load(Server.MapPath(@"data\detail\" + i + @"\weights.nn"));


            //Worse code ever.
            detailInputs = new TextBox[] {
            TextBox1, TextBox2, TextBox3, TextBox4,
            TextBox5, TextBox6, TextBox7, TextBox8,
            TextBox9, TextBox10, TextBox11, TextBox12,
            TextBox13, TextBox14, TextBox15, TextBox16,
            TextBox17, TextBox18, TextBox19, TextBox20,
            TextBox21, TextBox22, TextBox23, TextBox24,
            TextBox25, TextBox26, TextBox27, TextBox28,
            TextBox29, TextBox30 };
            #endregion

            for (int i = 0; i < 1; i++)
                imgnet[i] = Network.Load(Server.MapPath(@"data\img\" + i + ".nn"));
        }


        protected void proportionalFeedForward()
        {

            double tryparse = 0;
            double[] input = proportionInputs.Select((x, i) =>
                {
                    if(double.TryParse(x.Text, out tryparse))
                        return (tryparse); //Conversion expression
                    else
                        return 0;
                }).ToArray();

            double[] inp = {
                (input[0] == 0 ? 10 : input[0])/10,
                11 -(input[1] == 0 ? 10 : input[1])/10,
                11 -(input[2] == 0 ? 10 : input[2])/10,
                11 - (input[3] == 0 ? 10 : input[3])/10,
                (input[4] == 0 ? 10 : input[4])/10, 
                 (input[5] == 0 ? 10 : input[5])/10,
                (input[6] == 0 ? 10 : input[6])/10, 
                11 - (input[7] == 0 ? 10 : input[7])/10,
                11 - (input[8] == 0 ? 10 : input[8])/10 
                };

            int conclusive = 0;
            foreach (Network nn in proportional)
            {
                nn.FeedForward(inp);
                if (Gaussian.Step(nn.Output[0], 0.05) == 1)
                    conclusive++;
            }

            if (conclusive > 8)
                proportionDiagnosis.Text = "Malignant";
            else if (conclusive < 2)
                proportionDiagnosis.Text = "Benign";
            else
                proportionDiagnosis.Text = "Inconclusive";
        }

        protected void detailFeedForward()
        {
            double tryparse = 0;
            double[] input = detailInputs.Select((x) =>
            {
                if (double.TryParse(x.Text, out tryparse))
                    return (tryparse); //Conversion expression
                else
                    return 0;
            }).ToArray();

            int conclusive = 0;
            foreach (Network nn in detail)
            {
                nn.FeedForward(input);
                if (Gaussian.Step(nn.Output[0], 0.86) == 1)
                    conclusive++;
            }

            if (conclusive > 8)
                detailDiagnosis.Text = "Malignant";
            else if (conclusive < 2)
                detailDiagnosis.Text = "Benign";
            else
                detailDiagnosis.Text = "Inconclusive";
        }
       
        protected void proportionSubmit_Click(object sender, EventArgs e)
        {
            proportionalFeedForward();
        }

        protected void detailSubmit_Click(object sender, EventArgs e)
        {
            detailFeedForward();
        }
        Random r = new Random();
        protected void midSubmit_Click(object sender, EventArgs e)
        {
            string filePath = @"\uploads\" + System.IO.Path.GetRandomFileName();
            //save file
            if (midImage.HasFile)
            {
                // Height="573px" Width="639px"
                Image1.Height = 573;
                Image1.Width = 639;
                Label1.Text = midImage.FileName;
                midImage.SaveAs(Server.MapPath(filePath +@"image.png"));

                Image1.ImageUrl = filePath + "image.png";
                Label2.Visible = true;
                Image1.Visible = true;




                #region DWT
                Bitmap bmp = new Bitmap(System.Drawing.Image.FromFile(Server.MapPath(filePath + @"image.png")));
                int[,] imageC = new int[bmp.Width, bmp.Height];
                int[,] imageProcess = new int[bmp.Width, bmp.Height];
                for (int x = 0; x < bmp.Width; x++)
                    for (int y = 0; y < bmp.Height; y++)
                        imageC[x, y] = (int)(bmp.GetPixel(x, y).GetBrightness() * 255);

                DWT2D d = new DWT2D(imageC);
                imageProcess = d.Transform(imageC);

                for (int x = 0; x < bmp.Width; x++)
                    for (int y = 0; y < bmp.Height; y++)
                        bmp.SetPixel(x, y, Color.FromArgb(imageProcess[x, y], imageProcess[x, y], imageProcess[x, y]));
                //bmp.Save(@"..\..\..\..\DATASET\Pictures\Normal\OUTmdb140.png");

                Bitmap sbmp = new Bitmap(8, 8);
                double[] numout = new double[8 * 8];
                for (int x = 7; x < 15; x++)
                {
                    for (int y = 8; y < 16; y++)
                    {
                        sbmp.SetPixel(x - 7, y - 8, Color.FromArgb(imageProcess[x, y], imageProcess[x, y], imageProcess[x, y]));
                        numout[8 * (x - 7) + y - 8] = imageProcess[x, y];
                    }
                }
                Bitmap b = new Bitmap(200, 200);
                using (Graphics g = Graphics.FromImage((System.Drawing.Image)b))
                {
                    g.InterpolationMode = InterpolationMode.NearestNeighbor;
                    g.DrawImage(sbmp, 0, 0, 200, 200);
                }
                b.Save(Server.MapPath(filePath + @"dwt.png"));
                #endregion
                #region Network
                int conclusive = 0;
                foreach (Network nn in imgnet)
                {
                    nn.FeedForward(numout);
                    if (Gaussian.Step(nn.Output[0], 0.58) == 0)
                        conclusive++;
                }

                if (conclusive > 0)
                    midDiagnosis.Text = "Tumorous";
                else if (conclusive < 1)
                    midDiagnosis.Text = "Normal";
                else
                    midDiagnosis.Text = "Inconclusive" + conclusive;
                #endregion
                Image2.ImageUrl = filePath + "dwt.png";
                Image2.Visible = true;
                Image2.Height = 200;
                Image2.Width = 200;
                Label3.Visible = true;
            }
            else
            {
                Image1.Visible = false;
                Image1.ImageUrl = "";
                Image2.Visible = false;
                Image2.ImageUrl = "";
                Label2.Visible = false;
                Label2.Visible = false;
            }

        }
    }
}