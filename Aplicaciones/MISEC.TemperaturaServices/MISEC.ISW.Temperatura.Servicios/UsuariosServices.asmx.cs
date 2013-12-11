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
    /// Descripción breve de UsuariosServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class UsuariosServices : System.Web.Services.WebService
    {
        [WebMethod(Description = "Obtiene setpoints desde la BD")]
        public List<UsuarioDTO> ObtieneUsuarios()
        {
            AutoMapper.Mapper.CreateMap<dbControl.Usuario,UsuarioDTO >();
            IList<dbControl.Usuario> lista = new dbControlManager().Usuario.ToList();
            return AutoMapper.Mapper.Map<List<UsuarioDTO>>(lista);
        }

        [WebMethod(Description = "Obtiene usuarios desde la BD")]
        public UsuarioDTO ObtieneUsuario(string IdUsuario)
        {
            AutoMapper.Mapper.CreateMap<dbControl.Usuario, UsuarioDTO>();
            dbControl.Usuario lista = new dbControlManager().Usuario.Where(c => c.IdUsuario == IdUsuario).ToList()[0];
            return AutoMapper.Mapper.Map<UsuarioDTO>(lista);
        }

        [WebMethod(Description = "Inserta usuario en la BD")]
        public void InsertaUsuario(string IdUsuario, string Password,int Nivel)
        {
            dbControlManager db = new dbControlManager();
            var idInsertado = db.Usuario.InsertWithIdentity(() => new dbControl.Usuario
            {
                IdUsuario = IdUsuario,
                Password = Password,
                Nivel=Nivel
            });
        }
        
        [WebMethod(Description = "Actualiza usuario en la BD")]
        public bool ActualizaUsuario(string IdUsuario, string Password, int Nivel)
        {
            dbControlManager db = new dbControlManager();
            var actualizados = db.Usuario.Where(e => e.IdUsuario == IdUsuario).Set(e => e.Password, Password)
                                                .Set(e => e.Nivel, Nivel).Update();
            return actualizados > 0;
        }

        [WebMethod(Description = "Elimina usuario de la BD")]
        public bool EliminaUsuario(string IdUsuario)
        {
            dbControlManager db = new dbControlManager();
            var eliminados = db.Usuario.Where(e => e.IdUsuario == IdUsuario).Delete();
            return eliminados > 0;
        }

        [WebMethod(Description = "Valida Usuario")]
        public bool ValidaUsuario(string Usuario, string Password, out int nivel) {
            AutoMapper.Mapper.CreateMap<dbControl.Usuario, UsuarioDTO>();
            try
            {
                dbControl.Usuario lista = new dbControlManager().Usuario.Where(c => c.IdUsuario == Usuario &&
                                        c.Password == Password).ToList()[0];
                nivel = lista.Nivel;
                return true;
            }
            catch (Exception) {
                nivel = 0;
                return false;
            }
        }

    }
}
