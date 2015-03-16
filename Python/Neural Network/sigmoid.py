import math
class Sigmoid():
	def __init__(self, function, derivative):
		self.function = function
		self.derivative = derivative
	@staticmethod
	def none():
		return Sigmoid(lambda x: 0, lambda x: 0)
	@staticmethod
	def hyperbolicTangent():
		return Sigmoid(lambda x: math.tanh(x), lambda x: 1-math.tanh(x)**2)
	@staticmethod
	def logistic():
		return Sigmoid(lambda x: 1/(1+math.exp(-x)), lambda x: math.exp(x) / (1 + math.exp(x))**2)

