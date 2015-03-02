import random
#list is a list of datapoints
def step(p, stepPoint):
    if (stepPoint == -1):
        return p
    if (p <= stepPoint):
        return 0
    else:
        return 1
class DataSet(list):
    def load(self):
        pass
    def shuffle(self):
        n = self.count
        while n > 1:
            n -= 1
            k = random.randint(0,n+1)
            value = self[k]
            self[k] = self[n]
            self[n] = value
        return self
    def calculateErrors(self, nn, step = -1):
        output = list()
        for d in self:
            nn.feedForward(d.input)
            sum = 0
            i = 0
            #WTF is (x,i)?!?!
            for desire in d.desired:
                i+=1
                sum+=(step(nn.Output[i], step)-i)**2
            output.append(0.5*sum)
            
        return 
    def totalError(self, nn, step = -1):
        output = 0;
        for error in self.calculateErrors(nn, step):
            output += step
        return output
    def toString(self):
        output ="\n"
        for d in self:
            output+=str(d.input)+"--->"+str(d.desired)
        return output