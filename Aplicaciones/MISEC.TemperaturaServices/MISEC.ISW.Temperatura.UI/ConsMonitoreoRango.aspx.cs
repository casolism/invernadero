using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SensorServices;

public partial class ConsMonitoreoRango : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        //Consume el servicio web para consultar la información del setpoint
        SensorServices.SensorServicesSoapClient wsInvernadero = new SensorServices.SensorServicesSoapClient();
        DateTime inicio = Convert.ToDateTime(txtInicio.Text);
        DateTime fin = Convert.ToDateTime(txtFin.Text);

        SensorDTO[] Sensor = wsInvernadero.ObtieneSensadoRango(inicio,fin);

        GridSensor.DataSource = Sensor;
        GridSensor.DataBind();
    }

    
}