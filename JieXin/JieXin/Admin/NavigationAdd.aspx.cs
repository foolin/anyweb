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
            getLink(bean);
            bean.fdNaviTitle = txtTitle.Text;
            bean.fdNaviSort = bean.fdNaviID;
            dao.funcInsert(bean);
            this.AddLog(EventType.Insert, "添加导航栏", "添加导航栏[" + bean.fdNaviTitle + "]");
            WebAgent.SuccAndGo("添加成功", "NavigationList.aspx");
        }
    }

    /// <summary>
    /// 获取导航栏链接
    /// </summary>
    /// <returns></returns>
    protected void getLink(AW_Navigation_bean bean)
    {
        switch( drpType.SelectedValue )
        {
            case "1":
                bean.fdNaviLink = "/index.aspx";
                break;
            case "2":
                bean.fdNaviLink = "/User/Index.aspx";
                break;
            case "3":
                bean.fdNaviLink = "/search.aspx";
                break;
            case "4":
                bean.fdNaviLink = "/notice.aspx";
                break;
            case "5":
                bean.fdNaviLink = string.Format( "/c/{0}.aspx", drpColumn.SelectedValue );
                bean.fdNaviItemID = int.Parse( drpColumn.SelectedValue );
                break;
            case "6":
                {
                    switch( drpRecruit.SelectedValue )
                    {
                        case "-1":
                            bean.fdNaviLink = "/RecruitList.aspx";
                            break;
                        default:
                            bean.fdNaviLink = "/RecruitList.aspx?type=" + drpRecruit.SelectedValue;
                            break;
                    }
                    bean.fdNaviItemID = int.Parse( drpRecruit.SelectedValue );
                    break;
                }
            case "7":
                bean.fdNaviLink = string.Format( "/s/{0}.aspx", drpSite.SelectedValue );
                bean.fdNaviItemID = int.Parse( drpSite.SelectedValue );
                break;
            case "8":
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
