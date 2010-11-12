using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using System.IO;
using Studio.Web;

public partial class User_PhotoUpload : PageUser
{
    protected void Page_Load( object sender, EventArgs e )
    {
        if( Request.Files.Count == 0 )
        {
            Response.Write( "1:请选择上传的照片！" );
        }
        else if( Request.Files[ 0 ].ContentLength == 0 )
        {
            Response.Write( "2:请选择上传的照片！" );
        }
        else if( !Request.Files[ 0 ].ContentType.Contains( "image" ) )
        {
            Response.Write( "3:您上传的不是图片格式！" );
        }
        else if( Request.Files[ 0 ].ContentLength > 300 * 1024 )
        {
            Response.Write( "4:上传文件错误。文件过大，单个文件请不要超过300K。" );
        }
        else
        {
            string fileName = DL_helper.funcGetTicks().ToString();
            string savePath = "/Files/User/";
            if( !Directory.Exists( Server.MapPath( savePath ) ) )
            {
                Directory.CreateDirectory( Server.MapPath( savePath ) );
            }
            string path = savePath + fileName + Path.GetExtension( Request.Files[ 0 ].FileName );
            WebAgent.SaveFile( Request.Files[ 0 ], Server.MapPath( path ), 0, 0 );
            this.LoginUser.fdUserPhoto = path;
            if( string.IsNullOrEmpty( QS( "type" ) ) )
            {
                new AW_User_dao().funcUpdate( this.LoginUser );
            }
            Response.Write( "0:" + path );
        }
    }
}
