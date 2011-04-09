using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_Ajax_SiteSort : AjaxPageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        AW_Site_dao dao = new AW_Site_dao();

        int sid = 0, nid = 0;
        int.TryParse( QS( "sid" ), out sid );
        int.TryParse( QS( "nid" ), out nid );

        if( sid == 0 || nid == 0 )
        {
            RenderString( "非法站点编号！" );
        }

        AW_Site_bean bean = dao.funcGetSiteInfo( sid );
        AW_Site_bean nextbean = null;
        if( nid > 0 )
        {
            nextbean = dao.funcGetSiteInfo( nid );
        }

        if( bean == null || ( nid > 0 && nextbean == null ) )
        {
            RenderString( "出现操作已删除站点，此次排序不起效，系统将强行刷新页面！" );
        }

        if( !dao.funcSortSite( bean, nextbean ) )
        {
            RenderString( "排序失败，请稍候再试！" );
        }
        else
        {
            AddLog( EventType.Update, "修改站点排序", string.Format( "修改站点排序:{0}({1})", bean.fdSiteName, bean.fdSiteID ) );
        }
    }
}
