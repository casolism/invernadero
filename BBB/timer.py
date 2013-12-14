import threading
from GPIO import GPIO
class Timer:
	Ventilador = GPIO(12)
	enabled=False
	def __init__(self,Servidor):
		self.Servidor = Servidor
	def Start(self):
		threading.Timer(60.0, self.On).start()
	def On(self):
		if (self.enabled):
			print "Encender Ventilador"
			self.Ventilador.setSalida("1")
		else:
			print "On - Timer desactivado"
		threading.Timer(15.0, self.Off).start()
	def Off(self):
		if (self.enabled):
			print "Apagar Ventilador"
			self.Ventilador.setSalida("0")
		else:
			print "Off - Timer desactivado"
		threading.Timer(60.0, self.On).start()
	def Enable(self):
		self.enabled=True
	def Disable(self):
		self.enabled=False

