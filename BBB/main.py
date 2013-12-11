#from invernadero import Invernadero
import time
from timer import Timer
from tcp import TCPServer
svr = TCPServer()
svr.Run()
t = Timer(svr)
t.Start()
#InvernaderoMISEC = Invernadero()
#InvernaderoMISEC.test()
time.sleep(15)
svr.Temp=10
svr.Ilum=150
t.Enable()
time.sleep(20)
t.Disable()    
