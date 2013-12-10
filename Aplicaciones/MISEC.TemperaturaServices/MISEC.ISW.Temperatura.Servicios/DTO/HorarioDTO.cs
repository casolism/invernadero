using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISEC.ISW.Temperatura.Servicios.DTO
{
    public class HorarioDTO
    {
        public int IdHorario{ get; set; }
        public string Descripcion{ get; set; }
        public DateTime HoraInicio{ get; set; }
        public DateTime HoraFin{ get; set; }
        public string TemporadaDescripcion{ get; set; }
    }
}