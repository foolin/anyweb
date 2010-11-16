using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Studio.Web;
using AnyWell.AW_DL;
using Studio.Security;
using AnyWell.Configs;

public partial class User_MemAddInfo : PageUser
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AW_User_bean bean = this.LoginUser;

        if (!IsPostBack)
        {
            //初始化年月日
            int k;
            ArrayList day = new ArrayList();
            for (k = 1; k <= 31; k++)
                day.Add(k);
            drpBirDay.DataSource = day;
            drpBirDay.DataBind();
            drpGraDay.DataSource = day;
            drpGraDay.DataBind();
            drpBirDay.Items.Insert( 0, new ListItem( "日", "0" ) );
            drpGraDay.Items.Insert( 0, new ListItem( "日", "0" ) );
            int i;
            ArrayList month = new ArrayList();
            for (i = 1; i <= 12; i++)
                month.Add(i);
            drpBirMonth.DataSource = month;
            drpBirMonth.DataBind();
            drpGraMonth.DataSource = month;
            drpGraMonth.DataBind();
            drpBirMonth.Items.Insert( 0, new ListItem( "月", "0" ) );
            drpGraMonth.Items.Insert( 0, new ListItem( "月", "0" ) );
            int j;
            ArrayList year = new ArrayList();
            for (j = 1940; j <= DateTime.Now.Year; j++)
                year.Add(j);
            drpBirYear.DataSource = year;
            drpBirYear.DataBind();
            drpGraYear.DataSource = year;
            drpGraYear.DataBind();
            drpBirYear.Items.Insert( 0, new ListItem( "年", "0" ) );
            drpGraYear.Items.Insert( 0, new ListItem( "年", "0" ) );

            //性别
            txtName.Text = bean.fdUserName;
            if (bean.fdUserSex == 0)
            {
                Radio1.Checked = true;
                Radio2.Checked = false;
            }
            else
            {
                Radio1.Checked = false;
                Radio2.Checked = true;
            }
            //出生日期
            if( bean.fdUserBirthday.ToString( "yyyy-MM-dd" ) != "1900-01-01" )
            {
                drpBirYear.SelectedValue = bean.fdUserBirthday.Year.ToString();
                drpBirMonth.SelectedValue = bean.fdUserBirthday.Month.ToString();
                drpBirDay.SelectedValue = bean.fdUserBirthday.Day.ToString();
            }
            //工作年限
            drpExp.SelectedValue = bean.fdUserExperience.ToString();
            //证件类型
            drpIdenID.SelectedValue = bean.fdUserIdentificationID.ToString();
            //证件号码
            txtIdenNum.Text = bean.fdUserIdentificationNum.ToString();
            //求职状态
            drpCurrSitu.SelectedValue = bean.fdUserCurrentSituation.ToString();
            //毕业时间
            if( bean.fdUserGraDate.ToString( "yyyy-MM-dd" ) != "1900-01-01" )
            {
                drpGraYear.SelectedValue = bean.fdUserGraDate.Year.ToString();
                drpGraMonth.SelectedValue = bean.fdUserGraDate.Month.ToString();
                drpGraDay.SelectedValue = bean.fdUserGraDate.Day.ToString();
            }
            //政治面貌
            drpPolSta.SelectedValue = bean.fdUserPoliticalState.ToString();
            //教育程序
            drpDegree.SelectedValue = bean.fdUserDegree.ToString();
            //居住地               
            if( bean.fdUserAddressID != 0 )
            {
                txtAddressID.Text = bean.fdUserAddressID.ToString();
                txtAddress.Text = bean.fdUserAddress;
            }
            //联系方式
            if( !string.IsNullOrEmpty( bean.fdUserMobilePhone ) )
            {
                string[] moblie = bean.fdUserMobilePhone.Split( '-' );
                txtMobPhoNum1.Text = moblie[ 0 ];
                txtMobPhoNum2.Text = moblie[ 1 ];
            }
            if( !string.IsNullOrEmpty( bean.fdUserCompPhone ) )
            {
                string[] compPhone = bean.fdUserCompPhone.Split( '-' );
                txtComPhoNum1.Text = compPhone[ 0 ];
                txtComPhoNum2.Text = compPhone[ 1 ];
                txtComPhoNum3.Text = compPhone[ 2 ];
                txtComPhoNum4.Text = compPhone[ 3 ];
            }
            if( !string.IsNullOrEmpty( bean.fdUserFamiPhone ) )
            {
                string[] famiPhone = bean.fdUserFamiPhone.Split( '-' );
                txtFamPhoNum1.Text = famiPhone[ 0 ];
                txtFamPhoNum2.Text = famiPhone[ 1 ];
                txtFamPhoNum3.Text = famiPhone[ 2 ];
            }
            //户口
            if( bean.fdUserHouseAddressID != 0 )
            {
                txtHouseAddressID.Text = bean.fdUserHouseAddressID.ToString();
                txtHouseAddress.Text = bean.fdUserHouseAddress;
            }
            //国家地区
            drpCountry.SelectedValue = bean.fdUserCountryID.ToString();
            //身高
            if( bean.fdUserHeight != 0 )
            {
                txtHeight.Text = bean.fdUserHeight.ToString();
            }
            //邮政编号
            txtPostCode.Text = bean.fdUserPostCode.ToString();
            //联系地址
            txtConAddr.Text = bean.fdUserContactAddr;
            //婚姻状况
            drpMarry.SelectedValue = bean.fdUserMarry.ToString();
            //个人主页
            txtWebsite.Text = bean.fdUserWebsite;
        }
        else
        {
            using (AW_User_dao dao = new AW_User_dao())
            {
                //姓名
                bean.fdUserName = txtName.Text.Trim();
                //性别
                if(Radio1.Checked == true)
                {
                    bean.fdUserSex = 0;
                }
                else
                {
                    bean.fdUserSex = 1;
                }
                //出生日期
                DateTime date;
                if( DateTime.TryParse( drpBirYear.SelectedValue + "-" + drpBirMonth.SelectedValue + "-" + drpBirDay.SelectedValue, out date ) )
                {
                    bean.fdUserBirthday = date;
                }
                else
                {
                    bean.fdUserBirthday = DateTime.Parse( "1900-01-01" );
                }
                //工作年限
                bean.fdUserExperience = int.Parse(drpExp.SelectedValue);
                //证件类型
                bean.fdUserIdentificationID = int.Parse(drpIdenID.SelectedValue);
                //证件号码
                bean.fdUserIdentificationNum = txtIdenNum.Text.Trim();
                //居住地
                bean.fdUserAddressID = int.Parse( txtAddressID.Text.Trim() );
                bean.fdUserAddress = txtAddress.Text.Trim();
                //求职状态
                bean.fdUserCurrentSituation = int.Parse(drpCurrSitu.SelectedValue);
                //毕业时间
                if( drpGraYear.SelectedValue == "0" || drpGraMonth.SelectedValue == "0" || drpGraDay.SelectedValue == "0" )
                {
                    bean.fdUserGraDate = DateTime.Parse( "1900-01-01" );
                }
                else
                {
                    bean.fdUserGraDate = DateTime.Parse( drpGraYear.SelectedValue + "-" + drpGraMonth.SelectedValue + "-" + drpGraDay.SelectedValue );
                }
                //政治面貌
                bean.fdUserPoliticalState = int.Parse(drpPolSta.SelectedValue);
                //教育程序
                bean.fdUserDegree = int.Parse(drpDegree.SelectedValue);
                //联系方式
                bean.fdUserMobilePhone = txtMobPhoNum1.Text.Trim() + "-" + txtMobPhoNum2.Text.Trim();
                bean.fdUserCompPhone = txtComPhoNum1.Text.Trim() + "-" + txtComPhoNum2.Text.Trim() + "-" + txtComPhoNum3.Text.Trim() + "-" + txtComPhoNum4.Text.Trim();
                bean.fdUserFamiPhone = txtFamPhoNum1.Text.Trim() + "-" + txtFamPhoNum2.Text.Trim() + "-" + txtFamPhoNum3.Text.Trim();
                //户口
                if( !string.IsNullOrEmpty( txtHouseAddressID.Text.Trim() ) && txtHouseAddressID.Text.Trim() != "0" )
                {
                    bean.fdUserHouseAddressID = int.Parse( txtHouseAddressID.Text.Trim() );
                    bean.fdUserHouseAddress = txtHouseAddress.Text.Trim();
                }
                else
                {
                    bean.fdUserHouseAddressID = 0;
                    bean.fdUserHouseAddress = "";
                }
                //国家地区
                bean.fdUserCountryID = int.Parse( drpCountry.SelectedValue );
                //身高
                if( !string.IsNullOrEmpty( txtHeight.Text.Trim() ) )
                {
                    bean.fdUserHeight = int.Parse( txtHeight.Text.Trim() );
                }
                //邮编
                bean.fdUserPostCode = txtPostCode.Text.Trim();
                //联系地址
                bean.fdUserContactAddr = txtConAddr.Text.Trim();
                //婚姻状况
                bean.fdUserMarry = int.Parse(drpMarry.SelectedValue);
                //个人主页
                bean.fdUserWebsite = txtWebsite.Text.Trim();

                dao.funcUpdate(bean);
                WebAgent.SuccAndGo( "保存成功！", "/User/MemAddInfo.aspx" );
            }
        }

        this.Title = "基本信息管理" + GeneralConfigs.GetConfig().TitleExtension;
    }
}
