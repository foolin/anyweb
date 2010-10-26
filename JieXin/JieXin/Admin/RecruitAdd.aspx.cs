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
using Studio.Web;
using AnyWell.AW_DL;
using System.Collections.Generic;

public partial class Admin_RecruitAdd : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtTitle.Text))
            WebAgent.AlertAndBack("标题不能为空");

        if (String.IsNullOrEmpty(txtAreaID.Text))
            WebAgent.AlertAndBack("地区编号不能为空");

        if (String.IsNullOrEmpty(txtCompany.Text))
            WebAgent.AlertAndBack("公司名称不能为空");

        if (String.IsNullOrEmpty(txtJob.Text))
            WebAgent.AlertAndBack("职位名称不能为空");

        if (String.IsNullOrEmpty(txtContent.Text))
            WebAgent.AlertAndBack("内容不能为空");

        if (string.IsNullOrEmpty(txtSort.Text))
            WebAgent.AlertAndBack("排序不能为空");

        if (!WebAgent.IsInt32(txtSort.Text.Trim()))
            WebAgent.AlertAndBack("排序格式不正确");

        using (AW_Recruit_dao dao = new AW_Recruit_dao())
        {

            AW_Recruit_bean bean = new AW_Recruit_bean();
            bean.fdRecrID = dao.funcNewID();
            bean.fdRecrType = int.Parse(drpType.SelectedValue);
            bean.fdRecrTitle = txtTitle.Text.Trim();
            bean.fdRecrAreaID = int.Parse(txtAreaID.Text.Trim());
            bean.fdRecrCompany = txtCompany.Text.Trim();
            bean.fdRecrJob = txtJob.Text.Trim();
            bean.fdRecrContent = txtContent.Text;
            bean.fdRecrCreateAt = DateTime.Now;
            bean.fdRecrSort = int.Parse(txtSort.Text.Trim());
            if (bean.fdRecrSort == 0)
                bean.fdRecrSort = bean.fdRecrID * 100;

            int record = dao.funcInsert(bean);
            if (record > 0)
            {
                this.AddLog(EventType.Insert, "添加招聘", "分类[" + drpType.SelectedItem.Text + "]添加招聘[" + bean.fdRecrTitle + "]");
                Studio.Web.WebAgent.SuccAndGo("添加成功", "RecruitList.aspx");
            }
        }
    }
}
