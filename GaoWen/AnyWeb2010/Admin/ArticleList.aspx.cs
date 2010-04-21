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

public partial class Admin_ArticleList : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        foreach(AW_Column_bean bean1 in (new AW_Column_dao()).funcGetColumns())
        {
            drpColumn.Items.Add(new ListItem(bean1.fdColuName, bean1.fdColuID.ToString()));
            foreach (AW_Column_bean bean2 in bean1.Children)
            {
                drpColumn.Items.Add(new ListItem(bean1.fdColuName + "-" + bean2.fdColuName, bean2.fdColuID.ToString()));
            }
        }

        ListItem li = drpColumn.Items.FindByValue(QS("cid"));
        if (li != null) li.Selected = true;


        AW_Column_bean column = (new AW_Column_dao()).funcGetColumnInfo(int.Parse(drpColumn.SelectedValue));


        using (AW_Article_dao dao = new AW_Article_dao())
        {
            compRep.DataSource = dao.funcGetArticle(column, PN1.PageSize, PN1.PageIndex);
            compRep.DataBind();
            PN1.SetPage(dao.propPage);
        }
    }

}
