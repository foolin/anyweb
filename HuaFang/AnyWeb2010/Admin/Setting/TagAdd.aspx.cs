using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_TagAdd : PageAdmin
{
    protected void btnOk_Click( object sender, EventArgs e )
    {
        if( String.IsNullOrEmpty( txtTitle.Text.Trim() ) )
            WebAgent.AlertAndBack( "标签不能为空!" );

        AW_Tag_dao dao = new AW_Tag_dao();

        if( dao.funcCheckTagExist( txtTitle.Text.Trim(), 0 ) )
        {
            WebAgent.AlertAndBack( "标签已存在！" );
        }

        AW_Tag_bean bean = new AW_Tag_bean();
        bean.fdTagID = dao.funcNewID();
        bean.fdTagName = txtTitle.Text.Trim();
        bean.fdTagHightLight = chkHightLight.Checked ? 1 : 0;
        int sort = 0;
        if( int.TryParse( txtSort.Text.Trim(), out sort ) && sort > 0 )
        {
            bean.fdTagSort = sort;
        }
        else
        {
            bean.fdTagSort = bean.fdTagID * 100;
        }
        int record = dao.funcInsert( bean );
        if( record > 0 )
        {
            this.AddLog( EventType.Insert, "添加标签", "添加标签[" + bean.fdTagName + "]" );
            Studio.Web.WebAgent.SuccAndGo( "添加成功", "TagList.aspx" );
        }
    }
}
