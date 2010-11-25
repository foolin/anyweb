<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ResuAdd.aspx.cs" Inherits="User_ResuAdd" %>

<%@ Register Src="~/Control/UserSidebar.ascx" TagName="UserSidebar" TagPrefix="uc1" %>
<%@ Register Src="~/Control/Area.ascx" TagName="Area" TagPrefix="uc1" %>
<%@ Register Src="~/Control/Area2.ascx" TagName="Area2" TagPrefix="uc1" %>
<%@ Register Src="~/Control/Major.ascx" TagName="Major" TagPrefix="uc1" %>
<%@ Register Src="~/Control/Industry.ascx" TagName="Industry" TagPrefix="uc1" %>
<%@ Register Src="~/Control/Industry2.ascx" TagName="Industry2" TagPrefix="uc1" %>
<%@ Register Src="~/Control/Position.ascx" TagName="Position" TagPrefix="uc1" %>
<%@ Register Src="~/Control/Position2.ascx" TagName="Position2" TagPrefix="uc1" %>
<%@ Register Src="~/Control/Upload.ascx" TagName="Upload" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../js/resume.js"></script>

    <script type="text/javascript" src="../js/form.js"></script>

    <script type="text/javascript" src="../js/ajaxfileupload.js"></script>

    <script type="text/javascript" src="../js/Major.js"></script>

    <script type="text/javascript" src="../js/Position.js"></script>

    <div class="resumePage">
        <uc1:UserSidebar runat="server" />
        <div class="content">
            <div class="tit gray">
                <a href="/Index.aspx">首页</a> > <a href="/User/Index.aspx">个人会员</a> > <span class="green">
                    添加简历</span></div>
            <div class="MemCon">
                <div class="addResume">
                    <div class="flowhidden">
                        <div class="dTop">
                            <span class="subTit_up" id="resume_up" onclick="object_toggle('resume')" title="收起"
                                style="cursor: pointer"></span><span class="subTit" id="resume_down" onclick="object_toggle('resume')"
                                    title="展开" style="cursor: pointer; display: none"></span><strong class="f14 green">简历信息</strong>(<span
                                        class="orange">*</span>为必填项)</div>
                        <div class="dCon" id="resume">
                            <form action="/User/ResuNameSave.aspx?id=<%=QS("id") %>" id="resume_form" method="post">
                            <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th scope="row">
                                    </th>
                                    <td>
                                        <span class="tipW red hidden" id="errorMsg_Name">简历名称不能为空！</span>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        <span class="orange">*</span>简历名称
                                    </th>
                                    <td width="218">
                                        <input id="Resu_Name" name="Resu_Name" class="pwdinput" maxlength="30" type="text"
                                            value="我的简历" />
                                    </td>
                                    <td>
                                        <span class="right">&nbsp;&nbsp;<input id="btn_resu_save" class="btn60_28" value="保 存"
                                            onclick="resu_save('resume_form')" type="button"></span>
                                    </td>
                                </tr>
                            </table>
                            <div class="blank12px">
                            </div>
                            </form>
                        </div>
                    </div>
                    <div class="blank8px">
                    </div>
                    <div class="flowhidden">
                        <div class="dTop">
                            <span class="subTit_up" id="info_up" onclick="object_toggle('info')" title="收起" style="cursor: pointer">
                            </span><span class="subTit" id="info_down" onclick="object_toggle('info')" title="展开"
                                style="cursor: pointer; display: none"></span><strong class="f14 green">个人信息</strong>(<span
                                    class="orange">*</span>为必填项)</div>
                        <div class="dCon" id="info">
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
                                                        value="<%=this.LoginUser.fdUserName %>" />
                                                </td>
                                                <th>
                                                    <span class="orange">*</span>性&nbsp;&nbsp;&nbsp;&nbsp;别
                                                </th>
                                                <td>
                                                    <input type="radio" name="sex" value="0" <%=this.LoginUser.fdUserSex==0?"checked=\"checked\"":"" %> />男
                                                    <input type="radio" name="sex" value="1" <%=this.LoginUser.fdUserSex==1?"checked=\"checked\"":""%> />女
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
                                                        <option value="<%=i%>" <%=this.LoginUser.fdUserBirthday.Year==i?"selected=\"selected\"":"" %>>
                                                            <%=i%></option>
                                                        <%} %>
                                                    </select>
                                                    年
                                                    <select id="BirMonth" name="BirMonth">
                                                        <%for( int i = 1; i <= 12; i++ )
                                                          { %>
                                                        <option value="<%=i%>" <%=this.LoginUser.fdUserBirthday.Month==i?"selected=\"selected\"":"" %>>
                                                            <%=i%></option>
                                                        <%} %>
                                                    </select>
                                                    月
                                                    <select id="BirDay" name="BirDay">
                                                        <%for( int i = 1; i <= 31; i++ )
                                                          { %>
                                                        <option value="<%=i%>" <%=this.LoginUser.fdUserBirthday.Day==i?"selected=\"selected\"":"" %>>
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
                                                        <option value="0" <%=this.LoginUser.fdUserExperience==0?"selected=\"selected\"":"" %>>
                                                            请选择工作年限</option>
                                                        <option value="1" <%=this.LoginUser.fdUserExperience==1?"selected=\"selected\"":"" %>>
                                                            1年以下</option>
                                                        <option value="2" <%=this.LoginUser.fdUserExperience==2?"selected=\"selected\"":"" %>>
                                                            1-2年</option>
                                                        <option value="3" <%=this.LoginUser.fdUserExperience==3?"selected=\"selected\"":"" %>>
                                                            2-5年</option>
                                                        <option value="4" <%=this.LoginUser.fdUserExperience==4?"selected=\"selected\"":"" %>>
                                                            5-10年</option>
                                                        <option value="5" <%=this.LoginUser.fdUserExperience==5?"selected=\"selected\"":"" %>>
                                                            10年以上</option>
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
                                                        <option value="0" <%=this.LoginUser.fdUserIdentificationID==0?"selected=\"selected\"":"" %>>
                                                            请选择证件</option>
                                                        <option value="1" <%=this.LoginUser.fdUserIdentificationID==1?"selected=\"selected\"":"" %>>
                                                            身份证</option>
                                                        <option value="2" <%=this.LoginUser.fdUserIdentificationID==2?"selected=\"selected\"":"" %>>
                                                            军人证</option>
                                                        <option value="3" <%=this.LoginUser.fdUserIdentificationID==3?"selected=\"selected\"":"" %>>
                                                            香港身份证</option>
                                                        <option value="4" <%=this.LoginUser.fdUserIdentificationID==4?"selected=\"selected\"":"" %>>
                                                            其他</option>
                                                    </select>
                                                </td>
                                                <th>
                                                    <span class="orange">*</span>证&nbsp;件&nbsp;号
                                                </th>
                                                <td>
                                                    <input type="text" class="pwdinput" id="IdenNum" name="IdenNum" maxlength="20" value="<%=this.LoginUser.fdUserIdentificationNum %>" />
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
                                                    <a href="javascript:void(0);" onclick="ChooseArea(this,'ChooseArea','AddressID','Address','选择/修改');return false;"
                                                        id="Place" class="btn28H" style="font-size: 12px;">
                                                        <%=this.LoginUser.fdUserAddressID == 0 ? "选择/修改" : this.LoginUser.fdUserAddress%></a>
                                                    <input type="hidden" id="AddressID" name="AddressID" value="<%=this.LoginUser.fdUserAddressID%>" />
                                                    <input type="hidden" id="Address" name="Address" value="<%=this.LoginUser.fdUserAddress%>" />
                                                </td>
                                                <th>
                                                    <span class="orange">*</span>Email
                                                </th>
                                                <td>
                                                    <input type="text" class="pwdinput" id="email" name="email" maxlength="100" value="<%=this.LoginUser.fdUserEmail %>" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <th scope="row">
                                                    &nbsp;年&nbsp;&nbsp;&nbsp;&nbsp;薪
                                                </th>
                                                <td width="218">
                                                    <select id="Salary" name="Salary">
                                                        <option value="0">请选择年薪范围</option>
                                                        <option value="1">2万以下</option>
                                                        <option value="2">2-3万</option>
                                                        <option value="3">3-4万</option>
                                                        <option value="4">4-5万</option>
                                                        <option value="5">5-6万</option>
                                                        <option value="6">6-8万</option>
                                                        <option value="7">8-10万</option>
                                                        <option value="8">10-15万</option>
                                                        <option value="9">15-30万</option>
                                                        <option value="10">30-50万</option>
                                                        <option value="11">50-100万</option>
                                                        <option value="12">100万以上</option>
                                                    </select>
                                                </td>
                                                <th>
                                                    &nbsp;币&nbsp;&nbsp;&nbsp;&nbsp;种
                                                </th>
                                                <td>
                                                    <select id="CurrType" name="CurrType">
                                                        <option value="1" selected="selected">人民币</option>
                                                        <option value="2">港币</option>
                                                        <option value="3">美元</option>
                                                        <option value="4">日元</option>
                                                        <option value="5">欧元</option>
                                                        <option value="6">其它</option>
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
                                                        <option value="0" <%=this.LoginUser.fdUserCurrentSituation==0?"selected=\"selected\"":"" %>>
                                                            请选择求职状态</option>
                                                        <option value="1" <%=this.LoginUser.fdUserCurrentSituation==1?"selected=\"selected\"":"" %>>
                                                            目前正在找工作</option>
                                                        <option value="2" <%=this.LoginUser.fdUserCurrentSituation==2?"selected=\"selected\"":"" %>>
                                                            半年内无换工作的计划</option>
                                                        <option value="3" <%=this.LoginUser.fdUserCurrentSituation==3?"selected=\"selected\"":"" %>>
                                                            一年内无换工作的计划</option>
                                                        <option value="4" <%=this.LoginUser.fdUserCurrentSituation==4?"selected=\"selected\"":"" %>>
                                                            观望有好的机会再考虑</option>
                                                        <option value="5" <%=this.LoginUser.fdUserCurrentSituation==5?"selected=\"selected\"":"" %>>
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
                                                        maxlength="5" value="<%=this.LoginUser.fdUserMobilePhone==""?"086":this.LoginUser.fdUserMobilePhone.Split( '-' )[0] %>" />-<input
                                                            type="text" id="MobPhoNum2" name="MobPhoNum2" class="pwdinput" style="width: 111px;"
                                                            maxlength="11" value="<%=this.LoginUser.fdUserMobilePhone==""?"手机号码":this.LoginUser.fdUserMobilePhone.Split( '-' )[1] %>" />
                                                </td>
                                                <th>
                                                    &nbsp;公司电话
                                                </th>
                                                <td>
                                                    <input type="text" id="ComPhoNum1" name="ComPhoNum1" class="pwdinput" style="width: 40px"
                                                        maxlength="5" value="<%=this.LoginUser.fdUserCompPhone==""?"086":this.LoginUser.fdUserCompPhone.Split( '-' )[0] %>" />-<input
                                                            type="text" id="ComPhoNum2" name="ComPhoNum2" class="pwdinput" style="width: 40px"
                                                            maxlength="5" value="<%=this.LoginUser.fdUserCompPhone==""?"区号":this.LoginUser.fdUserCompPhone.Split( '-' )[1] %>" />-<input
                                                                type="text" id="ComPhoNum3" name="ComPhoNum3" class="pwdinput" style="width: 61px"
                                                                maxlength="8" value="<%=this.LoginUser.fdUserCompPhone==""?"总机号码":this.LoginUser.fdUserCompPhone.Split( '-' )[2] %>" />-<input
                                                                    type="text" id="ComPhoNum4" name="ComPhoNum4" class="pwdinput" style="width: 40px;"
                                                                    maxlength="10" value="<%=this.LoginUser.fdUserCompPhone==""?"分机":this.LoginUser.fdUserCompPhone.Split( '-' )[3] %>" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <th scope="row">
                                                    &nbsp;家庭电话
                                                </th>
                                                <td width="218">
                                                    <input type="text" id="FamPhoNum1" name="FamPhoNum1" class="pwdinput" style="width: 40px"
                                                        maxlength="5" value="<%=this.LoginUser.fdUserFamiPhone==""?"086":this.LoginUser.fdUserFamiPhone.Split( '-' )[0] %>" />-<input
                                                            type="text" id="FamPhoNum2" name="FamPhoNum2" class="pwdinput" style="width: 40px"
                                                            maxlength="5" value="<%=this.LoginUser.fdUserFamiPhone==""?"区号":this.LoginUser.fdUserFamiPhone.Split( '-' )[1] %>" />-<input
                                                                type="text" id="FamPhoNum3" name="FamPhoNum3" class="pwdinput" style="width: 61px"
                                                                maxlength="8" value="<%=this.LoginUser.fdUserFamiPhone==""?"电话号码":this.LoginUser.fdUserFamiPhone.Split( '-' )[2] %>" />
                                                </td>
                                                <th>
                                                    &nbsp;户&nbsp;&nbsp;&nbsp;&nbsp;口
                                                </th>
                                                <td>
                                                    <a href="javascript:void(0);" onclick="ChooseArea(this,'ChooseArea','HouseAddressID','HouseAddress','选择/修改');return false;"
                                                        id="Hukou" class="btn28H" style="font-size: 12px;">
                                                        <%=this.LoginUser.fdUserHouseAddressID == 0 ? "选择/修改" : this.LoginUser.fdUserHouseAddress%></a>
                                                    <input type="hidden" id="HouseAddressID" name="HouseAddressID" value="<%=this.LoginUser.fdUserHouseAddressID%>" />
                                                    <input type="hidden" id="HouseAddress" name="HouseAddress" value="<%=this.LoginUser.fdUserHouseAddress%>" />
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
                                                    <img id="imgPhoto" src="<%=this.LoginUser.fdUserPhotoIsShow==1&&this.LoginUser.fdUserPhoto!=""?this.LoginUser.fdUserPhoto:"../images/img_personPhoto.png" %>"
                                                        width="90" height="110" class="imgBor" />
                                                    <input type="hidden" class="" id="photo" name="photo" value="<%=this.LoginUser.fdUserPhotoIsShow==1&&this.LoginUser.fdUserPhoto!=""?this.LoginUser.fdUserPhoto:"" %>" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="green tc">
                                                    <a href="javascript:void(0);" onclick="upload();return false;">编辑>></a>&nbsp;&nbsp;<a
                                                        href="javascript:void(0);" onclick="delphoto();return false;">删除>></a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <div class="blank12px">
                            </div>
                            <div class=" lh24 green">
                                <a href="javascript:void(0);" onclick="object_toggle('ext_info');return false;">查看更多个人信息<span
                                    id="ext_info_up" style="display: none">↑</span><span id="ext_info_down">↓</span></a></div>
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
                                            <option value="0" <%=this.LoginUser.fdUserCountryID==0?"selected=\"selected\"":"" %>>
                                                请选择国家地区</option>
                                            <option value="1" <%=this.LoginUser.fdUserCountryID==1?"selected=\"selected\"":"" %>>
                                                大陆</option>
                                            <option value="2" <%=this.LoginUser.fdUserCountryID==2?"selected=\"selected\"":"" %>>
                                                香港</option>
                                            <option value="3" <%=this.LoginUser.fdUserCountryID==3?"selected=\"selected\"":"" %>>
                                                澳门</option>
                                            <option value="4" <%=this.LoginUser.fdUserCountryID==4?"selected=\"selected\"":"" %>>
                                                台湾</option>
                                            <option value="5" <%=this.LoginUser.fdUserCountryID==5?"selected=\"selected\"":"" %>>
                                                国外</option>
                                        </select>
                                    </td>
                                    <th>
                                        &nbsp;身&nbsp;&nbsp;&nbsp;&nbsp;高
                                    </th>
                                    <td>
                                        <input type="text" id="Height" name="Height" class="pwdinput" maxlength="3" value="<%=this.LoginUser.fdUserHeight==0?"":this.LoginUser.fdUserHeight.ToString() %>" />
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        &nbsp;邮&nbsp;&nbsp;&nbsp;&nbsp;编
                                    </th>
                                    <td width="218">
                                        <input type="text" class="pwdinput" id="PostCode" name="PostCode" maxlength="6" value="<%=this.LoginUser.fdUserPostCode %>" />
                                    </td>
                                    <th>
                                        &nbsp;地&nbsp;&nbsp;&nbsp;&nbsp;址
                                    </th>
                                    <td>
                                        <input type="text" class="pwdinput" id="ConAddr" name="ConAddr" maxlength="50" value="<%=this.LoginUser.fdUserContactAddr %>" />
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        &nbsp;婚姻状况
                                    </th>
                                    <td width="218">
                                        <select id="Marry" name="Marry">
                                            <option value="0" <%=this.LoginUser.fdUserMarry==0?"selected=\"selected\"":"" %>>请选择婚姻状况</option>
                                            <option value="1" <%=this.LoginUser.fdUserMarry==1?"selected=\"selected\"":"" %>>未婚</option>
                                            <option value="2" <%=this.LoginUser.fdUserMarry==2?"selected=\"selected\"":"" %>>已婚</option>
                                        </select>
                                    </td>
                                    <th>
                                        &nbsp;个人主页
                                    </th>
                                    <td>
                                        <input type="text" class="pwdinput" id="Website" name="Website" value="<%=this.LoginUser.fdUserWebsite %>" />
                                    </td>
                                </tr>
                            </table>
                            <div class="blank6px">
                            </div>
                            </form>
                        </div>
                    </div>
                    <div class="blank8px">
                    </div>
                    <div class="flowhidden">
                        <div class="dTop">
                            <span class="subTit_up" id="eduinfo_up" onclick="object_toggle('eduinfo')" title="收起"
                                style="cursor: pointer"></span><span class="subTit" id="eduinfo_down" onclick="object_toggle('eduinfo')"
                                    title="展开" style="cursor: pointer; display: none"></span><strong class="f14 green">教育经历</strong>(<span
                                        class="orange">*</span>为必填项)</div>
                        <div id="eduinfo" class="dCon">
                            <div id="edu">
                                <div id="edu_<%=eduID %>">
                                    <form action="/User/EduSave.aspx?id=<%=QS("id") %>&eduid=<%=eduID %>&type=add" id="edu_form_<%=eduID %>"
                                    method="post">
                                    <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <th scope="row">
                                            </th>
                                            <td>
                                                <span class="tipW red hidden" id="errorMsg_Date_1">请选择时间！</span> <span class="tipW red hidden"
                                                    id="errorMsg_Date_2">结束时间不能小于起始时间！</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                                <span class="orange">*</span>时&nbsp;&nbsp;&nbsp;&nbsp;间
                                            </th>
                                            <td>
                                                <span class="right">
                                                    <input type="button" id="btn_edu_del" class="btn60_28_gray" value="删 除" onclick="delinfo('edu',<%=eduID %>,'btn_edu_del','edu_<%=eduID %>')" />
                                                    &nbsp;&nbsp;<input type="button" id="btn_edu_save" class="btn60_28" value="保 存" onclick="edu_save('edu_form_<%=eduID %>')" /></span>
                                                <select id="Edu_FromYear" name="Edu_FromYear">
                                                    <option selected="selected" value="0">年</option>
                                                    <%for( int i = DateTime.Now.Year; i >= 1940; i-- )
                                                      { %>
                                                    <option value="<%=i%>">
                                                        <%=i%></option>
                                                    <%} %>
                                                </select>
                                                <select id="Edu_FromMonth" name="Edu_FromMonth">
                                                    <option selected="selected" value="0">月</option>
                                                    <%for( int i = 1; i <= 12; i++ )
                                                      { %>
                                                    <option value="<%=i%>">
                                                        <%=i%></option>
                                                    <%} %>
                                                </select>
                                                到
                                                <select id="Edu_ToYear" name="Edu_ToYear">
                                                    <option selected="selected" value="0">年</option>
                                                    <%for( int i = DateTime.Now.Year; i >= 1940; i-- )
                                                      { %>
                                                    <option value="<%=i%>">
                                                        <%=i%></option>
                                                    <%} %>
                                                </select>
                                                <select id="Edu_ToMonth" name="Edu_ToMonth">
                                                    <option selected="selected" value="0">月</option>
                                                    <%for( int i = 1; i <= 12; i++ )
                                                      { %>
                                                    <option value="<%=i%>">
                                                        <%=i%></option>
                                                    <%} %>
                                                </select>
                                                <span class="lgray">(后两项不填表示至今)</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                            </th>
                                            <td>
                                                <span class="tipW red hidden" id="errorMsg_School">请输入学校名称（限50个汉字）！</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                                <span class="orange">*</span>学&nbsp;&nbsp;&nbsp;&nbsp;校
                                            </th>
                                            <td>
                                                <input type="text" id="Edu_School" name="Edu_School" class="pwdinput" style="width: 296px;"
                                                    maxlength="50" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                            </th>
                                            <td>
                                                <span class="tipW red hidden" id="errorMsg_Speciality">请选择或者手动填写专业名称（限20个汉字）！</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                                <span class="orange">*</span>专&nbsp;&nbsp;&nbsp;&nbsp;业
                                            </th>
                                            <td>
                                                <a href="javascript:void(0);" id="place" class="btn28H" style="font-size: 12px;"
                                                    onclick="ChooseMajor(this, 'major', 'Edu_SpecialityID', 'Edu_Speciality', '选择/修改');return false;">
                                                    选择/修改</a>
                                                <input type="text" id="Edu_OtherSpeciality" name="Edu_OtherSpeciality" class="pwdinput"
                                                    value="若无合适项，请在此填写" style="color: #999;" maxlength="20" onclick="if('若无合适项，请在此填写'==this.value){this.value='';this.style.color='#000';}"
                                                    onblur="if(this.value==''){this.value = '若无合适项，请在此填写';this.style.color='#999';}" />
                                                <input type="hidden" id="Edu_SpecialityID" name="Edu_SpecialityID" />
                                                <input type="hidden" id="Edu_Speciality" name="Edu_Speciality" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                            </th>
                                            <td>
                                                <span class="tipW red hidden" id="errorMsg_Degree">请选择学历！</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                                <span class="orange">*</span>学&nbsp;&nbsp;&nbsp;&nbsp;历
                                            </th>
                                            <td>
                                                <select id="Edu_Degree" name="Edu_Degree">
                                                    <option value="0">请选择学历</option>
                                                    <option value="1">初中</option>
                                                    <option value="2">高中</option>
                                                    <option value="3">中技</option>
                                                    <option value="4">中专</option>
                                                    <option value="5">大专</option>
                                                    <option value="6">本科</option>
                                                    <option value="7">MBA</option>
                                                    <option value="8">硕士</option>
                                                    <option value="9">博士</option>
                                                    <option value="10">其他</option>
                                                </select>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                            </th>
                                            <td>
                                                <span class="tipW red hidden" id="errorMsg_Intro">输入错误。请控制在2000个汉字以内！</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row" valign="top">
                                                &nbsp;专业描述
                                            </th>
                                            <td>
                                                <table width="456" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td colspan="2">
                                                            <textarea id="Edu_Intro" name="Edu_Intro" class="txtArea" onkeyup="str_limit('edu_<%=eduID %>',this.value,'Edu_IntroLength')"
                                                                onchange="str_limit('edu_<%=eduID %>',this.value,'Edu_IntroLength')"></textarea>
                                                        </td>
                                                    </tr>
                                                    <tr style="color: #999;">
                                                        <td width="286">
                                                            填写您所学专业包括什么课程，您的毕业设计等等
                                                        </td>
                                                        <td align="right" width="209">
                                                            限2000个中文字，已输入<span class="orange" id="Edu_IntroLength">0</span>个字
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                                海外学习经历
                                            </th>
                                            <td>
                                                <input type="radio" name="Edu_IsOverSeas" value="0" />是<input type="radio"
                                                    value="1" name="Edu_IsOverSeas" checked="checked" />
                                                否
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="blank12px">
                                    </div>
                                    </form>
                                </div>
                            </div>
                            <div class=" lh24">
                                <a href="javascript:void(0);" id="btn_info_add" class="btn28H" style="font-size: 12px;"
                                    onclick="addinfo('edu',<%=QS("id") %>,this);return false;">继续添加</a></div>
                            <div class="blank6px">
                            </div>
                        </div>
                    </div>
                    <div class="blank8px">
                    </div>
                    <div class="flowhidden">
                        <div class="dTop">
                            <span class="subTit_up" id="learninfo_up" onclick="object_toggle('learninfo')" title="收起"
                                style="cursor: pointer"></span><span class="subTit" id="learninfo_down" onclick="object_toggle('learninfo')"
                                    title="展开" style="cursor: pointer; display: none"></span><strong class="f14 green">学习经历</strong>(<span
                                        class="orange">*</span>为必填项)</div>
                        <div id="learninfo" class="dCon">
                            <div id="rew">
                                <strong class="green">奖励</strong>
                            </div>
                            <div class=" lh24">
                                <a href="javascript:void(0);" id="btn_info_add" class="btn28H" style="font-size: 12px;"
                                    onclick="addinfo('rew',<%=QS("id") %>,this);return false;">继续添加</a></div>
                            <div class="blank12px dashLine">
                            </div>
                            <div id="pos">
                                <strong class="green">职务</strong>
                            </div>
                            <div class=" lh24">
                                <a href="javascript:void(0);" id="btn_info_add" class="btn28H" style="font-size: 12px;"
                                    onclick="addinfo('pos',<%=QS("id") %>,this);return false;">继续添加</a></div>
                            <div class="blank6px">
                            </div>
                        </div>
                    </div>
                    <div class="blank8px">
                    </div>
                    <div class="flowhidden">
                        <div class="dTop">
                            <span class="subTit_up" id="workinfo_up" onclick="object_toggle('workinfo')" title="收起"
                                style="cursor: pointer"></span><span class="subTit" id="workinfo_down" onclick="object_toggle('workinfo')"
                                    title="展开" style="cursor: pointer; display: none"></span><strong class="f14 green">工作经验</strong>(<span
                                        class="orange">*</span>为必填项)</div>
                        <div class="dCon" id="workinfo">
                            <div id="work">
                                <div id="work_<%=workID %>">
                                    <form action="/User/WorkSave.aspx?id=<%=QS("id") %>&workid=<%=workID %>&type=add"
                                    id="work_form_<%=workID %>" method="post">
                                    <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <th scope="row">
                                            </th>
                                            <td colspan="3">
                                                <span class="tipW red hidden" id="errorMsg_Date_1">请选择时间！</span> <span class="tipW red hidden"
                                                    id="errorMsg_Date_2">结束时间不能小于起始时间！</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                                <span class="orange">*</span>时&nbsp;&nbsp;&nbsp;&nbsp;间
                                            </th>
                                            <td colspan="3">
                                                <span class="right">
                                                    <input type="button" id="btn_work_del" class="btn60_28_gray" value="删 除" onclick="delinfo('work',<%=workID %>,'btn_work_del','work_<%=workID %>')" />
                                                    &nbsp;&nbsp;<input type="button" id="btn_work_save" class="btn60_28" value="保 存"
                                                        onclick="work_save('work_form_<%=workID %>')" /></span>
                                                <select id="Work_FromYear" name="Work_FromYear">
                                                    <option selected="selected" value="0">年</option>
                                                    <%for( int i = DateTime.Now.Year; i >= 1940; i-- )
                                                      { %>
                                                    <option value="<%=i%>">
                                                        <%=i%></option>
                                                    <%} %>
                                                </select>
                                                <select id="Work_FromMonth" name="Work_FromMonth">
                                                    <option selected="selected" value="0">月</option>
                                                    <%for( int i = 1; i <= 12; i++ )
                                                      { %>
                                                    <option value="<%=i%>">
                                                        <%=i%></option>
                                                    <%} %>
                                                </select>
                                                到
                                                <select id="Work_ToYear" name="Work_ToYear">
                                                    <option selected="selected" value="0">年</option>
                                                    <%for( int i = DateTime.Now.Year; i >= 1940; i-- )
                                                      { %>
                                                    <option value="<%=i%>">
                                                        <%=i%></option>
                                                    <%} %>
                                                </select>
                                                <select id="Work_ToMonth" name="Work_ToMonth">
                                                    <option selected="selected" value="0">月</option>
                                                    <%for( int i = 1; i <= 12; i++ )
                                                      { %>
                                                    <option value="<%=i%>">
                                                        <%=i%></option>
                                                    <%} %>
                                                </select>
                                                <span class="lgray">(后两项不填表示至今)</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                            </th>
                                            <td>
                                                <span class="tipW red hidden" id="errorMsg_Name">公司名称不能为空！</span>
                                            </td>
                                            <th scope="row">
                                            </th>
                                            <td>
                                                <span class="tipW red hidden" id="errorMsg_Industry">请选择行业！</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                                <span class="orange">*</span>公&nbsp;&nbsp;&nbsp;&nbsp;司
                                            </th>
                                            <td>
                                                <input type="text" id="Work_Name" name="Work_Name" class="pwdinput" maxlength="50" />
                                            </td>
                                            <th scope="row">
                                                <span class="orange">*</span>行&nbsp;&nbsp;&nbsp;&nbsp;业
                                            </th>
                                            <td>
                                                <a href="javascript:void(0);" id="place" class="btn28H" style="font-size: 12px;"
                                                    onclick="ChooseIndustry(this, 'ChooseIndustry', 'Work_IndustryID', 'Work_Industry', '选择/修改');return false;">
                                                    选择/修改</a>
                                                <input type="hidden" id="Work_IndustryID" name="Work_IndustryID" />
                                                <input type="hidden" id="Work_Industry" name="Work_Industry" />
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
                                                <span class="tipW red hidden" id="errorMsg_Type">请选择公司性质！</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                                &nbsp;公司规模
                                            </th>
                                            <td>
                                                <select id="Work_Dimension" name="Work_Dimension">
                                                    <option value="0">请选择公司规模</option>
                                                    <option value="1">少于50人</option>
                                                    <option value="2">50-150人</option>
                                                    <option value="3">150-500人</option>
                                                    <option value="4">500人以上</option>
                                                </select>
                                            </td>
                                            <th scope="row">
                                                <span class="orange">*</span>公司性质
                                            </th>
                                            <td>
                                                <select id="Work_Type" name="Work_Type">
                                                    <option value="0">请选择公司性质</option>
                                                    <option value="1">外资(欧美)</option>
                                                    <option value="2">外资(非欧美)</option>
                                                    <option value="3">合资(欧美)</option>
                                                    <option value="4">合资(非欧美)</option>
                                                    <option value="5">国企</option>
                                                    <option value="6">民营公司</option>
                                                    <option value="7">外企代表处</option>
                                                    <option value="8">政府机关</option>
                                                    <option value="9">事业单位</option>
                                                    <option value="10">非盈利机构</option>
                                                    <option value="11">其它性质</option>
                                                </select>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                            </th>
                                            <td>
                                                <span class="tipW red hidden" id="errorMsg_Department">部门不能为空！</span>
                                            </td>
                                            <th scope="row">
                                            </th>
                                            <td>
                                                <span class="tipW red hidden" id="errorMsg_Job">请选择或者手动填写职位（限20个汉字）！</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                                <span class="orange">*</span>部&nbsp;&nbsp;&nbsp;&nbsp;门
                                            </th>
                                            <td>
                                                <input type="text" id="Work_Department" name="Work_Department" class="pwdinput" maxlength="20" />
                                            </td>
                                            <th scope="row">
                                                <span class="orange">*</span>职&nbsp;&nbsp;&nbsp;&nbsp;位
                                            </th>
                                            <td>
                                                <a href="javascript:void(0);" id="place" class="btn28H" style="font-size: 12px;"
                                                    onclick="ChoosePosition(this, 'ChoosePosition', 'Work_JobID', 'Work_Job', '选择/修改');return false;">
                                                    选择/修改</a>
                                                <input type="text" id="Work_OtherJob" name="Work_OtherJob" class="pwdinput" value="若无合适项，请在此填写"
                                                    style="color: #999;" onclick="if('若无合适项，请在此填写'==this.value){this.value='';this.style.color='#000';}"
                                                    onblur="if(this.value==''){this.value = '若无合适项，请在此填写';this.style.color='#999';}" />
                                                <input type="hidden" id="Work_JobID" name="Work_JobID" />
                                                <input type="hidden" id="Work_Job" name="Work_Job" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                            </th>
                                            <td colspan="3">
                                                <span class="tipW red hidden" id="errorMsg_Intro_1">工作描述不能为空！</span> <span class="tipW red hidden"
                                                    id="errorMsg_Intro_2">输入错误。请控制在2000个汉字以内！</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row" valign="top">
                                                <span class="orange">*</span>工作描述
                                            </th>
                                            <td colspan="3">
                                                <table width="486" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td colspan="2">
                                                            <textarea id="Work_Intro" name="Work_Intro" class="txtArea" style="width: 495px;"
                                                                onkeyup="str_limit('work_<%=workID %>',this.value,'Work_IntroLength')" onchange="str_limit('work_<%=workID %>',this.value,'Work_IntroLength')"></textarea>
                                                        </td>
                                                    </tr>
                                                    <tr style="color: #999;">
                                                        <td width="295">
                                                            请详细描述您的职责范围、工作任务以及取得的成绩等
                                                        </td>
                                                        <td align="right" width="174">
                                                            限2000个中文字，已输入<span class="orange" id="Work_IntroLength">0</span>个字
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                                海外工作经历
                                            </th>
                                            <td>
                                                <input type="radio" name="Work_IsOverSeas" value="0" />是
                                                <input type="radio" value="1" name="Work_IsOverSeas" checked="checked" />否
                                            </td>
                                            <th scope="row">
                                            </th>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="blank12px">
                                    </div>
                                    </form>
                                </div>
                            </div>
                            <div class=" lh24">
                                <a href="javascript:void(0);" id="btn_info_add" class="btn28H" style="font-size: 12px;"
                                    onclick="addinfo('work',<%=QS("id") %>,this);return false;">继续添加</a></div>
                            <div class="blank6px">
                            </div>
                        </div>
                    </div>
                    <div class="blank8px">
                    </div>
                    <div class="flowhidden">
                        <div class="dTop">
                            <span class="subTit_up" id="obje_up" onclick="object_toggle('obje')" title="收起" style="cursor: pointer">
                            </span><span class="subTit" id="obje_down" onclick="object_toggle('obje')" title="展开"
                                style="cursor: pointer; display: none"></span><strong class="f14 green">求职意向</strong>(<span
                                    class="orange">*</span>为必填项)</div>
                        <div class="dCon" id="obje">
                            <form action="/User/ObjeSave.aspx?id=<%=QS("id") %>" id="obje_form" method="post">
                            <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th scope="row">
                                        &nbsp;工作类型
                                    </th>
                                    <td>
                                        <select id="Obje_Type" name="Obje_Type">
                                            <option value="1" selected="selected">全职</option>
                                            <option value="2">兼职</option>
                                            <option value="3">实习</option>
                                            <option value="4">全/兼职</option>
                                        </select>
                                    </td>
                                    <th scope="row">
                                        &nbsp;地&nbsp;&nbsp;&nbsp;&nbsp;点
                                    </th>
                                    <td>
                                        <span class="right">&nbsp;&nbsp;<input type="button" id="btn_obje_save" class="btn60_28"
                                            value="保 存" onclick="obje_save('obje_form')" /></span> <a href="javascript:void(0);"
                                                id="Obje_Area" class="btn28H" style="font-size: 12px;" onclick="ChooseArea2(this,'ChooseArea2','Obje_AreaID','Obje_AreaName');return false;">选择/修改</a>
                                        <input type="hidden" id="Obje_AreaID" name="Obje_AreaID" />
                                        <input type="hidden" id="Obje_AreaName" name="Obje_AreaName" />
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        &nbsp;行&nbsp;&nbsp;&nbsp;&nbsp;业
                                    </th>
                                    <td>
                                        <a href="javascript:void(0);" id="Obje_Industry" class="btn28H" style="font-size: 12px;" onclick="ChooseIndustry2(this,'ChooseIndustry2','Obje_IndustryID','Obje_IndustryName');return false;">
                                            选择/修改</a>
                                        <input type="hidden" id="Obje_IndustryID" name="Obje_IndustryID" />
                                        <input type="hidden" id="Obje_IndustryName" name="Obje_IndustryName" />
                                    </td>
                                    <th scope="row">
                                        &nbsp;职&nbsp;&nbsp;&nbsp;&nbsp;能
                                    </th>
                                    <td>
                                        <a href="javascript:void(0);" id="Obje_FuncType" class="btn28H" style="font-size: 12px;" onclick="choosePosition2(this,'ChoosePosition2','Obje_FuncTypeID','Obje_FuncTypeName');return false;">
                                            选择/修改</a>
                                        <input type="hidden" id="Obje_FuncTypeID" name="Obje_FuncTypeID" />
                                        <input type="hidden" id="Obje_FuncTypeName" name="Obje_FuncTypeName" />
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        &nbsp;期望薪水
                                    </th>
                                    <td>
                                        <select id="Obje_Salery" name="Obje_Salery">
                                            <option value="0" selected="selected">面议</option>
                                            <option value="1">1500以下</option>
                                            <option value="2">1500-1999</option>
                                            <option value="3">2000-2999</option>
                                            <option value="4">3000-4499</option>
                                            <option value="5">4500-5999</option>
                                            <option value="6">6000-7999</option>
                                            <option value="7">8000-9999</option>
                                            <option value="8">10000-14999</option>
                                            <option value="9">15000-19999</option>
                                            <option value="10">20000-29999</option>
                                            <option value="11">30000-49999</option>
                                            <option value="12">50000及以上</option>
                                        </select>
                                        /月
                                    </td>
                                    <th scope="row">
                                        &nbsp;到岗时间
                                    </th>
                                    <td>
                                        <select id="Obje_EntryTime" name="Obje_EntryTime">
                                            <option value="1" selected="selected">即时</option>
                                            <option value="2">一周以内</option>
                                            <option value="3">一个月内</option>
                                            <option value="4">1-3个月</option>
                                            <option value="5">三个月后</option>
                                            <option value="6">待定</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        &nbsp;部&nbsp;&nbsp;&nbsp;&nbsp;门
                                    </th>
                                    <td>
                                        <input type="text" id="Obje_Department" name="Obje_Department" class="pwdinput" maxlength="20" />
                                    </td>
                                    <th scope="row">
                                        &nbsp;公司性质
                                    </th>
                                    <td>
                                        <select id="Obje_CompType" name="Obje_CompType">
                                            <option value="1">外资(欧美)</option>
                                            <option value="2">外资(非欧美)</option>
                                            <option value="3">合资(欧美)</option>
                                            <option value="4">合资(非欧美)</option>
                                            <option value="5">国企</option>
                                            <option value="6">民营公司</option>
                                            <option value="7">外企代表处</option>
                                            <option value="8">政府机关</option>
                                            <option value="9">事业单位</option>
                                            <option value="10">非盈利机构</option>
                                            <option value="11">其它性质</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                    </th>
                                    <td colspan="3">
                                        <span class="tipW red hidden" id="errorMsg_Intro">输入错误。请控制在500个汉字以内！</span>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row" valign="top">
                                        &nbsp;自我评价
                                    </th>
                                    <td colspan="3">
                                        <table width="486" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <textarea id="Obje_Intro" name="Obje_Intro" class="txtArea" style="width: 495px;"
                                                        onkeyup="str_limit('obje',this.value,'Obje_IntroLength')" onchange="str_limit('obje',this.value,'Obje_IntroLength')"></textarea>
                                                </td>
                                            </tr>
                                            <tr style="color: #999;">
                                                <td>
                                                    <p class="lh20">
                                                        限500个中文字，输入您对自己的简短评价。请简明扼要的说明您最大的优势是什么，避免使 用一些空洞老套的话。</p>
                                                    <p class="lh20">
                                                        限500个中文字，已输入<span class="orange" id="Obje_IntroLength">0</span>个字</p>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <div class="blank6px">
                            </div>
                            </form>
                        </div>
                    </div>
                    <div class="blank8px">
                    </div>
                    <div class="flowhidden">
                        <div class="dTop">
                            <span class="subTit_up" id="langinfo_up" onclick="object_toggle('langinfo')" title="收起"
                                style="cursor: pointer"></span><span class="subTit" id="langinfo_down" onclick="object_toggle('langinfo')"
                                    title="展开" style="cursor: pointer; display: none"></span><strong class="f14 green">语言能力</strong>(<span
                                        class="orange">*</span>为必填项)</div>
                        <div class="dCon" id="langinfo">
                            <div id="lang">
                                <div id="lang_<%=langID %>">
                                    <form action="/User/LangSave.aspx?id=<%=QS("id") %>&langid=<%=langID %>&type=add"
                                    id="lang_form_<%=langID %>" method="post">
                                    <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <th scope="row">
                                            </th>
                                            <td>
                                                <span class="tipW red hidden" id="errorMsg_Type">请选择语言类别！</span>
                                            </td>
                                            <th scope="row">
                                            </th>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                                <span class="orange">*</span>语言类别
                                            </th>
                                            <td>
                                                <select id="Lang_Type" name="Lang_Type">
                                                    <option value="0">请选择语言类别</option>
                                                    <option value="1">英语</option>
                                                    <option value="2">日语</option>
                                                    <option value="3">俄语</option>
                                                    <option value="4">阿拉伯语</option>
                                                    <option value="5">法语</option>
                                                    <option value="6">德语</option>
                                                    <option value="7">西班牙语</option>
                                                    <option value="8">葡萄牙语</option>
                                                    <option value="9">意大利语</option>
                                                    <option value="10">韩语/朝鲜语</option>
                                                    <option value="11">普通话</option>
                                                    <option value="12">粤语</option>
                                                    <option value="13">闽南语</option>
                                                    <option value="14">上海话</option>
                                                    <option value="15">其它</option>
                                                </select>
                                            </td>
                                            <th scope="row">
                                                <span class="orange">*</span>掌握程度
                                            </th>
                                            <td>
                                                <span class="right">
                                                    <input type="button" id="btn_lang_del" class="btn60_28_gray" value="删 除" onclick="delinfo('lang',<%=langID %>,'btn_lang_del','lang_<%=langID %>')" />
                                                    &nbsp;&nbsp;<input type="button" id="btn_lang_save" class="btn60_28" value="保 存"
                                                        onclick="lang_save('lang_form_<%=langID %>')" /></span>
                                                <select id="Lang_Master" name="Lang_Master">
                                                    <option value="0" selected="selected">不限</option>
                                                    <option value="1">一般</option>
                                                    <option value="2">良好</option>
                                                    <option value="3">熟练</option>
                                                    <option value="4">精通</option>
                                                </select>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                                <span class="orange">*</span>读写能力
                                            </th>
                                            <td>
                                                <select id="Lang_RW" name="Lang_RW">
                                                    <option value="0" selected="selected">不限</option>
                                                    <option value="1">一般</option>
                                                    <option value="2">良好</option>
                                                    <option value="3">熟练</option>
                                                    <option value="4">精通</option>
                                                </select>
                                            </td>
                                            <th scope="row">
                                                <span class="orange">*</span>听说能力
                                            </th>
                                            <td>
                                                <select id="Lang_Listen" name="Lang_Listen">
                                                    <option value="0" selected="selected">不限</option>
                                                    <option value="1">一般</option>
                                                    <option value="2">良好</option>
                                                    <option value="3">熟练</option>
                                                    <option value="4">精通</option>
                                                </select>
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="blank6px">
                                    </div>
                                    </form>
                                </div>
                            </div>
                            <div class=" lh24">
                                <a href="javascript:void(0);" id="btn_info_add" class="btn28H" style="font-size: 12px;"
                                    onclick="addinfo('lang',<%=QS("id") %>,this);return false;">继续添加</a></div>
                            <div class="blank6px">
                            </div>
                            <div id="level">
                                <form action="/User/LevelSave.aspx?id=<%=QS("id") %>" id="level_form" method="post">
                                <table width="100%" class="tableInfo_1" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <th scope="row">
                                        </th>
                                        <td>
                                            <span class="tipW red hidden" id="errorMsg_EnLevel">请选择英语等级！</span>
                                        </td>
                                        <th scope="row">
                                        </th>
                                        <td>
                                            <span class="tipW red hidden" id="errorMsg_TOEFL">请正确输入分数！</span>
                                        </td>
                                        <th scope="row">
                                        </th>
                                        <td>
                                            <span class="tipW red hidden" id="errorMsg_GRE">请正确输入分数！</span>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th scope="row" style="width: 76px;">
                                            <span class="orange">*</span>英语等级
                                        </th>
                                        <td width="140">
                                            <select id="Level_EnLevel" name="Level_EnLevel">
                                                <option value="0">请选择级别</option>
                                                <option value="1">未参加</option>
                                                <option value="2">未通过</option>
                                                <option value="3">英语四级</option>
                                                <option value="4">英语六级</option>
                                                <option value="5">专业四级</option>
                                                <option value="6">专业八级</option>
                                            </select>
                                        </td>
                                        <th scope="row" style="width: 50px;">
                                            TOEFL
                                        </th>
                                        <td width="130">
                                            <input type="text" id="Level_TOEFL" name="Level_TOEFL" class="pwdinput" style="width: 100px;"
                                                maxlength="3" />
                                        </td>
                                        <th scope="row">
                                            GRE
                                        </th>
                                        <td>
                                            <input type="text" id="Level_GRE" name="Level_GRE" class="pwdinput" style="width: 100px;"
                                                maxlength="3" />
                                        </td>
                                        <td>
                                            <span class="right">
                                                <input type="button" id="btn_level_save" class="btn60_28" value="保 存" onclick="level_save('level_form')" /></span>
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
                                            <span class="tipW red hidden" id="errorMsg_GMAT">请正确输入分数！</span>
                                        </td>
                                        <th scope="row">
                                        </th>
                                        <td>
                                            <span class="tipW red hidden" id="errorMsg_IELTS">请正确输入分数！</span>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th scope="row" style="width: 76px;">
                                            &nbsp;日语等级
                                        </th>
                                        <td width="140">
                                            <select id="Level_JpLevel" name="Level_JpLevel">
                                                <option value="0">请选择级别</option>
                                                <option value="1">无</option>
                                                <option value="2">一级</option>
                                                <option value="3">二级</option>
                                                <option value="4">三级</option>
                                                <option value="5">四级</option>
                                            </select>
                                        </td>
                                        <th scope="row" style="width: 50px;">
                                            GMAT
                                        </th>
                                        <td width="130">
                                            <input type="text" id="Level_GMAT" name="Level_GMAT" class="pwdinput" style="width: 100px;"
                                                maxlength="3" />
                                        </td>
                                        <th scope="row">
                                            IELTS
                                        </th>
                                        <td>
                                            <input type="text" id="Level_IELTS" name="Level_IELTS" class="pwdinput" style="width: 100px;"
                                                maxlength="3" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                                <div class="blank6px">
                                </div>
                                </form>
                            </div>
                        </div>
                    </div>
                    <div class="blank8px">
                    </div>
                    <div class="flowhidden">
                        <div class="dTop">
                            <span class="subTit_up" id="certinfo_up" onclick="object_toggle('certinfo')" title="收起"
                                style="cursor: pointer"></span><span class="subTit" id="certinfo_down" onclick="object_toggle('certinfo')"
                                    title="展开" style="cursor: pointer; display: none"></span><strong class="f14 green">证
                                        书</strong>(<span class="orange">*</span>为必填项)</div>
                        <div class="dCon" id="certinfo">
                            <div id="cert">
                            </div>
                            <div class=" lh24">
                                <a href="javascript:void(0);" id="btn_info_add" class="btn28H" style="font-size: 12px;"
                                    onclick="addinfo('cert',<%=QS("id") %>,this);return false;">继续添加</a></div>
                            <div class="blank6px">
                            </div>
                        </div>
                    </div>
                    <div class="blank8px">
                    </div>
                    <div class="flowhidden">
                        <div class="dTop">
                            <span class="subTit_up" id="awarinfo_up" onclick="object_toggle('awarinfo')" title="收起"
                                style="cursor: pointer"></span><span class="subTit" id="awarinfo_down" onclick="object_toggle('awarinfo')"
                                    title="展开" style="cursor: pointer; display: none"></span><strong class="f14 green">奖
                                        项</strong>(<span class="orange">*</span>为必填项)</div>
                        <div class="dCon" id="awarinfo">
                            <div id="awar">
                            </div>
                            <div class=" lh24">
                                <a href="javascript:void(0);" id="btn_info_add" class="btn28H" style="font-size: 12px;"
                                    onclick="addinfo('awar',<%=QS("id") %>,this);return false;">继续添加</a></div>
                            <div class="blank6px">
                            </div>
                        </div>
                    </div>
                    <div class="blank8px">
                    </div>
                    <div class="flowhidden">
                        <div class="dTop">
                            <span class="subTit_up" id="skillinfo_up" onclick="object_toggle('skillinfo')" title="收起"
                                style="cursor: pointer"></span><span class="subTit" id="skillinfo_down" onclick="object_toggle('skillinfo')"
                                    title="展开" style="cursor: pointer; display: none"></span><strong class="f14 green">技
                                        能</strong>(<span class="orange">*</span>为必填项)</div>
                        <div class="dCon" id="skillinfo">
                            <div id="skill">
                            </div>
                            <div class=" lh24">
                                <a href="javascript:void(0);" id="btn_info_add" class="btn28H" style="font-size: 12px;"
                                    onclick="addinfo('skill',<%=QS("id") %>,this);return false;">继续添加</a></div>
                            <div class="blank6px">
                            </div>
                        </div>
                    </div>
                    <div class="blank30px">
                    </div>
                    <div class="tc">
                        <a href="javascript:void(0);" id="btn_save_all" class="btn94_28" onclick="all_save();return false;">
                            保存简历</a>
                    </div>
                    <div class="blank30px">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <uc1:Area runat="server" />
    <uc1:Area2 runat="server" />
    <uc1:Major runat="server" />
    <uc1:Industry runat="server" />
    <uc1:Industry2 runat="server" />
    <uc1:Position runat="server" />
    <uc1:Position2 runat="server" />
    <uc1:Upload runat="server" />

    <script type="text/javascript">
        setUserSidebar("JLGL"); 
    </script>
    
    <script type="text/javascript">
        $(document).ready(function() {
            myfun("industry2_ul", "li");
        });
    </script>

</asp:Content>
