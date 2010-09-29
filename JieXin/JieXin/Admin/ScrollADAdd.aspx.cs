using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_ScrollADAdd : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtName.Text))
            WebAgent.AlertAndBack("名称不能为空！");
        if (string.IsNullOrEmpty(txtLink.Text))
            WebAgent.AlertAndBack("链接不能为空！");
        if (string.IsNullOrEmpty(txtSort.Text))
            WebAgent.AlertAndBack("排序不能为空！");
        if (!WebAgent.IsInt32(txtSort.Text))
            WebAgent.AlertAndBack("排序格式不正确！");

        using (AW_AD_dao dao = new AW_AD_dao())
        {
            AW_AD_bean bean = new AW_AD_bean();
            bean.fdAdID = dao.funcNewID();
            bean.fdAdName = txtName.Text;
            string pics = Request.Form["pics"] + "";
            if (pics.Length > 0)
            {
                bean.fdAdPic = pics;
            }
            bean.fdAdLink = txtLink.Text.Trim().ToLower();
            if (!bean.fdAdLink.StartsWith("http://"))
            {
                bean.fdAdLink = "http://" + bean.fdAdLink;
            }
            bean.fdAdType = int.Parse(drpType.SelectedValue);
            bean.fdAdSort = int.Parse(txtSort.Text);
            if (bean.fdAdSort == 0)
            {
                bean.fdAdSort = bean.fdAdID * 100;
            }
            dao.funcInsert(bean);
            this.AddLog(EventType.Insert, "添加滚动图片", "添加滚动图片[" + bean.fdAdName + "]");
            WebAgent.SuccAndGo("添加成功！", "ScrollADList.aspx?type=" + bean.fdAdType);
        }
    }
}
