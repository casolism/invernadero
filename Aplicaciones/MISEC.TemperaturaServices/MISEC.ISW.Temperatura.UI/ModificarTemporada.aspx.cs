using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TemporadaServices;

public partial class ModificarTemporada : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["idtemporada"] != null)
            {
                if (Session["temporada"] != null)
                {
                    lblTemporada.Text = Session["idtemporada"].ToString();
                    txtTemporada.Text = Session["temporada"].ToString();
                }
                else
                    lblMensaje.Text = "Seleccione una temporada";
            }
            else
                lblMensaje.Text = "Seleccione una temporada";
        }
    }

   
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            TemporadaServices.TemporadaServicesSoapClient ws = new TemporadaServices.TemporadaServicesSoapClient();
            if (ws.ActualizaTemporada(int.Parse(lblTemporada.Text),txtTemporada.Text.Trim()))
                lblMensaje.Text = "Temporada modificada";
        }catch(Exception varEx)
        {
            lblMensaje.Text = varEx.Message;
        }
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("TemporadaHorario.aspx");
    }
}