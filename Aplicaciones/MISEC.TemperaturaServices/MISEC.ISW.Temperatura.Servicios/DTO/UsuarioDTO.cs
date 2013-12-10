using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISEC.ISW.Temperatura.Servicios.DTO
{
    public class UsuarioDTO
    {
        public string IdUsuario { get; set; }
        public string Password { get; set; }
        public int Nivel { get; set; }
    }
}