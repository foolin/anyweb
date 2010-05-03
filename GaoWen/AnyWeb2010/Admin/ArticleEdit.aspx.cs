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

public partial class Admin_ArticleEdit : PageAdmin
{
    protected AW_Article_bean article;

    protected override void OnPreRender(EventArgs e)
    {
        string id = QS("id");

        if (!WebAgent.IsInt32(id)) WebAgent.AlertAndBack("编号不正确!");

        article = AW_Article_bean.funcGetByID(QS("id"));
        article.Column = AW_Column_bean.funcGetByID(article.fdArtiColumnID);
        if (article == null) WebAgent.AlertAndBack("文章不存在!");

        if (!this.IsPostBack && Request.UrlReferrer != null)
        {
            ViewState["REFURL"] = Request.UrlReferrer.PathAndQuery;
        }
        else
        {
            ViewState["REFURL"] = "ArticleList.aspx";
        }

        txtTitle.Text = article.fdArtiTitle;
        txtContent.Text = article.fdArtiContent;
        txtSort.Text = article.fdArtiSort.ToString();
        int i = 0;
        foreach (AW_Column_bean bean1 in (new AW_Column_dao()).funcGetColumns())
        {
            drpColumn.Items.Add(new ListItem(bean1.fdColuName, bean1.fdColuID.ToString()));
            litJs.Text += string.Format("child[{0}] = new Array;", i);
            int j = 0;
            if (bean1.fdColuID == article.Column.fdColuParentID || bean1.fdColuID == article.Column.fdColuID)
            {
                drpChild.Items.Add(new ListItem("不选择二级栏目", "0"));
                foreach (AW_Column_bean bean2 in bean1.Children)
                {
                    drpChild.Items.Add(new ListItem(bean2.fdColuName, bean2.fdColuID.ToString()));
                    litJs.Text += string.Format("child[{0}][{1}] = \"{2}:{3}\";", i, j, bean2.fdColuID, bean2.fdColuName);
                    j++;
                }
            }
            else
            {
                foreach (AW_Column_bean bean2 in bean1.Children)
                {
                    litJs.Text += string.Format("child[{0}][{1}] = \"{2}:{3}\";", i, j, bean2.fdColuID, bean2.fdColuName);
                    j++;
                }
            }
            i++;
        }
        if (article.Column.fdColuParentID == 0)
        {
            drpColumn.SelectedValue = article.Column.fdColuID.ToString();
            drpChild.SelectedValue = "0";
        }
        else
        {
            drpColumn.SelectedValue = article.Column.fdColuParentID.ToString();
            drpChild.SelectedValue = article.Column.fdColuID.ToString();
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        article = AW_Article_bean.funcGetByID(QS("id"));
        string childColumn = Request.Form[drpChild.UniqueID] + "";
        using (AW_Article_dao dao = new AW_Article_dao())
        {
            article.fdArtiTitle = txtTitle.Text.Trim();
            article.fdArtiContent = txtContent.Text;
            article.fdArtiSort = int.Parse(txtSort.Text.Trim());
            if (article.fdArtiSort == 0)
                article.fdArtiSort = article.fdArtiID * 100;
            if (childColumn != "0")
            {
                article.fdArtiColumnID = int.Parse(childColumn);
            }
            else
            {
                article.fdArtiColumnID = int.Parse(drpColumn.SelectedValue);
            }
            dao.funcUpdate(article);
            WebAgent.SuccAndGo("修改文章成功", ViewState["REFURL"].ToString());
        }
    }

}
