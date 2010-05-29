using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AW_DL;
using Studio.Web;

public partial class renderarticle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string qs = Request.QueryString["id"] + "";
        if (!string.IsNullOrEmpty(qs) && WebAgent.IsInt32(qs))
        {
            AW_Article_bean article = AW_Article_bean.funcGetByID(int.Parse(qs));
            if (article != null)
            {
                List<AW_Article_bean> list = new List<AW_Article_bean>();
                list.Add(article);
                rep.DataSource = list;
                rep.DataBind();
            }
        }
    }
}
