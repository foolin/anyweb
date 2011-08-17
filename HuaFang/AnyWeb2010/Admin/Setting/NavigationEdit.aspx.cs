using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_NavigationEdit : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        if (!WebAgent.IsInt32(QS("id")))
            WebAgent.AlertAndBack("编号不正确!");

        AW_Navigation_bean bean = new AW_Navigation_dao().funcGetNavigationByID(int.Parse(QS("id")));
        if (bean == null)
            WebAgent.AlertAndBack("导航栏不存在!");

        foreach (AW_Navigation_bean navigation in new AW_Navigation_dao().funcGetNavigations())
        {
            if (navigation.fdNaviID != bean.fdNaviID)
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

        switch( bean.fdNaviType )
        {
            case 2:
                drpColumn.SelectedValue = bean.fdNaviItemID.ToString();
                break;
            case 3:
                drpSite.SelectedValue = bean.fdNaviItemID.ToString();
                break;
            case 4:
                txtLink.Text = bean.fdNaviLink;
                break;
            default:
                break;

        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        AW_Navigation_bean bean = new AW_Navigation_dao().funcGetNavigationByID(int.Parse(QS("id")));
        if (bean.Children != null && bean.Children.Count != 0 && bean.fdNaviParentID != int.Parse(drpParent.SelectedValue))
            WebAgent.AlertAndBack("该导航栏存在二级导航，不允许修改其父级导航栏!");

        using (AW_Navigation_dao dao = new AW_Navigation_dao())
        {
            bean.fdNaviParentID = int.Parse(drpParent.SelectedValue);
            bean.fdNaviType = int.Parse(drpType.SelectedValue);
            getLink( bean );
            bean.fdNaviTitle = txtTitle.Text;
            dao.funcUpdate(bean);
            this.AddLog( EventType.Update, "修改导航栏", "修改导航栏[" + bean.fdNaviTitle + "]" );
            WebAgent.SuccAndGo("修改成功", "NavigationList.aspx");
        }
    }

    /// <summary>
    /// 获取导航栏链接
    /// </summary>
    /// <returns></returns>
    protected void getLink( AW_Navigation_bean bean )
    {
        switch( drpType.SelectedValue )
        {
            case "1":
                bean.fdNaviLink = "/index.aspx";
                break;
            case "2":
                bean.fdNaviLink = string.Format( "/c/{0}.aspx", drpColumn.SelectedValue );
                bean.fdNaviItemID = int.Parse( drpColumn.SelectedValue );
                break;
            case "3":
                bean.fdNaviLink = string.Format( "/s/{0}.aspx", drpSite.SelectedValue );
                bean.fdNaviItemID = int.Parse( drpSite.SelectedValue );
                break;
            case "4":
                bean.fdNaviLink = string.Format( "/l/{0}.aspx", drpLibrary.SelectedValue );
                bean.fdNaviItemID = int.Parse( drpLibrary.SelectedValue );
                break;
            case "5":
                if( txtLink.Text.ToLower().StartsWith( "http://" ) )
                {
                    bean.fdNaviLink = txtLink.Text.ToLower();
                }
                else
                {
                    bean.fdNaviLink = "http://" + txtLink.Text.ToLower();
                }
                break;
            default:
                bean.fdNaviLink = "/index.aspx";
                break;
        }
    }
}
