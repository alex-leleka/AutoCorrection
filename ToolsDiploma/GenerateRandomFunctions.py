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
inputbitsCount = 5 # integer > 0
outputbitsCount = 1 # integer > 0
numberoffunctionstogenerate = 10
filename = "randomfunction"
# optinal arguent
genSpeed = 1 # integer > 0 

# generate new boolean function

m = GenerationManager(inputbitsCount, outputbitsCount, numberoffunctionstogenerate, filename)
m.run()