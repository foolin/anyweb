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

public partial class Ajax_1kLogin : ShopAjaxBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AW_Member_bean member = new AW_Member_bean();
        member.fdMembID = 1000;
        member.fdMembEmail = this.QF("email"); //email的记录用于执行强制注册
        //member.fdMembEmail = this.QS("email");

        using (AW_Member_dao dao = new AW_Member_dao())
        {
            if (dao.funcEmailExists(member.fdMembEmail))
            {
                this.ExecuteFalse(1, "该邮箱已被注册，需登录后才能使用");
            }

            dao.funcAddCookie(member);
            this.ExecuteSucc("匿名登录成功");
        }
    }
}