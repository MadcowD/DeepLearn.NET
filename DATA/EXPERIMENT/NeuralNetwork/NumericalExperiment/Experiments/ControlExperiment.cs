using NeuralLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalExperiment.Experiments
{
    public class ControlExperiment : Experiment
    {
        public ControlExperiment(CancerData training, CancerData testing, int i)
            :base(training, testing)
        {
            this.i = i;
        }


        public override void Run()
        {

                (new FileInfo(DATASTORE + PERSIST + i + "\\")).Directory.Create();
                Network nn = new Network(false, NETWORK_SIZE);
                Trainer trainer = new Trainer(nn, trainingSet);

                do
                {

                    nn.NudgeWeights();
                    nn.Save(DATASTORE + PERSIST + i + "\\" + "initial.nn"); //Save weights

                }
                while (!trainer.Train(NETWORK_EPOCHS, NETWORK_ERROR, NETWORK_LEARNING_RATE, NETWORK_MOMENTUM, NETWORK_NUDGING));

                Analyze(i + "\\", trainer, nn);
            
        }

        public override string PERSIST
        {
            get { return @"CONTROL\"; }
        }

        int i = 0;
    }
}
