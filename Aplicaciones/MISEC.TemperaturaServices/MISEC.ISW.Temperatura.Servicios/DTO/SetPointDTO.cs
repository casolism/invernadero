using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISEC.ISW.Temperatura.Servicios.DTO
{
    public class SetPointDTO
    {
        public int IdSetPoint {get; set;}
        public int IdTipo { get; set; }
        public double limiteMin { get; set; }
        public double limiteMax { get; set; }
        public string Estado { get; set; }
    }
}