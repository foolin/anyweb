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

using Studio.Web;
using AnyWell.AW_DL;
using AnyWell.Configs;

public partial class Admin_MemberInfo : PageAdmin
{
    protected AW_Member_bean member;

    protected override void OnPreRender(EventArgs e)
    {
        string id = QS("id");

        if (!WebAgent.IsInt32(id)) WebAgent.AlertAndBack("编号不正确!");

        member = AW_Member_bean.funcGetByID(id);

        if (member == null) WebAgent.AlertAndBack("会员不存在!");
    }
}
