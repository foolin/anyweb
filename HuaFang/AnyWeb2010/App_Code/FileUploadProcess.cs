using System;
using System.Collections.Generic;
using System.Web;
using System.IO;


public delegate void FileUploadCompletedEvent(object sender, FileUploadCompletedEventArgs args);
public class FileUploadCompletedEventArgs
{
    private string filename;
    public string FileName
    {
        get
        {
            return filename;
        }
        set
        {
            filename = value;
        }
    }
    private string filepath;
    public string FilePath
    {
        get
        {
            return filepath;
        }
        set
        {
            filepath = value;
        }
    }
    private string _extension;
    public string Extension
    {
        get
        {
            return _extension;
        }
        set
        {
            _extension = value;
        }
    }

    public FileUploadCompletedEventArgs()
    {
    }

    public FileUploadCompletedEventArgs( string fileName, string filePath, string extension )
    {
        FileName = fileName;
        FilePath = filePath;
        Extension = extension;
    }
}

public class FileUploadProcess
{
    public event FileUploadCompletedEvent FileUploadCompleted;
    /// <summary>
    /// Determines if uploaded files should be renamed according to the user uploading them, otherwise if
    /// multiple users upload a file of the same name, it would try to save the file to the same name, throwing an error.
    /// Another way to prevent this is to create a seperate folder for each file.
    /// </summary>
    private bool uniqueuserupload;
    public bool UniqueUserUpload
    {
        get
        {
            return uniqueuserupload;
        }
        set
        {
            uniqueuserupload = value;
        }
    }

    private string _filename;
    public string filename
    {
        get
        {
            return _filename;
        }
        set
        {
            _filename = value;
        }
    }

    public FileUploadProcess()
    {
    }

    public void ProcessRequest( HttpContext context, string uploadPath )
    {
        if( string.IsNullOrEmpty( filename ) )
        {
            filename = context.Request.QueryString[ "filename" ];
        }
        bool complete = string.IsNullOrEmpty( context.Request.QueryString[ "Complete" ] ) ? true : bool.Parse( context.Request.QueryString[ "Complete" ] );
        bool getBytes = string.IsNullOrEmpty( context.Request.QueryString[ "GetBytes" ] ) ? false : bool.Parse( context.Request.QueryString[ "GetBytes" ] );
        long startByte = string.IsNullOrEmpty( context.Request.QueryString[ "StartByte" ] ) ? 0 : long.Parse( context.Request.QueryString[ "StartByte" ] );
        
        string filePath;
        if( UniqueUserUpload )
        {
            if( context.User.Identity.IsAuthenticated )
            {
                filePath = Path.Combine( uploadPath, string.Format( "{0}_{1}", context.User.Identity.Name.Replace( "\\", "" ), filename ) );
            }
            else
            {
                if( context.Session[ "fileUploadUser" ] == null )
                    context.Session[ "fileUploadUser" ] = Guid.NewGuid();
                filePath = Path.Combine( uploadPath, string.Format( "{0}_{1}", context.Session[ "fileUploadUser" ], filename ) );
            }
        }
        else
            filePath = Path.Combine( uploadPath, filename.Replace( "S_", "" ) );

        if( getBytes )
        {
            FileInfo fi = new FileInfo( filePath );
            if( !fi.Exists )
                context.Response.Write( "0" );
            else
                context.Response.Write( fi.Length.ToString() );

            context.Response.Flush();
            return;
        }
        else
        {

            if( startByte > 0 && File.Exists( filePath ) )
            {
                using( FileStream fs = File.Open( filePath, FileMode.Append ) )
                {
                    SaveFile( context.Request.InputStream, fs );
                    fs.Close();
                }
            }
            else
            {
                using( FileStream fs = File.Create( filePath ) )
                {
                    SaveFile( context.Request.InputStream, fs );
                    fs.Close();
                }
            }
            if( complete )
            {
                if( FileUploadCompleted != null )
                {
                    FileInfo fi = new FileInfo( filePath );
                    FileUploadCompletedEventArgs args = new FileUploadCompletedEventArgs( filename, uploadPath, fi.Extension );
                    FileUploadCompleted( this, args );
                }
            }
        }
    }

    private void SaveFile( Stream stream, FileStream fs )
    {
        byte[] buffer = new byte[ 4096 ];
        int bytesRead;
        while( ( bytesRead = stream.Read( buffer, 0, buffer.Length ) ) != 0 )
        {
            fs.Write( buffer, 0, bytesRead );
        }
    }
}

