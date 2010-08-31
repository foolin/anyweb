using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AW.Configs;
using AnyWeb.AW_DL;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        this.Title = "高闻顾问" + GeneralConfigs.GetConfig().TitleExtension;

        repHot.DataSource = new AW_Article_dao().funcGetHotArticle(3);
        repHot.DataBind();

        flashList = new AW_FlaAW_dao().funcGetFlashList();
        repFlash.DataSource = flashList;
        repFlash.DataBind();
        repFlashNum.DataSource = flashList;
        repFlashNum.DataBind();
        //repJs1.DataSource = flashList;
        //repJs1.DataBind();
        //repJs2.DataSource = flashList;
        //repJs2.DataBind();
    }

    public List<AW_FlaAW_bean> flashList;
}
