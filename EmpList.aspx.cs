using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class EmpList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Data1_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        PN1.SetPage((int)e.OutputParameters["recordCount"]);
        lblRecords.Text = e.OutputParameters["recordCount"].ToString();
    }
}
