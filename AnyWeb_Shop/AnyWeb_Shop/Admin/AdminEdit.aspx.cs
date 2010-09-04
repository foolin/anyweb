using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Admin.Framework;
using Studio.Web;
using Common.Agent;
using Common.Common;

public partial class AdminEdit : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            switch (QS("mode"))
            {
                case "update":
                    this.fv1.ChangeMode(FormViewMode.Edit);
                    litTitle.Text = "修改用户";
                    break;
                case "delete":
                    if (QS("aid") == "" || !WebAgent.IsInt32(QS("aid")))
                        Response.Redirect("AdminList.aspx");

                    AdminAgent aa = new AdminAgent();
                    Common.Common.Admin admin = aa.GetAdminByID(int.Parse(QS("aid")));

                    if (admin == null)
                        Response.Redirect("AdminList.aspx");

                    if (admin.AdminAcc == "superadmin")
                        WebAgent.AlertAndBack("superadmin帐号不允许删除");

                    if (aa.DeleteAdmin(admin) > 0)
                    {
                        WebAgent.SuccAndGo("删除成功", "AdminList.aspx");
                    }
                    break;
                default:
                    this.fv1.ChangeMode(FormViewMode.Insert);
                    litTitle.Text = "添加用户";
                    break;
            }
        }
    }

    protected void ods3_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        Article ar = (Article)e.InputParameters[0];

        if (WebAgent.IsInt32(QS("aid")))
        {
            e.InputParameters["aid"] = int.Parse(QS("aid"));
        }
        else
        {
            WebAgent.AlertAndBack("参数不正确");
        }
    }

    protected void ods3_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.ReturnValue == null)
        {
            WebAgent.AlertAndBack("用户不存在");
        }
    }

    protected void ods3_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        TextBox txtAcc = (TextBox)fv1.FindControl("txtAcc");
        if (new AdminAgent().checkAdminExists(txtAcc.Text))
        {
            WebAgent.AlertAndBack("登录帐号已经存在");
        }
    }

    protected void ods3_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if ((int)e.ReturnValue > 0)
        {

            this.AddLog(EventID.Insert, "添加用户", "添加用户");

            WebAgent.SuccAndGo("添加成功。", "AdminList.aspx");
        }
        else
        {
            WebAgent.FailAndGo("添加失败。", ViewState["BACK"].ToString());
        }
    }

    protected void ods3_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        Common.Common.Admin a = (Common.Common.Admin)e.InputParameters[0];
        TextBox txtPwd = (TextBox)fv1.FindControl("txtPwd");
        if (txtPwd.Text.Length <= 0)
            a.AdminPass = Studio.Security.Secure.Md5(a.AdminPass);
    }

    protected void ods3_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {

        if ((int)e.ReturnValue > 0)
        {

            this.AddLog(EventID.Update, "修改用户", "修改用户");

            WebAgent.SuccAndGo("修改成功。", "AdminList.aspx");
        }
        else
        {
            WebAgent.FailAndGo("修改失败。", ViewState["BACK"].ToString());
        }
    }

    protected void ods3_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        if (QS("aid") == "" || !WebAgent.IsInt32(QS("aid")))
        {
            WebAgent.AlertAndBack("参数不正确");
        }
        Common.Common.Admin admin = new AdminAgent().GetAdminByID(int.Parse(QS("aid")));
        if (admin.AdminAcc == "superadmin")
        {
            WebAgent.AlertAndBack("superadmin帐号不允许删除");
        }
    }
    
    protected void ods3_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if ((int)e.ReturnValue > 0)
        {

            this.AddLog(EventID.Delete, "删除用户", "删除用户");

            WebAgent.SuccAndGo("删除成功。", "AdminList.aspx");
        }
        else
        {
            WebAgent.FailAndGo("删除失败。", ViewState["BACK"].ToString());
        }
    }
}
