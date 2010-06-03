using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWeb.AW_DL;
using AnyWeb.AW.Configs;

public partial class singlearticle : System.Web.UI.Page
{
    public AW_Article_bean bean;
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
        this.Title = bean.fdArtiTitle + GeneralConfigs.GetConfig().TitleExtension;
        if (!string.IsNullOrEmpty(Request.QueryString["byadmin"]) && Request.QueryString["byadmin"] == "1")
        {
            column = new AW_Column_dao().funcGetColumnInfo(bean.fdArtiColumnID);   //获取所属栏目
            if (column.fdColuParentID == 0)
            {
                repColumn.DataSource = new AW_Column_dao().funcGetColumnListByAdmin(column.fdColuID);
                repColumn.DataBind();
            }
            else
            {
                repColumn.DataSource = new AW_Column_dao().funcGetColumnListByAdmin(column.Parent.fdColuID);
                repColumn.DataBind();
            }
        }
        else
        {
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
        }
        Context.Items.Add("COLUMN", column);
    }
}
