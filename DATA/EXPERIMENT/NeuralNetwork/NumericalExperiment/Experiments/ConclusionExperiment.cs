using NeuralLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalExperiment.Experiments
{
    /// <summary>
    /// Runs the conclusion experiment based on information acquired through previous univariant experiments.
    /// </summary>
    class ConclusionExperiment : Experiment
    {
        public override void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                Network nn = new Network(false, NETWORK_SIZE);
                Trainer trainer = new Trainer(nn, trainingSet);

                do
                {

                } while (testingSet);
            }
        }

        public override string PERSIST
        {
            get { return @"CONCLUSION\"; }
        }
    }
}
