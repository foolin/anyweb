using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.HtmlControls;


public class ArticleBase : PageAdmin
{
    protected override void OnLoad( EventArgs e )
    {
        base.OnLoad( e );
        HtmlForm form = ( HtmlForm ) this.Master.FindControl( "form1" );
        if( form != null )
        {
            form.Target = "ifrSelf";
        }
    }

    /// <summary>
    /// 重写提示信息
    /// </summary>
    /// <param name="msg"></param>
    protected void Success( string msg,string goUrl )
    {
        Response.Clear();
        Response.Write( string.Format( "<script type=text/javascript>alert('{0}');parent.window.location='{1}';</script>", msg, goUrl ) );
        Response.End();
    }

    protected void Fail( string msg )
    {
        Response.Clear();
        Response.Write( string.Format( "<script type=text/javascript>alert('{0}');</script>", msg ) );
        Response.End();
    }
}
