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
        TextBox[] proportionInputs = new TextBox[10];
        protected void Page_Load(object sender, EventArgs e)
        {
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
          
        }

        protected void proportionalFeedForward(object sender, EventArgs e)
        {

            double tryparse = 0;
            double[] input = proportionInputs.Select((x, i) =>
                {
                    if(double.TryParse(x.Text, out tryparse))
                        return (tryparse); //Conversion expression
                    else
                        return 0;
                }).ToArray();

            int conclusive = 0;
            foreach (Network nn in proportional)
            {
                nn.FeedForward(input);
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
    }
}