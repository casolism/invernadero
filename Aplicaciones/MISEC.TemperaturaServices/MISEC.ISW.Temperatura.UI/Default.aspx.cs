using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsuariosServices;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnEntrar_Click(object sender, EventArgs e)
    {
        //Consume el servicio web para consultar la información
        try
        {
            UsuariosServices.UsuariosServicesSoapClient wsLogin = new UsuariosServices.UsuariosServicesSoapClient();
            int nivel;
            //Validar el nivel del usuario
            if (wsLogin.ValidaUsuario(txtUsuario.Text.Trim(), txtPassword.Text.Trim(), out nivel))
            {
                //Si el nivel es 1, 2, 3,4  accesa al sistema
                if (nivel != 5)
                {
                    Session["nivel"] = nivel.ToString().Trim();
                    ConsultaUsuario(txtUsuario.Text.Trim());
                    Response.Redirect("Principal.aspx");
                }
                else
                    lblMensaje.Text = "No tiene permisos para accesar al sistema";
            }
            else
                lblMensaje.Text = "El usuario no existe! verifique sus datos.";

        }
        catch (Exception varEx)
        {
            lblMensaje.Text = varEx.Message;
        }

    }

    void ConsultaUsuario(string usuario)
    {
        UsuariosServices.UsuariosServicesSoapClient wsLogin = new UsuariosServices.UsuariosServicesSoapClient();
        UsuarioDTO Usr = wsLogin.ObtieneUsuario(usuario);
        Session["usuario"] = Usr.IdUsuario.ToString().Trim();
    }
}