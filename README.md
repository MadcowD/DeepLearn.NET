ISEFNeuralNetwork - Breast Cancer Numerical
=================

Abstract
The challenge of diagnosing any type of cancer is that the no single test can accurately succeed. Diagnostic testing is essential to successfully evaluate the health of an individual and determine whether or not the symptoms are caused by cancer or another disease. Diagnostic imaging is a useful technique to produce an internal picture of the body in order to analyze its structure. However, it is still up to the medical professional to successful analyze the images and determine whether the individual has cancer. While analyzing the data taken from the imaging with neural networks, the analysis can be made more efficient, but also one can minimize the error that occurs during diagnostic testing.
The purpose of the project is to implement a successful neural network with back propagation to analyze a breast cancer numerical dataset. It also evaluates the efficiency or the network as it is influenced by different conditions. The efficiency is gauged by the error percentages accumulated by the network. Furthermore, statistical analysis is applied to the network in order to analyze the effectiveness of the neural network.
The project showed that despite the adaptability of the neural network, it is still unable to reduce the error completely down to zero percent. Thus while neural networks may be useful, they cannot be relied on completely. However, there is a tradeoff between the error of the network and the flexibility of the network. While the error has the potential to be removed from the testing of the neural network, the network would be over fitted to the dataset it is being trained and tested on so that it would lose its ability to successful analyze any other similar yet not exact forms of data.
Background Research
	Neural networks take a different approach to problem solving than conventional algorithmic problem solving. Algorithmic problem solving requires a fixed set of actions to determine a solution, and if absent, an algorithmic function for such a problem is impossible, restricting the problem solving capabilities of conventional computing.
Neural networks, in contrast, learn by example and cannot be programmed to perform a specific task, allowing a computer system to approximate an otherwise unknown function. Neural networks, as a result, are able to perform adaptive learning, self-organization, real time operation, as well as fault tolerance. The reliability of a neural network fails to match that of a conventional algorithm, as operation under certain conditions can be unpredictable. Often, to combat uncertainties in the neural network and the limitations of an algorithmic approach, the two problem solving methods are combing to perform a task at a high efficiency. 
	Neural networks are a form of artificial intelligence that derive from the structure of biological nervous systems and data processing methods within those systems. Both the brain and neural networks are composed of a large number of processing elements, referred to as neurons, which are interconnected by weights (in artificial neural networks) or axons and dendrites (in biological neural networks), which work together with the neurons to solve problems. Artificial networks and an organism's nervous system learn by example. These two structures update their weights or connections in response to inputs and whatever result is desired.
	Whereas artificial networks are typically data intensive and thus limited to several hundred units, biological neurons can consist of 10,000 individual inputs, immensely more complex. The complexity of the existing neural network is limited by the computing power of the computers or artificial systems in place today.

	To account for the lack of an algorithm, neural networks attempt to discern patterns from a dataset. Although any dataset is able to work, a larger dataset is typically required to allow a more adaptive nature for the neural network. The neural network takes in a set of inputs and passes on the values through a series of numbers termed “weights”, which then pass on an altered value to neurons in subsequent layers (either hidden or output). Once the network outputs values, the results are compared to the desired output, and the network's weights are adjusted accordingly, through the method of back-propagation.    
	The feed forward neural network is the simplest type of an artificial neural network utilized. Information moves in a single direction, forward, from the input nodes, through hidden nodes (if any) and to output nodes. There are no cycles or loops in the network. Feed forward networks are the most popular and widely used function-modeling structures that reflect a dataset. 
Advantages of a Neural Network

1.	Adaptive learning: An ability to learn how to do tasks based on the data given for training or initial experience.
2.	Self-Organization: A neural network can create its own organization or representation of the information it receives during learning time.
3.	Real Time Operation: Neural network computations may be carried out in parallel, and special hardware devices are being designed and manufactured which take advantage of this capability.
4.	Fault Tolerance via Redundant Information Coding: Partial destruction of a network leads to the corresponding degradation of performance. However, some network capabilities may be retained even with major network damage


Algorithm

To begin processing data through the neurons, an algorithm trains the multi-layer feed forward network by gradient descent to approximate an unknown function. The overall gradient with respect to the entire training set is the sum of the gradients for each pattern. 

Definitions:
the error signal for unit j:	
	 *
the (negative) gradient for weight wij:	
	 *
the set of nodes anterior to unit i:	
	 *
the set of nodes posterior to unit j:	
	 *
Expand the gradient into two factors by use of the chain rule:
 
 
 .
Forward activation: The activity of the input units is determined by the network's external input. For all other units, the activity is propagated forward:
 
The activity of all its anterior nodes must be known. 

Calculating output error
Using the sum-squared loss,
 
the error for output unit o is simply
 
Error back propagation 
For hidden units, we must propagate the error back from the output nodes. Using the chain rule, expand the error of a hidden unit in terms of its posterior nodes:
 '
 
 
 
 
In order to calculate the error for unit j, we must first know the error of all its posterior nodes.
The equation for the change in the weight relative to the error is including momentum is given by the equation. 
 
where μ is the momentum and t is the epoch

Nudging

