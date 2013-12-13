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
    /// Descripción breve de TemporadaServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class TemporadaServices : System.Web.Services.WebService
    {

        [WebMethod(Description = "Inserta Temporada")]
        public int RegistraTemporada(string Descripcion)
        {
            dbControlManager db = new dbControlManager();
            var idInsertado = db.Temporada.InsertWithIdentity(() => new dbControl.Temporada
            {
                Descripcion = Descripcion
            });
            return Convert.ToInt32(idInsertado);
        }

        [WebMethod(Description = "Obtiene setpoints desde la BD")]
        public List<TemporadaDTO> ObtieneTemporadas()
        {
            AutoMapper.Mapper.CreateMap<dbControl.Temporada, TemporadaDTO>();
            IList<dbControl.Temporada> lista = new dbControlManager().Temporada.ToList();
            return AutoMapper.Mapper.Map<List<TemporadaDTO>>(lista);
        }

        [WebMethod(Description = "Elimina Temporada en la BD")]
        public bool EliminaTemporada(int Id)
        {
            dbControlManager db = new dbControlManager();
            var eliminados = db.Temporada.Where(e => e.IdTemporada == Id).Delete();
            return eliminados > 0;
        }

        [WebMethod(Description = "Activa o descativa setpoints de la temporada")]
        public void ActivaTemporada(int IdTemporada, bool Activar)
        {
            dbControlManager db = new dbControlManager();
            string valor = Activar ? "S" : "N";
            List<int> Actualizar = new List<int>();
            var query =
                    from h in db.Horario
                    from s in db.SetPoint
                    where h.IdHorario == s.IdHorario
                    && h.IdTemporada == IdTemporada
                    select s.IdSetPoint;
            foreach (var sp in query)
                Actualizar.Add(sp);
            db.Close();
            db = new dbControlManager();
            foreach (var value in Actualizar)
                db.SetPoint.Where(e => e.IdSetPoint == value).Set(e => e.Activo, valor).Update();
        }

        [WebMethod(Description = "Actualiza Temporada en la BD")]
        public bool ActualizaTemporada(int IdTemporada, string Descripcion)
        {
            dbControlManager db = new dbControlManager();
            var actualizados = db.Temporada.Where(e => e.IdTemporada == IdTemporada)
                                                    .Set(e => e.Descripcion, Descripcion).Update();
            return actualizados > 0;
        }

        [WebMethod(Description = "Elimina Temporada en la BD")]
        public bool EliminaSetPoint(int IdTemporada)
        {
            dbControlManager db = new dbControlManager();
            var eliminados = db.Temporada.Where(e => e.IdTemporada == IdTemporada).Delete();
            return eliminados > 0;
        }

        #region Horarios

        [WebMethod(Description = "Inserta Horario asociado a una temporada")]
        public int RegistraHorarioEnTemporada(string Descripcion, DateTime HoraInicio, DateTime HoraFin, int IdTemporada)
        {
            dbControlManager db = new dbControlManager();
            var idInsertado = db.Horario.InsertWithIdentity(() => new dbControl.Horario
            {
                Descripcion = Descripcion,
                Inicio = HoraInicio,
                Fin = HoraFin,
                IdTemporada = IdTemporada
            });
            return Convert.ToInt32(idInsertado);
        }

        [WebMethod(Description = "Inserta Horario sin temporada")]
        public int RegistraHorario(string Descripcion, DateTime HoraInicio, DateTime HoraFin)
        {
            dbControlManager db = new dbControlManager();
            var idInsertado = db.Horario.InsertWithIdentity(() => new dbControl.Horario
            {
                Descripcion = Descripcion,
                Inicio = HoraInicio,
                Fin = HoraFin
            });
            return Convert.ToInt32(idInsertado);
        }

        [WebMethod(Description = "Obtiene setpoints desde la BD")]
        public List<HorarioDTO> ObtieneHorariosPorTemporada(int IdTemporada)
        {
            AutoMapper.Mapper.CreateMap<dbControl.Horario, HorarioDTO>();
            dbControlManager db = new dbControlManager();
            List<HorarioDTO> lista = new List<HorarioDTO>();
            var query =
                    from h in db.Horario
                    where h.IdTemporada == IdTemporada
                    select new
                    {
                        h.IdHorario,
                        h.Descripcion,
                        h.Inicio,
                        h.Fin,
                        TemporadaDescripcion = h.Descripcion
                    };
            foreach (var item in query)
            {
                lista.Add(new HorarioDTO
                {
                    Descripcion = item.Descripcion,
                    IdHorario = item.IdHorario,
                    Inicio = item.Inicio,
                    Fin = item.Inicio,
                    TemporadaDescripcion = item.TemporadaDescripcion
                });
            }
            return lista;
        }

        [WebMethod(Description = "Obtiene setpoints desde la BD")]
        public List<HorarioDTO> ObtieneHorarios()
        {
            AutoMapper.Mapper.CreateMap<dbControl.Horario, HorarioDTO>();
            IList<dbControl.Horario> lista = new dbControlManager().Horario.Where(c => c.IdTemporada == null).ToList();
            return AutoMapper.Mapper.Map<List<HorarioDTO>>(lista);
        }

        [WebMethod(Description = "Activa o descativa setpoints de la temporada")]
        public void ActivaHorario(int IdHorario, bool Activar)
        {
            dbControlManager db = new dbControlManager();
            string valor = Activar ? "S" : "N";
            db.SetPoint.Where(e => e.IdHorario == IdHorario).Set(e => e.Activo, valor).Update();
        }

        [WebMethod(Description = "Actualiza Temporada en la BD")]
        public bool ActualizaHorario(string Descripcion, DateTime HoraInicio, DateTime HoraFin, int IdTemporada)
        {
            dbControlManager db = new dbControlManager();
            var actualizados = db.Temporada.Where(e => e.IdTemporada == IdTemporada)
                                                    .Set(e => e.Descripcion, Descripcion).Update();
            return actualizados > 0;
        }

        [WebMethod(Description = "Actualiza Temporada en la BD")]
        public bool ActualizaHorarioEnTemporada(int IdHorario, string Descripcion, DateTime HoraInicio, DateTime HoraFin)
        {
            dbControlManager db = new dbControlManager();
            var actualizados = db.Horario.Where(e => e.IdHorario == IdHorario)
                                                    .Set(e => e.Descripcion, Descripcion).Update();
            return actualizados > 0;
        }

        [WebMethod(Description = "Elimina Temporada en la BD")]
        public bool EliminaHorario(int IdHorario)
        {
            dbControlManager db = new dbControlManager();
            var eliminados = db.Horario.Where(e => e.IdHorario == IdHorario).Delete();
            return eliminados > 0;
        }

        #endregion

    }
}
