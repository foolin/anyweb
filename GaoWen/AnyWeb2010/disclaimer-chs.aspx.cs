using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AW_DL;
using AnyWeb.AW.Configs;
using System.IO;

public partial class disclaimer_chs : System.Web.UI.Page
{
    public AW_Column_bean column;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "免责声明" + GeneralConfigs.GetConfig().TitleExtension;
    }

    protected override void OnPreRender(EventArgs e)
    {
        column = new AW_Column_dao().funcGetColumnInfo(121);
        string str = File.ReadAllText(Server.MapPath("/MZSM.txt"));
        lit.Text = str;
    }
}
