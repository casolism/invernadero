using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISEC.ISW.Temperatura.Servicios.DTO
{
    public class SensorDTO
    {
        public int IdSensor { get; set; }
        public double Valor { get; set; }
        public DateTime Fecha { get; set; }
        public int SetPoint { get; set; }
        public string Variable { get; set; }
        public string SetPointEstado { get; set; }
    }
}