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
        public ControlExperiment(CancerData training, CancerData testing)
            :base(training, testing)
        {
        }


        public override void Run()
        {
            for (int i = 0; i < 10; i++) //Make 10 controls.
            {
                (new FileInfo(DATASTORE + PERSIST + i + "\\")).Directory.Create();
                Network nn = new Network(false, NETWORK_SIZE);
                Trainer trainer = new Trainer(nn, trainingSet);

                do
                {

                    nn.NudgeWeights();
                    nn.Save(DATASTORE + PERSIST + "initial.nn"); //Save weights

                }
                while (trainer.Train(NETWORK_EPOCHS, NETWORK_ERROR, NETWORK_LEARNING_RATE, NETWORK_MOMENTUM, NETWORK_NUDGING));

                Analyze(i + "\\", trainer, nn);
            }
        }

        public override string PERSIST
        {
            get { return @"CONTROL\"; }
        }
    }
}
