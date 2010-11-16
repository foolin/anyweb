using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;
using AnyWell.Configs;

public partial class User_ResuEdit : PageUser
{
    protected void Page_Load( object sender, EventArgs e )
    {
        if( string.IsNullOrEmpty( QS( "id" ) ) || !WebAgent.IsInt32( QS( "id" ) ) )
        {
            WebAgent.FailAndGo( "简历不存在！", "/User/Index.aspx" );
        }

        bean = new AW_Resume_dao().funcGetResume( int.Parse( QS( "id" ) ) );
        if( bean == null || bean.fdResuUserID != this.LoginUser.fdUserID )
        {
            WebAgent.FailAndGo( "简历不存在！", "/User/Index.aspx" );
        }

        //教育经历
        repEdu.DataSource = bean.EducationList;
        repEdu.DataBind();
        //奖励
        repRew.DataSource = bean.RewardList;
        repRew.DataBind();
        //职务
        repPos.DataSource = bean.PositionList;
        repPos.DataBind();
        //工作经验
        repWork.DataSource = bean.WorkList;
        repWork.DataBind();
        //语言能力
        repLan.DataSource = bean.LanguageList;
        repLan.DataBind();
        //证书
        repCert.DataSource = bean.CertList;
        repCert.DataBind();
        //奖项
        repAwar.DataSource = bean.AwardList;
        repAwar.DataBind();
        //技能
        repSkill.DataSource = bean.SkillList;
        repSkill.DataBind();

        this.Title = "修改简历" + GeneralConfigs.GetConfig().TitleExtension;
    }

    private AW_Resume_bean _bean;
    public AW_Resume_bean bean
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
