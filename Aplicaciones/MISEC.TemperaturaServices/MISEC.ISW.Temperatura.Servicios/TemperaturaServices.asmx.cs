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
    /// Descripción breve de TemperaturaServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class TemperaturaServices : System.Web.Services.WebService
    {

        [WebMethod(Description = "Obtiene temperaturas desde la BD")]
        public TemperaturaDTO[] SeleccionaTemperaturas()
        {
            AutoMapper.Mapper.CreateMap<dbControl.Temperatura, TemperaturaDTO>();
            IList<dbControl.Temperatura> lista = new dbControlManager().Temperatura.ToList();
            return AutoMapper.Mapper.Map<IList<TemperaturaDTO>>(lista).ToArray();
        }

        [WebMethod(Description = "Obtiene temperaturas desde la BD")]
        public TemperaturaDTO[] SeleccionaTemperaturasRango(DateTime Inicio, DateTime Fin)
        {
            AutoMapper.Mapper.CreateMap<dbControl.Temperatura, TemperaturaDTO>();

            IList<dbControl.Temperatura> lista = new dbControlManager().Temperatura.Where(c=>c.Fecha>=Inicio &&
                                                c.Fecha<=Fin).ToList();
            return AutoMapper.Mapper.Map<IList<TemperaturaDTO>>(lista).ToArray();
        }

        [WebMethod(Description = "Obtiene temperaturas desde la BD")]
        public TemperaturaEstadoDTO[] SeleccionaTemperaturasXEstado(int Estado)
        {
            AutoMapper.Mapper.CreateMap<dbControl.Temperatura, TemperaturaDTO>();
            dbControlManager db = new dbControlManager();
            List<TemperaturaEstadoDTO> lista = new List<TemperaturaEstadoDTO>();
            var query =
                    from t in db.Temperatura where t.Estado==Estado
                    select new
                    {
                        t.IdSensor,t.Sensor,t.Fecha,t.SetPoint.Estado
                    };
            foreach (var item in query)
            {
                lista.Add(new TemperaturaEstadoDTO {IdSensor=item.IdSensor,Sensor=item.Sensor,Fecha=item.Fecha,Estado=item.Estado});
            }
            return lista.ToArray();
        }

        [WebMethod(Description = "Inserta temperatura en la BD")]
        public int InsertaTemperaturas(double Sensor,DateTime Fecha,int Estado)
        {
            dbControlManager db = new dbControlManager();
            var idInsertado = db.Temperatura.InsertWithIdentity(() => new dbControl.Temperatura
                                                { Sensor = Sensor, Estado = Estado, Fecha = Fecha });
            return Convert.ToInt32(idInsertado);
        }


        [WebMethod(Description = "Actualiza temperatura en la BD")]
        public bool ActualizaTemperaturas(int IdSensor,double Sensor, DateTime Fecha, int Estado)
        {
            dbControlManager db = new dbControlManager();
            var actualizados = db.Temperatura.Where(e=>e.IdSensor==IdSensor).Set(e => e.Sensor, Sensor)
                                                .Set(e => e.Estado, Estado)
                                                .Set(e => e.Fecha, Fecha).Update();
            return actualizados > 0;
        }

        [WebMethod(Description = "Elimina temperatura en la BD")]
        public bool EliminaTemperaturas(int IdSensor)
        {
            return  (new dbControlManager().Temperatura.Where(e => e.IdSensor == IdSensor).Delete()) > 0;
        }  

    }
}
