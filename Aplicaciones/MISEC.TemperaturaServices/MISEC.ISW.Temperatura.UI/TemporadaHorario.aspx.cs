using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;


public partial class TemporadaHorario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ConsultarTemporadas();
    }

    void ConsultarTemporadas()
    {
        try
        {
            DataSet ds = new DataSet();

            ds.ReadXml(Server.MapPath("xml/Temporadas.xml"));

            GridTemporadas.DataSource = ds.Tables[0];
            GridTemporadas.DataBind();
        }
        catch (UnauthorizedAccessException)
        {

        }
    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
      ClientScript.RegisterStartupScript(this.GetType(), "myScript", "mensaje();", true);
        
    }


    //Contiene el ID del renglon seleccionado 
    protected void GridTemporadas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());
        GridView grid = (GridView)sender;

        GridViewRow r = GridTemporadas.Rows[index];

        //Registrar Horario de la temporada
        if (e.CommandName == "Horario")
        {
            Session["idtemporada"] = r.Cells[0].Text.ToString();
            Session["temporada"] = r.Cells[1].Text.ToString();
            Response.Redirect("Horario.aspx");
        }

        //Activar temporada
        if (e.CommandName == "Activar")
        {
            txtTemporada.Text = "Activar";
        }

        //DesactivarTemprada
        if (e.CommandName == "Desactivar")
        {
            txtTemporada.Text = "Descactivar";
        }

        //Modificar temporada
        if (e.CommandName == "Modificar")
        {
            Response.Redirect("ModificarTemporada.aspx");
        }

        //Eliminar temporada
        if (e.CommandName == "Eliminar")
        {
            
        }
    }
}