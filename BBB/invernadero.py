#!/usr/bin/python
from mail import Mail
from xivelyClass import XivelyClass
from ADC import ADC

from timer import Timer
from tcp import TCPServer

class Invernadero:
	ADCTemp = ADC(39)
	ADCIlum = ADC(40)
	Temp = 0
	Ilum = 0
	HistT = 2
	HistI = 1
	stTemp="Normal"
	stIlum="Normal"
	destinatarioCorreo = "ca_solis@hotmail.com"
	correo = Mail()
	statusVentilador="Apagado"
	statusCalentador="Apagado"
	statusLuz="Apagado"
	#cloud = XivelyClass()

	def __init__(self):
		self.svr = TCPServer()
		self.svr.Run()
		self.t = Timer(self.svr)
		self.t.Start()
		self.t.Enable()
	def test(self):
		self.correo.sendMail(str(self.ADCTemp.getTemperatura()),destinatarioCorreo)
		self.cloud.GuardaTemperatura(self.ADCTemp.getTemperatura())
		self.cloud.GuardaIluminacion(self.ADCIlum.getIluminacion())

	def Sensar(self):
		self.Temp = self.ADCTemp.getTemperatura()
		self.Ilum =	self.ADCIlum.getIluminacion()
		self.svr.Temp = self.Temp
		self.svr.Ilum = self.Ilum
	def ComparaSetPoints(self):
		if (self.svr.statusSetPoint=="Establecido"):
			if (self.Temp<self.svr.SPTemp-self.HistT):
				self.stTemp="Low"
				#print "LOW TEMP " + str(self.Temp)
			else:
				if (self.Temp>self.svr.SPTemp+self.HistT):
					self.stTemp="High"
					#print "HIGH TEMP" + str(self.Temp)
				else:
					self.stTemp="Normal"
			if (self.Ilum<self.svr.SPIlum-self.HistI):
				self.stIlum="Low"
				#print "Low light"
			else:			
				if (self.Ilum>self.svr.SPIlum+self.HistI):
					self.stIlum="High"
				else:
					self.stIlum="Normal"
		if (self.stTemp!="Normal"):
			self.t.Disable()
		else:
			self.t.Enable()
	def RevisaStatusDispositivos(self):
		if (self.stTemp=="Normal" and self.statusCalentador=="Encendido"):
			self.statusCalentador="Apagado"
			print "++++++++++++++++++++ Apaga calentador +++++++++++++++++++++++"
		if (self.stTemp=="Normal" and self.statusVentilador=="Encendido"):
			self.statusVentilador="Apagado"
			print "++++++++++++++++++++ Apaga ventilador +++++++++++++++++++++++"
		if (self.stIlum=="Normal" and self.statusLuz=="Encendido"):
			self.statusLuz="Apagado"
			print "++++++++++++++++++++ Apaga luz +++++++++++++++++++++++"
		if (self.stTemp=="Low" and self.statusCalentador=="Apagado"):
			self.statusCalentador="Encendido"
			self.statusVentilador="Apagado"
			print "++++++++++++++++++++ Enciende calentador +++++++++++++++++++++++"
		if (self.stTemp=="High" and self.statusVentilador=="Apagado"):
			self.statusVentilador="Encendido"
			self.statusCalentador="Apagado"
			print "++++++++++++++++++++ Enciende ventilador ++++++++++++++++++++"
		if (self.stIlum=="Low" and self.statusLuz=="Apagado"):
			self.statusLuz="Encendido"
			print "++++++++++++++++++++ Enciende luz ++++++++++++++++++++"
		if (self.stIlum=="High" and self.statusLuz=="Encendido"):
			self.statusLuz="Apagado"
			print "++++++++++++++++++++ Apaga luz ++++++++++++++++++++"
		
