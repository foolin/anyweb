using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_ApplyList : PageAdmin
{
    protected override void OnPreRender( EventArgs e )
    {
        if( string.IsNullOrEmpty( QS( "id" ) ) && !WebAgent.IsInt32( QS( "id" ) ) )
        {
            WebAgent.AlertAndBack( "职位不存在！" );
        }
        if( !string.IsNullOrEmpty( QS( "back" ) ) )
        {
            this.back = QS( "back" ).Replace( "pageindex", "pid" );
        }
        else
        {
            this.back = "recruitlist.aspx";
        }
        int recordCount = 0;
        compRep.DataSource = new AW_Resume_dao().funcGetApplyResumeList( int.Parse( QS( "id" ) ), PN1.PageIndex, PN1.PageSize, out recordCount );
        compRep.DataBind();
        PN1.SetPage( recordCount );
    }


    private string _back;
    public string back
    {
        get
        {
            return _back;
        }
        set
        {
            _back = value;
        }
    }
}