Nudging was implemented into the network. Once the difference between ten epochs was less than .0001, then the weights randomly adjust based on the Gaussian distribution. The rationale is that once the change becomes so small, then the network has become stuck in a local minimum without the ability to escape and also has not converged yet. Thus, in order to converge at the predetermined minimum error value, nudging must occur to distribute the weights randomly to try to reach the minimum.  
Inputs of the Data Points
1. Clump Thickness                 1 - 10
2. Uniformity of Cell Size       1 - 10
3. Uniformity of Cell Shape    1 - 10
4. Marginal Adhesion              1 - 10
5. Single Epithelial Cell Size   1 - 10
6. Bare Nuclei                          1 - 10
7. Bland Chromatin                 1 - 10
8. Normal Nucleoli                  1 - 10
9. Mitoses                                1 - 10

1.	Clump Thickness: Benign cells tend to be group in a monolayer, while cancerous cells are often grouped in a multilayer.

2.	Uniformity of Cell Size
3.	Uniformity of Cell Shape
Cancer cells tend to vary drastically in size and shape, thus a lower uniformity correlates with a higher possibility of cancer cells.

4.	Marginal Adhesion: Cancer cells tend not to stick to one another as well as normal cells, so less adhesion correlates to a higher malignancy.

5.	Single epithelial Cell Size: The size is related to uniformity, but enlarged epithelial cells may be malignant. 

6.	Bare Nuclei: It is an index of nuclei not surrounded by a cell, which is present in malignant tumors. 

7.	Bland Chromatin: Uniformity of “texture” appears in benign cells, while malignant tumors are typically coarse-textured.  A lower number corresponds to more unity.

8.	Normal Nucleoli: The rate of occurrence of normal nucleoli; abnormal nucleoli indicate possible mutated DNA, thus possible genetic expression for cancer reproduction. Thus, the smaller the rate of occurrence, the larger the chance of malignancy becomes. 

9.	Mitoses: Cancer cells tend to replicate faster which contributes to a tumor and leads to increased potential in harmful consequences. Thus, a set of cells with a higher rate of mitoses has an increased chance of being malignant.

The dataset used had 9 input attributes, each from a range of 1 to 10. There were a total of 699 data points. However, 16 of the points had inconsistencies where a question mark stood in place of a number. The 16 data points thus were excluded from both the training and the testing of the neural network.
While the data had the output of 2 for benign and 4 for malignant, during the testing of the network these numbers were changed to 0 and 1 for benign and malignant respectively. This is because the logistic function can only output from a range of -1 to 1. For the actual dataset, 65.5% were benign and the other 35.5 percent were malignant. 
The source also claimed that there is also a 5% discrepancy in the dataset.
Data processing

The training dataset was altered first by randomly excluding 68 data points, or 10% percent, of the 683 original dataset. 10 different neural networks were created by training them on the training dataset and their weights were then saved. These sets of weights are radically different from each other because of the existence of local minima, random weight space, and a preset convergence at .004% error. 

The 68 data points excluded were used as the testing data points. These data points were independently ran through the networks and then the probability of malignancy was recorded. A step function was then implemented to heavily weight the results of the network towards the malignant output. If the output was greater than .05 then the network would automatically consider the output for that data point to be malignant. 

Then, the output of the network was compared to the desired actual output. The average error for a single specific data point over all 10 networks next. Furthermore the average error for the total network is calculated by the average of the error for each data point. These calculations result in the total error of the network. 

The entire equation is given by,

 
Conclusion
The final total error calculated for the neural network is 3.2%. However, one must consider that the error in the original dataset was 5% indicating that the network was able to adapt to the error, yet not to 100% accuracy. Despite the possibility of imprecision with the network, an algorithmic model would be extremely difficult and time consuming to create, thus the approximation allows an efficient solution. The random initial weight values created difficulties in the code processing, as repeated generations of networks varied significantly. For the future, a heuristic determination of  the starting weights would be more desirable in creating the network. The gradient method used to determine the values of the weights is not very accurate because it locates only local minimum as the threshold error value is set at .44%, where instead finding the global error minimum would be more accurate. However, the problem with finding global minimum is that the network might over fit the data, causing it to only recognize the training dataset and lose its adaptive nature to recognize other potential data points, rendering it useless to model complex functions.
Although establishing potential for inaccuracy, the step function is an extremely important part of the data processing to recognize potential outliers. By weighting the output significantly, the network also becomes more accurate. Because the field the network is being applied to allows no room for error, minimizing the amount of error received is more beneficial. Thus the step function favored a false positive to ensure a diagnosis doesn’t result in an unnecessary death, as is apparent in breast cancer diagnosis.
Finally, the 10 networks differed greatly, caused by the random initialized weight values. Even though the values are centered near zero for the range, they are still randomly placed according to the Gaussian distribution, causing a variance in convergence. The network also has many potential uses. It is not only applicable to breast cancer but any dataset that is or isn’t able to be modeled by conventional method. The project allowed an application to utilized a generated neural network to quickly and accurately diagnose cases of potential breast cancer.


Bibliography

http://cancer.stanford.edu/information/cancerDiagnosis/

http://www.cs.stir.ac.uk/~lss/NNIntro/InvSlides.html 

http://www.doc.ic.ac.uk/~nd/surprise_96/journal/vol4/cs11/report.html 

http://www.grappa.univ-lille3.fr/~torre/Recherche/Experiments/Datasets/#breast-cancer 

http://www.mdanderson.org/patient-and-cancer-information/cancer-information/cancer-topics/detection-and-diagnosis/diagnostic-tests/index.html

http://www.willamette.edu/~gorr/classes/cs449/backprop.html

William H. Wolberg and O.L. Mangasarian: "Multisurface method of 
     pattern separation for medical diagnosis applied to breast cytology", 
     Proceedings of the National Academy of Sciences, U.S.A., Volume 87, 
     December 1990, pp 9193-9196.



