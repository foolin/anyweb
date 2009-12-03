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

public partial class VenditionStat :AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.rdzdy.Attributes.Add("onclick", "javascript:GetData();");
            this.rd1M.Attributes.Add("onclick", "javascript:GetData();");
            this.rd2D.Attributes.Add("onclick", "javascript:GetData();");
            this.rd3M.Attributes.Add("onclick", "javascript:GetData();");
            this.rdmo.Attributes.Add("onclick", "javascript:GetData();");

            ArrayList list = (new CategoryAgent()).GetCategoryNameByType();
            Category c = new Category();
            c.ID = 0;
            c.Name = "所有类别";
            list.Insert(0, c);
            ddlCategory.DataSource = list;
            ddlCategory.DataBind();

            DateTime starttime = DateTime.Now.AddDays(-1000);
            DateTime endtime = DateTime.Now;
            int recount = 0;
            this.repGoods.DataSource = (new GoodsAgent()).GetVenditionStat(0,starttime, endtime, PN1.PageSize, PN1.PageIndex, out recount);
            this.repGoods.DataBind();
            PN1.SetPage(recount);
        }
    }
    protected void rdmo_CheckedChanged(object sender, EventArgs e)
    {
        DateTime starttime = Convert.ToDateTime("2008/3/1");
        if (rdmo.Checked)
        {
            starttime = Convert.ToDateTime("2008/3/1");
        }
        if (rd2D.Checked)
        {
            starttime = DateTime.Now.AddDays(-14);
        }
        if (rd1M.Checked)
        {
            starttime = DateTime.Now.AddMonths(-1);
        }
        if (rd3M.Checked)
        {
            starttime = DateTime.Now.AddMonths(-3);
        }

        DateTime endtime = DateTime.Now;

        int recount = 0;
        this.repGoods.DataSource = (new GoodsAgent()).GetVenditionStat(0,starttime, endtime, PN1.PageSize, PN1.PageIndex, out recount);
        this.repGoods.DataBind();
        PN1.SetPage(recount);

    }
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        if (WebAgent.IsDate(txtStart.Text) && WebAgent.IsDate(txtEnd.Text))
        {
            DateTime starttime = Convert.ToDateTime(txtStart.Text);
            DateTime endtime = Convert.ToDateTime(txtEnd.Text);

            int categoryid = int.Parse(ddlCategory.SelectedValue);

            int recount = 0;
            this.repGoods.DataSource = (new GoodsAgent()).GetVenditionStat(categoryid, starttime, endtime, PN1.PageSize, PN1.PageIndex, out recount);
            this.repGoods.DataBind();
            PN1.SetPage(recount);
        }
        else
        {
            DateTime starttime = Convert.ToDateTime("2008/3/1");
            DateTime endtime = DateTime.Now;

            int categoryid = int.Parse(ddlCategory.SelectedValue);

            int recount = 0;
            this.repGoods.DataSource = (new GoodsAgent()).GetVenditionStat(categoryid, starttime, endtime, PN1.PageSize, PN1.PageIndex, out recount);
            this.repGoods.DataBind();
            PN1.SetPage(recount);
        }
    }
}
