﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWeb.AW_DL;

public partial class article : System.Web.UI.Page
{
    public AW_Article_bean bean;
    public AW_Article_bean nextArticle;
    public AW_Article_bean preArticle;
    public AW_Column_bean column;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        string artiID = Request.QueryString["id"];
        if (string.IsNullOrEmpty(artiID) || !WebAgent.IsInt32(artiID))
        {
            WebAgent.AlertAndBack("文章不存在！");
        }
        bean = AW_Article_bean.funcGetByID(int.Parse(artiID));  //获取文章
        if (bean == null)
        {
            WebAgent.AlertAndBack("文章不存在！");
        }
        nextArticle = new AW_Article_dao().funcGetNextArticle(bean.fdArtiID);   //获取下一篇文章
        preArticle = new AW_Article_dao().funcGetPreviousArticle(bean.fdArtiID);    //获取前一篇文章
        column = new AW_Column_dao().funcGetColumnIndex(bean.fdArtiColumnID);   //获取所属栏目
        if (column.fdColuParentID == 0)
        {
            repColumn.DataSource = new AW_Column_dao().funcGetColumnList(column.fdColuID);
            repColumn.DataBind();
        }
        else
        {
            repColumn.DataSource = new AW_Column_dao().funcGetColumnList(column.Parent.fdColuID);
            repColumn.DataBind();
        }
        repRelation.DataSource = new AW_Relation_dao().funcGetRelationList(column.fdColuID);    //获取关联文章
        repRelation.DataBind();
        Context.Items.Add("COLUMN", column);
    }
}