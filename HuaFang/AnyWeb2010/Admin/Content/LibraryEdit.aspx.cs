using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_LibraryEdit : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        int id = int.Parse(QS("id"));
        if (!WebAgent.IsInt32(id.ToString())) WebAgent.AlertAndBack("编号不正确!");

        AW_Library_bean bean = (new AW_Library_dao()).funcGetLibraryItemByID(id);
        if (bean == null) WebAgent.AlertAndBack("信息不存在!");

        drpLibrary.SelectedValue = bean.fdLibrType.ToString();
        txtLibrName.Text = bean.fdLibrName;
        txtLibrEnName.Text = bean.fdLibrEnName;
        drpFirstLetter.SelectedValue = bean.fdLibrFirLetter.ToString();
        txtLibrDesc.Text = bean.fdLibrDesc;
        txtLibrOrder.Text = bean.fdLibrSort.ToString();
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtLibrName.Text))
            WebAgent.AlertAndBack("名称不能为空");
        if (string.IsNullOrEmpty(txtLibrEnName.Text))
            WebAgent.AlertAndBack("英文名称不能为空");
        if (string.IsNullOrEmpty(txtLibrOrder.Text))
            WebAgent.AlertAndBack("排序不能为空");
        if (!WebAgent.IsInt32(txtLibrOrder.Text.Trim()))
            WebAgent.AlertAndBack("排序格式不正确");

        using (AW_Library_dao dao = new AW_Library_dao())
        {
            AW_Library_bean bean = dao.funcGetLibraryItemByID(int.Parse(QS("id")));
            bean.fdLibrType = int.Parse(drpLibrary.SelectedValue);
            bean.fdLibrName = txtLibrName.Text.Trim();
            bean.fdLibrEnName = txtLibrEnName.Text.Trim();
            bean.fdLibrFirLetter = int.Parse( drpFirstLetter.SelectedValue );
            bean.fdLibrDesc = txtLibrDesc.Text;
            if (int.Parse(txtLibrOrder.Text) == 0)
            {
                bean.fdLibrSort = bean.fdLibrID * 100;
            }
            else
            {
                bean.fdLibrSort = int.Parse( txtLibrOrder.Text );
            }
            dao.funcUpdate(bean);

            if (int.Parse(drpLibrary.SelectedValue) == 1)
            {
                this.AddLog(EventType.Insert, "修改名人", "修改名人[" + bean.fdLibrName + "]");
            }
            else
            {
                this.AddLog(EventType.Insert, "修改品牌", "修改品牌[" + bean.fdLibrName + "]");
            }
            WebAgent.SuccAndGo("修改成功", "LibraryList.aspx");
        }
    }
}
