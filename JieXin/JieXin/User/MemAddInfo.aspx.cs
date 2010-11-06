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

public partial class User_Default : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AW_User_bean bean = (new AW_User_dao()).funcGetUserFromCookie();

        if (!IsPostBack)
        {
            int k;
            ArrayList day = new ArrayList();
            for (k = 1; k <= 31; k++)
                day.Add(k);
            drpBirDay.DataSource = day;
            drpBirDay.DataBind();
            drpGraDay.DataSource = day;
            drpGraDay.DataBind();
            int i;
            ArrayList month = new ArrayList();
            for (i = 1; i <= 12; i++)
                month.Add(i);
            drpBirMonth.DataSource = month;
            drpBirMonth.DataBind();
            drpGraMonth.DataSource = month;
            drpGraMonth.DataBind();
            int j;
            ArrayList year = new ArrayList();
            for (j = 1940; j <= 2010; j++)
                year.Add(j);
            drpBirYear.DataSource = year;
            drpBirYear.DataBind();
            drpGraYear.DataSource = year;
            drpGraYear.DataBind();


            txtName.Text = bean.fdUserName;
            if (bean.fdUserSex == 1)
            {
                Radio1.Checked = true;
                Radio2.Checked = false;
            }
            else if (bean.fdUserSex == 0)
            {
                Radio1.Checked = false;
                Radio2.Checked = true;
            }
            drpBirYear.SelectedValue = bean.fdUserBirthday.Year.ToString();
            drpBirMonth.SelectedValue = bean.fdUserBirthday.Month.ToString();
            drpBirDay.SelectedValue = bean.fdUserBirthday.Day.ToString();
            drpExp.SelectedValue = bean.fdUserExperience.ToString();
            drpIdenID.SelectedValue = bean.fdUserIdentificationID.ToString();
            txtIdenNum.Text = bean.fdUserIdentificationNum.ToString();
            //居住地 bean.fdUserAddress
            drpCurrSitu.SelectedValue = bean.fdUserCurrentSituation.ToString();
            drpNation.SelectedValue = bean.fdUserNation.ToString();
            drpGraYear.SelectedValue = bean.fdUserGraDate.Year.ToString();
            drpGraMonth.SelectedValue = bean.fdUserGraDate.Month.ToString();
            drpGraDay.SelectedValue = bean.fdUserGraDate.Day.ToString();
            drpPolSta.SelectedValue = bean.fdUserPoliticalState.ToString();
            drpDegree.SelectedValue = bean.fdUserDegree.ToString();
            txtEmail.Text = bean.fdUserEmail;
            //联系方式
            //户口 bean.fdUserHouseAddress  
            //国家地区 bean.fdUserCountry
            txtHeight.Text = bean.fdUserHeight.ToString();
            txtPostCode.Text = bean.fdUserPostCode.ToString();
            txtConAddr.Text = bean.fdUserContactAddr;
            drpMarry.SelectedValue = bean.fdUserMarry.ToString();
            txtWebsite.Text = bean.fdUserWebsite;
        }

        

        if (IsPostBack)
        {
            using (AW_User_dao dao = new AW_User_dao())
            {
                bean.fdUserName = txtName.Text.Trim();
                if(Radio1.Checked == true)
                {
                    bean.fdUserSex = 1;
                }
                else if (Radio2.Checked == true)
                {
                    bean.fdUserSex = 0;
                }
                bean.fdUserBirthday = DateTime.Parse(drpBirYear.SelectedValue + "-" + drpBirMonth.SelectedValue + "-" + drpBirDay.SelectedValue);
                bean.fdUserExperience = int.Parse(drpExp.SelectedValue);
                bean.fdUserIdentificationID = int.Parse(drpIdenID.SelectedValue);
                bean.fdUserIdentificationNum = txtIdenNum.Text.Trim();
                bean.fdUserAddress = "广州";
                bean.fdUserCurrentSituation = int.Parse(drpCurrSitu.SelectedValue);
                bean.fdUserNation = int.Parse(drpNation.SelectedValue);
                bean.fdUserGraDate = DateTime.Parse(drpGraYear.SelectedValue + "-" + drpGraMonth.SelectedValue + "-" + drpGraDay.SelectedValue);
                bean.fdUserPoliticalState = int.Parse(drpPolSta.SelectedValue);
                bean.fdUserDegree = int.Parse(drpDegree.SelectedValue);
                bean.fdUserEmail = txtEmail.Text.Trim();
                //联系方式
                bean.fdUserHouseAddress = "广州";
                bean.fdUserCountryID = 0;
                bean.fdUserHeight = int.Parse( txtHeight.Text.Trim() );
                bean.fdUserPostCode = txtPostCode.Text.Trim();
                bean.fdUserContactAddr = txtConAddr.Text.Trim();
                bean.fdUserMarry = int.Parse(drpMarry.SelectedValue);
                bean.fdUserWebsite = txtWebsite.Text.Trim();

                dao.funcUpdate(bean);
                dao.funcLogin(bean.fdUserAccount.Trim(), bean.fdUserPwd.Trim(), false);
                Response.Redirect("/User/MemAddInfo.aspx");
            }
        }
    }
}
