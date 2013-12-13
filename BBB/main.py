from invernadero import Invernadero
import time

InvernaderoMISEC = Invernadero()
while 1:
	InvernaderoMISEC.Sensar()
	InvernaderoMISEC.ComparaSetPoints()
	InvernaderoMISEC.RevisaStatusDispositivos()
	time.sleep(0.01)
