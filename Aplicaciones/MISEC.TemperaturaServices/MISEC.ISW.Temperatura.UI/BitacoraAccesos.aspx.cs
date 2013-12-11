using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BitacoraAccesos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void bntConsultar_Click(object sender, EventArgs e)
    {
        ConsultarBitacora();
    }

    void ConsultarBitacora()
    {
        try
        {
            DataSet ds = new DataSet();

            ds.ReadXml(Server.MapPath("xml/BitacoraAccesos.xml"));

            GridBitacora.DataSource = ds.Tables[0];
            GridBitacora.DataBind();
        }
        catch (UnauthorizedAccessException)
        {

        }
    }
}