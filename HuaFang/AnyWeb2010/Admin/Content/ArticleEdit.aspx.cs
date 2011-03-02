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

using AnyWell.AW_DL;
using Studio.Web;
using System.IO;

public partial class Admin_ArticleEdit : ArticleBase
{
    protected AW_Article_bean article;

    protected override void OnPreRender(EventArgs e)
    {
        string id = QS("id");

        if (!WebAgent.IsInt32(id)) WebAgent.AlertAndBack("编号不正确!");

        article = new AW_Article_dao().funcGetArticleById( int.Parse( QS( "id" ) ) );
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
        txtDesc.Text = article.fdArtiDesc;
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
        if( String.IsNullOrEmpty( txtTitle.Text ) )
            WebAgent.AlertAndBack( "标题不能为空" );

        if( String.IsNullOrEmpty( txtContent.Text ) )
            WebAgent.AlertAndBack( "内容不能为空" );

        if( txtDesc.Text.Trim().Length > 1000 )
            WebAgent.AlertAndBack( "文章摘要不能超出1000字" );

        if( string.IsNullOrEmpty( txtSort.Text ) )
            WebAgent.AlertAndBack( "排序不能为空" );

        if( !WebAgent.IsInt32( txtSort.Text.Trim() ) )
            WebAgent.AlertAndBack( "排序格式不正确" );
        article = new AW_Article_dao().funcGetArticleById( int.Parse( QS( "id" ) ) );
        string childColumn = Request.Form[drpChild.UniqueID] + "";
        using (AW_Article_dao dao = new AW_Article_dao())
        {
            article.fdArtiTitle = txtTitle.Text.Trim();
            article.fdArtiContent = txtContent.Text;
            if( txtDesc.Text.Trim().Length > 0 )
            {
                article.fdArtiDesc = txtDesc.Text.Trim();
            }
            else
            {
                string strDesc = WebAgent.GetText( article.fdArtiContent );
                if( strDesc.Length < 1000 )
                {
                    article.fdArtiDesc = strDesc;
                }
                else
                {
                    article.fdArtiDesc = strDesc.Substring( 0, 1000 );
                }
            }
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
            this.SetTags( article, QF( "tags" ).Trim() );
            this.AddLog(EventType.Update, "修改文章", "修改文章[" + article.fdArtiTitle + "]");
            Success("修改文章成功", ViewState["REFURL"].ToString());
        }
    }

    protected string GetTags(string resule)
    {
        string str = "";
        foreach( AW_Tag_bean bean in article.TagList )
        {
            str += "," + bean.fdTagName;
        }
        if( str.Length > 0 )
        {
            return str.Substring( 1 );
        }
        else
        {
            return resule;
        }
    }
}
