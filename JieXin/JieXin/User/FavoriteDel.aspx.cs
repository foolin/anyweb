using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class User_FavoriteDel : PageUser
{
    protected void Page_Load( object sender, EventArgs e )
    {
        if( string.IsNullOrEmpty( QS( "id" ) ) || !WebAgent.IsInt32( QS( "id" ) ) )
        {
            WebAgent.AlertAndBack( "收藏职位不存在！" );
        }
        AW_Favorite_bean bean = AW_Favorite_bean.funcGetByID( int.Parse( QS( "id" ) ) );
        if( bean == null || bean.fdFavoUserID != this.LoginUser.fdUserID )
        {
            WebAgent.AlertAndBack( "收藏职位不存在！" );
        }
        new AW_Favorite_dao().funcDelete( bean.fdFavoID );
        WebAgent.SuccAndGo( "删除成功！", string.IsNullOrEmpty( Request.UrlReferrer + "" ) ? "/User/FavoriteList.aspx" : Request.UrlReferrer.ToString() );
    }
}
