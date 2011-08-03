<%@ WebHandler Language="C#" Class="ArticlePicUpload" %>

using System;
using System.Web;
using System.IO;
using Studio.Web;
using AnyWell.Configs;

public class ArticlePicUpload : IHttpHandler
{
    private HttpContext ctx;
    public void ProcessRequest( HttpContext context )
    {
        ctx = context;
        string uploadPath = context.Server.MapPath( "Files" );
        if( !string.IsNullOrEmpty( context.Request.QueryString[ "filepath" ] ) )
        {
            uploadPath = context.Server.MapPath( context.Request.QueryString[ "filepath" ] );
            if( !Directory.Exists( uploadPath ) )
            {
                Directory.CreateDirectory( uploadPath );
            }
        }
        FileUploadProcess fileUpload = new FileUploadProcess();
        fileUpload.FileUploadCompleted += new FileUploadCompletedEvent( fileUpload_FileUploadCompleted );
        if( GeneralConfigs.GetConfig().ImageWatermarkType != 0 || GeneralConfigs.GetConfig().ArticleImageWidth > 0 )
        {
            fileUpload.filename = "temp_" + context.Request.QueryString[ "filename" ];
        }
        fileUpload.ProcessRequest( context, uploadPath );
    }

    void fileUpload_FileUploadCompleted( object sender, FileUploadCompletedEventArgs args )
    {
        string filePath = Path.Combine( args.FilePath, args.FileName );
        string ThumbPath = Path.Combine( args.FilePath, args.FileName.Substring( 5 ) );
        if( GeneralConfigs.GetConfig().ArticleImageWidth > 0 )
        {
            WebAgent.MakeThumbnail( filePath, ThumbPath, GeneralConfigs.GetConfig().ArticleImageWidth, GeneralConfigs.GetConfig().ArticleImageHeight, "W", WebAgent.GetImageType( args.Extension ) );
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}