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
using Studio.Web;
using AnyWeb.AW.Configs;

public partial class Admin_HelpEdit : ShopAdmin
{
    AW_Help_bean help;

    protected void Page_Load(object sender, EventArgs e)
    {
        string id = QS("id");

        if (!WebAgent.IsInt32(id)) WebAgent.AlertAndBack("编号不正确!");

        help = AW_Help_bean.funcGetByID(QS("id"));

        if (help == null) WebAgent.AlertAndBack("帮助不存在!");
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        compType.DataSource = new AW_Help_Type_dao().funcGetHelpTypes();
        compType.DataBind();

        compType.SelectedValue = help.fdHelpTypeID.ToString();
        compQuestion.Text = help.fdHelpQuestion;
        compAnswer.Text = help.fdHelpAnswer;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        using (AW_Help_dao dao = new AW_Help_dao())
        {
            help.fdHelpTypeID = int.Parse(compType.SelectedValue);
            help.fdHelpQuestion = compQuestion.Text.Trim();
            help.fdHelpAnswer = compAnswer.Text.Trim();
            dao.funcUpdate(help);

            if (GeneralConfigs.GetConfig().SetupConfigHelp == false)
            {
                GeneralConfigs.GetConfig().SetupConfigHelp = true;
                GeneralConfigs.Serialiaze(GeneralConfigs.GetConfig(), DefaultConfigFileManager.ConfigFilePath);
            }

            WebAgent.SuccAndGo("修改帮助成功", "HelpList.aspx?tid=" + help.fdHelpTypeID.ToString());
        }
    }

}
