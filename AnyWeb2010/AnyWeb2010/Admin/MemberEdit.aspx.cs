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

using System.IO;
using AnyWeb.AW.Configs;
using AnyWeb.AW_DL;
using Studio.Web;


public partial class Admin_MemberEdit : PageAdmin
{
    protected AW_Member_bean member;

    protected void Page_Load(object sender, EventArgs e)
    {
        string id = QS("id");

        if (!WebAgent.IsInt32(id)) WebAgent.AlertAndBack("编号不正确!");

        member = AW_Member_bean.funcGetByID(id);

        if (member == null) WebAgent.AlertAndBack("会员不存在!");
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        txtEmail.Text = member.fdMembEmail;
        txtName.Text = member.fdMembName;
        txtTrueName.Text = member.fdMembTrueName;
        imgPicture.ImageUrl = member.fdMembAvator;
        imgPicture.Width = GeneralConfigs.GetConfig().MemberAvatorWidth;
        imgPicture.Height = GeneralConfigs.GetConfig().MemberAvatorHeight;
        drpSex.SelectedValue = member.fdMembSex.ToString();
        txtBirthday.Text = member.fdMembBirthday;
        drpStatus.SelectedValue = member.fdMembStatus.ToString();

        txtAddress.Text = member.fdMembAddress;
        txtPostCode.Text = member.fdMembPostcode;
        txtMobile.Text = member.fdMembMobile;
        txtPhone.Text = member.fdMembPhone;
        txtQQ.Text = member.fdMembQQ;
        txtMSN.Text = member.fdMembMSN;
        txtOtherContact.Text = member.fdMembOtherContact;

        txtPoint.Text = member.fdMembPoint.ToString();
        lblLoginIP.Text = member.fdMembLoginIP;
        lblLoginAt.Text = member.fdMembLoginAt.ToString("yyyy年MM月dd日 HH时mm分ss秒");
        lblUpdateAt.Text = member.fdMembUpdateAt.ToString("yyyy年MM月dd日 HH时mm分ss秒");
        txtQuestion.Text = member.fdMembPwdQuestion;
        txtAnswer.Text = member.fdMembPwdAnswer;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {

        member.fdMembName = txtName.Text;
        member.fdMembTrueName = txtTrueName.Text;
        member.fdMembSex = int.Parse(drpSex.SelectedValue);
        member.fdMembBirthday = txtBirthday.Text;
        int status = 0;
        if (int.TryParse(drpStatus.SelectedValue, out status)) member.fdMembStatus = status;

        if (txtPassword.Text != "") member.fdMembPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "MD5");

        member.fdMembAddress = txtAddress.Text;
        member.fdMembPostcode = txtPostCode.Text;
        member.fdMembMobile = txtMobile.Text;
        member.fdMembPhone = txtPhone.Text;
        member.fdMembQQ = txtQQ.Text;
        member.fdMembMSN = txtMSN.Text;
        member.fdMembOtherContact = txtOtherContact.Text;

        int pId = 0, cId = 0, aId = 0, point = 0;
        int.TryParse(Request.Form["drpProvince"], out pId);
        int.TryParse(Request.Form["drpCity"], out cId);
        int.TryParse(Request.Form["drpArea"], out aId);

        member.fdMembProvinceID = pId;
        member.fdMembCityID = cId;
        member.fdMembAreaID = aId;

        if (int.TryParse(txtPoint.Text, out point))
            member.fdMembPoint = point;

        member.fdMembAvator = uploadFile();

        member.fdMembPwdQuestion = txtQuestion.Text;
        member.fdMembPwdAnswer = txtAnswer.Text;

        using (AW_Member_dao dao = new AW_Member_dao())
        {
            int record = dao.funcUpdate(member);
            if (record > 0)
            {
                WebAgent.Alert("修改成功！");
            }
        }

    }

    string uploadFile()
    {
        if (fileAvator.PostedFile.ContentLength == 0 || !fileAvator.PostedFile.ContentType.ToLower().Contains("image"))
            return member.fdMembAvator;

        string path = "/Files/Member/";
        if (!Directory.Exists(Server.MapPath(path))) Directory.CreateDirectory(Server.MapPath(path));

        string filePath = path + DL_helper.funcGetTicks().ToString() + fileAvator.FileName;
        //fileAvator.SaveAs(Server.MapPath(filePath));
        WebAgent.SaveFile(fileAvator.PostedFile, Server.MapPath(filePath), GeneralConfigs.GetConfig().MemberAvatorWidth, GeneralConfigs.GetConfig().MemberAvatorHeight);

        return filePath;
    }


}
