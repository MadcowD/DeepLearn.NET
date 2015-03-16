'''
Included all connections in a single file again for quick importation into projects
'''
from connection import Connection
import math
class RPROPMinusConnection(Connection):
    def __init__(self, anteriorNeuron, posteriorNeuron):
        super(RPROPMinusConnection, self).__init__(anteriorNeuron, posteriorNeuron)
        self.lastGradient = 0
        self.lastStep = 0
        self.step = Connection.stepInitial
    def updateWeight(self, learningParameters):
        comparison = self.lastGradient * self.getGradient()
        deltaWeight = -math.copysign(self.step, self.getGradient())
        if(comparison > 0):
            self.step = min(self.lastStep * Connection.stepIncrease, Connection.stepMax)
            self.weight += deltaWeight
            self.lastGradient = self.getGradient()
        elif (comparison < 0):
            self.step = max(self.lastStep * Connection.stepDecrease, Connection.stepMin)
            self.lastGradient = 0
        elif (comparison == 0):
            self.weight += deltaWeight
            self.lastGradient = self.getGradient()
        self.lastStep = self.step

    def learningParameterCount(self):
        return 0
class ALRConnection(Connection):
    def __init__(self, anteriorNeuron, posteriorNeuron):
        super(ALRConnection, self).__init__(anteriorNeuron, posteriorNeuron)
        self.lastGradient = 0
        self.lastStep = 0
        self.step = Connection.stepInitial
    def updateWeight(self, learningParameters):
        comparison = self.lastGradient * self.getGradient()
        deltaWeight = -math.copysign(self.step, self.getGradient())
        if(comparison > 0):
            self.step = min(self.lastStep * (min(abs(self.getGradient()), 50) * 0.01+1.2), Connection.stepMax)
            self.weight += deltaWeight
            self.lastGradient = self.getGradient()
        elif (comparison < 0):
            self.step = max(self.lastStep * Connection.stepDecrease, Connection.stepMin)
            self.lastGradient = 0
        elif (comparison == 0):
            self.weight += deltaWeight
            self.lastGradient = self.getGradient()
        self.lastStep = self.step
    def learningParameterCount(self):
        return 0
class BPROPConnection(Connection):
    def __init__(self, anteriorNeuron, posteriorNeuron):
        super(BPROPConnection, self).__init__(anteriorNeuron, posteriorNeuron)
        self.lastDeltaWeight = 0
    def updateWeight(self, learningParameters):
        learningRate = learningParameters[0]
        momentum = learningParameters[1]
        deltaWeight = -self.getGradient()*learningRate+momentum*self.lastDeltaWeight
        self.weight += deltaWeight
        self.lastDeltaWeight = deltaWeight
    def learningParameterCount(self):
        return 2