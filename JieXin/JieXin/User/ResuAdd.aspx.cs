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
        this._workId = new AW_Work_dao().funcNewID();
        this._langId = new AW_Language_dao().funcNewID();
        this._certId = new AW_Cert_dao().funcNewID();
        this._awarId = new AW_Awards_dao().funcNewID();
        this._skillId = new AW_Skills_dao().funcNewID();
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
    /// <summary>
    /// 职务编号
    /// </summary>
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

    private int _workId;
    /// <summary>
    /// 工作经历编号
    /// </summary>
    public int workID
    {
        get
        {
            return _workId;
        }
        set
        {
            _workId = value;
        }
    }

    private int _langId;
    /// <summary>
    /// 语言能力编号
    /// </summary>
    public int langID
    {
        get
        {
            return _langId;
        }
        set
        {
            _langId = value;
        }
    }

    private int _certId;
    /// <summary>
    /// 证书编号
    /// </summary>
    public int certID
    {
        get
        {
            return _certId;
        }
        set
        {
            _certId = value;
        }
    }

    private int _awarId;
    /// <summary>
    /// 奖项编号
    /// </summary>
    public int awarID
    {
        get
        {
            return _awarId;
        }
        set
        {
            _awarId = value;
        }
    }

    private int _skillId;
    /// <summary>
    /// 技能编号
    /// </summary>
    public int skillID
    {
        get
        {
            return _skillId;
        }
        set
        {
            _skillId = value;
        }
    }
}
