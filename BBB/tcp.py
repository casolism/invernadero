import socket
import time
import threading

class TCPServer:
	HOST = ''       # Symbolic name meaning all available interfaces
	PORT = 6342     # Arbitrary non-privileged port
	data = "N"		# Inicialmente data debe leer datos de la red
	s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
	status="Desconectado"
	Temp = 0
	Ilum = 0
	def __init__(self):
		print "Esperando conexion..."
		self.status = "Esperando conexion"
		self.s.bind((self.HOST, self.PORT))
		self.s.listen(1)
		self.conn, self.addr = self.s.accept()
		print 'Connected by', self.addr
		self.conn.settimeout(0.3)
		self.status = "Conectado"
	def Run(self):
		try:
			data = self.conn.recv(32)
			if data.find("STOP")>=0: # Recibe orden de detenerse desde TCP
				self.status = "Desconectado"
				self.conn.close()
			else: # Recibio informacion por TCP
				if (data!="."):
					print(data)
		except socket.error:
			data = "."
		if (self.status=="Conectado"):
			self.conn.sendall(str(self.Temp) + "|" + str(self.Ilum)) # Envia informacion por TCP
			threading.Timer(1.0, self.Run).start()
