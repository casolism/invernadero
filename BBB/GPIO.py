# -*- coding: utf-8 -*-
import Adafruit_BBIO.GPIO as IO

import time
class GPIO:
	pinEntrada = 11
	pinSalida = 12 
	def setSalida(self,valor):
		IO.setup("P8_" + str(self.pinSalida), IO.OUT)
		if (valor=="1"):
			IO.output("P8_" + str(self.pinSalida), IO.HIGH)
		else:
			IO.output("P8_" + str(self.pinSalida), IO.LOW)
	def getEntrada(self):
		IO.setup("P8_" + str(self.pinEntrada), IO.IN)
		return str(IO.input("P8_" + str(self.pinEntrada)))
