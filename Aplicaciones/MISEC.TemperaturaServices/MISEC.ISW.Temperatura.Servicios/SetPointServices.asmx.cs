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
    /// Descripción breve de SetPointServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class SetPointServices : System.Web.Services.WebService
    {
        [WebMethod(Description = "Obtiene setpoints desde la BD")]
        public List<SetPointDTO> SeleccionaSetPointG()
        {
            AutoMapper.Mapper.CreateMap<dbControl.SetPoint, SetPointDTO>();
            IList<dbControl.SetPoint> lista = new dbControlManager().SetPoint.ToList();
            return AutoMapper.Mapper.Map<List<SetPointDTO>>(lista);
        }

        [WebMethod(Description = "Obtiene setpoints desde la BD")]
        public SetPointDTO SeleccionaSetPointI(int IdSetpoint)
        {
            AutoMapper.Mapper.CreateMap<dbControl.SetPoint, SetPointDTO>();
            dbControl.SetPoint lista = new dbControlManager().SetPoint.Where(c=>c.IdSetPoint==IdSetpoint).ToList()[0];
            return AutoMapper.Mapper.Map<SetPointDTO>(lista);
        }

        [WebMethod(Description = "Inserta setpoint en la BD")]
        public int InsertaSetPoint(string Variable, double LimiteMin, double LimiteMax, string Estado)
        {
            dbControlManager db = new dbControlManager();
            var idInsertado = db.SetPoint.InsertWithIdentity(() => new dbControl.SetPoint
            {
                Variable = Variable,
                limiteMin = LimiteMin,
                limiteMax = LimiteMax,
                Estado = Estado
            });
            return Convert.ToInt32(idInsertado);
        }

        [WebMethod(Description = "Inserta setpoint en la BD")]
        public int InsertaSetPointHorario(int IdHorario, string Variable, double LimiteMin, double LimiteMax, string Estado)
        {
            dbControlManager db = new dbControlManager();
            var idInsertado = db.SetPoint.InsertWithIdentity(() => new dbControl.SetPoint
            {
                Variable = Variable,
                limiteMin = LimiteMin,
                limiteMax = LimiteMax,
                Estado = Estado,
                IdHorario = IdHorario
            });
            return Convert.ToInt32(idInsertado);
        }


        [WebMethod(Description = "Actualiza setpoint en la BD")]
        public bool ActualizaSetPoint(int IdSetPoint,string Variable, double LimiteMin,double LimiteMax, string Estado)
        {
            dbControlManager db = new dbControlManager();
            var actualizados = db.SetPoint.Where(e => e.IdSetPoint == IdSetPoint).Set(e => e.Variable, Variable)
                                                .Set(e => e.limiteMin, LimiteMin).Set(e => e.limiteMax, LimiteMax)
                                                .Set(e => e.Estado, Estado).Update();
            return actualizados > 0;
        }

        [WebMethod(Description = "Elimina setpoint en la BD")]
        public bool EliminaSetPoint(int IdSetPoint)
        {
            dbControlManager db = new dbControlManager();
            var eliminados = db.SetPoint.Where(e => e.IdSetPoint == IdSetPoint).Delete();
            return eliminados > 0;
        }

        [WebMethod(Description = "Obtiene valores de setpoints por Horario en la BD")]
        public List<SetPointDTO> ObtieneSetPointsXHorario(int Horario)
        {
            AutoMapper.Mapper.CreateMap<dbControl.Sensor, SensorDTO>();
            dbControlManager db = new dbControlManager();
            List<SetPointDTO> lista = new List<SetPointDTO>();
            var query =
                    from t in db.SetPoint
                    where t.IdHorario == Horario
                    select new
                    {
                        t.IdSetPoint,
                        t.limiteMax,
                        t.limiteMin,
                        t.Variable,
                        t.Estado
                    };
            foreach (var item in query)
            {
                lista.Add(new SetPointDTO { Estado = item.Estado, IdSetPoint = item.IdSetPoint, limiteMax = item.limiteMax, 
                                            limiteMin = item.limiteMin, Variable=item.Variable });
            }
            return lista;
        }

        [WebMethod(Description = "Obtiene valores de sensado desde la BD")]
        public List<SetPointDTO> ObtieneSetPointsXTemporada(int Temporada)
        {
            AutoMapper.Mapper.CreateMap<dbControl.Sensor, SensorDTO>();
            dbControlManager db = new dbControlManager();
            List<SetPointDTO> lista = new List<SetPointDTO>();
            var query =
                    from s in db.SetPoint
                    from h in db.Horario
                    where s.IdHorario== h.IdHorario && h.IdTemporada== Temporada
                    select new
                    {
                        s.IdSetPoint,
                        s.limiteMax,
                        s.limiteMin,
                        s.Variable,
                        s.Estado
                    };
            foreach (var item in query)
            {
                lista.Add(new SetPointDTO
                {
                    Estado = item.Estado,
                    IdSetPoint = item.IdSetPoint,
                    limiteMax = item.limiteMax,
                    limiteMin = item.limiteMin,
                    Variable = item.Variable
                });
            }
            return lista;
        }

   
    }

}
