from sigmoid import Sigmoid
class Neuron(object):
	def __init__(self):
		self.reset()
	def reset(self):
		self.error = 0
		self.net = 0
		self.output = 0
	# activation should be of type Sigmoid
	def updateOutput(self, activation):
		self.output = activation.function(self.net)
	#activation should be of type Sigmoid
	def updateError(self, activation, errorCoefficient):
		self.error = activation.derivative(self.net)*errorCoefficient
	def toString(self):

		return "Error: "+str(self.error)+"Net: "+str(self.net)+"Output"+str(self.output)
	def getID(self, network):
		for neurons in network.neurons:
			for i in range(0, len(neurons)):
				if neurons[i] == self:
					return i
		return -1
	def getOutput(self):
		return self.output
	def getInput(self):
		return self.input
	def getNet(self):
		return self.net


