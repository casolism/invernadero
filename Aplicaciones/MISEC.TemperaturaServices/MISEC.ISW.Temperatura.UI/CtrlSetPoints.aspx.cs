using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CtrlSetPoints : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    //Control de setpoints por temporada y horario
    protected void ImgTemporada_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("TemporadaHorario.aspx");
    }
    //Control de setpoints por horario
    protected void ImgHorario_Click(object sender, ImageClickEventArgs e)
    {
        Session["temporada"] = null;    //Control de setpoints sin temporada
        Response.Redirect("Horario.aspx");
    }
    //Control de setpoints libre
    protected void ImgLibre_Click(object sender, ImageClickEventArgs e)
    {
        Session["renglon"] = null;  //Control de setpoints sin temporada
        Response.Redirect("SetPoint.aspx");
    }
}