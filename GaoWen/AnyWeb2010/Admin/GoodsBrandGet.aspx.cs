using System;
using System.Collections;
using System.Collections.Generic;
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
using AnyWeb.AW;


public partial class Admin_GoodsBrandGet : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        if (QS("id") != "" && WebAgent.IsInt32(QS("id")))
        {
            List<AW_Brand_bean> list = new List<AW_Brand_bean>();
            if (QS("id") == "0")
            {
                list = (new AW_Brand_dao()).funcGetBrands();
            }
            else
            {
                AW_Brand_bean bean = (new AW_Brand_dao()).funcGetBrandInfo(int.Parse(QS("id")));
                if (bean != null && bean.Children != null) list = bean.Children;
            }

            foreach (AW_Brand_bean bean in list)
            {
                Response.Write(bean.fdBranID.ToString() + ":" + bean.fdBranName.Replace(":", "").Replace(",", "") + ",");
            }
        }
        Response.End();
    }
}
