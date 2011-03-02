<%@ WebHandler Language="C#" Class="FileUpload" %>

using System;
using System.Web;
using System.IO;
using Studio.Web;

public class FileUpload : IHttpHandler {
    private HttpContext ctx;
    public void ProcessRequest (HttpContext context) {
        ctx = context;
        string uploadPath = context.Server.MapPath( "/Files" );
        if( !string.IsNullOrEmpty( context.Request.QueryString[ "filepath" ] ) )
        {
            uploadPath = context.Server.MapPath( context.Request.QueryString[ "filepath" ] );
        }
        FileUploadProcess fileUpload = new FileUploadProcess();
        fileUpload.FileUploadCompleted += new FileUploadCompletedEvent( fileUpload_FileUploadCompleted );
        fileUpload.ProcessRequest( context, uploadPath );
    }

    void fileUpload_FileUploadCompleted( object sender, FileUploadCompletedEventArgs args )
    {
        string filePath = Path.Combine( args.FilePath, args.FileName.Replace( "S_", "" ) );
        string ThumbPath = Path.Combine( args.FilePath, args.FileName );
        WebAgent.MakeThumbnail( filePath, ThumbPath, 100, 100, "W", WebAgent.GetImageType( args.Extension ) );
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}