using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class GetBandCode : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        string code = QS( "code" );
        if( string.IsNullOrEmpty(code) )
        {
            Fail( "" );
        }

        BandCode.Code39 _Code39 = new BandCode.Code39();

        _Code39.Height = 50;
        _Code39.Magnify = 1;
        _Code39.ViewFont = new Font( "宋体", 20 );


        System.Drawing.Image _CodeImage = _Code39.GetCodeImage( code, BandCode.Code39.Code39Model.Code39Normal, true );

        System.IO.MemoryStream _Stream = new System.IO.MemoryStream();
        _CodeImage.Save( _Stream, System.Drawing.Imaging.ImageFormat.Jpeg );

        Response.ContentType = "image/jpeg";
        Response.Clear();
        Response.BufferOutput = true;
        Response.BinaryWrite( _Stream.GetBuffer() );
        Response.Flush();

    }
}
