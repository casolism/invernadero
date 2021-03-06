#!/usr/bin/python
#!/usr/lib/python2.7/site-packages
import time
import datetime
import xively

class XivelyClass:
	error = 0
	def __init__(self):
		self.api= xively.XivelyAPIClient('F73tcNeJx3OZBUt3OXhqL4JpmeRXlcFQ53t4xYufQ1fV7dsR')
		self.feed = self.api.feeds.get(1449620157)
		print('API de xively inicializada!')
	def GuardaTemperatura(self,Temp):
		V = Temp
		now = datetime.datetime.utcnow()
		self.feed.datastreams = [xively.Datastream(id='Temperatura',current_value=V,at=now)]
		try:
			self.feed.update()
		except:
			self.error = 1
		#print('xively: Temperatura registrada')
	def GuardaIluminacion(self,Iluminacion):
		V = Iluminacion
		now = datetime.datetime.utcnow()
		self.feed.datastreams = [xively.Datastream(id='Iluminacion',current_value=V,at=now)]
		try:
			self.feed.update()
		except:
			error = 1
		#print('xively: Iluminacion registrada')

