using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Ajax_ExhibitorSort : AjaxPageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int exhibitorId = 0;
        int previewId = 0;
        int nextId = 0;

        int.TryParse( QS( "id" ), out exhibitorId );

        int.TryParse( QS( "previewid" ), out previewId );

        int.TryParse( QS( "nextid" ), out nextId );

        if( exhibitorId > 0 && ( previewId > 0 || nextId > 0 ) )
        {
            AW_Exhibitor_bean exhibitor = AW_Exhibitor_bean.funcGetByID( exhibitorId );

            if( exhibitor == null )
            {
                RenderString( "展商不存在，排序失败！" );
            }

            AW_Exhibitor_bean next = nextId == 0 ? null : AW_Exhibitor_bean.funcGetByID( nextId, "fdExhiID,fdExhiSort" );
            AW_Exhibitor_bean preview = previewId == 0 ? null : AW_Exhibitor_bean.funcGetByID( previewId, "fdExhiID,fdExhiSort" );

            if( next == null && preview == null )
            {
                RenderString( "存在操作已删除展商，排序失败！" );
            }

            using( AW_Exhibitor_dao dao = new AW_Exhibitor_dao() )
            {
                if( dao.funcSortExhibitor( exhibitor, preview, next ) )
                {
                    this.AddLog( EventType.Update, "修改展商排序", "修改展商[" + exhibitor.fdExhiName + "]排序" );
                    RenderString( "" );
                }
                else
                {
                    RenderString( "排序失败，请稍候再试！" );
                }
            }
        }
        else
        {
            RenderString( "存在操作已删除展商，排序失败！" );
        }
    }
}
