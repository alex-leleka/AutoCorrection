import sys
print ("Hello world")
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







