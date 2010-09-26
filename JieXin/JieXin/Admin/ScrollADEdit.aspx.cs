using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_ScrollADEdit : PageAdmin
{
    public bool hasPic;
    public string picUrl;

    protected override void OnPreRender(EventArgs e)
    {
        if (!WebAgent.IsInt32(QS("id")))
            WebAgent.AlertAndBack("编号不正确!");

        AW_AD_bean bean = AW_AD_bean.funcGetByID(int.Parse(QS("id")));
        if (bean == null)
            WebAgent.AlertAndBack("滚动图片不存在!");

        drpType.SelectedValue = bean.fdAdType.ToString();
        txtName.Text = bean.fdAdName;
        txtLink.Text = bean.fdAdLink;
        txtSort.Text = bean.fdAdSort.ToString();

        if (!string.IsNullOrEmpty(bean.fdAdPic))
        {
            hasPic = true;
            picUrl = bean.fdAdPic;
        }
        else
        {
            hasPic = false;
            picUrl = "";
        }

        if (!this.IsPostBack && Request.UrlReferrer != null)
        {
            ViewState["REFURL"] = Request.UrlReferrer.PathAndQuery;
        }
        else
        {
            ViewState["REFURL"] = "ScrollADList.aspx";
        }
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

        string pics = Request.Form["pics"] + "";
        using (AW_AD_dao dao = new AW_AD_dao())
        {
            AW_AD_bean bean = AW_AD_bean.funcGetByID(int.Parse(QS("id")));
            bean.fdAdName = txtName.Text;
            bean.fdAdLink = txtLink.Text;
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
            bean.fdAdPic = pics;
            dao.funcUpdate(bean);
            WebAgent.SuccAndGo("修改成功", ViewState["REFURL"].ToString());
        }
    }
}
