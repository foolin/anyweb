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

public partial class Admin_ArticleEdit : ShopAdmin
{
    protected AW_Article_bean article;

    protected override void OnPreRender(EventArgs e)
    {
        string id = QS("id");

        if (!WebAgent.IsInt32(id)) WebAgent.AlertAndBack("编号不正确!");

        article = AW_Article_bean.funcGetByID(QS("id"));

        if (article == null) WebAgent.AlertAndBack("文章不存在!");

        txtTitle.Text = article.fdArtiTitle;
        txtContent.Text = article.fdArtiContent;

        foreach (AW_Column_bean bean1 in (new AW_Column_dao()).funcGetColumns())
        {
            drpColumn.Items.Add(new ListItem(bean1.fdColuName, bean1.fdColuID.ToString()));
            foreach (AW_Column_bean bean2 in bean1.Children)
            {
                drpColumn.Items.Add(new ListItem(bean1.fdColuName + "-" + bean2.fdColuName, bean2.fdColuID.ToString()));
            }
        }
        drpColumn.SelectedValue = article.fdArtiColumnID.ToString();
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        article = AW_Article_bean.funcGetByID(QS("id"));
        using (AW_Article_dao dao = new AW_Article_dao())
        {
            article.fdArtiTitle = txtTitle.Text.Trim();
            article.fdArtiColumnID = int.Parse(drpColumn.SelectedValue);
            article.fdArtiContent = txtContent.Text;

            dao.funcUpdate(article);
            WebAgent.SuccAndGo("修改文章成功", "ArticleList.aspx?cid=" + article.fdArtiColumnID.ToString());
        }
    }

}
