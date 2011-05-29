using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using System.IO;

public partial class Admin_Content_ColumnsDel : PageAdmin
{
    AW_Column_dao dao = new AW_Column_dao();

    protected void Page_Load( object sender, EventArgs e )
    {
        string ids = QS( "ids" ).Trim();
        if( string.IsNullOrEmpty( ids ) )
        {
            ShowError( "请选择栏目！" );
        }

        List<AW_Column_bean> columns = new List<AW_Column_bean>();
        foreach( string str in ids.Split( ',' ) )
        {
            if( str == "" )
                continue;
            columns.Add( dao.funcGetColumnInfo( int.Parse( str ) ) );
        }

        if( !IsPostBack )
        {
            repColumns.DataSource = columns;
            repColumns.DataBind();
        }
        else
        {
            if( dao.funcDeleteColumns( ids ) > 0 )
            {
                foreach( AW_Column_bean column in columns )
                {
                    if( column == null )
                        continue;
                    DeleteColumnFiles( column );
                }
                AddLog( EventType.Delete, "删除栏目", string.Format( "删除栏目[编号：{0}]", ids ) );
                Response.Write( string.Format( "<script type=text/javascript>parent.delColumnsOK('{0}');</script>", ids ) );
                Response.End();
            }
            else
            {
                Fail( "栏目删除失败，请稍候再试！", true );
            }
        }
    }

    /// <summary>
    /// 删除已发布的静态文件
    /// </summary>
    /// <param name="column"></param>
    void DeleteColumnFiles( AW_Column_bean column )
    {
        DirectoryInfo dirColumn = new DirectoryInfo( string.Format( "{0}\\{1}\\{2}\\", Server.MapPath( "~/" ), column.Site.fdSitePath, column.fdColuID ) );
        if( dirColumn.Exists )
        {
            dirColumn.Delete( true );
        }
        //级联删除所有子栏目页
        foreach( AW_Column_bean childColumn in column.Children )
        {
            DeleteColumnFiles( childColumn );
        }
    }
}
