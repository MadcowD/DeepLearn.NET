﻿namespace NeuralNetwork.Neurons
 {
     /// <summary>
     /// Type specific implementation of the neuron class for output neurons.
     /// </summary>
     public class BiasNeuron : Neuron
     {
         /// <summary>
         /// Updates the output of the bias neuron. Always returns one.
         /// </summary>
         public override void UpdateOutput(Sigmoid activation)
         {
             Net = 0;
             Error = 0;
             Output = 0;
         }
     }
 }