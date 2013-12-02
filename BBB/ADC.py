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
		valor = AD.read("P9_" + str(self.pin))*5
		return valor
	def getIluminacion(self):
		valor = AD.read("P9_" + str(self.pin))*30
		return valor
