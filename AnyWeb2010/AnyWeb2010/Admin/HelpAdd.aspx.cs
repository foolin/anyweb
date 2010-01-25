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
using AnyWeb.AW.Configs;

public partial class Admin_HelpAdd : ShopAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        compType.DataSource = new AW_Help_Type_dao().funcGetHelpTypes();
        compType.DataBind();

        ListItem li = compType.Items.FindByValue(QS("tid"));
        if (li != null) li.Selected = true;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        string typeId = compType.SelectedValue;
        if (String.IsNullOrEmpty(typeId) || !Studio.Web.WebAgent.IsInt32(typeId)) return;
        using (AW_Help_dao dao = new AW_Help_dao())
        {
            AW_Help_bean bean = new AW_Help_bean();
            bean.fdHelpID =dao.funcNewID();
            bean.fdHelpTypeID = int.Parse(typeId);
            bean.fdHelpQuestion = compQuestion.Text;
            bean.fdHelpAnswer = compAnswer.Text;
            bean.fdHelpSort = bean.fdHelpID;
            dao.funcInsert(bean);

            if (GeneralConfigs.GetConfig().SetupConfigHelp == false)
            {
                GeneralConfigs.GetConfig().SetupConfigHelp = true;
                GeneralConfigs.Serialiaze(GeneralConfigs.GetConfig(), DefaultConfigFileManager.ConfigFilePath);
            }

            Studio.Web.WebAgent.SuccAndGo("添加帮助成功！", "HelpList.aspx?tid=" + bean.fdHelpTypeID.ToString());
        }
    }

}
