using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class AnyWell_RefurbishAll : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        string msg = "";
        if( this.LoginUser == null )
        {
            msg = "alert(\"请先登录！\")";
            WriteScript( msg );
            return;
        }

        new AW_Resume_dao().funcRefurbishAll( this.LoginUser.fdUserID );
        WriteScript( "alert(\"刷新简历成功！\");" );
    }

    protected void WriteScript( string Script )
    {
        Response.Clear();
        Response.Write( Script );
        Response.End();
    }
}
