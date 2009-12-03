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
using Admin.Framework;

public partial class LogList :AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {

    }
    protected void ods3_Selected(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( e.OutputParameters["record"] != null )
        {
            int record = (int)e.OutputParameters["record"];
            PN1.SetPage( record );

        }
        drpType.SelectedValue = QS( "eventid" );
    }

    protected void btnSearch_Click(object sender , EventArgs e)
    {
        Response.Redirect( "LogList.aspx?eventid=" + drpType.SelectedValue );
    }

    public string status(int status)
    {
        switch ( status )
        {
            case 1:
                return "登陆";
            case 2:
                return "添加";
            case 3:
                return "修改";
            case 4:
                return "删除";
            default:
                return "";
        }

    }
}
