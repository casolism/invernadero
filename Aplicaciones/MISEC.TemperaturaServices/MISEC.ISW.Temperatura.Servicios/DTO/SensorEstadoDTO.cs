using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISEC.ISW.Temperatura.Servicios.DTO
{
    public class SensorEstadoDTO
    {
        public int IdSensor { get; set; }
        public double Sensor { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
    }
}