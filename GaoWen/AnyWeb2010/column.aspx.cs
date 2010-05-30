using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AW_DL;
using Studio.Web;

public partial class column : System.Web.UI.Page
{
    public AW_Column_bean bean;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        string columnID = Request.QueryString["id"];
        if (string.IsNullOrEmpty(columnID) || !WebAgent.IsInt32(columnID))
        {
            WebAgent.AlertAndBack("栏目不存在！");
        }
        bean = new AW_Column_dao().funcGetColumnIndex(int.Parse(columnID));
        if (bean == null)
        {
            WebAgent.AlertAndBack("栏目不存在！");
        }
        if (bean.fdColuParentID == 0)
        {
            repColumn.DataSource = new AW_Column_dao().funcGetColumnList(bean.fdColuID);
            repColumn.DataBind();
        }
        else
        {
            repColumn.DataSource = new AW_Column_dao().funcGetColumnList(bean.Parent.fdColuID);
            repColumn.DataBind();
        }
        repRelation.DataSource = new AW_Relation_dao().funcGetRelationList(bean.fdColuID);
        repRelation.DataBind();
        using (AW_Article_dao dao = new AW_Article_dao())
        {
            repArticle.DataSource = dao.funcGetArticle(bean, PN1.PageSize, PN1.PageIndex);
            repArticle.DataBind();
            PN1.SetPage(dao.propCount);
        }
        Context.Items.Add("COLUMN", bean);
    }
}
