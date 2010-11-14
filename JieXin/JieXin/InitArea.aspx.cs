using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using System.Text;

public partial class AnyWell_InitArea : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    protected void Page_Load( object sender, EventArgs e )
    {
        List<AW_Area_bean> list = new AW_Area_dao().funcInitArea();
        str.AppendLine( "var areas = new Array();" );
        InitAreaString( list );
        Response.Write( str.ToString() );
    }

    protected void InitAreaString(List<AW_Area_bean> list)
    {
        foreach( AW_Area_bean bean in list )
        {
            if( bean.Children.Count > 0 )
            {
                AreaString( list, bean.fdAreaID );
                InitAreaString( bean.Children );
            }
        }
    }

    protected void AreaString( List<AW_Area_bean> list, int areaID )
    {
        foreach( AW_Area_bean bean in list )
        {
            if( bean.fdAreaID == areaID&&bean.Children.Count>0 )
            {
                string strTemp = "";
                foreach( AW_Area_bean child in bean.Children )
                {
                    strTemp += string.Format( ",\"{0}|{1}\"", child.fdAreaName, child.fdAreaID );
                }
                str.AppendLine( "areas[" + bean.fdAreaID + "] = new Array(" + strTemp.Substring( 1 ) + ");" );
            }
        }
    }
}
