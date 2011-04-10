using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using AnyWell.AW_DL;
using Studio.Web;
using System.Web.UI.WebControls;

/// <summary>
/// 文章页面基类
/// </summary>
public class ArticlePageAdmin : PageAdmin
{
    /// <summary>
    /// 自动生成摘要
    /// </summary>
    /// <param name="str"></param>
    protected void GetDesc( AW_Article_bean bean, bool auto )
    {
        if( auto )
        {
            string str = WebAgent.GetText( bean.fdArtiContent );
            bean.fdArtiDescription = str.Length > 2000 ? str.Substring( 0, 2000 ) : str;
        }
    }

    /// <summary>
    /// 上传文件
    /// </summary>
    /// <param name="uploader"></param>
    /// <returns></returns>
    protected string SaveFile( FileUpload uploader )
    {
        string extension = Path.GetExtension( uploader.PostedFile.FileName ).ToLower();
        string dir = AnyWellSetting.GetSetting().DataRootPath + "/Article";
        if( !Directory.Exists( this.Server.MapPath( dir ) ) )
        {
            Directory.CreateDirectory( this.Server.MapPath( dir ) );
        }
        string fileName = dir + DL_helper.funcGetTicks().ToString() + extension;
        uploader.SaveAs( Server.MapPath( fileName ) );
        return fileName;
    }

    /// <summary>
    /// 上传图片
    /// </summary>
    /// <param name="uploader"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    protected string SaveImage( FileUpload uploader, int width, int height )
    {
        string extensions = ".jpg,.gif,.png";
        string extension = Path.GetExtension( uploader.PostedFile.FileName ).ToLower();

        if( !uploader.PostedFile.ContentType.ToLower().Contains( "image" ) )
        {
            Fail( "文档图片格式错误，请上传jpg,gif,png格式的图片" );
        }

        if( extensions.IndexOf( extension ) == -1 )
        {
            Fail( "文档图片格式错误，请上传jpg,gif,png格式的图片" );
        }

        string dir = AnyWellSetting.GetSetting().DataRootPath + "/Article";
        if( !Directory.Exists( this.Server.MapPath( dir ) ) )
        {
            Directory.CreateDirectory( this.Server.MapPath( dir ) );
        }
        string fileName = dir + DL_helper.funcGetTicks().ToString() + extension;
        WebAgent.SaveFile( uploader.PostedFile, Server.MapPath( fileName ), width, height );
        return fileName;
    }
}
