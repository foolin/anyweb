using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_NoticeAdd : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtTitle.Text))
            WebAgent.AlertAndBack("标题不能为空");
        if (string.IsNullOrEmpty(txtContent.Text))
            WebAgent.AlertAndBack("内容不能为空");
        if (string.IsNullOrEmpty(txtSort.Text))
            WebAgent.AlertAndBack("排序不能为空");
        if (!WebAgent.IsInt32(txtSort.Text.Trim()))
            WebAgent.AlertAndBack("排序格式不正确");

        using (AW_Notice_dao dao = new AW_Notice_dao())
        {
            AW_Notice_bean bean = new AW_Notice_bean();
            bean.fdNotiID = dao.funcNewID();
            bean.fdNotiTitle = txtTitle.Text;
            bean.fdNotiContent = txtContent.Text;
            bean.fdNotiCreateAt = DateTime.Now;
            if (int.Parse(txtSort.Text) == 0)
            {
                bean.fdNotiOrder = bean.fdNotiID * 100;
            }
            else
            {
                bean.fdNotiOrder = int.Parse(txtSort.Text);
            }
            dao.funcInsert(bean);
            this.AddLog(EventType.Insert, "添加公告", "添加公告[" + bean.fdNotiTitle + "]");
            WebAgent.SuccAndGo("添加成功", "NoticeList.aspx");
        }
    }
}
