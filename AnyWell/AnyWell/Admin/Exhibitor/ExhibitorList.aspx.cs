using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Exhibitor_ExhibitorList : PageAdmin
{
    private string field = "";
    private string orderBy = "";
    private bool getChildren = false;

    protected void Page_Load( object sender, EventArgs e )
    {
        int cid = 0;

        int.TryParse( QS( "cid" ), out cid );

        if( cid == 0 )
        {
            ShowError( "请选择栏目！" );
        }

        AW_Column_dao dao = new AW_Column_dao();
        CurrentColumn = dao.funcGetColumnInfo( cid );
        if( CurrentColumn == null )
        {
            ShowError( "栏目不存在！" );
        }

        field = QS( "field" );

        orderBy = QS( "orderby" ) == "1" ? "ASC" : "DESC";

        getChildren = !string.IsNullOrEmpty( QS( "getch" ) ) && QS( "getch" ) == "1" ? true : false;

        int recordCount = 0;
        List<AW_Exhibitor_bean> list = new AW_Exhibitor_dao().funcGetExhibitorList( CurrentColumn, getChildren, field, orderBy, PN1.PageIndex, PN1.PageSize, out recordCount );
        if( list.Count == 0 )
        {
            noDatas.Visible = true;
            tableFooter.Visible = false;
        }
        else
        {
            repExhibitors.DataSource = list;
            repExhibitors.DataBind();
            PN1.SetPage( recordCount );
            litRecords.Text = recordCount.ToString();
        }
    }

    /// <summary>
    /// 获取排序JS函数
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    protected string getOrderJs( string key )
    {
        return string.Format( "setOrder({0},{1},'{2}',{3})", CurrentColumn.fdColuID, getChildren ? 1 : 0, key, key == field ? orderBy == "ASC" ? 0 : 1 : 1 );
    }

    /// <summary>
    /// 获取排序样式
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    protected string getOrderCssClass( string key )
    {
        if( field == key )
        {
            return orderBy.ToLower();
        }
        else
        {
            return "";
        }
    }
}
