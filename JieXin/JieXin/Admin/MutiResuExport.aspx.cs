using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Net;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using Studio.Web;

public partial class Admin_MutiResuExport : PageAdmin
{
    protected override void OnPreRender( EventArgs e )
    {
        string ids = QS( "ids" );
        List<string> namelist = new List<string>();
        foreach( string id in ids.Split( ',' ) )
        {
            string name = DL_helper.funcGetTicks().ToString();
            string resText = HttpAgent.ReadRemoteFile( string.Format( "http://{0}/Admin/ResuExport.aspx?id={1}&name={2}", Request.Url.Authority, id, name ) );
            namelist.Add( name );
        }
        string savePath = "/Files/Resume/";
        string zipName = string.Format( "{0}{1}.zip", savePath, DL_helper.funcGetTicks().ToString() );
        try
        {
            using( ZipOutputStream s = new ZipOutputStream( File.Create( Server.MapPath( zipName ) ) ) )
            {
                s.SetLevel( 9 );
                foreach( string name in namelist )
                {
                    string path = Server.MapPath( string.Format( "{0}{1}.doc", savePath, name ) );
                    if( File.Exists( path ) )
                    {
                        ZipEntry entry = new ZipEntry( Path.GetFileName( path ) );
                        entry.DateTime = DateTime.Now;
                        s.PutNextEntry( entry );
                        using( FileStream fs = File.OpenRead( path ) )
                        {
                            byte[] buffer = new byte[ fs.Length ];
                            fs.Read( buffer, 0, buffer.Length );
                            s.Write( buffer, 0, buffer.Length );
                        }
                        File.Delete( path );
                    }
                }
                s.Finish();
                s.Close();
            }
            Response.Write( "0" + zipName );
        }
        catch( Exception ex )
        {
            WebAgent.AlertAndBack( "导出失败，请稍后再试！" );
        }
    } 
}
