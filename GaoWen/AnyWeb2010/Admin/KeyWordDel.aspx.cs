using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWeb.AW_DL;
using AnyWeb.AW_DL;

public partial class Admin_KeyWordDel : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        if (Request.UrlReferrer == null)
            return;

        using (AW_KeyWord_dao dao = new AW_KeyWord_dao())
        {
            AW_KeyWord_bean bean = AW_KeyWord_bean.funcGetByID(int.Parse(QS("id")));

            if (bean == null)
                WebAgent.AlertAndBack("商品不存在");

            dao.funcDelete(bean.fdKeyWID);
        }

        Response.Redirect(Request.UrlReferrer == null ? "KeyWordList.aspx" : Request.UrlReferrer.AbsoluteUri);
    }
}