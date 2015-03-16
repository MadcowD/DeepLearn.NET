class Trainer:
    def __init__(self, network, trainingSet, testingSet, online=True):
        self.trainingSet = trainingSet
        self.network = network
        self.testingSet = testingSet
        self.online = online
        self.errorHistory = list()
    def train(self, epochs, minimumError, nudging=False, learningParameters):
        self.errorHistory = list()
        epoch = 0
        error = 0
        while(True):
            epoch+=1
            if(self.online):
                error = 0
                for dp in self.trainingSet:
                    error += self.network.train(dp,learningParameters)
            else:
                error = self.network.train(self.trainingSet, learningParameters)
            self.errorHistory.append(error)
            #TODO nudging
            #if nudging and 
            if(not(epoch<epochs and error > minimumError)):
                break
    