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

public partial class Ajax_MemberIDExists : ShopAjaxBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = int.Parse(this.QS("id"));
        AW_Member_bean member = AW_Member_bean.funcGetByID(id);
        if (member != null)
        {
            this.ExecuteSucc("存在该会员");
        }
        else
        {
            this.ExecuteFalse(1, "不存在该会员");
        }
    }
}