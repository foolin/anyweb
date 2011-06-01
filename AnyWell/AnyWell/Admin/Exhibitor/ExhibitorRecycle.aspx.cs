using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Exhibitor_ExhibitorRecycle : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        string ids = QS( "ids" ).Trim();
        if( string.IsNullOrEmpty( ids ) )
        {
            ShowError( "请选择展商！" );
        }

        AW_Exhibitor_dao dao = new AW_Exhibitor_dao();
        AW_Publish_dao publishDao = new AW_Publish_dao();
        List<AW_Exhibitor_bean> list = dao.funcGetExhibitorList( ids );

        if( !IsPostBack )
        {
            repExhibitors.DataSource = list;
            repExhibitors.DataBind();
        }
        else
        {
            if( dao.funcRecycleExhibitor( ids ) > 0 )
            {
                foreach( AW_Exhibitor_bean bean in list )
                {
                    if( bean.fdExhiStatus == 2 )
                    {
                        AW_Publish_bean publish = new AW_Publish_bean();
                        publish.fdPublID = publishDao.funcNewID();
                        publish.fdPublName = "撤销发布展商:[" + bean.fdExhiName + "]";
                        publish.fdPublCreateAt = DateTime.Now;
                        publish.fdPublAdminID = AdminInfo.fdAdmiID;
                        publish.fdPublObjID = bean.fdExhiID;
                        publish.fdPublObjType = 3;
                        publish.fdPublType = 4;
                        publish.fdPublStatus = 0;

                        publishDao.funcInsert( publish );
                        PublishService.GetService().AddPublish( publish );
                    }
                    AddLog( EventType.Delete, "删除展商", string.Format( "删除展商:{0}({1})", bean.fdExhiName, bean.fdExhiID ) );
                }
            }
            Response.Write( "<script type=text/javascript>parent.recycleExhibitorOK();</script>" );
            Response.End();
        }
    }
}
