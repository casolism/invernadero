using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MenuBitacora : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnBitacoraAccesos_Click(object sender, EventArgs e)
    {
        Response.Redirect("BitacoraAccesos.aspx");
    }
    protected void btnControlProcesos_Click(object sender, EventArgs e)
    {
        Response.Redirect("BitacoraProcesos.aspx");

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("BitacoraSetpoints.aspx");

    }
}