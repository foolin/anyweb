using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class User_SetPhoto : PageUser
{
    protected void Page_Load( object sender, EventArgs e )
    {
        if( string.IsNullOrEmpty( QS( "show" ) ) ||!WebAgent.IsInt32(QS("show")))
        {
            Response.Write( "1:参数错误！" );
            return;
        }
        int show;
        int.TryParse( QS( "show" ), out show );
        if( show != 0 && show != 1 )
        {
            Response.Write( "1:参数错误！" );
            return;
        }
        this.LoginUser.fdUserPhotoIsShow = show;
        new AW_User_dao().funcUpdate( this.LoginUser );
        Response.Write( "0:保存成功！" );
    }
}
