using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Content_ColumnDel : PageAdmin
{
    AW_Column_dao dao = new AW_Column_dao();
    protected void Page_Load( object sender, EventArgs e )
    {
        string ids = QS( "ids" ).Trim();
        if( string.IsNullOrEmpty( ids ) )
        {
            ShowError( "请选择栏目！" );
        }

        if( !IsPostBack )
        {
            List<AW_Column_bean> columns = new List<AW_Column_bean>();
            foreach( string str in ids.Split( ',' ) )
            {
                if( str == "" )
                    continue;
                columns.Add( dao.funcGetColumnInfo( int.Parse( str ) ) );
            }
            repColumns.DataSource = columns;
            repColumns.DataBind();
        }
        else
        {
            AW_Column_bean parent = new AW_Column_bean();
            foreach( string str in ids.Split( ',' ) )
            {
                if( str == "" )
                    continue;
                AW_Column_bean column = dao.funcGetColumnInfo( int.Parse( str ) );

                if( column != null )
                {
                    if( dao.funcDelete( int.Parse( str ) ) > 0 )
                    {
                        if( column.Children != null && column.Children.Count > 0 )
                        {
                            funcDeleteChild( column.Children );
                        }

                        if( column.Parent == null )
                        {
                            column.Site.Columns.Remove( column );
                        }
                        else
                        {
                            column.Parent.Children.Remove( column );
                        }

                        AddLog( EventType.Delete, "删除栏目", string.Format( "删除栏目:{0}({1})", column.fdColuName, column.fdColuID ) );
                    }
                }
            }

            Response.Write( string.Format( "<script type=text/javascript>parent.delColumnOK('{0}');</script>", ids ) );
            Response.End();
        }
    }

    void funcDeleteChild( List<AW_Column_bean> list )
    {
        foreach( AW_Column_bean column in list )
        {
            dao.funcDelete( column.fdColuID );

            if( column.Children != null && column.Children.Count > 0 )
            {
                funcDeleteChild( column.Children );
            }
        }
    }
}
