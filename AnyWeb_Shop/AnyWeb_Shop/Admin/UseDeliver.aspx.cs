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

public partial class UseDeliver :AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (WebAgent.IsInt32(QS("mid")))
        {
            Common.Common.Mode m = (new ModeAgent()).GetModeInfo(int.Parse(QS("mid")));

            if (m.ShopID != 0)
            {
                WebAgent.FailAndGo("操作错误", ViewState["BACK"].ToString());

                //Response.Write("3");

                //return;
            }

            if ((new ModeAgent()).InsertMode(m) > 0)
            {
                WebAgent.SuccAndGo("使用成功", ViewState["BACK"].ToString());

                //Response.Write("1");

                //return;
            }
            else
            {
                WebAgent.FailAndGo("操作错误", ViewState["BACK"].ToString());

                //Response.Write("1");

                //return;
            }
        }
        else
        {
            //Response.Write("2");

            //return;
            WebAgent.SuccAndGo("参数错误", ViewState["BACK"].ToString());
        }
    }
}
