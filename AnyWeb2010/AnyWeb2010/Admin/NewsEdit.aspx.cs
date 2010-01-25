using System;
using System.Collections;
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

public partial class Admin_NewsEdit : ShopAdmin
{
    protected AW_News_bean news;

    protected void Page_Load(object sender, EventArgs e)
    {
        string id = QS("id");

        if (!WebAgent.IsInt32(id)) WebAgent.AlertAndBack("编号不正确!");

        news = AW_News_bean.funcGetByID(QS("id"));

        if (news == null) WebAgent.AlertAndBack("新闻不存在!");
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        txtTitle.Text = news.fdNewsTitle;
        txtContent.Text = news.fdNewsContent;

        foreach (AW_News_Column_bean bean1 in (new AW_News_Column_dao()).funcGetColumns())
        {
            drpColumn.Items.Add(new ListItem(bean1.fdColuName, bean1.fdColuID.ToString()));
            foreach (AW_News_Column_bean bean2 in bean1.Children)
            {
                drpColumn.Items.Add(new ListItem(bean1.fdColuName + "-" + bean2.fdColuName, bean2.fdColuID.ToString()));
            }
        }
        drpColumn.SelectedValue = news.fdNewsColumnID.ToString();
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        using (AW_News_dao dao = new AW_News_dao())
        {
            news.fdNewsTitle = txtTitle.Text.Trim();
            news.fdNewsColumnID = int.Parse(drpColumn.SelectedValue);
            news.fdNewsContent = txtContent.Text;

            dao.funcUpdate(news);
            WebAgent.SuccAndGo("修改新闻成功", "NewsList.aspx?cid=" + news.fdNewsColumnID.ToString());
        }
    }

}
