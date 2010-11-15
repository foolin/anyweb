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
        int recruitid = 0;
        int.TryParse( Context.Items[ "RECRUITID" ] + "", out recruitid );
        if( recruitid == 0 )
        {
            goErrorPage();
        }
        bean = AW_Recruit_bean.funcGetByID( int.Parse( Context.Items[ "RECRUITID" ].ToString() ) );
        if( bean == null )
        {
            goErrorPage();
        }

        this.Title = "广州市杰信人力资源有限公司 - " + bean.fdRecrTitle;

        if( this.LoginUser != null )
        {
            this._resuList = new AW_Resume_dao().funcGetResumeList( this.LoginUser.fdUserID );
            repResu.DataSource = resuList;
            repResu.DataBind();
        }
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

    protected List<AW_Resume_bean> _resuList;
    public List<AW_Resume_bean> resuList
    {
        get
        {
            return _resuList;
        }
        set
        {
            _resuList = value;
        }
    }
}
