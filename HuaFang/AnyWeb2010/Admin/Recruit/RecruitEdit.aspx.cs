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

using AnyWell.AW_DL;
using Studio.Web;
using System.IO;

public partial class Admin_RecruitEdit : PageAdmin
{
    protected AW_Recruit_bean recruit;

    protected override void OnPreRender(EventArgs e)
    {
        string id = QS("id");

        if (!WebAgent.IsInt32(id)) WebAgent.AlertAndBack("编号不正确!");

        recruit = AW_Recruit_bean.funcGetByID(QS("id"));
        if (recruit == null) WebAgent.AlertAndBack("招聘信息不存在!");

        if (!this.IsPostBack && Request.UrlReferrer != null)
        {
            ViewState["REFURL"] = Request.UrlReferrer.PathAndQuery;
        }
        else
        {
            ViewState["REFURL"] = "RecruitList.aspx";
        }

        txtTitle.Text = recruit.fdRecrTitle;
        txtAreaName.Text = recruit.fdRecrAreaName;
        txtJob.Text = recruit.fdRecrJob;
        txtContent.Text = recruit.fdRecrContent;
        txtSort.Text = recruit.fdRecrSort.ToString();
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtTitle.Text))
            WebAgent.AlertAndBack("标题不能为空");

        if( string.IsNullOrEmpty( txtAreaName.Text ) )
            WebAgent.AlertAndBack("地区不能为空");

        if (String.IsNullOrEmpty(txtJob.Text))
            WebAgent.AlertAndBack("职位名称不能为空");

        if (String.IsNullOrEmpty(txtContent.Text))
            WebAgent.AlertAndBack("内容不能为空");

        if (string.IsNullOrEmpty(txtSort.Text))
            WebAgent.AlertAndBack("排序不能为空");

        if (!WebAgent.IsInt32(txtSort.Text.Trim()))
            WebAgent.AlertAndBack("排序格式不正确");

        recruit = AW_Recruit_bean.funcGetByID(QS("id"));
        using (AW_Recruit_dao dao = new AW_Recruit_dao())
        {
            recruit.fdRecrTitle = txtTitle.Text.Trim();
            recruit.fdRecrAreaName = txtAreaName.Text;
            recruit.fdRecrJob = txtJob.Text.Trim();
            recruit.fdRecrContent = txtContent.Text;
            recruit.fdRecrSort = int.Parse(txtSort.Text.Trim());
            if (recruit.fdRecrSort == 0)
                recruit.fdRecrSort = recruit.fdRecrID * 100;
            dao.funcUpdate(recruit);
            this.AddLog(EventType.Update, "修改招聘", "修改招聘[" + recruit.fdRecrTitle + "]");
            WebAgent.SuccAndGo("修改招聘成功", ViewState["REFURL"].ToString());
        }
    }

}
