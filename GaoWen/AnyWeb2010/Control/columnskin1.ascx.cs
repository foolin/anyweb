﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AW_DL;

public partial class Control_columnskin1 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        AW_Column_bean column = (AW_Column_bean)Context.Items["COLUMN"];
        using (AW_Article_dao dao = new AW_Article_dao())
        {
            List<AW_Article_bean> articleList = dao.funcGetArticle(column, PN1.PageSize, PN1.PageIndex);
            if (articleList.Count == 1) //如果当前栏目仅有一篇文章
            {
                Response.Redirect("singlearticle.aspx?id=" + articleList[0].fdArtiID);
            }
            repArticle.DataSource = dao.funcGetArticle(column, PN1.PageSize, PN1.PageIndex);
            repArticle.DataBind();
            PN1.SetPage(dao.propCount);
        }
    }
}
