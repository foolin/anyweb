<%@ WebHandler Language="C#" Class="ArticleFlashUpload" %>

using System;
using System.Web;
using System.IO;
using Studio.Web;
using AnyWell.Configs;

public class ArticleFlashUpload : IHttpHandler
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
        
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}