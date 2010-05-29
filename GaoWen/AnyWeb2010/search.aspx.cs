using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWeb.AW_DL;

public partial class search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (Request.Form["keyword"] == null)
        {
            WebAgent.AlertAndBack("请输入搜索关键词！");
        }
        string keyword = Request.Form["keyword"];
        if (keyword.Contains("%"))
        {
            keyword = keyword.Replace("%", "[%]");
        }
        if (keyword.Contains("'"))
        {
            keyword = keyword.Replace("'", "''");
        }
        string querryString = SearchKeyWord.getQueryString(keyword);
        int record = 0;
        List<AW_Article_bean> list = new AW_Article_dao().funcGetSearchArtcile(querryString, 1, 20, out record);
    }
}
