using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISEC.ISW.Temperatura.Servicios.DTO
{
    public class BitacoraDTO
    {
        public int idBitacora { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public string Usuario;
    }
    ///Descripción de procesos:
    ///MONITOREO
    ///CONSULTAS
    ///ADMINISTRACION DE USUARIOS
    ///CONFIGURACION DE SETPOINTS
    ///
    ///Descripcion de control de setpoints:
    ///REGISTRAR
    ///ELIMINAR
    ///ACTUALIZAR
    ///ACTIVAR
    ///DESACTIVAR
    ///
}