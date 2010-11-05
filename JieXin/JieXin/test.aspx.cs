using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


public partial class test : System.Web.UI.Page
{
    protected void Page_Load( object sender, EventArgs e )
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine( "=EF=BB=BF<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" = \"http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd\">" );
        sb.AppendLine( "<HTML>" );
        sb.AppendLine( "<BODY>" );
        sb.AppendLine( "<b>Word文档</b>" );
        sb.AppendLine( "     <table><tr><td>  . 待办任务 任务数量</td>" );
        sb.AppendLine( " <td>    1 设备采购申请 6 deviced_apply </td>  " );
        sb.AppendLine( "<td>     2 生产厂商信息登记 14 provider </td>  " );
        sb.AppendLine( " <td>    3 设备质量索赔记录 142 </td>" );
        sb.AppendLine( "<td><img src=\"images/img_19.jpg\" /></td>" );
        sb.AppendLine( "</tr> </table> " );
        sb.AppendLine( "</BODY>" );
        sb.AppendLine( "</HTML>" );
        SaveAsDoc( sb.ToString() );
    }

    /// <summary>
    /// 编码的静态方法
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

    public void SaveAsDoc(string str)
    {
        string t1 = "src=\"((.|\n)*?)\"";
        string t2 = "src=3D\"$1\"";
        StringBuilder imageSb = new StringBuilder();

        StringBuilder sb = new StringBuilder();
        sb.Append( "MIME-Version: 1.0\n" );
        sb.Append( "Content-Type: multipart/related;\n" );
        sb.Append("	type=\"text/html\";\n");
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
            string strLink = m.ToString().Substring( 5, m.ToString().Length - 6 );
            string strBianm = ConvertBase64( this, strLink );
            if( strBianm != "" )
            {
                string strW = "Content-Location:" + strLink;
                imageSb.Append( "\n" );
                imageSb.Append( "------=_NextPart\n" );
                imageSb.Append( "Content-Type: image/jpeg\n" );
                imageSb.Append( "Content-Transfer-Encoding: base64\n" );
                imageSb.Append( strW + "\n" );
                imageSb.Append( "\n" );
                imageSb.Append( strBianm + "\n" );
                imageSb.Append( "------=_NextPart--\n" );
                imageSb.Append( "\n" );
            }
        }

        str = Regex.Replace( str, t1, t2, RegexOptions.IgnoreCase );
        sb.Append( str );
        sb.Append( "\n" );
        sb.Append( imageSb.ToString() );

        File.WriteAllText( Server.MapPath( "/test.doc" ), sb.ToString() );
    }
}
