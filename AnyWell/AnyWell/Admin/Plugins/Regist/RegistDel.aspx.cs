using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Plugins_Regist_RegistDel : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        string ids = QS( "ids" ).Trim();
        if( string.IsNullOrEmpty( ids ) )
        {
            ShowError( "请选择观众预登记！" );
        }

        AW_Regist_dao dao = new AW_Regist_dao();
        List<AW_Regist_bean> list = dao.funcGetRegistList( ids );

        if( !IsPostBack )
        {
            repRegist.DataSource = list;
            repRegist.DataBind();
        }
        else
        {
            if( dao.funcDeletes( ids ) > 0 )
            {
                foreach( AW_Regist_bean bean in list )
                {
                    AddLog( EventType.Delete, "删除观众预登记", string.Format( "删除观众预登记:{0}", bean.fdRegiID ) );
                }
            }
            Response.Write( "<script type=text/javascript>parent.deleteRegistOK();</script>" );
            Response.End();
        }
    }
}
