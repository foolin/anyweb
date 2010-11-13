using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class User_InfoSave : PageUser
{
    protected AW_Resume_bean resume;
    protected void Page_Load( object sender, EventArgs e )
    {
        if( string.IsNullOrEmpty( QS( "id" ) ) || !WebAgent.IsInt32( QS( "id" ) ) )
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }

        resume = AW_Resume_bean.funcGetByID( int.Parse( QS( "id" ) ) );
        if( resume == null || resume.fdResuUserID != this.LoginUser.fdUserID )
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
        //姓名
        resume.fdResuUserName = QF( "userName" ).Trim();
        //性别
        resume.fdResuSex = int.Parse( QF( "sex" ) );
        //出生日期
        DateTime date;
        if( !DateTime.TryParse( string.Format( "{0}-{1}-{2}", QF( "BirYear" ), QF( "BirMonth" ), QF( "BirDay" ) ), out date ) )
        {
            resume.fdResuBirthday = DateTime.Parse( "1900-01-01" );
        }
        else
        {
            resume.fdResuBirthday = date;
        }
        //工作年限
        resume.fdResuExperience = int.Parse( QF( "Exp" ) );
        //证件类型
        resume.fdResuIdentificationID = int.Parse( QF( "IdenID" ) );
        //证件号码
        resume.fdResuIdentificationNum = QF( "IdenNum" ).Trim();
        //居住地
        if( WebAgent.IsInt32( QF( "AddressID" ) ) )
        {
            resume.fdResuAddressID = int.Parse( QF( "AddressID" ) );
            resume.fdResuAddress = QF( "Address" );
        }
        //Email
        resume.fdResuEmail = QF( "email" ).Trim();
        //年薪
        resume.fdResuSalary = int.Parse( QF( "Salary" ) );
        //币种
        resume.fdResuCurrType = int.Parse( QF( "CurrType" ) );
        //求职状态
        resume.fdResuCurrentSituation = int.Parse( QF( "CurrSitu" ) );
        //手机号码
        resume.fdResuMobilePhone = string.Format( "{0}-{1}", QF( "MobPhoNum1" ).Trim(), QF( "MobPhoNum2" ).Trim() );
        //公司电话
        resume.fdResuCompPhone = string.Format( "{0}-{1}-{2}-{3}", QF( "ComPhoNum1" ).Trim(), QF( "ComPhoNum2" ).Trim(), QF( "ComPhoNum3" ), QF( "ComPhoNum4" ).Trim() );
        //家庭电话
        resume.fdResuFamiPhone = string.Format( "{0}-{1}-{2}", QF( "FamPhoNum1" ).Trim(), QF( "FamPhoNum2" ).Trim(), QF( "FamPhoNum3" ).Trim() );
        //户口
        if( WebAgent.IsInt32( QF( "HouseAddressID" ) ) )
        {
            resume.fdResuHouseAddressID = int.Parse( QF( "HouseAddressID" ) );
            resume.fdResuHouseAddress = QF( "HouseAddress" );
        }
        //国家地区
        resume.fdResuCountry = int.Parse( QF( "Country" ) );
        //身高
        if( WebAgent.IsInt32( QF( "Height" ).Trim() ) )
        {
            resume.fdResuHeight = int.Parse( QF( "Height" ).Trim() );
        }
        //邮编
        resume.fdResuPostCode = QF( "PostCode" ).Trim();
        //地址
        resume.fdResuContactAddr = QF( "ConAddr" ).Trim();
        //婚姻状况
        resume.fdResuMarry = int.Parse( QF( "Marry" ) );
        //个人主页
        resume.fdResuWebsite = QF( "Website" ).Trim();
        //照片
        resume.fdResuPhoto = QF( "photo" ).Trim();

        resume.fdResuStatus = 0;
        resume.fdResuUpdateAt = DateTime.Now;

        new AW_Resume_dao().funcUpdate( resume );
    }
}
