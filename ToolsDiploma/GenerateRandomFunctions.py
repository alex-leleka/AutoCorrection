import sys
import random
print ("Generate random Boolean functions and save them in txt file")
print (sys.version)


class MyMath:

	def numTo32Str(num):
		if (num < 10):
			return str(num)
		c = chr(ord('A') + num - 10)
		return "".join(c)


	def binaryTo32(binList):
		step = 5
		i = 0
		result = ""
		while i < len(binList):
			num = 0
			for wordIndex in range(i, i+step):
				if (wordIndex >= len(binList)):
					i = wordIndex;
					break
				num = num + (binList[wordIndex] << (wordIndex - i))
			result += MyMath.numTo32Str(num)
			i = i + step
		return result


class BooleanFunction:
	""" Boolean function. Truth table stored as list. """
	def __init__(self, inputbitsCount, outputbitsCount):
		self.operandbitsCount = inputbitsCount
		self.outputbitsCount = outputbitsCount
		self.table = []

	def generatefunction(self):
		self.table = []
		linesCount = 1 << self.operandbitsCount
		for index in range(0, linesCount):
			self.table.append(self.getrandomResult())

	def getrandomResult(self):
		maxValue = (1 << self.outputbitsCount) - 1
		return random.randint(0, maxValue)

	def writetofile(self, fileVar):
		values = "# " + MyMath.binaryTo32(self.table) + "\n"
		fileVar.write(values)
		fileVar.write("# function created by GenerateRandomFunctions.py \n")
		fileVar.write("# inputbitsCount \n")
		fileVar.write(str(self.operandbitsCount))
		fileVar.write("\n")
		fileVar.write("# outputbitsCount \n")
		fileVar.write(str(self.outputbitsCount))
		fileVar.write("\n")
		fileVar.write("# truth table: \n")
		for result in self.table:
			fileVar.write(str(result))
			fileVar.write("\n")


class InputDistortion:
	""" Input distortions for logical network """
	def __init__(self, inputbitsCount, outputbitsCount):
		self.operandbitsCount = inputbitsCount
		self.outputbitsCount = outputbitsCount
		self.disttozero = []
		self.disttoone = []
		self.disttoinverse = []
		self.zeroinput = []

	def getrandom(a, b):
		return round(random.uniform(a, b), 4)

	def generatedistprob(self):
		self.disttozero = []
		self.disttoone = []
		self.disttoinverse = []
		self.zeroinput = []
		for i in range(0, self.operandbitsCount):
			self.disttozero.append(InputDistortion.getrandom(0.001, 0.01))
			self.disttoone.append(InputDistortion.getrandom(0.001, 0.01))
			self.disttoinverse.append(InputDistortion.getrandom(0.001, 0.01))
			self.zeroinput.append(InputDistortion.getrandom(0.4, 0.6))

	def writetofile(self, fileVar):
		fileVar.write("# Input Distortions created by GenerateRandomFunctions.py \n")
		fileVar.write("# inputbitsCount \n")
		fileVar.write(str(self.operandbitsCount))
		fileVar.write("\n")
		fileVar.write("# outputbitsCount \n")
		fileVar.write(str(self.outputbitsCount))
		fileVar.write("\n")

		fileVar.write("# dist to const zero : \n")
		for value in self.disttozero:
			fileVar.write(str(value) + " ")
		fileVar.write("\n")

		fileVar.write("# dist to const one : \n")
		for value in self.disttoone:
			fileVar.write(str(value) + " ")
		fileVar.write("\n")

		fileVar.write("# dist to inverse : \n")
		for value in self.disttoinverse:
			fileVar.write(str(value) + " ")
		fileVar.write("\n")

		fileVar.write("# input zero probability: \n")
		for value in self.zeroinput:
			fileVar.write(str(value) + " ")
		fileVar.write("\n")


class GenerationManager:
	""" Creates functions and saves them on disk"""
	def __init__(self, inputbitsCount, outputbitsCount, numberoffunctionstogenerate, funcfilename, numberofdistprobstogenerate = 0, distporbsfilename = "autogeninpdist"):
		self.inputbitsCount = inputbitsCount
		self.outputbitsCount = outputbitsCount
		self.numberoffunctionstogenerate = numberoffunctionstogenerate
		self.numberofdistprobstogenerate = numberofdistprobstogenerate
		self.funcfilename = funcfilename
		self.distporbsfilename = distporbsfilename + str(self.inputbitsCount) + "bit_order"

	def genfunctionsrun(self):
		for i in range(0, self.numberoffunctionstogenerate):
			filename = self.funcfilename + str(i) + ".txt"
			bf = BooleanFunction(self.inputbitsCount, self.outputbitsCount)
			bf.generatefunction()
			with open(filename, 'w') as outfile:
				bf.writetofile(outfile)

	def gendistporbsrun(self):
		for i in range(0, self.numberofdistprobstogenerate):
			filename = self.distporbsfilename + str(i) + ".txt"
			distprob = InputDistortion(self.inputbitsCount, self.outputbitsCount)
			distprob.generatedistprob()
			with open(filename, 'w') as outfile:
				distprob.writetofile(outfile)

# arguments 
inputbitsCount = 5 # integer > 0
outputbitsCount = 1 # integer > 0
numberoffunctionstogenerate = 10
filename = "randomfunction"
# optinal arguent
genSpeed = 1 # integer > 0 

# generate new boolean function

m = GenerationManager(inputbitsCount, outputbitsCount, numberoffunctionstogenerate, filename, 4)
m.genfunctionsrun()
m.gendistporbsrun()