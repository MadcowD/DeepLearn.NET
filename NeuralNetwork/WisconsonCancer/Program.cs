using NeuralLibrary;
using System;
using System.IO;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace WisconsonCancer
{
    internal class Program
    {
        public static double Step(double d)
        {
            if (d > 0.05)
                return 1;
            else
                return 0;
        }

        public static string fileTest = @"C:\Programming\C#\ISEFNeuralNetwork";
        ///commentted out to prevent problems from analysis of unconstructed networks
        
        /// <summary>
        /// Runs the network and outputs a graph of error by weights
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            MainTrain(args);
            /*string fileName = fileTest + "nn8\\errorbyweighttraining.dat";
            Network nn = Network.Load(fileTest + "nn8\\network.nn");
            List<string> file = new List<string>();

            CancerSet cset = new CancerSet();
            cset.Load();

            for (double x = -4; x < 4; x += 0.1, nn.GetConnection(2, 2, 0).Weight = x)
                for (double y = -4; y < 4; y += 0.1, nn.GetConnection(2, 1, 0).Weight = y)
                {
                    double error = 0;
                    foreach (DataPoint dp in cset)
                    {
                        nn.FeedForward(dp.Input);
                        error += Math.Pow(dp.Desired[0] - nn.Output[0], 2) / 2;
                    }

                    file.Add(x.ToString() + " " + y.ToString() + " " + error.ToString());

                }
            System.IO.File.WriteAllLines(fileName, file);*/
        }

        ///commentted out to prevent problems from analysis of unconstructed networks
        /*
        /// <summary>
        /// The input output variance with two variables on network 8
        /// </summary>
        /// <param name="args"></param>
        public static void MainInputOutputVairence(string[] args)
        {


            string fileName = fileTest + "nn8\\inputOuputData";
            Network nn = Network.Load(fileTest + "nn8\\network.nn");

            //make 4 level surfaces
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Surface " + i);
                List<string> file = new List<string>();
                double v = i * 1.67;

                for (double x = 0; x < 10; x += 0.1)
                    for (double y = 0; y < 10; y += 0.1)
                    {
                        double[] values = new double[]
                        {
                            v, v, v, v, x, v, y, v, v 
                        };

                        nn.FeedForward(values);
                        double output = nn.Output[0];

                        file.Add(x.ToString() + " " + y.ToString() + " " + output.ToString());
                    }

                System.IO.File.WriteAllLines(fileName + i.ToString() + ".dat", file);

            }
        }


        /// <summary>
        /// The  network weights outputted
        /// </summary>
        /// <param name="args"></param>
        public static void MainNetworkWeights(string[] args)
        {
            List<string> file = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                Network nn = Network.Load(fileTest + "nn" + i + "\\network.nn");

                double[] weights = nn.GetWeights();
                for (int ix = 0; ix < nn.GetWeights().Length; ix++)
                    file.Add((i).ToString() + " " + (ix).ToString() + " " + (weights[ix]).ToString());

            }
            System.IO.File.WriteAllLines(fileTest + "weights.dat", file.ToArray());

        }

        /// <summary>
        /// Runs the analysis on error again.
        /// </summary>
        /// <param name="args"></param>
        public static void MainAnalysis(string[] args)
        {

            CancerSet cset = new CancerSet();
            cset.Load();
            double[][] error = new double[10][];

            for (int i = 0; i < 10; i++)
            {
                Network nn = Network.Load(fileTest + "nn" + i + "\\network.nn");

                error[i] = new double[cset.Count];
                double TotalError = 0;
                List<string> file = new List<string>();


                for (int set = 0; set < cset.Count; set++)
                {
                    nn.FeedForward(cset[set].Input);
                    error[i][set] = Math.Pow(Step(nn.Output[0]) - cset[set].Desired[0], 2) / 2;
                    TotalError += error[i][set];
                    file.Add(set + " " + error[i][set]);
                }

                file.Add((TotalError / cset.Count).ToString());
                System.IO.File.WriteAllLines(fileTest + "nn" + i + "\\analysis.txt", file.ToArray());
            }

            List<string> full = new List<string>();
            double fullError = 0;
            for (int i = 0; i < cset.Count; i++)
            {
                double errorinst = 0;

                for (int nn = 0; nn < 10; nn++)
                {
                    errorinst += error[nn][i];
                }
                errorinst /= 10;
                fullError += errorinst;
                full.Add(i + " " + errorinst.ToString());
            }

            fullError /= cset.Count;
            full.Add(fullError.ToString());
            System.IO.File.WriteAllLines(fileTest + "analysis.txt", full);


        }
        */

        /// <summary>
        /// Trains the neural network given outputs
        /// </summary>
        /// <param name="args"></param>
        private static void MainTrain(string[] args)
        {


            WDBCSet wset = new WDBCSet();
            wset.Load();


            Console.WriteLine("Thread " + " running");
            Network nn = new Network(new int[] { 10, 15, 6, 1 },
                new Sigmoid[] {Sigmoid.None, Sigmoid.HyperbolicTangent, Sigmoid.HyperbolicTangent,
                Sigmoid.HyperbolicTangent});

            Trainer cancerTrainer = new Trainer(nn, wset);

            string setString = fileTest + "nn9";
            if ((cancerTrainer.Train(40000000, 6, 0.04, 0.2, false)))
                nn.Save(setString + "\\network.nn");

            //Save error history
            string[] filedata = new string[cancerTrainer.ErrorHistory.Count];
            for (int i = 0; i < filedata.Length; i++)
                filedata[i] = i.ToString() + "\t" + cancerTrainer.ErrorHistory[i].ToString();

            File.WriteAllLines(setString + "\\convergance.dat", filedata);
            Console.WriteLine("Thread " + " finished");


        }
    }
}