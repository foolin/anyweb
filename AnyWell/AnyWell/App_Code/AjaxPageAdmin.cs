using System;
using System.Collections.Generic;
using System.Web;
using AnyWell.AW_DL;

/// <summary>
///AjaxPageAdmin 的摘要说明
/// </summary>
public class AjaxPageAdmin : PageAdmin
{
    protected override void OnPreInit( EventArgs e )
    {
        AdminInfo = ( new AW_Admin_dao() ).funcGetAdminFromCookie();
        if( AdminInfo == null )
        {
            RenderString( "" );
        }
    }

    /// <summary>
    /// 输出字符串
    /// </summary>
    /// <param name="content"></param>
    protected void RenderString( string content )
    {
        Response.Clear();
        Response.Write( content );
        Response.End();
    }

    public string QS( string key )
    {
        return Request.QueryString[ key ] + "";
    }

    public string QF( string key )
    {
        return Request.Form[ key ] + "";
    }
}
