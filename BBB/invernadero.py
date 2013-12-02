#!/usr/bin/python
from mail import Mail
from xivelyClass import XivelyClass
from ADC import ADC

class Invernadero:
	Temp = ADC(39)
	Ilum = ADC(40)
	destinatarioCorreo = "ca_solis@hotmail.com"
	correo = Mail()
	cloud = XivelyClass()
	def test(self):
		self.correo.sendMail(str(self.Temp.getTemperatura()),destinatarioCorreo)
		self.cloud.GuardaTemperatura(self.Temp.getTemperatura())
		self.cloud.GuardaIluminacion(self.Ilum.getIluminacion())
