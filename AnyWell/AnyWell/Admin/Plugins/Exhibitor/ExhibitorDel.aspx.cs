using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Plugins_Exhibitor_ExhibitorDel : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        string ids = QS( "ids" ).Trim();
        if( string.IsNullOrEmpty( ids ) )
        {
            ShowError( "请选择展商！" );
        }

        AW_Exhibitor_dao dao = new AW_Exhibitor_dao();
        List<AW_Exhibitor_bean> list = dao.funcGetExhibitorList( ids );

        if( !IsPostBack )
        {
            repExhibitors.DataSource = list;
            repExhibitors.DataBind();
        }
        else
        {
            if( dao.funcDeletes( ids ) > 0 )
            {
                foreach( AW_Exhibitor_bean bean in list )
                {
                    AddLog( EventType.Delete, "删除展商", string.Format( "删除展商:{0}({1})", bean.fdExhiName, bean.fdExhiID ) );
                }
            }
            Response.Write( "<script type=text/javascript>parent.deleteExhibitorOK();</script>" );
            Response.End();
        }
    }
}
