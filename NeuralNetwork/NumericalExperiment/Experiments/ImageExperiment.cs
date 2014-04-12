using NeuralLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalExperiment.Experiments
{
    class ImageExperiment: Experiment
    {
        public ImageExperiment(CancerData training, CancerData testing)
            : base(training, testing)
        { }
        public override void Run()
        {
            //Create 10 pretty awesome nets with low error
            for (int i = 1; i < 10; i++)
            {
                Network nn = new Network(false, 64, 10, 5, 1);
                Trainer trainer = new Trainer(nn, trainingSet);

                do
                {
                    nn.NudgeWeights();
                    //nn.Save(DATASTORE + PERSIST + i + "\\initial.nn");
                    trainer.Train(NETWORK_EPOCHS, 2, 0.000171875, 0.25, false, -1);
                    Console.WriteLine("NIGGERS: {0}", testingSet.CalculateError(nn, -1) / 8.0);
                }
                while (testingSet.CalculateError(nn, -1) > 0.6);

                Analyze(i.ToString() + "\\", trainer, nn);
                nn.Save(DATASTORE + PERSIST + i + "\\weights.nn");

            }
        }

        public override string PERSIST
        {
            get { return @"IMAGES\"; }
        }

    }
}
