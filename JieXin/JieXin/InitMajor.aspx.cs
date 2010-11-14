using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using AnyWell.AW_DL;

public partial class AnyWell_InitMajor : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    protected void Page_Load( object sender, EventArgs e )
    {
        List<AW_Major_bean> list = new AW_Major_dao().funcInitMajor();
        str.AppendLine( "var majors = new Array();" );
        InitMajorString( list );
        Response.Write( str.ToString() );
    }

    protected void InitMajorString( List<AW_Major_bean> list )
    {
        foreach( AW_Major_bean bean in list )
        {
            if( bean.Children.Count > 0 )
            {
                MajorString( list, bean.fdMajoID );
                InitMajorString( bean.Children );
            }
        }
    }

    protected void MajorString( List<AW_Major_bean> list, int majorID )
    {
        foreach( AW_Major_bean bean in list )
        {
            if( bean.fdMajoID == majorID && bean.Children.Count > 0 )
            {
                string strTemp = "";
                foreach( AW_Major_bean child in bean.Children )
                {
                    strTemp += string.Format( ",\"{0}|{1}\"", child.fdMajoName, child.fdMajoID );
                }
                str.AppendLine( "majors[" + bean.fdMajoID + "] = new Array(" + strTemp.Substring( 1 ) + ");" );
            }
        }
    }
}
