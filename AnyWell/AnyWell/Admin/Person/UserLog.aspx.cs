using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Person_UserLog : PageAdmin
{
    private string field = "";
    private string orderBy = "";
    protected void Page_Load( object sender, EventArgs e )
    {
        string key = QS( "key" ).Trim();

        field = QS( "field" );

        orderBy = QS( "orderby" ) == "1" ? "ASC" : "DESC";

        int recordCount = 0;
        List<AW_Log_bean> list = new AW_Log_dao().funcGetLogList( AdminInfo.fdAdmiID, key, field, orderBy, PN1.PageIndex, PN1.PageSize, out recordCount );
        if( list.Count == 0 )
        {
            noDatas.Visible = true;
            tableFooter.Visible = false;
        }
        else
        {
            repLogs.DataSource = list;
            repLogs.DataBind();
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
        return string.Format( "setLogOrder('{0}',{1})", key, key == field ? orderBy == "ASC" ? 0 : 1 : 1 );
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
