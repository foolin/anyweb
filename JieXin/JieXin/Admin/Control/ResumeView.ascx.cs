using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Control_ResumeView : ControlBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        this._bean = ( AW_Resume_bean ) Context.Items[ "RESUME" ];

        //最高学历
        int degree = 0;
        foreach( AW_Education_bean edu in bean.EducationList )
        {
            if( edu.fdEducDegree > degree )
            {
                degree = edu.fdEducDegree;
                education = edu;
            }
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

    private AW_Education_bean _education;
    /// <summary>
    /// 最高学历
    /// </summary>
    public AW_Education_bean education
    {
        get
        {
            return _education;
        }
        set
        {
            _education = value;
        }
    }

    /// <summary>
    /// 获取联系电话
    /// </summary>
    /// <returns></returns>
    protected string getPhone()
    {
        string[] mobilePhone = bean.fdResuMobilePhone.Split( '-' );
        string[] companyPhone = bean.fdResuCompPhone.Split( '-' );
        string[] familyPhone = bean.fdResuFamiPhone.Split( '-' );
        if( mobilePhone.Length == 2 && mobilePhone[ 1 ].Length > 0 && mobilePhone[ 1 ] != "手机号码" )
        {
            return mobilePhone[ 1 ] + "（手机）";
        }
        else if( companyPhone.Length == 4 && companyPhone[ 1 ].Length > 0 && companyPhone[ 1 ] != "区号" && companyPhone[ 2 ].Length > 0 && companyPhone[ 2 ] != "总机号码" )
        {
            if( companyPhone[ 3 ] != "分机" )
            {
                return string.Format( "{0}-{1}-{2}（公司电话）", companyPhone[ 1 ], companyPhone[ 2 ], companyPhone[ 3 ] );
            }
            else
            {
                return string.Format( "{0}-{1}（公司电话）", companyPhone[ 1 ], companyPhone[ 2 ] );
            }
        }
        else if( familyPhone.Length == 3 && familyPhone[ 1 ].Length > 0 && familyPhone[ 1 ] != "区号" && familyPhone[ 2 ].Length > 0 && familyPhone[ 2 ] != "电话号码" )
        {
            return string.Format( "{0}-{1}（手机）", familyPhone[ 1 ], familyPhone[ 2 ] );
        }
        else
        {
            return "";
        }
    }
}
