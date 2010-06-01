using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AW_DL;
using Studio.Web;
using AnyWeb.AW.Configs;

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
        
        this.Title = bean.fdColuName + GeneralConfigs.GetConfig().TitleExtension;
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
        Context.Items.Add("COLUMN", bean);
    }

    public int getSkin(AW_Column_bean bean)
    {
        int columnID = 0;
        if (bean.fdColuParentID == 0)
        {
            columnID = bean.fdColuID;
        }
        else        
        {
            columnID = bean.Parent.fdColuID;
        }
        switch (columnID)
        {
            case 122:
                return 1;
            default:
                return 2;
        }
    }
}
