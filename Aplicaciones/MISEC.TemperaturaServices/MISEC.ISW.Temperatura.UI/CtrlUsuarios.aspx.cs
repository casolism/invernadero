using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsuariosServices;

public partial class CtrlUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ConsultarNiveles();
        ConsultarUsuarios();
    }


    void ConsultarUsuarios()
    {
        try
        {   UsuariosServices.UsuariosServicesSoapClient ws = new UsuariosServices.UsuariosServicesSoapClient();
            IList<UsuarioDTO> usuario = ws.ObtieneUsuarios();

            GridUsuarios.DataSource = usuario;
            GridUsuarios.DataBind();
        }
        catch (Exception varEx)
        {
            lblMensaje.Text = varEx.Message;
        }
    }

    void ConsultarNiveles()
    {
        try
        {
            DataSet ds = new DataSet();
            //Llena el combo de las variables
            ds.ReadXml(Server.MapPath("xml/Niveles.xml"));
            cmbNiveles.DataSource = ds.Tables[0];
            cmbNiveles.DataTextField = "descripcion";
            cmbNiveles.DataBind();
        }
        catch (UnauthorizedAccessException)
        {

        }

    }
    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        try
        {
            UsuariosServices.UsuariosServicesSoapClient ws = new UsuariosServices.UsuariosServicesSoapClient();
            ws.InsertaUsuario(txtUsuario.Text, txtPassword.Text, int.Parse(cmbNiveles.SelectedItem.ToString().Substring(1, 1)));
            
            lblMensaje.Text = "Usuario registrado";
 
        }
        catch(Exception varEx)
        {
            lblMensaje.Text = varEx.Message;
        }

    }
    protected void GridUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow r = GridUsuarios.Rows[index];
            string idusuario = r.Cells[0].Text.ToString().Trim();

            //Modificar usuario
            if (e.CommandName == "Modificar")
            {
                Response.Redirect("ModificarUsuario.aspx?idUsuario=" + idusuario);
            }


            //eliminar usuario
            if (e.CommandName == "Eliminar")
            {
                UsuariosServices.UsuariosServicesSoapClient ws = new UsuariosServices.UsuariosServicesSoapClient();
                if (ws.EliminaUsuario(idusuario))
                {
                    lblMensaje.Text = "Usuario Eliminado!!";
                    ConsultarUsuarios();
                }
            }
        }
        catch (Exception varEx)
        {
            lblMensaje.Text = varEx.Message;
        }
    }
}
