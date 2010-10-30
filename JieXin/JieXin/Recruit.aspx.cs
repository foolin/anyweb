using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Recruit : PageBase
{
    protected override void OnPreRender( EventArgs e )
    {
        if( Context.Items[ "RECRUITID" ] == null || !WebAgent.IsInt32( Context.Items[ "RECRUITID" ].ToString() ) )
        {
            WebAgent.FailAndGo( "职位不存在！", "/Index.aspx" );
        }
        bean = AW_Recruit_bean.funcGetByID( int.Parse( Context.Items[ "RECRUITID" ].ToString() ) );
        if( bean == null )
        {
            WebAgent.FailAndGo( "职位不存在！", "/Index.aspx" );
        }

        this.Title = "广州市杰信人力资源有限公司 - " + bean.fdRecrTitle;
    }

    private AW_Recruit_bean _bean;
    public AW_Recruit_bean bean
    {
        get
        {
            return _bean;
        }
        set
        {
            _bean = value;
        }
    }
}
