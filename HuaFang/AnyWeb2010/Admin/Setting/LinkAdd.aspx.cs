using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Setting_LinkAdd : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {

    }

    protected void btnOk_Click( object sender, EventArgs e )
    {
        AW_Link_bean bean = new AW_Link_bean();
        bean.fdLinkName = txtTitle.Text.Trim();
        bean.fdLinkUrl = txtUrl.Text.Trim();
        bean.fdLinkSort = int.Parse( txtSort.Text.Trim() );
        using( AW_Link_dao dao = new AW_Link_dao() )
        {
            bean.fdLinkID = dao.funcNewID();
            if( bean.fdLinkSort == 0 )
            {
                bean.fdLinkSort = bean.fdLinkID * 100;
            }
            int record = dao.funcInsert( bean );
            if( record > 0 )
            {
                this.AddLog( EventType.Insert, "添加友情链接", "添加友情链接[" + bean.fdLinkName + "]" );
                Studio.Web.WebAgent.SuccAndGo( "添加成功", "LinkList.aspx" );
            }
        }
    }
}
