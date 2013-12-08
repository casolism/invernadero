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
    public class SensorServices : System.Web.Services.WebService
    {

        [WebMethod(Description = "Obtiene valores de sensado de la BD")]
        public SensorDTO[] ObtieneSensado()
        {
            AutoMapper.Mapper.CreateMap<dbControl.Sensor, SensorDTO>();
            IList<dbControl.Sensor> lista = new dbControlManager().Sensor.ToList();
            return AutoMapper.Mapper.Map<IList<SensorDTO>>(lista).ToArray();
        }

        [WebMethod(Description = "Obtiene valores de sensado desde la BD")]
        public SensorDTO[] ObtieneSensadoRango(DateTime Inicio, DateTime Fin)
        {
            AutoMapper.Mapper.CreateMap<dbControl.Sensor, SensorDTO>();

            IList<dbControl.Sensor> lista = new dbControlManager().Sensor.Where(c => c.Fecha >= Inicio &&
                                                c.Fecha<=Fin).ToList();
            return AutoMapper.Mapper.Map<IList<SensorDTO>>(lista).ToArray();
        }

        [WebMethod(Description = "Obtiene valores de sensado desde la BD")]
        public SensorEstadoDTO[] ObtieneSensadoXEstado(int Estado)
        {
            AutoMapper.Mapper.CreateMap<dbControl.Sensor, SensorDTO>();
            dbControlManager db = new dbControlManager();
            List<SensorEstadoDTO> lista = new List<SensorEstadoDTO>();
            var query =
                    from t in db.Sensor
                    where t.IdSetPoint == Estado
                    select new
                    {
                        t.IdSensor,t.Valor,t.Fecha,t.SetPoint.Estado
                    };
            foreach (var item in query)
            {
                lista.Add(new SensorEstadoDTO {IdSensor=item.IdSensor,Sensor=item.Valor,Fecha=item.Fecha,Estado=item.Estado});
            }
            return lista.ToArray();
        }

        [WebMethod(Description = "Inserta valores de sensado en la BD")]
        public int InsertaSensado(double Valor, DateTime Fecha, int SetPoint)
        {
            dbControlManager db = new dbControlManager();
            var idInsertado = db.Sensor.InsertWithIdentity(() => new dbControl.Sensor
                                                { Valor = Valor, IdSetPoint = SetPoint, Fecha = Fecha });
            return Convert.ToInt32(idInsertado);
        }


        [WebMethod(Description = "Actualiza valores de sensado en la BD")]
        public bool ActualizaSensado(int IdSensor, double Valor, DateTime Fecha, int SetPoint)
        {
            dbControlManager db = new dbControlManager();
            var actualizados = db.Sensor.Where(e => e.IdSensor == IdSensor).Set(e => e.Valor, Valor)
                                                .Set(e => e.IdSensor, SetPoint)
                                                .Set(e => e.Fecha, Fecha).Update();
            return actualizados > 0;
        }

        [WebMethod(Description = "Elimina valores de sensado en la BD")]
        public bool EliminaSensado(int IdSensor)
        {
            return (new dbControlManager().Sensor.Where(e => e.IdSensor == IdSensor).Delete()) > 0;
        }  

    }
}
