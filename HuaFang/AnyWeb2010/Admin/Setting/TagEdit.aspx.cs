using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_TagEdit : PageAdmin
{
    protected override void OnPreRender( EventArgs e )
    {
        string id = QS( "id" );

        if( !WebAgent.IsInt32( id ) )
            WebAgent.AlertAndBack( "编号不正确!" );

        AW_Tag_bean tag = AW_Tag_bean.funcGetByID( QS( "id" ) );
        if( tag == null )
            WebAgent.AlertAndBack( "标签不存在!" );

        txtTitle.Text = tag.fdTagName;
        chkHightLight.Checked = tag.fdTagHightLight == 1 ? true : false;
        txtSort.Text = tag.fdTagSort.ToString();

        if( !this.IsPostBack && Request.UrlReferrer != null )
        {
            ViewState[ "REFURL" ] = Request.UrlReferrer.PathAndQuery;
        }
        else
        {
            ViewState[ "REFURL" ] = "TagList.aspx";
        }
    }

    protected void btnOk_Click( object sender, EventArgs e )
    {
        if( String.IsNullOrEmpty( txtTitle.Text.Trim() ) )
            WebAgent.AlertAndBack( "标签不能为空!" );

        AW_Tag_dao dao = new AW_Tag_dao();
        if( dao.funcCheckTagExist( txtTitle.Text.Trim(), int.Parse( QS( "id" ) ) ) )
        {
            WebAgent.AlertAndBack( "标签已存在！" );
        }
        AW_Tag_bean tag = AW_Tag_bean.funcGetByID( QS( "id" ) );
        tag.fdTagName = txtTitle.Text.Trim();
        tag.fdTagHightLight = chkHightLight.Checked ? 1 : 0;
        int sort = 0;
        if( int.TryParse( txtSort.Text.Trim(), out sort ) && sort > 0 )
        {
            tag.fdTagSort = sort;
        }
        else
        {
            tag.fdTagSort = tag.fdTagID * 100;
        }
        dao.funcUpdate( tag );
        this.AddLog( EventType.Update, "修改标签", "修改标签[" + tag.fdTagName + "]" );
        WebAgent.SuccAndGo( "修改标签成功", ViewState[ "REFURL" ].ToString() );
    }
}
