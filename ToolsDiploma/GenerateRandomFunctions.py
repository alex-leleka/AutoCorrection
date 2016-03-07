import sys
print ("Generate random Boolean functions and save them in txt file")
print (sys.version)
# print autocorrecting error vectors for adder

class TableElement:

	def __init__(self, op1, op2):
		self.op1 = op1
		self.op2 = op2
		self.result = op1 + op2
		self.errList = []

	def adderrorvector(self, err1, err2):
		# skip obvious case
		#if err1 == err2: return
		self.errList.append((err1, err2))
		#print(err1 , err2)

	def GetOperands(self, operandbitsCount):
		str = bin(self.op1)[2:].zfill(operandbitsCount)
		str = str + bin(self.op2)[2:].zfill(operandbitsCount)
		return str

	def GetResult(self, outputbitsCount):
		str = bin(self.result)[2:].zfill(outputbitsCount)
		return str

	def GetErrors(self, operandbitsCount):
		str = ''
		for (err1, err2) in self.errList:
			str = str + bin(err1)[2:].zfill(operandbitsCount)
			str = str + bin(err2)[2:].zfill(operandbitsCount)
			str = str + ' '
		return str




class Adder:
	""" Adder properties """
	def __init__(self, inputbitsCount):
		self.operandbitsCount = inputbitsCount
		self.outputbitsCount = inputbitsCount + 1
		self.table = []

	def isautocorrected(self, op1, op2, err1, err2):
		
		if err1 == 0 and err2 == 0 :
			return 0

		result = op1 + op2
		distResult = (op1 ^ err1)  + (op2 ^ err2)

		if result == distResult :
			return 1
		return 0

	def builderrvectable(self):
		opValueBorder = 1 << self.operandbitsCount
		self.table = []

		for op1 in xrange(0, opValueBorder):
			for op2 in xrange(0, opValueBorder):
				te = TableElement(op1, op2)
				for err1 in xrange(0, opValueBorder):
					for err2 in xrange(0, opValueBorder):
						if self.isautocorrected(op1, op2, err1, err2):
							te.adderrorvector(err1, err2)
				self.table.append(te)

	def printerrvectable(self):
		if not self.table:
			print ("error vector table is empty!")
			return
		for te in self.table:
			print( "|" + te.GetOperands(self.operandbitsCount) + "|" + te.GetResult(self.outputbitsCount) + "|" + te.GetErrors(self.operandbitsCount) )



add2 = Adder(2)
add2.builderrvectable()
add2.printerrvectable()

class BooleanFunction:
	""" Boolean function. Truth table stored as list. """
	def __init__(self, inputbitsCount, outputbitsCount):
		self.operandbitsCount = inputbitsCount
		self.outputbitsCount = outputbitsCount
		self.table = []

	def generatefunction(self):
		self.table = []
		linesCount = 1 << self.operandbitsCount
		for index in xrange(0, linesCount):
			self.table[index] = self.getrandomResult()

	def getrandomResult(self):
		if (6 > random.randint(1, 10)):
			return 1
		return 0

	def writetofile(self, fileVar):
		fileVar.write("# function created by GenerateRandomFunctions.py \n")
		fileVar.write("# inputbitsCount \n")
		fileVar.write(self.operandbitsCount)
		fileVar.write("\n")
		fileVar.write("# outputbitsCount \n")
		fileVar.write(self.outputbitsCount)
		fileVar.write("\n")
		for result in self.table:
			fileVar.write(result)
			fileVar.write("\n")


class GenerationManager:
	""" Creates functions and saves them on disk"""
	def __init__(self, inputbitsCount, outputbitsCount, numberoffunctionstogenerate, filename):
		self.inputbitsCount = inputbitsCount
		self.outputbitsCount = outputbitsCount
		self.numberoffunctionstogenerate = numberoffunctionstogenerate
		self.filename = filename

	def run(self):
		

# arguments 
inputbitsCount = 4 # integer > 0
outputbitsCount = 1 # integer > 0
numberoffunctionstogenerate = 10
filename = "randomfunction"
# optinal arguent
genSpeed = 1 # integer > 0 

# generate new boolean function




