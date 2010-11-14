using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using AnyWell.AW_DL;

public partial class AnyWell_InitPosition : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    protected void Page_Load( object sender, EventArgs e )
    {
        List<AW_Job_bean> list = new AW_Job_dao().funcInitJob();
        str.AppendLine( "var wPos = new Array();" );
        InitPositionString( list );
        Response.Write( str.ToString() );
    }

    protected void InitPositionString( List<AW_Job_bean> list )
    {
        foreach( AW_Job_bean bean in list )
        {
            if( bean.Children.Count > 0 )
            {
                PositionString( list, bean.fdJobID );
                InitPositionString( bean.Children );
            }
        }
    }

    protected void PositionString( List<AW_Job_bean> list, int posiID )
    {
        foreach( AW_Job_bean bean in list )
        {
            if( bean.fdJobID == posiID && bean.Children.Count > 0 )
            {
                string strTemp = "";
                foreach( AW_Job_bean child in bean.Children )
                {
                    strTemp += string.Format( ",\"{0}|{1}\"", child.fdJobName, child.fdJobID );
                }
                str.AppendLine( "wPos[" + bean.fdJobID + "] = new Array(" + strTemp.Substring( 1 ) + ");" );
            }
        }
    }
}
