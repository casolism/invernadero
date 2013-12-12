using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class HorarioConTemporada : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Mostrar de que temporada es el horario
        if (Session["temporada"] == null)
            lblTemporada.Text = "SIN TEMPORADA";
        else
            lblTemporada.Text = Session["temporada"].ToString();
        ConsultarHorarios();
    }


    void ConsultarHorarios()
    {
        try
        {
            DataSet ds = new DataSet();

            ds.ReadXml(Server.MapPath("xml/Horarios.xml"));

            GridHorarios.DataSource = ds.Tables[0];
            GridHorarios.DataBind();

            //TemporadaServices.TemporadaServicesSoapClient ws = new TemporadaServices.TemporadaServicesSoapClient();
            //IList<HorarioDTO> horarios = ws.ObtieneHorarios();
            //GridHorarios.DataSource = horarios;
            //GridHorarios.DataBind();
        }
        catch (UnauthorizedAccessException)
        {

        }
    }



    protected void GridHorarios_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());
        GridViewRow r = GridHorarios .Rows[index];

        if (e.CommandName == "SetPoint")
        {
            //Lista que contiene la información del renglon seleccionado
            List<string> renglon = new List<string> { r.Cells[0].Text.ToString(), r.Cells[1].Text.ToString(), r.Cells[2].Text.ToString(), r.Cells[3].Text.ToString() };
            Session["renglon"] = renglon;
            Response.Redirect("SetPoint.aspx");
        }
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("TemporadaHorario.aspx");
    }
    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        try 
        {
            TemporadaServices.TemporadaServicesSoapClient ws = new TemporadaServices.TemporadaServicesSoapClient();
           int idHorario= ws.RegistraHorario(txtDescripcion.Text.Trim(),DateTime.Parse(txtHrInicio.Text),DateTime.Parse(txtHrFin.Text));
            if (idHorario>0)
                lblMensaje.Text="Horario registrado ID: " + idHorario.ToString();            

        }
        catch(Exception varEx)
        {
            lblMensaje.Text = varEx.Message;
        }
    }
}