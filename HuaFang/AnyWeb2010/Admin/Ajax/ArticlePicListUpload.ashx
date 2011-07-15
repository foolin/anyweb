<%@ WebHandler Language="C#" Class="ArticlePicListUpload" %>

using System;
using System.Web;
using System.IO;
using Studio.Web;
using AnyWell.Configs;

public class ArticlePicListUpload : IHttpHandler
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
        if( GeneralConfigs.GetConfig().ImageWatermarkType != 0 )
        {
            fileUpload.filename = "temp_" + context.Request.QueryString[ "filename" ];
        }
        fileUpload.ProcessRequest( context, uploadPath );
    }

    void fileUpload_FileUploadCompleted( object sender, FileUploadCompletedEventArgs args )
    {
        int ThumbWidth = 398, ThumbHeight = 628;
        string filePath = Path.Combine( args.FilePath, args.FileName );
        string ThumbPath = Path.Combine( args.FilePath, "S_" + args.FileName );

        ImageWaterMark wm = new ImageWaterMark();
        switch( GeneralConfigs.GetConfig().ImageWatermarkType )
        {
            case 0:
                if( GeneralConfigs.GetConfig().ArticleImageWidth > 0 )
                {
                    WebAgent.MakeThumbnail( filePath, ThumbPath, ThumbWidth, ThumbHeight, "W", WebAgent.GetImageType( args.Extension ) );
                }
                break;
            case 1:
                wm.SaveWaterMarkImageByText(
                    args.FileName,
                    args.FileName.Substring( 5 ),
                    args.FilePath,
                    GeneralConfigs.GetConfig().ImageWatermarkText,
                    GeneralConfigs.GetConfig().ImageWatermarkFontFamily,
                    GeneralConfigs.GetConfig().ImageWatermarkFontsize,
                    GeneralConfigs.GetConfig().ImageWatermarkFontColor,
                    GeneralConfigs.GetConfig().ImageWatermarkShadowColor,
                    wm.GetTextCSS( GeneralConfigs.GetConfig().ImageWatermarkFontCss ),
                    GeneralConfigs.GetConfig().ImageWatermarkTransparency,
                    3,
                    -3,
                    GeneralConfigs.GetConfig().ImageWatermarkAngle,
                    wm.GetImageAlign( GeneralConfigs.GetConfig().ImageWatermarkPosition ),
                    0,
                    0,
                    ThumbWidth,
                    ThumbHeight,
                    true
                    );
                break;
            case 2:
                wm.SaveWaterMarkImageByPic(
                    args.FileName,
                    args.FileName.Substring( 5 ),
                    args.FilePath,
                    ctx.Server.MapPath( GeneralConfigs.GetConfig().ImageWatermarkUrl ),
                    GeneralConfigs.GetConfig().ImageWatermarkAngle,
                    wm.GetImageAlign( GeneralConfigs.GetConfig().ImageWatermarkPosition ),
                    0,
                    0,
                    ThumbWidth,
                    ThumbHeight,
                    true
                    );
                break;
            default:
                break;
        }
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}