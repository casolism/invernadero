#!/usr/bin/python
#!/usr/lib/python2.7
#!/usr/lib/python2.7/email

import smtplib
from email.mime.text import MIMEText
class Mail:
	def sendMail(self,Temperatura, to):
		myAddress ='carlos.solis.madrigal@gmail.com'
		body = "Estimado administrador\n\nLa temperatura en el \
						invernadero actualmente esta excedida y tiene un valor \
						de " + Temperatura + " Grados Centigrados\n\n \
						Favor de realizar las acciones correspondientes \
						\n\nAttentamente\n\nMISEC Invernaderos"
		msg = MIMEText(body)
		msg['Subject'] = "MISEC [Invernadero] - Temperatura excedida"
		msg['From'] = myAddress
		msg['Reply-to'] = myAddress
		msg['To'] = to
		server = smtplib.SMTP('smtp.gmail.com',587)
		server.starttls()
		server.login(myAddress,'casm1218')
		server.sendmail(myAddress,to,msg.as_string())
		print('Atencion: Correo por exceso de temperatura enviado a ' + to )
		server.quit()
