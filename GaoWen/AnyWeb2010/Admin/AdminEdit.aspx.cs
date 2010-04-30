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
using AnyWeb.AW_DL;
using AnyWeb.AW.Configs;
using AnyWeb.AW;

public partial class Admin_AdminEdit : PageAdmin
{
    protected AW_Admin_bean bean = null;
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        AW_Admin_dao dao = new AW_Admin_dao();

        bean = dao.funcGetAdminInfo(int.Parse(QS("id")));

        if (bean.fdAdmiAccount == "admin" && dao.funcGetAdminFromCookie().fdAdmiAccount != "admin")
            WebAgent.AlertAndBack("您没有权限修改");

        txtName.Text = bean.fdAdmiName;
        txtAcc.Text = bean.fdAdmiAccount;
        if (bean.fdAdmiLevel == 1)
        {
            radio1.Checked = true;
            radio2.Checked = false;
        }
        if (bean.fdAdmiAccount == "superadmin")
            radio2.Enabled = false;


        radio1.Attributes["onclick"] = "$('#" + purviewArea.ClientID + "').css('display','none');";
        radio2.Attributes["onclick"] = "$('#" + purviewArea.ClientID + "').css('display','block');";
        purviewArea.Attributes["style"] = "display:" + (bean.Level == AdminLevel.Administrator ? "none" : "block");

        string menuFile = "~/App_Data/menus.xml";

        DropMenu menu = DropMenu.GetMenuData(menuFile);
        DropMenuItem root = menu.RootItem;
        ArrayList menuList = new ArrayList();
        foreach (DropMenuItem child in root.Children)
        {
            if (child.Type == 1)
            {
                menuList.Add(child);
            }
        }
        repPurviews.DataSource = menuList;
        repPurviews.DataBind();
    }

    protected void repPurviews_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DropMenuItem item = (DropMenuItem)e.Item.DataItem;
        HtmlInputCheckBox box = (HtmlInputCheckBox)e.Item.FindControl("boxs");
        box.Attributes["onclick"] = "checkChildren(this)";
        box.Attributes["value"] = item.ID.ToString();
        if (bean.Purviews != null && bean.Purviews.Contains(item.ID))
            box.Checked = true;
    }

    protected void repChildren_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DropMenuItem item = (DropMenuItem)e.Item.DataItem;
        HtmlInputCheckBox box = (HtmlInputCheckBox)e.Item.FindControl("boxs");
        box.Attributes["value"] = item.ID.ToString();
        if (bean.Purviews != null && bean.Purviews.Contains(item.ID))
            box.Checked = true;
        e.Item.Visible = item.Type == 1;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        using (AW_Admin_dao dao = new AW_Admin_dao())
        {
            bean = dao.funcGetAdminInfo(int.Parse(QS("id")));
            if (bean.fdAdmiAccount == "superadmin" && txtAcc.Text.Trim().ToLower() != "superadmin")
            {
                WebAgent.AlertAndBack("超管[superadmin]登陆帐号不允许更改！");
            }
            bean.fdAdmiLevel = radio1.Checked ? 1 : 2;
            bean.fdAdmiCreateAt = DateTime.Now;
            bean.fdAdmiAccount = txtAcc.Text;
            bean.fdAdmiLoginAt = DateTime.Parse("1900-1-1");
            bean.fdAdmiName = txtName.Text;
            if( txtPwd.Text.Length > 0)
                bean.fdAdmiPwd = Studio.Security.Secure.Md5(txtPwd.Text);
            if (bean.fdAdmiLevel == 2)
            {
                bean.fdAdmiPurview = Request.Form["purviews"] + "";
            }
            foreach (AW_Admin_bean admin in dao.funcGetAdmins())
            {
                if (admin.fdAdmiID != bean.fdAdmiID && admin.fdAdmiAccount.ToLower() == bean.fdAdmiAccount.ToLower())
                    WebAgent.AlertAndBack("用户帐号已被占用");
            }

            dao.funcUpdate(bean);

            WebAgent.SuccAndGo("修改用户成功", "adminlist.aspx");
        }
    }
}
