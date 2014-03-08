using NeuralLibrary;
using System;
using System.Collections.Generic;
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


            
            //for(int i = 0; i < 9; i++)
            //{
            //    string query = Request.QueryString["proportion" + i.ToString()];
            //    proportionInputs[i].Text = string.IsNullOrWhiteSpace(query) ? "0" : query;
            //}

            proportionalFeedForward();
            #endregion
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
                proportionDiagnosis.Text = "Malignant" + conclusive.ToString();
            else if (conclusive < 2)
                proportionDiagnosis.Text = "Benign" + conclusive.ToString();
            else
                proportionDiagnosis.Text = "Inconclusive" + conclusive.ToString();
        }

        protected void proportionSubmit_Click(object sender, EventArgs e)
        {
            //proportionalFeedForward();
        }
    }
}