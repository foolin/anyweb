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
using Studio.Web;
using Admin.Framework;

public partial class User_UserList :AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ods3_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.OutputParameters["recordCount"] != null)
        {
            int record = (int)e.OutputParameters["recordCount"];
            PN1.SetPage(record);
        }
        drpType.SelectedValue = QS( "status" );

    }
    protected void btnSearch_Click(object sender , EventArgs e)
    {
        Response.Redirect( "UserList.aspx?userName=" + txtname.Text + "&useracc=" + txtacc.Text + "&status=" + drpType.SelectedValue );
    }

    protected void ods3_Selecting(object sender , ObjectDataSourceSelectingEventArgs e)
    {

        e.InputParameters["userName"] = QS( "userName" );
        e.InputParameters["useracc"] = QS( "useracc" );
        txtacc.Text = QS("useracc");
        txtname.Text = QS("userName");
    }
}
