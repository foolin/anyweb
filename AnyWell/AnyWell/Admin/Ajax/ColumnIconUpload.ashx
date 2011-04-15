<%@ WebHandler Language="C#" Class="ColumnIconUpload" %>

using System;
using System.Web;
using System.IO;
using Studio.Web;

public class ColumnIconUpload : IHttpHandler
{
    private HttpContext ctx;
    public void ProcessRequest (HttpContext context) {
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
        fileUpload.ProcessRequest( context, uploadPath );
    }

    void fileUpload_FileUploadCompleted( object sender, FileUploadCompletedEventArgs args )
    {
        string filePath = Path.Combine( args.FilePath, args.FileName );
        string ThumbPath = Path.Combine( args.FilePath, "S_" + args.FileName );
        WebAgent.MakeThumbnail( filePath, ThumbPath, 32, 32, "W", WebAgent.GetImageType( args.Extension ) );
        File.Delete( filePath );
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}