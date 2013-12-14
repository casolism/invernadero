# -*- coding: utf-8 -*-
import Adafruit_BBIO.ADC as AD
import time

class ADC:
	pin = 0
	def __init__(self,pin):
		self.pin = pin
		AD.setup()
		print("ADC pin " + str(pin) + " iniciado")
	def getTemperatura(self):
		c = 0
		suma = 0			
		while 1:
			valor = AD.read("P9_" + str(self.pin))
			if (valor>.001):
				valor = valor*180
				suma = suma + valor
				c = c + 1
				if (c==10):
					break;
		return suma / c;
	def getIluminacion(self):
		while 1:
			valor = AD.read("P9_" + str(self.pin))
			if (valor>.001):
				valor = 100 - valor*100
				break;
		return valor
