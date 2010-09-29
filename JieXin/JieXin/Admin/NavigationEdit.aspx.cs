using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_NavigationEdit : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (!WebAgent.IsInt32(QS("id")))
            WebAgent.AlertAndBack("编号不正确!");

        AW_Navigation_bean bean = AW_Navigation_bean.funcGetByID(int.Parse(QS("id")));
        if (bean == null)
            WebAgent.AlertAndBack("导航栏不存在!");

        foreach (AW_Navigation_bean navigation in new AW_Navigation_dao().funcGetNavigations())
        {
            drpParent.Items.Add(new ListItem(navigation.fdNaviTitle, navigation.fdNaviID.ToString()));
        }

        foreach (AW_Column_bean column in new AW_Column_dao().funcGetColumns())
        {
            drpColumn.Items.Add(new ListItem(column.fdColuName, column.fdColuID.ToString()));
            foreach (AW_Column_bean child in column.Children)
            {
                drpColumn.Items.Add(new ListItem(column.fdColuName + "----" + child.fdColuName, child.fdColuID.ToString()));
            }
        }
        
        drpParent.SelectedValue = bean.fdNaviParentID.ToString();
        drpType.SelectedValue = bean.fdNaviType.ToString();
        txtTitle.Text = bean.fdNaviTitle;
        if (bean.fdNaviType == 1)
        {
            drpColumn.SelectedValue = bean.fdNaviItemID.ToString();
        }
        else if (bean.fdNaviType == 3)
        {
            txtLink.Text = bean.fdNaviLink;
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        AW_Navigation_bean bean = AW_Navigation_bean.funcGetByID(int.Parse(QS("id")));
        using (AW_Navigation_dao dao = new AW_Navigation_dao())
        {
            bean.fdNaviParentID = int.Parse(drpParent.SelectedValue);
            bean.fdNaviType = int.Parse(drpType.SelectedValue);
            if (bean.fdNaviType == 1)
            {
                bean.fdNaviItemID = int.Parse(drpColumn.SelectedValue);
                bean.fdNaviLink = "/column.aspx?id=" + bean.fdNaviItemID;
            }
            else if (bean.fdNaviType == 2)
            {
                bean.fdNaviLink = "/temp.aspx";
            }
            else
            {
                if (txtLink.Text.ToLower().StartsWith("http://"))
                {
                    bean.fdNaviLink = txtLink.Text.ToLower();
                }
                else
                {
                    bean.fdNaviLink = "http://" + txtLink.Text.ToLower();
                }
            }
            bean.fdNaviTitle = txtTitle.Text;
            dao.funcUpdate(bean);
            this.AddLog(EventType.Update, "修改导航栏", "修改导航栏[" + bean.fdNaviTitle + "]");
            WebAgent.SuccAndGo("修改成功", "NavigationList.aspx");
        }
    }
}
