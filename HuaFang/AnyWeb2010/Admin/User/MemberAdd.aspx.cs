﻿using System;
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
using AnyWell.Configs;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_MemberAdd : PageAdmin
{
    protected AW_Member_bean member;
    protected void btnOk_Click(object sender, EventArgs e)
    {
        member = new AW_Member_bean();
        member.fdMembEmail = txtEmail.Text;
        member.fdMembName = txtName.Text;
        member.fdMembTrueName = txtTrueName.Text;
        member.fdMembSex = int.Parse(drpSex.SelectedValue);
        member.fdMembBirthday = txtBirthday.Text;
        int status = 0;
        if (int.TryParse(drpStatus.SelectedValue, out status)) member.fdMembStatus = status;

        member.fdMembPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "MD5");

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
            if(dao.funcEmailExists(member.fdMembEmail))
                WebAgent.AlertAndBack("邮箱已经存在");

            member.fdMembID = dao.funcNewID();
            dao.funcInsert(member);
            WebAgent.SuccAndGo("添加成功","memberlist.aspx");
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