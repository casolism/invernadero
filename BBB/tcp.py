import socket
import time
import threading

class TCPServer:
	HOST = ''       # Symbolic name meaning all available interfaces
	PORT = 6342     # Arbitrary non-privileged port
	data = "N"	# Inicialmente data debe leer datos de la red
	s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
	status="Desconectado"
	Temp = 30
	Ilum = 7
	SPTemp = 0
	SPIlum = 0
	statusSetPoint = "Espera"
	def __init__(self):
		print "Esperando conexion..."
		self.status = "Esperando conexion"
		self.s.bind((self.HOST, self.PORT))
		self.s.listen(1)
		self.conn, self.addr = self.s.accept()
		print 'Connected by', self.addr
		self.conn.settimeout(0.1)
		self.status = "Conectado"
	def Run(self):
		try:
			data = self.conn.recv(32)
			if data.find("STOP")>=0: # Recibe orden de detenerse desde TCP
				self.status = "Desconectado"
				self.conn.close()
			else: # Recibio informacion por TCP
				if (data!="."):
					v = data.split('{')[1]
					self.SPTemp = float(v.split('|')[0])
					self.SPIlum = float(v.split('|')[1])
					statusSetPoint = "Establecido"
					print ("Configurar Set points T " + str(self.SPTemp))
					print ("Configurar Set points I " + str(self.SPIlum))
		except socket.error:
			data = "."
		if (self.status=="Conectado"):
			self.conn.sendall("{" + str(self.Temp) + "|" + str(self.Ilum)) # Envia informacion por TCP
			print("{" + str(self.Temp) + "|" + str(self.Ilum))
			threading.Timer(1.0, self.Run).start()
