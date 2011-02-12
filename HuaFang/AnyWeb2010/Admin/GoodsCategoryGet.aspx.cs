﻿using System;
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
using AnyWell.AW_DL;
using AnyWell.AW;

public partial class Admin_GoodsCategoryGet : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        if(QS("id") != "" && WebAgent.IsInt32(QS("id")))
        {
            List<AW_Category_bean> list = new List<AW_Category_bean>();
            if (QS("id") == "0")
            {
                list = (new AW_Category_dao()).funcGetCategories();
            }
            else
            {
                AW_Category_bean bean = (new AW_Category_dao()).funcGetCategoryInfo(int.Parse(QS("id")));
                if (bean != null && bean.Children != null) list = bean.Children;
            }

            foreach (AW_Category_bean bean in list)
            {
                Response.Write(bean.fdCateID.ToString() + ":" + bean.fdCateName.Replace(":", "").Replace(",", "") + ",");
            }
        }
        Response.End();
    }
}
