import threading

class Timer:
	enabled=False
	def __init__(self,Servidor):
		self.Servidor = Servidor
	def Start(self):
		threading.Timer(5.0, self.On).start()
	def On(self):
		if (self.enabled):
			print "Encender Ventilador"
		else:
			print "On - Timer desactivado"
		threading.Timer(1.0, self.Off).start()
	def Off(self):
		if (self.enabled):
			print "Apagar Ventilador"
		else:
			print "Off - Timer desactivado"
		threading.Timer(5.0, self.On).start()
	def Enable(self):
		self.enabled=True
	def Disable(self):
		self.enabled=False

