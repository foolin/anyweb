using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_User_UserList : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int record = 0;
        List<AW_Admin_bean> list = new AW_Admin_dao().funcGetAdminList( PN1.PageIndex, PN1.PageSize, out record );
        if( list.Count == 0 )
        {
            noDatas.Visible = true;
            tableFooter.Visible = false;
        }
        else
        {
            repUsers.DataSource = list;
            repUsers.DataBind();
            PN1.SetPage( record );
            litRecords.Text = record.ToString();
        }
    }
}
