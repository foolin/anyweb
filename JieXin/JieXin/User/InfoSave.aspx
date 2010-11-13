<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InfoSave.aspx.cs" Inherits="User_InfoSave" %>

<table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td width="598" valign="top">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <th scope="row">
                        &nbsp;姓&nbsp;&nbsp;&nbsp;&nbsp;名
                    </th>
                    <td width="218">
                        <%=resume.fdResuUserName%>
                    </td>
                    <th>
                        &nbsp;性&nbsp;&nbsp;&nbsp;&nbsp;别
                    </th>
                    <td>
                        <%=resume.fdResuSex==0?"男":"女" %>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        &nbsp;出生日期
                    </th>
                    <td width="218">
                        <%=resume.fdResuBirthday!=DateTime.Parse("1900-01-01")?resume.fdResuBirthday.ToString("yyyy年M月d日"):"" %>
                    </td>
                    <th>
                        &nbsp;工作年限
                    </th>
                    <td>
                        <%=getExpString(resume.fdResuExperience) %>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        &nbsp;证件类型
                    </th>
                    <td width="218">
                        <%=getIdentString(resume.fdResuIdentificationID) %>
                    </td>
                    <th>
                        &nbsp;证&nbsp;件&nbsp;号
                    </th>
                    <td>
                        <%=resume.fdResuIdentificationNum %>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        &nbsp;居&nbsp;住&nbsp;地
                    </th>
                    <td width="218">
                        <%=resume.fdResuAddress %>
                    </td>
                    <th>
                        &nbsp;Email
                    </th>
                    <td>
                        <%=resume.fdResuEmail %>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        &nbsp;年&nbsp;&nbsp;&nbsp;&nbsp;薪
                    </th>
                    <td width="218">
                        <%=getSalaryString( resume.fdResuSalary )%>
                    </td>
                    <th>
                        &nbsp;币&nbsp;&nbsp;&nbsp;&nbsp;种
                    </th>
                    <td>
                        <%=getCurrTypeString( resume.fdResuCurrType )%>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        &nbsp;联系方式
                    </th>
                    <td width="218" class="orange">
                    </td>
                    <th>
                        &nbsp;求职状态
                    </th>
                    <td>
                        <%=getCurrSituString( resume.fdResuCurrentSituation )%>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        &nbsp;手机号码
                    </th>
                    <td width="218">
                        <%=resume.fdResuMobilePhone %>
                    </td>
                    <th>
                        &nbsp;公司电话
                    </th>
                    <td>
                        <%=resume.fdResuCompPhone %>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        &nbsp;家庭电话
                    </th>
                    <td width="218">
                        <%=resume.fdResuFamiPhone %>
                    </td>
                    <th>
                        &nbsp;户&nbsp;&nbsp;&nbsp;&nbsp;口
                    </th>
                    <td>
                        <%=resume.fdResuHouseAddress %>
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="38" class="tr">
                        <input type="button" class="btn60_28" id="btn_info_save" value="修改" onclick="editinfo('info',<%=resume.fdResuID %>,'btn_info_save','info')" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <img src="<%=resume.fdResuPhoto==""?"../images/img_personPhoto.png":resume.fdResuPhoto %>"
                            width="90" height="110" class="imgBor" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<div class="blank12px">
</div>
<div class=" lh24 green">
    <a href="javascript:void(0);" onclick="object_toggle('ext_info')">查看更多个人信息<span id="ext_info_up"
        style="display: none">↑</span><span id="ext_info_down">↓</span></a></div>
<table id="ext_info" width="598" class="tableInfo" style="display:none" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <th scope="row">
            &nbsp;国家地区
        </th>
        <td width="218">
            <%=getCountryString(resume.fdResuCountry) %>
        </td>
        <th>
            &nbsp;身&nbsp;&nbsp;&nbsp;&nbsp;高
        </th>
        <td>
            <%=resume.fdResuHeight==0?"":resume.fdResuHeight.ToString() %>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;邮&nbsp;&nbsp;&nbsp;&nbsp;编
        </th>
        <td width="218">
            <%=resume.fdResuPostCode %>
        </td>
        <th>
            &nbsp;地&nbsp;&nbsp;&nbsp;&nbsp;址
        </th>
        <td>
            <%=resume.fdResuContactAddr %>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;婚姻状况
        </th>
        <td width="218">
            <%=getMarryString(resume.fdResuMarry) %>
        </td>
        <th>
            &nbsp;个人主页
        </th>
        <td>
            <%=resume.fdResuWebsite %>
        </td>
    </tr>
</table>
<div class="blank6px">
</div>
