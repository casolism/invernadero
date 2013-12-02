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
        public SetPointDTO[] SeleccionaSetPointG()
        {
            AutoMapper.Mapper.CreateMap<dbControl.SetPoint, SetPointDTO>();
            IList<dbControl.SetPoint> lista = new dbControlManager().SetPoint.ToList();
            return AutoMapper.Mapper.Map<IList<SetPointDTO>>(lista).ToArray();
        }

        [WebMethod(Description = "Obtiene setpoints desde la BD")]
        public SetPointDTO SeleccionaSetPointI(int IdSetpoint)
        {
            AutoMapper.Mapper.CreateMap<dbControl.SetPoint, SetPointDTO>();
            dbControl.SetPoint lista = new dbControlManager().SetPoint.Where(c=>c.IdSetPoint==IdSetpoint).ToList()[0];
            return AutoMapper.Mapper.Map<SetPointDTO>(lista);
        }

        [WebMethod(Description = "Inserta setpoint en la BD")]
        public int InsertaSetPoint(int IdTipo, double LimiteMin,double LimiteMax, string Estado)
        {
            dbControlManager db = new dbControlManager();
            var idInsertado = db.SetPoint.InsertWithIdentity(() => new dbControl.SetPoint { IdTipo = IdTipo, limiteMin = LimiteMin,
                                                                                            limiteMax = LimiteMax,Estado=Estado });
            return Convert.ToInt32(idInsertado);
        }


        [WebMethod(Description = "Actualiza setpoint en la BD")]
        public bool ActualizaSetPoint(int IdSetPoint,int IdTipo, double LimiteMin,double LimiteMax, string Estado)
        {
            dbControlManager db = new dbControlManager();
            var actualizados = db.SetPoint.Where(e => e.IdSetPoint == IdSetPoint).Set(e => e.IdTipo, IdTipo)
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

    }
}
