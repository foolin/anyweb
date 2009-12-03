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
using Common.Agent;
using Studio.Web;
using Common.Common;

public partial class OrderList :AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {

    }

    protected void btnSearch_Click(object sender , EventArgs e)
    {
      
        Response.Redirect( "OrderList.aspx?username=" + txtUserName.Text + "&orderid=" + txtOrderID.Text + "&starttime=" + txtData.Text + "&endtime=" + txtDataEnd.Text + "&status=" + drpStatus.SelectedValue+"&orderdate="+txtorderdate.Text +"&orderdate2="+txtorderdate2.Text );
    }

    protected void ods3_Selected(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( e.OutputParameters["record"] != null)
        {
            PN1.SetPage((int)e.OutputParameters["record"]  );
        }
        drpStatus.SelectedValue = QS( "status" );

    }

    protected void ods3_Selecting(object sender , ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["username"] = QS( "username" ); 
    }


    public string GetStatus( int status)
    {
        switch(status)
        {

            case 2:
                return "<font color='green'>已发货</font>";
            case 3:
                return "<font color='gray'>取消发货</font>";
            default:
                return "<font color='red'>未处理</font>";
        
        }
    }

    protected void btnDel_Click(object sender , EventArgs e)
    {
        using ( OrderAgent oa = new OrderAgent() )
        {
            if ( Request.Form["ids"] + "" != "" )
            {
                oa.OrderDelete( Request.Form["ids"] , Request.Form["ids"].Split( ',' ).Length );
            
                this.AddLog( EventID.Delete , "批量删除订单" , "批量删除订单,订单编号:"+Request.Form["ids"] );

                WebAgent.SuccAndGo( "删除成功。" , "OrderList.aspx" );
            }
            else
            {
                WebAgent.FailAndGo( "请在要删除的项前打勾。" , "OrderList.aspx" );
            }
        }
        
      
    }
}
