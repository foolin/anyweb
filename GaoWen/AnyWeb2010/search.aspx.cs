using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWeb.AW_DL;
using AnyWeb.AW.Configs;

public partial class search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        this.Title = "高闻顾问" + GeneralConfigs.GetConfig().TitleExtension;
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
        using (AW_Article_dao dao = new AW_Article_dao())
        {
            List<AW_Article_bean> list = dao.funcGetSearchArtcile(querryString, 1, 20, out record);
            repArticle.DataSource = list;
            repHot.DataSource = dao.funcGetHotArticle(14);
            repHot.DataBind();
        }
        repArticle.DataBind();
        repColumn.DataSource = new AW_Column_dao().funcGetIndexColumns();
        repColumn.DataBind();
    }
}
