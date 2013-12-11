using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        {
            DataSet ds = new DataSet();

            ds.ReadXml(Server.MapPath("xml/Usuarios.xml"));

            GridUsuarios.DataSource = ds.Tables[0];
            GridUsuarios.DataBind();
        }
        catch (UnauthorizedAccessException)
        {

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
}
