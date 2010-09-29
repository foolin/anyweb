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
using System.Collections.Generic;
using AnyWell.AW_DL;


public partial class Admin_KeyWordsSort : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        Response.Buffer = true;
        Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
        Response.Expires = 0;
        Response.CacheControl = "no-cache";
        Response.AppendHeader("Pragma", "No-Cache");

        int keyWId = 0;
        int previewId = 0;
        int nextId = 0;

        if (QS("id") != "" && WebAgent.IsInt32(QS("id")))
            keyWId = int.Parse(QS("id"));

        if (QS("previewid") != "" && WebAgent.IsInt32(QS("previewid")))
            previewId = int.Parse(QS("previewid"));

        if (QS("nextid") != "" && WebAgent.IsInt32(QS("nextid")))
            nextId = int.Parse(QS("nextid"));

        if (keyWId > 0 && (previewId > 0 || nextId > 0))
        {
            AW_KeyWord_bean bean = AW_KeyWord_bean.funcGetByID(keyWId);
            if (bean == null)
            {
                return;
            }
            using (AW_KeyWord_dao dao = new AW_KeyWord_dao())
            {
                dao.funcSortKeyWords(keyWId, nextId, previewId);
                this.AddLog(EventType.Update, "修改关键词排序", "修改关键词[" + bean.fdKeyWName + "]排序");
                Response.Write("ok");
            }
        }
        else
        {
            Response.Write("parmaters null");
        }
    }
}
