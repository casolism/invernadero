from ADC import ADC
from flask import Flask, render_template
app=Flask(__name__) 
import datetime 
@app.route("/") 
def index():
	ADCTemp = ADC(39)
	ADCIlum = ADC(40)
	Temp = str(ADCTemp.getTemperatura())
	Ilum = str(ADCIlum.getIluminacion())
	now = datetime.datetime.now()
	timeString = now.strftime("%Y-%m-%d %H:%M")
	templateData = {'time': timeString,'Temp': Temp, 'Ilum': Ilum}
	return render_template("web.html", **templateData)
@app.route("/acercade")
def acercade():
	return render_template("acercade.html")
@app.route("/links")
def links():
	return render_template("links.html")	
if __name__ == "__main__":
	app.run(host="0.0.0.0", port=81, debug=True)
