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
	LowTemp=0
	HighTemp=0
	LowIlum=0
	HighIlum=0
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
			if (self.Temp<self.svr.SPTemp-HistT):
				self.LowTemp=1
			else:
				self.LowTemp=0							
			if (self.Temp>self.svr.SPTemp+HistT):
				self.HighTemp=1
			else:
				self.HighTemp=0
			if (self.Ilum<self.svr.SPIlum-HistI):
				self.LowIlum=1
			else:			
				self.LowIlum=0
			if (self.Ilum>self.svr.SPIlum+HistI):
				self.HighIlum=1
			else:
				self.HighIlum=0
		if (self.LowTemp==1 or self.HighTemp==1):
			self.t.Disable()
		else:
			self.t.Enable()
	def RevisaStatusDispositivos(self):
		if (self.LowTemp==1 && self.statusCalentador=="Apagado")
			self.statusCalentador="Encendido"
			print "Encdiende calentador"
		if (self.HighTemp==1 && self.statusVentilador=="Apagado")
			self.statusVentilador="Encendido"
			print "Enciende ventilador"
		if (self.LowIlum==1 && self.statusLuz=="Apagado")
			self.statusLuz="Encendido"
			print "Enciende luz"
		if (self.LowTemp==0 && self.statusCalentador=="Encendido")
			self.statusCalentador="Apagado"
			print "Apaga calentador"
		if (self.HighTemp==0 && self.statusVentilador=="Encendido")
			self.statusVentilador="Apagado"
			print "Apaga ventilador"
		if (self.LowIlum==0 && self.statusLuz=="Encendido")
			self.statusLuz="Apagado"
			print "Apaga luz"
		
