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
        public ConclusionExperiment(CancerData training, CancerData testing)
            : base(training, testing)
        { }

        public override void Run()
        {

            //Create 10 pretty awesome nets with low error
            for (int i = 0; i < 10; i++)
            {
                Network nn = Network.Load(DATASTORE + "CONTROL\\0\\weights.nn", false);
                Trainer trainer = new Trainer(nn, trainingSet);

                do
                {
                    //nn.NudgeWeights();
                    //nn.Save(DATASTORE + PERSIST + i + "\\initial.nn");
                    trainer.Train(NETWORK_EPOCHS, 2, 0.0001, 0.15, false, -1, 
                        () => { Console.WriteLine(testingSet.CalculateError(nn, -1)); return testingSet.CalculateError(nn, -1) <= 3.1;});
                }
                while (testingSet.CalculateError(nn, -1) < 3.1);

                Analyze(i.ToString(), trainer, nn);
                nn.Save(DATASTORE + PERSIST + i + "\\weights.nn");
                
            }
        }

        public override string PERSIST
        {
            get { return @"CONCLUSION\"; }
        }
    }
}
