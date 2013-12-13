using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SetPointServices;

public partial class SetPoint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LlenaTitulo();
            LlenarCombos();
            ConsultarSetPoints();  //Consulta los setpoints registrados para mostrarlos en el grid
        }
    }

    //Coloca el valor en las etiquetas para identificar el horario al que corresponde el SetPoint
    void LlenaTitulo()
    {   
        List<string> renglon = Session["renglon"] != null ? (List<string>)Session["renglon"] : null;
        if (renglon != null)
        {
            if (renglon[0] == null)
            {
                lblTemporada.Text = "";
                lblHorario.Text = "";
                lblDescripcion.Text = "";
            }
            else
            {
                lblTemporada.Text = renglon[0];
                lblHorario.Text = renglon[1] + " - " + renglon[2];
                lblDescripcion.Text = renglon[3];
            }
        }

    }

    //Llena Variables y estados
    void LlenarCombos()
    {
        DataSet ds = new DataSet();
        //Llena el combo de las variables
        ds.ReadXml(Server.MapPath("xml/Variables.xml"));
        cmbVariables.DataSource = ds.Tables[0];
        cmbVariables.DataTextField = "variable";
        cmbVariables.DataBind();

        //Llena el combo de estados
        DataSet ds1 = new DataSet();
        ds1.ReadXml(Server.MapPath("xml/Estados.xml"));
        cmbEstados.DataSource = ds1.Tables[0];
        cmbEstados.DataTextField = "estado";
        cmbEstados.DataBind();

    }

    //Consulta todos los setpoints registrados
    void ConsultarSetPoints()
    {
        SetPointServices.SetPointServicesSoapClient wsInvernadero = new SetPointServices.SetPointServicesSoapClient();
        IList<SetPointDTO> SetPoint = wsInvernadero.SeleccionaSetPointG();

        GridSetPoint.DataSource = SetPoint;
        GridSetPoint.DataBind();
    }


    //Registrar el setPoint
    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        try
        {
            SetPointServices.SetPointServicesSoapClient wsInvernadero = new SetPointServices.SetPointServicesSoapClient();
            int idSetPoint = wsInvernadero.InsertaSetPoint(cmbVariables.SelectedValue.Trim(), double.Parse(txtLimiteMin.Text), double.Parse(txtLimiteMax.Text), cmbEstados.SelectedValue.Trim());
            lblIdSetPoint.Text = "Se ha registrado el SetPoint con ID: " + idSetPoint.ToString();
            ConsultarSetPoints();
        }catch(Exception varEx)
        {
            lblIdSetPoint.Text = varEx.Message;
        }
    }

    void EliminarSetPoint(int id)
    {
        try
        {
            SetPointServices.SetPointServicesSoapClient wsInvernadero = new SetPointServices.SetPointServicesSoapClient();
            if (wsInvernadero.EliminaSetPoint(id))
            {
                lblIdSetPoint.Text = "Se ha Eliminado el SetPoint con ID: " + id.ToString();
                ConsultarSetPoints();
            }
        }
        catch (Exception varEx)
        {
            lblIdSetPoint.Text = varEx.Message;
        }

    }

    //SetPoint seleccionado
    protected void GridSetPoint_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = int.Parse(e.CommandArgument.ToString());
        GridView grid = (GridView)sender;

        GridViewRow r = GridSetPoint.Rows[index];

        //Modificar SetPoint
        if (e.CommandName == "Modificar")
        {
            Response.Redirect("ModificarSetPoint.aspx?idSetPoint=" + r.Cells[0].Text.ToString());
        }

        //Eliminar SetPoint
        if (e.CommandName == "Eliminar")
        {
            EliminarSetPoint(int.Parse(r.Cells[0].Text.ToString()));
        }

    }
 
}