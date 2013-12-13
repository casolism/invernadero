from invernadero import Invernadero
import time

InvernaderoMISEC = Invernadero()
while 1:
	InvernaderoMISEC.Sensar()
	InvernaderoMISEC.ComparaSetPoints()
	time.sleep(0.001)
