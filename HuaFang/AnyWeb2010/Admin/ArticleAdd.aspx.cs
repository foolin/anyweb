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
using Studio.Web;
using AnyWell.AW_DL;
using System.Collections.Generic;

public partial class Admin_ArticleAdd : ArticleBase
{
    protected AW_Article_bean bean;
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        int i = 0;
        List<AW_Column_bean> coluList = new AW_Column_dao().funcGetColumns();
        if (coluList.Count == 0)
        {
            WebAgent.FailAndGo("文章栏目为空，请先添加文章栏目！", "ColumnAdd.aspx");
        }
        foreach (AW_Column_bean bean1 in coluList)
        {
            drpColumn.Items.Add(new ListItem(bean1.fdColuName, bean1.fdColuID.ToString()));
            litJs.Text += string.Format("child[{0}] = new Array;", i);
            int j = 0;
            foreach (AW_Column_bean bean2 in bean1.Children)
            {
                litJs.Text += string.Format("child[{0}][{1}] = \"{2}:{3}\";", i, j, bean2.fdColuID, bean2.fdColuName);
                j++;
            }
            i++;
        }

        ListItem li = drpColumn.Items.FindByValue(QS("cid"));
        if (li != null) li.Selected = true;

        if (!this.IsPostBack && Request.UrlReferrer != null)
        {
            ViewState["REFURL"] = Request.UrlReferrer.PathAndQuery;
        }
        else
        {
            ViewState["REFURL"] = "ArticleList.aspx";
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtTitle.Text))
            WebAgent.AlertAndBack("标题不能为空");

        if (String.IsNullOrEmpty(txtContent.Text))
            WebAgent.AlertAndBack("内容不能为空");

        if( txtDesc.Text.Trim().Length > 1000 )
            WebAgent.AlertAndBack( "文章摘要不能超出1000字" );

        if (string.IsNullOrEmpty(txtSort.Text))
            WebAgent.AlertAndBack("排序不能为空");

        if (!WebAgent.IsInt32(txtSort.Text.Trim()))
            WebAgent.AlertAndBack("排序格式不正确");

        string childColumn = Request.Form["drpChild"] + "";
        using (AW_Article_dao dao = new AW_Article_dao())
        {

            bean = new AW_Article_bean();
            bean.fdArtiID = dao.funcNewID();
            if (childColumn != "0")
            {
                bean.fdArtiColumnID = int.Parse(childColumn);
            }
            else
            {
                bean.fdArtiColumnID = int.Parse(drpColumn.SelectedValue);
            }
            bean.fdArtiTitle = txtTitle.Text.Trim();
            bean.fdArtiContent = txtContent.Text;
            if( txtDesc.Text.Trim().Length > 0 )
            {
                bean.fdArtiDesc = txtDesc.Text.Trim();
            }
            else
            {
                string strDesc = WebAgent.GetText( bean.fdArtiContent );
                if( strDesc.Length < 1000 )
                {
                    bean.fdArtiDesc = strDesc;
                }
                else
                {
                    bean.fdArtiDesc = strDesc.Substring( 0, 1000 );
                }
            }
            bean.fdArtiSort = int.Parse(txtSort.Text.Trim());
            if (bean.fdArtiSort == 0)
                bean.fdArtiSort = bean.fdArtiID * 100;
            
            int record = dao.funcInsert(bean);
            if (record > 0)
            {
                this.SetTags( bean, QF( "tags" ).Trim() );
                this.AddLog(EventType.Insert, "添加文章", "栏目[" + drpColumn.SelectedItem.Text + "]添加文章[" + bean.fdArtiTitle + "]");
                Success( "添加成功", "ArticleList.aspx" );
            }
        }
    }
}
