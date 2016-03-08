import sys
import random
print ("Generate random Boolean functions and save them in txt file")
print (sys.version)


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


class GenerationManager:
	""" Creates functions and saves them on disk"""
	def __init__(self, inputbitsCount, outputbitsCount, numberoffunctionstogenerate, filename):
		self.inputbitsCount = inputbitsCount
		self.outputbitsCount = outputbitsCount
		self.numberoffunctionstogenerate = numberoffunctionstogenerate
		self.filename = filename

	def run(self):
		for i in range(0, self.numberoffunctionstogenerate):
			filename = self.filename + str(i) + ".txt"
			bf = BooleanFunction(self.inputbitsCount, self.outputbitsCount)
			bf.generatefunction()
			with open(filename, 'w') as outfile:
				bf.writetofile(outfile)


# arguments 
inputbitsCount = 4 # integer > 0
outputbitsCount = 1 # integer > 0
numberoffunctionstogenerate = 10
filename = "randomfunction"
# optinal arguent
genSpeed = 1 # integer > 0 

# generate new boolean function

m = GenerationManager(inputbitsCount, outputbitsCount, numberoffunctionstogenerate, filename)
m.run()

