﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sensado : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
            Response.Redirect("Default.aspx");
        else
            lblUsuario.Text = "Usuario [" + Session["usuario"].ToString() +"]";
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("CtrlUsuarios.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ConsBitacora.aspx");
    }
}
