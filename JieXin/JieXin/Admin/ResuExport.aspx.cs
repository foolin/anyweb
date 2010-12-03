using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

public partial class Admin_ResuExport : Page
{
    protected override void OnPreRender( EventArgs e )
    {
        if( string.IsNullOrEmpty( QS( "id" ) ) || !WebAgent.IsInt32( QS( "id" ) ) )
        {
            WebAgent.FailAndGo( "简历不存在！", "/Admin/Index.aspx" );
        }

        AW_Resume_bean bean = new AW_Resume_dao().funcGetResume( int.Parse( QS( "id" ) ), false );
        if( bean == null )
        {
            WebAgent.FailAndGo( "简历不存在！", "/Admin/Index.aspx" );
        }

        Context.Items.Add( "RESUME", bean );
    }

    protected override void Render( HtmlTextWriter writer )
    {
        TextWriter strWriter = new StringWriter();
        base.Render( new HtmlTextWriter( strWriter ) );
        string path = SaveAsDoc( strWriter.ToString() );
        Response.Redirect( path );
    }

    /// <summary>
    /// 保存doc文件
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public string SaveAsDoc( string str )
    {
        string fileName = "";
        if( !string.IsNullOrEmpty( QS( "name" ) ) )
        {
            fileName = QS( "name" );
        }
        else
        {
            fileName = DL_helper.funcGetTicks().ToString();
        }
        string savePath = "/Files/Resume/";
        string path = savePath + fileName + ".doc";
        if( !Directory.Exists( Server.MapPath( savePath ) ) )
        {
            Directory.CreateDirectory( Server.MapPath( savePath ) );
        }

        string t1 = "src=3D\"((.|\n)*?)\"";
        StringBuilder imageSb = new StringBuilder();

        StringBuilder sb = new StringBuilder();
        sb.Append( "MIME-Version: 1.0\n" );
        sb.Append( "Content-Type: multipart/related;\n" );
        sb.Append( "	type=\"text/html\";\n" );
        sb.Append( "	boundary=\"----=_NextPart\"\n" );
        sb.Append( "X-MimeOLE: Produced By Microsoft MimeOLE V6.1.7600.16543\n" );
        sb.Append( "\n" );
        sb.Append( "------=_NextPart\n" );
        sb.Append( "Content-Type: text/html;\n" );
        sb.Append( "	charset=\"utf-8\"\n" );
        sb.Append( "Content-Transfer-Encoding: quoted-printable\n" );
        sb.Append( "\n" );

        string[] j = new string[] { "src\"", "\"" };

        Regex re = new Regex( t1 );

        foreach( Match m in re.Matches( str ) )
        {
            string strLink = m.ToString().Substring( 7, m.ToString().Length - 8 );
            string strBianm = ConvertBase64( this, strLink );
            if( strBianm != "" )
            {
                string strW = "Content-Location:" + strLink;
                imageSb.Append( "\n" );
                imageSb.Append( "------=_NextPart\n" );
                if( strLink.ToLower().IndexOf( "bmp" ) > -1 )
                {
                    imageSb.Append( "Content-Type: image/bmp\n" );
                }
                else
                {
                    imageSb.Append( "Content-Type: image/jpeg\n" );
                }
                imageSb.Append( "Content-Transfer-Encoding: base64\n" );
                imageSb.Append( strW + "\n" );
                imageSb.Append( "\n" );
                imageSb.Append( strBianm + "\n" );
            }
        }

        if( imageSb.Length > 0 )
        {
            imageSb.Append( "------=_NextPart--\n" );
            imageSb.Append( "\n" );
        }

        sb.Append( str );
        sb.Append( "\n" );
        sb.Append( imageSb.ToString() );

        File.WriteAllText( Server.MapPath( path ), sb.ToString() );
        return path;
    }

    /// <summary>
    /// 编码的方法
    /// </summary>
    /// <param name="filepath"></param>
    /// <returns>编码后的字符串</returns>
    public string ConvertBase64( Page pg, string filepath )
    {
        //变量
        string result = string.Empty;

        string path = string.Empty;
        if( filepath.Trim().Substring( 0, 4 ) == "http" )
        {
            result = string.Empty;
        }
        else
        {
            path = pg.Server.MapPath( filepath );
            if( !File.Exists( path ) )
                return "";
            //将文件转换为stream
            using( FileStream fs = new FileStream( path, FileMode.Open ) )
            {
                byte[] buffer = new byte[ fs.Length ];
                fs.Read( buffer, 0, buffer.Length );
                result = Convert.ToBase64String( buffer ); //base64编码
            }

        }
        //返回编码后的字符串
        return result;
    }

    private string QS( string key )
    {
        return Request.QueryString[ key ] + "";
    }
}
