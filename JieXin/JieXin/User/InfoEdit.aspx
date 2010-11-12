<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InfoEdit.aspx.cs" Inherits="User_InfoEdit" %>

<form action="/User/InfoSave.aspx?id=<%=QS("id") %>" id="Info_form" method="post">
<table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td width="598" valign="top">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <th scope="row">
                    </th>
                    <td colspan="3">
                        <span class="tipW red hidden" id="errorMsg_Name">姓名不能为空！</span>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        <span class="orange">*</span>姓&nbsp;&nbsp;&nbsp;&nbsp;名
                    </th>
                    <td width="218">
                        <input type="text" class="pwdinput" id="userName" name="userName" maxlength="30"
                            value="<%=resume.fdResuName %>" />
                    </td>
                    <th>
                        <span class="orange">*</span>性&nbsp;&nbsp;&nbsp;&nbsp;别
                    </th>
                    <td>
                        <input type="radio" name="sex" value="0" <%=resume.fdResuSex==0?"checked=\"checked\"":"" %> />男
                        <input type="radio" name="sex" value="1" <%=resume.fdResuSex==1?"checked=\"checked\"":""%> />女
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                    </th>
                    <td>
                        <span class="tipW red hidden" id="errorMsg_Bir">请选择正确的出生日期！</span>
                    </td>
                    <th scope="row">
                    </th>
                    <td>
                        <span class="tipW red hidden" id="errorMsg_Exp">请选择工作年限！</span>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        <span class="orange">*</span>出生日期
                    </th>
                    <td width="218">
                        <select id="BirYear" name="BirYear">
                            <%for( int i = DateTime.Now.Year; i >= 1940; i-- )
                              { %>
                            <option value="<%=i%>" <%=resume.fdResuBirthday.Year==i?"selected=\"selected\"":"" %>>
                                <%=i%></option>
                            <%} %>
                        </select>
                        年
                        <select id="BirMonth" name="BirMonth">
                            <%for( int i = 1; i <= 12; i++ )
                              { %>
                            <option value="<%=i%>" <%=resume.fdResuBirthday.Month==i?"selected=\"selected\"":"" %>>
                                <%=i%></option>
                            <%} %>
                        </select>
                        月
                        <select id="BirDay" name="BirDay">
                            <%for( int i = 1; i <= 31; i++ )
                              { %>
                            <option value="<%=i%>" <%=resume.fdResuBirthday.Day==i?"selected=\"selected\"":"" %>>
                                <%=i%></option>
                            <%} %>
                        </select>
                        日
                    </td>
                    <th>
                        <span class="orange">*</span>工作年限
                    </th>
                    <td>
                        <select id="Exp" name="Exp">
                            <option value="0" <%=resume.fdResuExperience==0?"selected=\"selected\"":"" %>>请选择工作年限</option>
                            <option value="1" <%=resume.fdResuExperience==1?"selected=\"selected\"":"" %>>1年以下</option>
                            <option value="2" <%=resume.fdResuExperience==2?"selected=\"selected\"":"" %>>1-2年</option>
                            <option value="3" <%=resume.fdResuExperience==3?"selected=\"selected\"":"" %>>2-5年</option>
                            <option value="4" <%=resume.fdResuExperience==4?"selected=\"selected\"":"" %>>5-10年</option>
                            <option value="5" <%=resume.fdResuExperience==5?"selected=\"selected\"":"" %>>10年以上</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                    </th>
                    <td>
                        <span class="tipW red hidden" id="errorMsg_IdenID">请选择证件类型！</span>
                    </td>
                    <th scope="row">
                    </th>
                    <td>
                        <span class="tipW red hidden" id="errorMsg_IdenNum">证件号不能为空！</span>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        <span class="orange">*</span>证件类型
                    </th>
                    <td width="218">
                        <select id="IdenID" name="IdenID">
                            <option value="0" <%=resume.fdResuIdentificationID==0?"selected=\"selected\"":"" %>>
                                请选择证件</option>
                            <option value="1" <%=resume.fdResuIdentificationID==1?"selected=\"selected\"":"" %>>
                                身份证</option>
                            <option value="2" <%=resume.fdResuIdentificationID==2?"selected=\"selected\"":"" %>>
                                军人证</option>
                            <option value="3" <%=resume.fdResuIdentificationID==3?"selected=\"selected\"":"" %>>
                                香港身份证</option>
                            <option value="4" <%=resume.fdResuIdentificationID==4?"selected=\"selected\"":"" %>>
                                其他</option>
                        </select>
                    </td>
                    <th>
                        <span class="orange">*</span>证&nbsp;件&nbsp;号
                    </th>
                    <td>
                        <input type="text" class="pwdinput" id="IdenNum" name="IdenNum" maxlength="20" value="<%=resume.fdResuIdentificationNum %>" />
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                    </th>
                    <td>
                        <span class="tipW red hidden" id="errorMsg_Address">请选择居住地！</span>
                    </td>
                    <th scope="row">
                    </th>
                    <td>
                        <span class="tipW red hidden" id="errorMsg_Email_1">邮箱地址不能为空！</span> <span class="tipW red hidden"
                            id="errorMsg_Email_2">邮箱地址格式不正确！</span>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        <span class="orange">*</span>居&nbsp;住&nbsp;地
                    </th>
                    <td width="218">
                        <a href="javascript:void(0);" onclick="selectArea('Place','AddressID','Address')"
                            id="Place" class="btn28H" style="font-size: 12px;">
                            <%=resume.fdResuAddressID == 0 ? "选择/修改" : resume.fdResuAddress%></a>
                        <input type="hidden" id="AddressID" name="AddressID" value="<%=resume.fdResuAddressID%>" />
                        <input type="hidden" id="Address" name="Address" value="<%=resume.fdResuAddress%>" />
                    </td>
                    <th>
                        <span class="orange">*</span>Email
                    </th>
                    <td>
                        <input type="text" class="pwdinput" id="email" name="email" maxlength="100" value="<%=resume.fdResuEmail %>" />
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        &nbsp;年&nbsp;&nbsp;&nbsp;&nbsp;薪
                    </th>
                    <td width="218">
                        <select id="Salary" name="Salary">
                            <option value="0" <%=resume.fdResuSalary==0?"selected=\"selected\"":"" %>>请选择年薪范围</option>
                            <option value="1" <%=resume.fdResuSalary==1?"selected=\"selected\"":"" %>>2万以下</option>
                            <option value="2" <%=resume.fdResuSalary==2?"selected=\"selected\"":"" %>>2-3万</option>
                            <option value="3" <%=resume.fdResuSalary==3?"selected=\"selected\"":"" %>>3-4万</option>
                            <option value="4" <%=resume.fdResuSalary==4?"selected=\"selected\"":"" %>>4-5万</option>
                            <option value="5" <%=resume.fdResuSalary==5?"selected=\"selected\"":"" %>>5-6万</option>
                            <option value="6" <%=resume.fdResuSalary==6?"selected=\"selected\"":"" %>>6-8万</option>
                            <option value="7" <%=resume.fdResuSalary==7?"selected=\"selected\"":"" %>>8-10万</option>
                            <option value="8" <%=resume.fdResuSalary==8?"selected=\"selected\"":"" %>>10-15万</option>
                            <option value="9" <%=resume.fdResuSalary==9?"selected=\"selected\"":"" %>>15-30万</option>
                            <option value="10" <%=resume.fdResuSalary==10?"selected=\"selected\"":"" %>>30-50万</option>
                            <option value="11" <%=resume.fdResuSalary==11?"selected=\"selected\"":"" %>>50-100万</option>
                            <option value="12" <%=resume.fdResuSalary==12?"selected=\"selected\"":"" %>>100万以上</option>
                        </select>
                    </td>
                    <th>
                        &nbsp;币&nbsp;&nbsp;&nbsp;&nbsp;种
                    </th>
                    <td>
                        <select id="CurrType" name="CurrType">
                            <option value="1" <%=resume.fdResuCurrType==1?"selected=\"selected\"":"" %>>人民币</option>
                            <option value="2" <%=resume.fdResuCurrType==2?"selected=\"selected\"":"" %>>港币</option>
                            <option value="3" <%=resume.fdResuCurrType==3?"selected=\"selected\"":"" %>>美元</option>
                            <option value="4" <%=resume.fdResuCurrType==4?"selected=\"selected\"":"" %>>日元</option>
                            <option value="5" <%=resume.fdResuCurrType==5?"selected=\"selected\"":"" %>>欧元</option>
                            <option value="6" <%=resume.fdResuCurrType==6?"selected=\"selected\"":"" %>>其它</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                    </th>
                    <td>
                    </td>
                    <th scope="row">
                    </th>
                    <td>
                        <span class="tipW red hidden" id="errorMsg_CurrSitu">请选择求职状态！</span>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        &nbsp;联系方式
                    </th>
                    <td width="218" class="orange">
                        (请至少填写一项)
                    </td>
                    <th>
                        <span class="orange">*</span>求职状态
                    </th>
                    <td>
                        <select id="CurrSitu" name="CurrSitu">
                            <option value="0" <%=resume.fdResuCurrentSituation==0?"selected=\"selected\"":"" %>>
                                请选择求职状态</option>
                            <option value="1" <%=resume.fdResuCurrentSituation==1?"selected=\"selected\"":"" %>>
                                目前正在找工作</option>
                            <option value="2" <%=resume.fdResuCurrentSituation==2?"selected=\"selected\"":"" %>>
                                半年内无换工作的计划</option>
                            <option value="3" <%=resume.fdResuCurrentSituation==3?"selected=\"selected\"":"" %>>
                                一年内无换工作的计划</option>
                            <option value="4" <%=resume.fdResuCurrentSituation==4?"selected=\"selected\"":"" %>>
                                观望有好的机会再考虑</option>
                            <option value="5" <%=resume.fdResuCurrentSituation==5?"selected=\"selected\"":"" %>>
                                我暂时不想找工作</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        &nbsp;手机号码
                    </th>
                    <td width="218">
                        <input type="text" id="MobPhoNum1" name="MobPhoNum1" class="pwdinput" style="width: 40px"
                            maxlength="5" value="<%=resume.fdResuMobilePhone==""?"086":resume.fdResuMobilePhone.Split( '-' )[0] %>" />-<input
                                type="text" id="MobPhoNum2" name="MobPhoNum2" class="pwdinput" style="width: 111px;"
                                maxlength="11" value="<%=resume.fdResuMobilePhone==""?"手机号码":resume.fdResuMobilePhone.Split( '-' )[1] %>" />
                    </td>
                    <th>
                        &nbsp;公司电话
                    </th>
                    <td>
                        <input type="text" id="ComPhoNum1" name="ComPhoNum1" class="pwdinput" style="width: 40px"
                            maxlength="5" value="<%=resume.fdResuCompPhone==""?"086":resume.fdResuCompPhone.Split( '-' )[0] %>" />-<input
                                type="text" id="ComPhoNum2" name="ComPhoNum2" class="pwdinput" style="width: 40px"
                                maxlength="5" value="<%=resume.fdResuCompPhone==""?"区号":resume.fdResuCompPhone.Split( '-' )[1] %>" />-<input
                                    type="text" id="ComPhoNum3" name="ComPhoNum3" class="pwdinput" style="width: 61px"
                                    maxlength="8" value="<%=resume.fdResuCompPhone==""?"总机号码":resume.fdResuCompPhone.Split( '-' )[2] %>" />-<input
                                        type="text" id="ComPhoNum4" name="ComPhoNum4" class="pwdinput" style="width: 40px;"
                                        maxlength="10" value="<%=resume.fdResuCompPhone==""?"分机":resume.fdResuCompPhone.Split( '-' )[3] %>" />
                    </td>
                </tr>
                <tr>
                    <th scope="row">
                        &nbsp;家庭电话
                    </th>
                    <td width="218">
                        <input type="text" id="FamPhoNum1" name="FamPhoNum1" class="pwdinput" style="width: 40px"
                            maxlength="5" value="<%=resume.fdResuFamiPhone==""?"086":resume.fdResuFamiPhone.Split( '-' )[0] %>" />-<input
                                type="text" id="FamPhoNum2" name="FamPhoNum2" class="pwdinput" style="width: 40px"
                                maxlength="5" value="<%=resume.fdResuFamiPhone==""?"区号":resume.fdResuFamiPhone.Split( '-' )[1] %>" />-<input
                                    type="text" id="FamPhoNum3" name="FamPhoNum3" class="pwdinput" style="width: 61px"
                                    maxlength="8" value="<%=resume.fdResuFamiPhone==""?"电话号码":resume.fdResuFamiPhone.Split( '-' )[2] %>" />
                    </td>
                    <th>
                        &nbsp;户&nbsp;&nbsp;&nbsp;&nbsp;口
                    </th>
                    <td>
                        <a href="javascript:void(0);" onclick="selectArea('Hukou','HouseAddressID','HouseAddress')"
                            id="Hukou" class="btn28H" style="font-size: 12px;">
                            <%=resume.fdResuHouseAddressID == 0 ? "选择/修改" : resume.fdResuHouseAddress%></a>
                        <input type="hidden" id="HouseAddressID" name="HouseAddressID" value="<%=resume.fdResuHouseAddressID%>" />
                        <input type="hidden" id="HouseAddress" name="HouseAddress" value="<%=resume.fdResuHouseAddress%>" />
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="38" class="tr">
                        <input type="button" class="btn60_28" value="保 存" id="btn_info_save" onclick="info_save()" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <img id="imgPhoto" src="<%=resume.fdResuPhoto==""?"../images/img_personPhoto.png":resume.fdResuPhoto %>"
                            width="90" height="110" class="imgBor" />
                        <input type="hidden" class="" id="photo" name="photo" value="<%=resume.fdResuPhoto==""?"":resume.fdResuPhoto %>" />
                    </td>
                </tr>
                <tr>
                    <td class="green tc">
                        <a href="javascript:void(0);" onclick="upload()">编辑>></a>&nbsp;&nbsp;<a href="javascript:void(0);"
                            onclick="delphoto()">删除>></a>
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
<table id="ext_info" width="598" class="tableInfo" style="display: none" border="0"
    cellspacing="0" cellpadding="0">
    <tr>
        <th scope="row">
        </th>
        <td>
        </td>
        <th scope="row">
        </th>
        <td>
            <span class="tipW red hidden" id="errorMsg_Height">身高格式不正确！</span>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;国家地区
        </th>
        <td width="218">
            <select id="Country" name="Country">
                <option value="0" <%=resume.fdResuCountry==0?"selected=\"selected\"":"" %>>请选择国家地区</option>
                <option value="1" <%=resume.fdResuCountry==1?"selected=\"selected\"":"" %>>大陆</option>
                <option value="2" <%=resume.fdResuCountry==2?"selected=\"selected\"":"" %>>香港</option>
                <option value="3" <%=resume.fdResuCountry==3?"selected=\"selected\"":"" %>>澳门</option>
                <option value="4" <%=resume.fdResuCountry==4?"selected=\"selected\"":"" %>>台湾</option>
                <option value="5" <%=resume.fdResuCountry==5?"selected=\"selected\"":"" %>>国外</option>
            </select>
        </td>
        <th>
            &nbsp;身&nbsp;&nbsp;&nbsp;&nbsp;高
        </th>
        <td>
            <input type="text" id="Height" name="Height" class="pwdinput" maxlength="3" value="<%=resume.fdResuHeight==0?"":resume.fdResuHeight.ToString() %>" />
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;邮&nbsp;&nbsp;&nbsp;&nbsp;编
        </th>
        <td width="218">
            <input type="text" class="pwdinput" id="PostCode" name="PostCode" maxlength="6" value="<%=resume.fdResuPostCode %>" />
        </td>
        <th>
            &nbsp;地&nbsp;&nbsp;&nbsp;&nbsp;址
        </th>
        <td>
            <input type="text" class="pwdinput" id="ConAddr" name="ConAddr" maxlength="50" value="<%=resume.fdResuContactAddr %>" />
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;婚姻状况
        </th>
        <td width="218">
            <select id="Marry" name="Marry">
                <option value="0" <%=resume.fdResuMarry==0?"selected=\"selected\"":"" %>>请选择婚姻状况</option>
                <option value="1" <%=resume.fdResuMarry==1?"selected=\"selected\"":"" %>>未婚</option>
                <option value="2" <%=resume.fdResuMarry==2?"selected=\"selected\"":"" %>>已婚</option>
            </select>
        </td>
        <th>
            &nbsp;个人主页
        </th>
        <td>
            <input type="text" class="pwdinput" id="Website" name="Website" value="<%=resume.fdResuWebsite %>" />
        </td>
    </tr>
</table>
<div class="blank6px">
</div>
</form>
