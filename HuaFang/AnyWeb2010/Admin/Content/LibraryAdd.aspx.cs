using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_LibraryAdd : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
            AW_Library_bean bean = new AW_Library_bean();
            bean.fdLibrID = dao.funcNewID();
            bean.fdLibrType = int.Parse(drpLibrary.SelectedValue);
            bean.fdLibrName = txtLibrName.Text.Trim();
            bean.fdLibrEnName = txtLibrEnName.Text.Trim();
            bean.fdLibrFirLetter = int.Parse( drpFirstLetter.SelectedValue );
            bean.fdLibrDesc = txtLibrDesc.Text;
            bean.fdLibrPic = QF( "imgPath" ).Trim();
            if (int.Parse(txtLibrOrder.Text) == 0)
            {
                bean.fdLibrSort = bean.fdLibrID * 100;
            }
            else
            {
                bean.fdLibrSort = int.Parse( txtLibrOrder.Text );
            }
            dao.funcInsert(bean);

            if (int.Parse(drpLibrary.SelectedValue) == 1)
            {
                this.AddLog(EventType.Insert, "添加名人", "添加名人[" + bean.fdLibrName + "]");
            }
            else
            {
                this.AddLog(EventType.Insert, "添加品牌", "添加品牌[" + bean.fdLibrName + "]");
            }
            WebAgent.SuccAndGo("添加成功", "LibraryList.aspx");
        }
    }
}
