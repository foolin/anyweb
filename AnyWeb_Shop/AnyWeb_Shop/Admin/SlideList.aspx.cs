using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Admin.Framework;
using Studio.Web;
using Common.Agent;

public partial class SlideList :AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {
      
        
    }

    protected override void OnPreRender(EventArgs e)
    {
        if ( QS( "mode" ) == "delete" )
        {
            if ( WebAgent.IsInt32( QS( "sid" ) ) )
            {
                using ( SlideAgent sa = new SlideAgent() )
                {
                    if ( sa.SlideDelete( int.Parse( QS( "sid" ) ) ) > 0 )
                    {
                        Response.Redirect( "SlideList.aspx" );
                    }
                }
            }
        }
       
    }
}
