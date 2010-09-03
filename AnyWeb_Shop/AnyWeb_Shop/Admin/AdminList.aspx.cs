using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Admin.Framework;

using Studio.Web;
using Common.Common;
using Common.Agent;

public partial class Admin_AdminList : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /*protected override void OnPreRender(EventArgs e)
    {
        int RecordCount = 0;
        repAdmins.DataSource = new AdminAgent().GetAdmins(PN1.PageSize, PN1.PageIndex, out RecordCount);
        repAdmins.DataBind();
        PN1.SetPage(RecordCount);
    }*/

    protected void ods3_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.OutputParameters["recordCount"] != null)
        {
            int record = (int)e.OutputParameters["recordCount"];
            PN1.SetPage(record);
        }
    }
}
