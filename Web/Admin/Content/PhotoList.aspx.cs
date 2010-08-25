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
using AnyWeb.AnyWeb_DL;

public partial class Admin_Content_PhotoList : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        type.SelectedValue = QS("type");

        int RecordCount = 0;
        repPhoto.DataSource = new PhotoAgent().GetPhotoList(int.Parse(type.SelectedValue), PN1.PageSize, PN1.PageIndex, out RecordCount);
        repPhoto.DataBind();
        PN1.SetPage(RecordCount);
    }

    protected string getCateName(int cateID)
    {
        switch (cateID)
        {
            case 1: return "首页幻灯片";
            case 2: return "网上菜篮子";
            case 3: return "知名合作企业";
            case 4: return "先进单位";
            default: return "首页幻灯片";
        }
    }
}
