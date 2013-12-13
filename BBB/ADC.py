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
		while 1:
			valor = AD.read("P9_" + str(self.pin))*25
			if (valor>.001):
				break;
		return valor
	def getIluminacion(self):
		while 1:
			valor = AD.read("P9_" + str(self.pin))*8
			if (valor>.001):
				break;
		return valor
