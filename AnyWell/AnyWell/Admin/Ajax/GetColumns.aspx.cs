using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_Ajax_GetColumns : AjaxPageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        StringBuilder sb = new StringBuilder();
        int idx = 1;
        if( !string.IsNullOrEmpty(QS( "siteid" )) && WebAgent.IsInt32( QS( "siteid" ) ) )
        {
            AW_Site_bean site = new AW_Site_dao().funcGetSiteInfo( int.Parse( QS( "siteid" ) ) );
            if( site != null )
            {
                foreach( AW_Column_bean column in site.Columns )
                {
                    sb.AppendFormat( "c = new column(s, \"{0}\", \"{1}\", {2}, \"{3}\",{4});c.site = s;columns.push(c);", column.fdColuID, column.fdColuName, idx++, (ColumnType)column.fdColuType, ( column.Children != null && column.Children.Count > 0 ? "true" : "false" ) );
                }
            }
            else
            {
                RenderString( "alert(\"站点不存在！\");" );
            }
        }
        if( QS( "parentid" ) != "" && WebAgent.IsInt32( QS( "parentid" ) ) )
        {
            AW_Column_bean column = new AW_Column_dao().funcGetColumnInfo( int.Parse( QS( "parentid" ) ) );
            if( column == null )
                RenderString( "alert(\"栏目不存在！\");" );
            if( column.Children != null )
            {
                foreach( AW_Column_bean col in column.Children )
                {
                    sb.AppendFormat( "child = new column(null, \"{0}\", \"{1}\", {2}, \"{3}\",{4});child.parent = c;columns.push(child);", col.fdColuID, col.fdColuName, idx++, (ColumnType)col.fdColuType, ( col.Children != null && col.Children.Count > 0 ? "true" : "false" ) );
                }
            }
        }
        RenderString( sb.ToString() );
    }
}
