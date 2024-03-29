﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AnyWeb.AnyWeb_DL;
using Studio.Web;
using System.IO;

public partial class Content_ArticleEdit : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (QS("id") == "" || !WebAgent.IsInt32(QS("id")))
            WebAgent.AlertAndBack("参数错误");
        Article ar = new ArticleAgent().GetArticleInfoByAdmin(int.Parse(QS("id")));
        if (ar == null)
            WebAgent.AlertAndBack("文章不存在");

        drpColumn.DataSource = new ColumnAgent().GetColumnListByArticle();
        drpColumn.DataBind();

        drpColumn.SelectedValue = ar.ArtiColumnID.ToString();
        txtTitle.Text = ar.ArtiTitle;
        edtContent.Text = ar.ArtiContent;
        txtOrder.Text = ar.ArtiOrder.ToString();
    }

    protected void btnSaveArticle_Click(object sender, EventArgs e)
    {
        Article ar = new ArticleAgent().GetArticleInfoByAdmin(int.Parse(QS("id")));
        ar.ArtiTitle = txtTitle.Text;
        ar.ArtiContent = edtContent.Text;
        ar.ArtiOrder = int.Parse(txtOrder.Text);
        ar.ArtiColumnID = int.Parse(drpColumn.SelectedValue);

        if (new ArticleAgent().UpdateArticleInfo(ar) > 0)
        {
            EventLog log = new EventLog();
            log.EvenDesc = "修改文章" + ar.ArtiTitle + "成功.";
            log.EvenAt = DateTime.Now;
            log.EvenIP = HttpContext.Current.Request.UserHostAddress;
            log.EvenUserAcc = this.LoginUser.UserAcc;
            new EventLogAgent().AddLog(log);
            if (ViewState["BACK"].ToString() == "/Admin/Default.aspx")
                WebAgent.SuccAndGo("修改文章成功", "ArticleList.aspx");
            else
                WebAgent.SuccAndGo("修改文章成功", ViewState["BACK"].ToString());
        }
        else
            WebAgent.AlertAndBack("修改修改失败");
    }
}
