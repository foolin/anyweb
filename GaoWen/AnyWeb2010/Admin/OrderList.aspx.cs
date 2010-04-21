using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using AnyWeb.AW_DL;
using Studio.Web;

public partial class Admin_OrderList : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        switch (this.QS("type"))
        {
            case "del":
                (new AW_Order_dao()).funcDelete(int.Parse(this.QS("id")));
                WebAgent.SuccAndGo("删除成功", "OrderList.aspx");
                break;
            case "dels":
                if (this.QF("ids") != "")
                {
                    (new AW_Order_dao()).funcDeletes(this.QF("ids"));
                    WebAgent.SuccAndGo("删除成功", "OrderList.aspx");
                }
                break;
            default:
                break;
        }

        if (this.QS("status") != "")
        {
            this.drpStatus.SelectedValue = this.QS("status");
        }

        if (this.QS("startDate") != "")
        {
            this.txtStartDate.Text = this.QS("startDate");
        }

        if (this.QS("endDate") != "")
        {
            this.txtEndDate.Text = this.QS("endDate");
        }

        //绑定rep
        using (AW_Order_dao dao = new AW_Order_dao())
        {
            if (this.drpStatus.SelectedValue != "0")
            {
                dao.propWhere = "fdOrdeStatus = " + this.drpStatus.SelectedValue;
            }

            if (this.txtStartDate.Text != "")
            {
                dao.propWhere += " AND fdOrdeCreateAt >= '" + this.txtStartDate.Text + "'";
            }

            if (this.txtEndDate.Text != "")
            {
                dao.propWhere += " AND fdOrdeCreateAt <= '" + this.txtEndDate.Text + "'";
            }

            dao.propOrder = "ORDER BY fdOrdeCreateAt desc";
            dao.propGetCount = true;
            dao.propPage = this.PN1.PageIndex;
            dao.propPageSize = this.PN1.PageSize;
            
            this.repOrders.DataSource = dao.funcGetList();
            this.repOrders.DataBind();

            this.PN1.SetPage(dao.propCount);
            this.litRecords.Text = dao.propCount.ToString();

            if (dao.propCount == 0)
            {
                this.rowNull.Visible = true;
                tableFooter.Visible = false;
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderList.aspx?status="+this.drpStatus.SelectedValue
                          +"&startDate="+this.txtStartDate.Text
                          +"&endDate="+this.txtEndDate.Text);
    }
}