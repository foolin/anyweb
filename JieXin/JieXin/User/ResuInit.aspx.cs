using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class User_ResuInit : PageUser
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected override void OnPreRender(EventArgs e)
    {
        AW_Resume_bean bean = new AW_Resume_bean();
        using (AW_Resume_dao dao = new AW_Resume_dao())
        {
            bean.fdResuID = dao.funcNewID();
            bean.fdResuName = "我的简历";
            bean.fdResuUserID = this.LoginUser.fdUserID;

            //姓名
            bean.fdResuUserName = this.LoginUser.fdUserName;
            //性别
            bean.fdResuSex = this.LoginUser.fdUserSex;
            //出生日期
            bean.fdResuBirthday = this.LoginUser.fdUserBirthday;
            //工作年限
            bean.fdResuExperience = this.LoginUser.fdUserExperience;
            //证件类型
            bean.fdResuIdentificationID = this.LoginUser.fdUserIdentificationID;
            //证件号码
            bean.fdResuIdentificationNum = this.LoginUser.fdUserIdentificationNum;
            //居住地
            bean.fdResuAddressID = this.LoginUser.fdUserAddressID;
            bean.fdResuAddress = this.LoginUser.fdUserAddress;
            //Email
            bean.fdResuEmail = this.LoginUser.fdUserEmail;
            //求职状态
            bean.fdResuCurrentSituation = this.LoginUser.fdUserCurrentSituation;
            //手机号码
            bean.fdResuMobilePhone = this.LoginUser.fdUserMobilePhone;
            //公司电话
            bean.fdResuCompPhone = this.LoginUser.fdUserCompPhone;
            //家庭电话
            bean.fdResuFamiPhone = this.LoginUser.fdUserFamiPhone;
            //户口
            bean.fdResuHouseAddressID = this.LoginUser.fdUserHouseAddressID;
            bean.fdResuHouseAddress = this.LoginUser.fdUserHouseAddress;
            //照片
            if( this.LoginUser.fdUserPhotoIsShow == 1 )
            {
                bean.fdResuPhoto = this.LoginUser.fdUserPhoto;
            }

            //国家地区
            bean.fdResuCountry = this.LoginUser.fdUserCountryID;
            //身高
            bean.fdResuHeight = this.LoginUser.fdUserHeight;
            //邮编
            bean.fdResuPostCode = this.LoginUser.fdUserPostCode;
            //地址
            bean.fdResuContactAddr = this.LoginUser.fdUserContactAddr;
            //婚姻状况
            bean.fdResuMarry = this.LoginUser.fdUserMarry;
            //个人主页
            bean.fdResuWebsite = this.LoginUser.fdUserWebsite;

            bean.fdResuStatus = 1;
            dao.funcInsert(bean);
        }
        Response.Redirect("/User/ResuAdd.aspx?id=" + bean.fdResuID);
    }
}
