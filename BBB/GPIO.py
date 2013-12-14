# -*- coding: utf-8 -*-
import Adafruit_BBIO.GPIO as IO

import time
class GPIO:
	pin=0
	def __init__(self,valor):
		self.pin = valor
	def setSalida(self,valor):
		IO.setup("P8_" + str(self.pin), IO.OUT)
		if (valor=="1"):
			IO.output("P8_" + str(self.pin), IO.HIGH)
		else:
			IO.output("P8_" + str(self.pin), IO.LOW)

