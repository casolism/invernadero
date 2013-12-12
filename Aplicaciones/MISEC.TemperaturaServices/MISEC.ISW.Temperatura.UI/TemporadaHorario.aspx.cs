using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using TemporadaServices;


public partial class TemporadaHorario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
        ConsultarTemporadas();
    }

    void ConsultarTemporadas()
    {
        try
        {
            TemporadaServices.TemporadaServicesSoapClient ws = new TemporadaServices.TemporadaServicesSoapClient();
            IList<TemporadaDTO> temporadas = ws.ObtieneTemporadas();
           
            GridTemporadas.DataSource = temporadas;
            GridTemporadas.DataBind();
        }
        catch (UnauthorizedAccessException)
        {

        }
    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        try
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "myScript", "mensaje();", true);
            TemporadaServices.TemporadaServicesSoapClient ws = new TemporadaServices.TemporadaServicesSoapClient();
            int idTemporada = ws.RegistraTemporada(txtTemporada.Text.Trim());
            lblMensaje.Text = "Temporada registrada ID: " + idTemporada.ToString();
            ConsultarTemporadas();
        }
        catch (Exception varEx)
        {
            lblMensaje.Text = varEx.Message;
        }
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
            Response.Redirect("HorarioConTemporada.aspx");
        }

        //Activar temporada
        if (e.CommandName == "Activar")
        {
            TemporadaServices.TemporadaServicesSoapClient ws = new TemporadaServices.TemporadaServicesSoapClient();
            ws.ActivaTemporada(int.Parse(r.Cells[0].Text.ToString()),true);
        }

        //DesactivarTemprada
        if (e.CommandName == "Desactivar")
        {
            TemporadaServices.TemporadaServicesSoapClient ws = new TemporadaServices.TemporadaServicesSoapClient();
            ws.ActivaTemporada(int.Parse(r.Cells[0].Text.ToString()), false);
        }

        //Modificar temporada
        if (e.CommandName == "Modificar")
        {
            Session["idtemporada"] = r.Cells[0].Text.ToString();
            Session["temporada"] = r.Cells[1].Text.ToString();
            Response.Redirect("ModificarTemporada.aspx?idTemporada=" + r.Cells[0].Text.ToString());
        }

        //Eliminar temporada
        if (e.CommandName == "Eliminar")
        {
            //TemporadaServices.TemporadaServicesSoapClient ws = new TemporadaServices.TemporadaServicesSoapClient();
            
        }
    }
}