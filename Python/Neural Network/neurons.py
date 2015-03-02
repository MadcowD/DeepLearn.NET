'''
Because of the brevity of each class, I included everything in a single file to
make imports extremely easy
'''

from neuron import Neuron
from sigmoid import Sigmoid
class InputNeuron(Neuron):
    def getOutput(self):
        self.output = self.getNet()
        super(self).getOutput()
    #main point is to not do anything.
    def updateOutput(self):
        pass

class OutputNeuron(Neuron):
    def updateError(self, activation, desired):
        self.error = (self.output-desired)*activation.function(self.net)

class BiasNeuron(Neuron):
    def updateOutput(self, activation):
        self.net = 1
        self.error = 1
    def getOutput(self):
        return 1
    