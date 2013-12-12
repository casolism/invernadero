using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsuariosServices;

public partial class ModificarUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ConsultarUsuario(Request["idUsuario"].ToString().Trim());
        }
    }
   

    void ConsultarUsuario(string idusuario)
{
    try
    {
        UsuariosServices.UsuariosServicesSoapClient ws = new UsuariosServices.UsuariosServicesSoapClient();
        UsuarioDTO usuario = ws.ObtieneUsuario(idusuario);
        txtUsuario.Text = usuario.IdUsuario;
        txtPassword.Text = usuario.Password;
        txtNivel.Text = usuario.Nivel.ToString();
 
    }
    catch (Exception varEx)
    {
        lblMensaje.Text = varEx.Message;
    }
}
 

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            UsuariosServices.UsuariosServicesSoapClient ws = new UsuariosServices.UsuariosServicesSoapClient();
            if (ws.ActualizaUsuario(txtUsuario.Text, txtPassword.Text, int.Parse(txtNivel.Text)))
                lblMensaje.Text = "Usuario modificado";
        }
        catch (Exception varEx)
        { lblMensaje.Text = varEx.Message; }
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("CtrlUsuarios.aspx");
    }
}