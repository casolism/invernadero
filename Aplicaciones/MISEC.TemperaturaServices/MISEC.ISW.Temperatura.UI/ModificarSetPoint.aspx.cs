using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SetPointServices;

public partial class ModificarSetPoint : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             LlenarCombos();
            ConsultarSetPoint();
           
            
        }
    }

    //Consulta la información del setpoint desde la BD
    void ConsultarSetPoint()
    { 
     try
        {
         
         int idSetPoint = int.Parse(Request["idSetPoint"].ToString());   //Id del setPoint a modificar

         //Consume el servicio web para consultar la información del setpoint
         SetPointServices.SetPointServicesSoapClient wsInvernadero = new SetPointServices.SetPointServicesSoapClient();

         if (idSetPoint!=0)
         {
             SetPointDTO SetPoint = wsInvernadero.SeleccionaSetPointI(idSetPoint);
             lblIdSetPoint.Text = SetPoint.IdSetPoint.ToString();
             txtLimiteMin.Text = SetPoint.limiteMin.ToString();
             txtLimiteMax.Text = SetPoint.limiteMax.ToString();
             cmbVariables.SelectedValue = SetPoint.Variable.Trim();
             cmbEstados.SelectedValue= SetPoint.Estado.Trim();
             
         }

        }catch(Exception varEx)
        {
            lblMensaje.Text = varEx.Message;
        }
    }
    

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
    //Modificar el SetPoint
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            SetPointServices.SetPointServicesSoapClient wsInvernadero = new SetPointServices.SetPointServicesSoapClient();
            if (wsInvernadero.ActualizaSetPoint(int.Parse(lblIdSetPoint.Text), cmbVariables.SelectedValue.Trim(), double.Parse(txtLimiteMin.Text), double.Parse(txtLimiteMax.Text), cmbEstados.SelectedValue.Trim()))
            lblMensaje.Text = "Se ha modificado el SetPoint con ID: " + lblIdSetPoint.Text;
        }
        catch (Exception varEx)
        {
            lblMensaje.Text = varEx.Message;
        }
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("SetPoint.aspx");
    }
}