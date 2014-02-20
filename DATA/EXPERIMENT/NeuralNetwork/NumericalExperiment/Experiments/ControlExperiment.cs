using NeuralLibrary;
using System;
using System.Collections.Generic;
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
            Network nn = new Network(false, NETWORK_SIZE);
            Trainer trainer = new Trainer(nn, trainingSet);

            trainer.Train(NETWORK_EPOCHS, NETWORK_ERROR, NETWORK_LEARNING_RATE, NETWORK_MOMENTUM, NETWORK_NUDGING);
            double testingError = testingSet.Select<DataPoint, double>(
                (x) =>
                {
                    nn.FeedForward(x.Input);
                    return 0.5 * Math.Pow(nn.Output[0] - x.Desired[0], 2);
                }).Sum();

            Console.WriteLine("Testing Error: " + testingError);
            Analyze("", trainer, nn);
        }

        public override string PERSIST
        {
            get { return @"CONTROL\"; }
        }
    }
}
