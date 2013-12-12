using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MISEC.ISW.Temperatura.Datos;
using BLToolkit.Data.Linq;
using MISEC.ISW.Temperatura.Servicios.DTO;

namespace MISEC.ISW.Temperatura.Servicios
{
    /// <summary>
    /// Summary description for ConsultasServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ConsultasServices : System.Web.Services.WebService
    {

        [WebMethod(Description = "Obtiene un listado de registros de bitacora por Accesos")]
        public List<BitacoraDTO> ObtenerBitacoraAccesos(string UF,string Usuario, DateTime Inicio,DateTime Fin)
        {
            AutoMapper.Mapper.CreateMap<dbControl.Bitacora, BitacoraDTO>();
            List<dbControl.Bitacora> lista = new dbControlManager().Bitacora.Where(f => f.Tipo.Equals("ACCESO")).ToList();
            if (UF[0]=='1')
                lista = lista.Where(f=>f.IdUsuario.Equals(Usuario)).ToList();
            if (UF[1] == '1')
                lista= lista.Where(f=> f.Fecha >= Inicio && f.Fecha <= Fin).ToList();
            return AutoMapper.Mapper.Map<List<BitacoraDTO>>(lista);
        }

        [WebMethod(Description = "")]
        public List<BitacoraDTO> ObtenerBitacoraProcesos(string PUF, string Proceso, string Usuario, DateTime Inicio, DateTime Fin)
        {
            AutoMapper.Mapper.CreateMap<dbControl.Bitacora, BitacoraDTO>();
            List<dbControl.Bitacora> lista = new dbControlManager().Bitacora.Where(f => f.Tipo.Equals("PROCESO")).ToList();
            if (PUF[0] == '1')
                lista = lista.Where(f => f.Descripcion.Equals(Proceso)).ToList();
            if (PUF[1] == '1')
                lista = lista.Where(f => f.Usuario.Equals(Usuario)).ToList();
            if (PUF[2] == '1')
                lista = lista.Where(f => f.Fecha >= Inicio && f.Fecha <= Fin).ToList();
            return AutoMapper.Mapper.Map<List<BitacoraDTO>>(lista);
        }

        [WebMethod(Description = "Obtiene un listado de registros de bitacora por procesos")]
        public List<BitacoraDTO> ObtenerBitacoraSetPoints(string MUF, string Movimiento, string Usuario, DateTime Inicio, DateTime Fin)
        {
            AutoMapper.Mapper.CreateMap<dbControl.Bitacora, BitacoraDTO>();
            List<dbControl.Bitacora> lista = new dbControlManager().Bitacora.Where(f => f.Tipo.Equals("SETPOINT")).ToList();
            if (MUF[0] == '1')
                lista = lista.Where(f => f.Descripcion.Equals(Movimiento)).ToList();
            if (MUF[1] == '1')
                lista = lista.Where(f => f.Usuario.Equals(Usuario)).ToList();
            if (MUF[2] == '1')
                lista = lista.Where(f => f.Fecha >= Inicio && f.Fecha <= Fin).ToList();
            return AutoMapper.Mapper.Map<List<BitacoraDTO>>(lista);
        }

        [WebMethod(Description = "Obtiene un listado de registros de bitacora por Setpoints")]
        public List<SensorDTO> ObtenerSensado(string Variable, DateTime Inicio, DateTime Fin)
        {
            dbControlManager db = new dbControlManager();
            List<SensorDTO> lista = new List<SensorDTO>();
            var query =
                    from s in db.Sensor
                    from p in db.SetPoint
                    where s.IdSetPoint == p.IdSetPoint && p.Variable.Equals(Variable)
                    select new
                    {   s.IdSensor,
                        s.Valor,
                        s.Fecha,
                        p.Variable,
                        p.Estado
                    };
            foreach (var item in query)
            {
                lista.Add(new SensorDTO
                {   IdSensor = item.IdSensor,
                    Valor = item.Valor,
                    Fecha = item.Fecha,
                    Variable = item.Variable,
                    SetPointEstado = item.Estado
                });
            }
            return lista;
        }

        [WebMethod(Description = "Escribe un registro de bitacora")]
        public void EscribeBitacora(string Descripcion, string Tipo, string Usuario)
        {
            dbControlManager db = new dbControlManager();
            var idInsertado = db.Bitacora.InsertWithIdentity(() => new dbControl.Bitacora
            {
                Descripcion = Descripcion,
                Tipo = Tipo,
                IdUsuario = Usuario,
                Fecha = DateTime.Now
            });
        }

    }
}
