using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;
using AnyWell.Configs;

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
        this._workId = new AW_Work_dao().funcNewID();
        this._langId = new AW_Language_dao().funcNewID();

        this.Title = "添加简历" + GeneralConfigs.GetConfig().TitleExtension;
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
}
