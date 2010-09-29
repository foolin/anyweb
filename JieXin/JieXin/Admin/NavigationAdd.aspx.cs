using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_NavigationAdd : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
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
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        AW_Navigation_bean bean = new AW_Navigation_bean();
        using (AW_Navigation_dao dao = new AW_Navigation_dao())
        {
            bean.fdNaviID = dao.funcNewID();
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
            bean.fdNaviSort = bean.fdNaviID;
            dao.funcInsert(bean);
            this.AddLog(EventType.Insert, "添加导航栏", "添加导航栏[" + bean.fdNaviTitle + "]");
            WebAgent.SuccAndGo("添加成功", "NavigationList.aspx");
        }
    }
}
