using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.Configs;
using AnyWell.AW_DL;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected override void OnPreRender( EventArgs e )
    {
        this.lt_description.Text = string.Format( "<meta name=\"description\" content=\"{0}\" />", GeneralConfigs.GetConfig().MetaDescription );
        this.lt_keywords.Text = string.Format( "<meta name=\"keywords\" content=\"{0}\" />", GeneralConfigs.GetConfig().MetaKeywords );

        HttpCookie co = HttpContext.Current.Request.Cookies[ "USER" ];
        if( co == null )
            LoginUser = null;
        else
            LoginUser = new AW_User_dao().funcGetUserInfo( int.Parse( co[ "ID" ] ) );
    }

    private AW_User_bean _loginUser;
    /// <summary>
    /// 个人用户
    /// </summary>
    public AW_User_bean LoginUser
    {
        get
        {
            return _loginUser;
        }
        set
        {
            _loginUser = value;
        }
    }
}
