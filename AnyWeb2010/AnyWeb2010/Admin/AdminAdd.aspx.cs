using System;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Studio.Web;
using AnyWeb.AW_DL;
using AnyWeb.AW.Configs;
using AnyWeb.AW;

public partial class Admin_AdminAdd : ShopAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        radio1.Attributes["onclick"] = "$('#" + purviewArea.ClientID + "').css('display','none');";
        radio2.Attributes["onclick"] = "$('#" + purviewArea.ClientID + "').css('display','block');";
        purviewArea.Attributes["style"] = "display:block";


        string menuFile = "~/App_Data/menus.xml";

        DropMenu menu = DropMenu.GetMenuData(menuFile);
        DropMenuItem root = menu.RootItem;

        repPurviews.DataSource = root.Children;
        repPurviews.DataBind();
    }

    protected void repChildren_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DropMenuItem item = (DropMenuItem)e.Item.DataItem;
        e.Item.Visible = item.Type == 1;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        AW_Admin_bean bean = new AW_Admin_bean();
        bean.fdAdmiLevel = radio1.Checked ? 1 : 2;
        bean.fdAdmiCreateAt = DateTime.Now;
        bean.fdAdmiAccount = txtAcc.Text;
        bean.fdAdmiLoginAt = DateTime.Parse("1900-1-1");
        bean.fdAdmiName = txtName.Text;
        bean.fdAdmiPwd = Studio.Security.Secure.Md5(txtPwd.Text);
        if (bean.fdAdmiLevel == 2)
        {
            bean.fdAdmiPurview = Request.Form["purviews"] + "";
        }

        using (AW_Admin_dao dao = new AW_Admin_dao())
        {
            foreach (AW_Admin_bean admin in dao.funcGetAdmins())
            {
                if (admin.fdAdmiAccount.ToLower() == bean.fdAdmiAccount.ToLower())
                    WebAgent.AlertAndBack("用户帐号已被占用");
            }

            bean.fdAdmiID = dao.funcNewID();
            dao.funcInsert(bean);

            WebAgent.SuccAndGo("添加用户成功", "adminlist.aspx");
        }
    }
}
