using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class User_ResuAdd : PageUser
{
    protected void Page_Load( object sender, EventArgs e )
    {
        if( string.IsNullOrEmpty( QS( "id" ) ) || !WebAgent.IsInt32( QS( "id" ) ) )
        {
            Response.Redirect( "/User/Index.aspx" );
        }
        AW_Resume_bean bean = AW_Resume_bean.funcGetByID( int.Parse( QS( "id" ) ) );
        if( bean == null )
        {
            Response.Redirect( "/User/Index.aspx" );
        }
        if( bean.fdResuUserID != this.LoginUser.fdUserID )
        {
            Response.Redirect( "/User/Index.aspx" );
        }

        this._eduId = new AW_Education_dao().funcNewID();
        this._rewardsId = new AW_Rewards_dao().funcNewID();
        this._posiId = new AW_Position_dao().funcNewID();
    }

    private int _eduId;
    /// <summary>
    /// 教育经历编号
    /// </summary>
    public int eduID
    {
        get
        {
            return _eduId;
        }
        set
        {
            _eduId = value;
        }
    }

    private int _rewardsId;
    /// <summary>
    /// 奖励编号
    /// </summary>
    public int rewardsID
    {
        get
        {
            return _rewardsId;
        }
        set
        {
            _rewardsId = value;
        }
    }

    private int _posiId;
    public int posiID
    {
        get
        {
            return _posiId;
        }
        set
        {
            _posiId = value;
        }
    }
}
