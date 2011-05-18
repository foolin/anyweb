using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_User_UserLock : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        string ids = QS( "ids" ).Trim();
        if( string.IsNullOrEmpty( ids ) )
        {
            ShowError( "请选择用户！" );
        }

        AW_Admin_dao dao = new AW_Admin_dao();
        List<AW_Admin_bean> list = dao.funcGetAdminList( ids );

        if( !IsPostBack )
        {
            repUsers.DataSource = list;
            repUsers.DataBind();
        }
        else
        {
            dao.funcLockAdmin( ids );
            foreach( AW_Admin_bean bean in list )
            {
                AddLog( EventType.Update, "锁定用户", string.Format( "锁定用户[{0}]", bean.fdAdmiAccount ) );
            }
            Response.Write( "<script type=text/javascript>parent.lockUserOK();</script>" );
            Response.End();
        }
    }
}
