using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Studio.Web;

public partial class Admin_FileDel : PageAdmin
{
    protected override void OnPreRender( EventArgs e )
    {
        base.OnPreRender( e );

        string fileName = ( QS( "path" ) + "/" + QS( "link" ) ).Replace( "//", "/" );
        string extensions = ".jpg.png.gif.bmp.zip.rar.doc.xls.ppt.pdf.txt.log";

        FileInfo fi = new FileInfo( Server.MapPath( fileName ) );
        if( !fi.Exists )
        {
            WebAgent.AlertAndBack( "文件不存在" );
        }
        else if( !extensions.Contains( fi.Extension.ToLower() ) )
        {
            WebAgent.AlertAndBack( "文件类型不允许删除" );
        }
        else
        {
            fi.Delete();
            WebAgent.SuccAndGo( "删除成功", "filelist.aspx?path=" + QS( "path" ) );
        }
    }
}
