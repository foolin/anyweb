<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ResuAdd.aspx.cs" Inherits="User_ResuAdd" %>

<%@ Register Src="~/Control/UserSidebar.ascx" TagName="UserSidebar" TagPrefix="uc1" %>
<%@ Register Src="~/Control/Area.ascx" TagName="Area" TagPrefix="uc1" %>
<%@ Register Src="~/Control/Upload.ascx" TagName="Upload" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../js/resume.js"></script>

    <script type="text/javascript" src="../js/form.js"></script>

    <script type="text/javascript" src="../js/ajaxfileupload.js"></script>

    <div class="resumePage">
        <uc1:UserSidebar runat="server" />
        <div class="content column">
            <div class="tit gray">
                <a href="/Index.aspx">首页</a> > <a href="/User/Index.aspx">个人会员</a> > <span class="green">
                    添加简历</span></div>
            <div class="MemCon">
                <div class="addResume">
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
                                                    <a href="javascript:void(0);" onclick="selectArea('Place','AddressID','Address')"
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
                                                    <a href="javascript:void(0);" onclick="selectArea('Hukou','HouseAddressID','HouseAddress')"
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
                                                <a href="javascript:void(0);" id="place" class="btn28H" style="font-size: 12px;">选择/修改</a>
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
                                                <input type="radio" name="forlen" value="0" checked="checked" />是<input type="radio"
                                                    value="1" name="forlen" />
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
                                    onclick="addinfo('edu',<%=QS("id") %>)">继续添加</a></div>
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
                                <div id="rew_<%=rewardsID %>">
                                    <form action="/User/RewardsSave.aspx?id=<%=QS("id") %>&rewid=<%=rewardsID %>&type=add"
                                    id="rew_form_<%=rewardsID %>" method="post">
                                    <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <th scope="row">
                                                <strong class="green">奖励</strong>
                                            </th>
                                            <td>
                                                <span class="right">
                                                    <input type="button" id="btn_rew_del" class="btn60_28_gray" value="删 除" onclick="delinfo('rew',<%=rewardsID %>,'btn_rew_del','rew_<%=rewardsID %>')" />
                                                    &nbsp;&nbsp;<input type="button" id="btn_rew_save" class="btn60_28" value="保 存" onclick="rew_save('rew_form_<%=rewardsID %>')" /></span>
                                            </td>
                                        </tr>
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
                                                <select id="Rew_FromYear" name="Rew_FromYear">
                                                    <option selected="selected" value="0">年</option>
                                                    <%for( int i = DateTime.Now.Year; i >= 1940; i-- )
                                                      { %>
                                                    <option value="<%=i%>">
                                                        <%=i%></option>
                                                    <%} %>
                                                </select>
                                                <select id="Rew_FromMonth" name="Rew_FromMonth">
                                                    <option selected="selected" value="0">月</option>
                                                    <%for( int i = 1; i <= 12; i++ )
                                                      { %>
                                                    <option value="<%=i%>">
                                                        <%=i%></option>
                                                    <%} %>
                                                </select>
                                                到
                                                <select id="Rew_ToYear" name="Rew_ToYear">
                                                    <option selected="selected" value="0">年</option>
                                                    <%for( int i = DateTime.Now.Year; i >= 1940; i-- )
                                                      { %>
                                                    <option value="<%=i%>">
                                                        <%=i%></option>
                                                    <%} %>
                                                </select>
                                                <select id="Rew_ToMonth" name="Rew_ToMonth">
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
                                                <span class="tipW red hidden" id="errorMsg_Name">奖项不能为空！</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                                <span class="orange">*</span>奖&nbsp;&nbsp;&nbsp;&nbsp;项
                                            </th>
                                            <td>
                                                <input type="text" id="Rew_Name" name="Rew_Name" class="pwdinput" style="width: 296px;"
                                                    maxlength="50" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                                &nbsp;级&nbsp;&nbsp;&nbsp;&nbsp;别
                                            </th>
                                            <td>
                                                <input type="text" id="Rew_Level" name="Rew_Level" class="pwdinput" style="width: 296px;"
                                                    maxlength="50" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                            </th>
                                            <td>
                                                <input type="checkbox" checked="checked" id="Rew_IsShow" name="Rew_IsShow" value="0" />
                                                <label for="Rew_IsShow">
                                                    <span class="lgray">将此奖项显示在我的简历中 </span>
                                                </label>
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
                                    onclick="addinfo('rew',<%=QS("id") %>)">继续添加</a></div>
                            <div class="blank12px dashLine">
                            </div>
                            <div id="pos">
                                <div id="pos_<%=posiID %>">
                                    <form action="/User/PositionSave.aspx?id=<%=QS("id") %>&posid=<%=posiID %>&type=add"
                                    id="pos_form_<%=posiID %>" method="post">
                                    <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <th scope="row">
                                                <strong class="green">职务</strong>
                                            </th>
                                            <td>
                                                <span class="right">
                                                    <input type="button" id="btn_pos_del" class="btn60_28_gray" value="删 除" onclick="delinfo('pos',<%=posiID %>,'btn_pos_del','pos_<%=posiID %>')" />
                                                    &nbsp;&nbsp;<input type="button" id="btn_pos_save" class="btn60_28" value="保 存" onclick="pos_save('pos_form_<%=posiID %>')" /></span>
                                            </td>
                                        </tr>
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
                                                <select id="Pos_FromYear" name="Pos_FromYear">
                                                    <option selected="selected" value="0">年</option>
                                                    <%for( int i = DateTime.Now.Year; i >= 1940; i-- )
                                                      { %>
                                                    <option value="<%=i%>">
                                                        <%=i%></option>
                                                    <%} %>
                                                </select>
                                                <select id="Pos_FromMonth" name="Pos_FromMonth">
                                                    <option selected="selected" value="0">月</option>
                                                    <%for( int i = 1; i <= 12; i++ )
                                                      { %>
                                                    <option value="<%=i%>">
                                                        <%=i%></option>
                                                    <%} %>
                                                </select>
                                                到
                                                <select id="Pos_ToYear" name="Pos_ToYear">
                                                    <option selected="selected" value="0">年</option>
                                                    <%for( int i = DateTime.Now.Year; i >= 1940; i-- )
                                                      { %>
                                                    <option value="<%=i%>">
                                                        <%=i%></option>
                                                    <%} %>
                                                </select>
                                                <select id="Pos_ToMonth" name="Pos_ToMonth">
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
                                                <span class="tipW red hidden" id="errorMsg_Name">职务名称不能为空！</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                                <span class="orange">*</span>职务名称
                                            </th>
                                            <td>
                                                <input type="text" id="Pos_Name" name="Pos_Name" class="pwdinput" style="width: 296px;"
                                                    maxlength="50" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                            </th>
                                            <td>
                                                <span class="tipW red hidden" id="errorMsg_Org">单位名称不能为空！</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                                <span class="orange">*</span>单位名称
                                            </th>
                                            <td>
                                                <input type="text" id="Pos_Org" name="Pos_Org" class="pwdinput" style="width: 296px;"
                                                    maxlength="50" />
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
                                                &nbsp;职务描述
                                            </th>
                                            <td>
                                                <table width="456" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td>
                                                            <textarea id="Pos_Intro" name="Pos_Intro" class="txtArea" onkeyup="str_limit('pos_<%=posiID %>',this.value,'Pos_IntroLength')"
                                                                onchange="str_limit('pos_<%=posiID %>',this.value,'Pos_IntroLength')"></textarea>
                                                        </td>
                                                    </tr>
                                                    <tr style="color: #999;">
                                                        <td width="284">
                                                            限2000个中文字，已输入<span class="orange" id="Pos_IntroLength">0</span>个字
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">
                                            </th>
                                            <td>
                                                <input type="checkbox" checked="checked" value="0" id="Pos_IsShow" name="Pos_IsShow" />
                                                <label for="Pos_IsShow">
                                                    <span class="lgray">将此职务信息显示在我的简历中 </span>
                                                </label>
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
                                    onclick="addinfo('pos',<%=QS("id") %>)">继续添加</a></div>
                            <%--<div class="blank12px dashLine">
                            </div>
                            <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th scope="row">
                                        <strong class="green">职务</strong>
                                    </th>
                                    <td>
                                        <span class="right">
                                            <input type="button" class="btn60_28_gray" value="删 除" />
                                            &nbsp;&nbsp;<input type="button" class="btn60_28" value="保 存" /></span>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        <span class="orange">*</span>时&nbsp;&nbsp;&nbsp;&nbsp;间
                                    </th>
                                    <td>
                                        <select>
                                            <option class="gray">2010</option>
                                        </select>年<select><option class="gray">12</option>
                                        </select>月 到
                                        <select>
                                            <option class="gray">2010</option>
                                        </select>年<select><option class="gray">12</option>
                                        </select>月 <span class="lgray">(后两项不填表示至今)</span>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        <span class="orange">*</span>职务名称
                                    </th>
                                    <td>
                                        <input type="text" class="pwdinput" style="width: 296px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row" valign="top">
                                        &nbsp;职位描述
                                    </th>
                                    <td>
                                        <table width="456" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <textarea class="txtArea"></textarea>
                                                </td>
                                            </tr>
                                            <tr style="color: #999;">
                                                <td width="284">
                                                    限2000个中文字，已输入<span class="orange">0</span>个字
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                    </th>
                                    <td>
                                        <input type="checkbox" checked="checked" id="posres" />
                                        <label for="posres">
                                            <span class="lgray">将此职务信息显示在我的简历中 </span>
                                        </label>
                                    </td>
                                </tr>
                            </table>
                            <div class="blank12px">
                            </div>
                            <div class=" lh24">
                                <a href="#" class="btn28H" style="font-size: 12px;">继续添加</a></div>
                            <div class="blank12px dashLine">
                            </div>--%>
                            <div class="blank6px">
                            </div>
                        </div>
                    </div>
                    <div class="blank8px">
                    </div>
                    <div class="flowhidden">
                        <div class="dTop">
                            <span class="subTit"></span><strong class="f14 green">求职意向</strong>(<span class="orange">*</span>为必填项)</div>
                        <div class="dCon">
                            <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th scope="row">
                                        <span class="orange">*</span>时&nbsp;&nbsp;&nbsp;&nbsp;间
                                    </th>
                                    <td colspan="3">
                                        <span class="right">
                                            <input type="button" class="btn60_28_gray" value="删 除" />
                                            &nbsp;&nbsp;<input type="button" class="btn60_28" value="保 存" /></span>
                                        <select>
                                            <option class="gray">2010</option>
                                        </select>年<select><option class="gray">12</option>
                                        </select>月 到
                                        <select>
                                            <option class="gray">2010</option>
                                        </select>年<select><option class="gray">12</option>
                                        </select>月 <span class="lgray">(后两项不填表示至今)</span>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        <span class="orange">*</span>公&nbsp;&nbsp;&nbsp;&nbsp;司
                                    </th>
                                    <td>
                                        <input type="text" class="pwdinput" />
                                    </td>
                                    <th scope="row">
                                        <span class="orange">*</span>行&nbsp;&nbsp;&nbsp;&nbsp;业
                                    </th>
                                    <td>
                                        <a href="javascript:void(0);" id="place" class="btn28H" style="font-size: 12px;">选择/修改</a>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        &nbsp;公司规模
                                    </th>
                                    <td>
                                        <select>
                                            <option class="gray">请选择公司规模</option>
                                        </select>
                                    </td>
                                    <th scope="row">
                                        <span class="orange">*</span>公司性质
                                    </th>
                                    <td>
                                        <select>
                                            <option class="gray">请选择公司性质</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        <span class="orange">*</span>部&nbsp;&nbsp;&nbsp;&nbsp;门
                                    </th>
                                    <td>
                                        <input type="text" class="pwdinput" />
                                    </td>
                                    <th scope="row">
                                        <span class="orange">*</span>公司性质
                                    </th>
                                    <td>
                                        <a href="javascript:void(0);" id="place" class="btn28H" style="font-size: 12px;">选择/修改</a>
                                        <input type="text" class="pwdinput" value="若无合适项，请在此填写" style="color: #999;" />
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
                                                    <textarea class="txtArea" style="width: 495px;"></textarea>
                                                </td>
                                            </tr>
                                            <tr style="color: #999;">
                                                <td width="295">
                                                    请详细描述您的职责范围、工作任务以及取得的成绩等
                                                </td>
                                                <td align="right" width="174">
                                                    限2000个中文字，已输入<span class="orange">0</span>个字
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
                                        <input type="radio" name="forlen" value="是" checked="checked" />是<input type="radio"
                                            value="否" name="forlen" />
                                        否
                                    </td>
                                    <th scope="row">
                                    </th>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                            <div class="blank12px">
                            </div>
                            <div class=" lh24">
                                <a href="#" class="btn28H" style="font-size: 12px;">继续添加</a></div>
                            <div class="blank6px">
                            </div>
                        </div>
                    </div>
                    <div class="blank8px">
                    </div>
                    <div class="flowhidden">
                        <div class="dTop">
                            <span class="subTit"></span><strong class="f14 green">求职意向</strong>(<span class="orange">*</span>为必填项)</div>
                        <div class="dCon">
                            <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th scope="row">
                                        &nbsp;工作类型
                                    </th>
                                    <td>
                                        <select>
                                            <option class="gray">请选择工作类型</option>
                                        </select>
                                    </td>
                                    <th scope="row">
                                        &nbsp;地&nbsp;&nbsp;&nbsp;&nbsp;点
                                    </th>
                                    <td>
                                        <span class="right">
                                            <input type="button" class="btn60_28_gray" value="删 除" />
                                            &nbsp;&nbsp;<input type="button" class="btn60_28" value="保 存" /></span> <a href="javascript:void(0);"
                                                id="place" class="btn28H" style="font-size: 12px;">选择/修改</a>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        &nbsp;行&nbsp;&nbsp;&nbsp;&nbsp;业
                                    </th>
                                    <td>
                                        <a href="javascript:void(0);" id="place" class="btn28H" style="font-size: 12px;">选择/修改</a>
                                    </td>
                                    <th scope="row">
                                        &nbsp;职&nbsp;&nbsp;&nbsp;&nbsp;能
                                    </th>
                                    <td>
                                        <a href="javascript:void(0);" id="place" class="btn28H" style="font-size: 12px;">选择/修改</a>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        &nbsp;期望薪水
                                    </th>
                                    <td>
                                        <select>
                                            <option class="gray">请选择薪水范围</option>
                                        </select>
                                    </td>
                                    <th scope="row">
                                        &nbsp;到岗时间
                                    </th>
                                    <td>
                                        <select>
                                            <option class="gray">请选择到岗时间</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        &nbsp;部&nbsp;&nbsp;&nbsp;&nbsp;门
                                    </th>
                                    <td>
                                        <input type="text" class="pwdinput" />
                                    </td>
                                    <th scope="row">
                                        &nbsp;公司性质
                                    </th>
                                    <td>
                                        <a href="javascript:void(0);" id="place" class="btn28H" style="font-size: 12px;">选择/修改</a>
                                        <input type="text" class="pwdinput" value="若无合适项，请在此填写" style="color: #999;" />
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
                                                    <textarea class="txtArea" style="width: 495px;"></textarea>
                                                </td>
                                            </tr>
                                            <tr style="color: #999;">
                                                <td>
                                                    <p class="lh20">
                                                        限500个中文字，输入您对自己的简短评价。请简明扼要的说明您最大的优势是什么，避免使 用一些空洞老套的话。范例一：? 范例二：?</p>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <div class="blank6px">
                            </div>
                        </div>
                    </div>
                    <div class="blank8px">
                    </div>
                    <div class="flowhidden">
                        <div class="dTop">
                            <span class="subTit"></span><strong class="f14 green">语言能力</strong>(<span class="orange">*</span>为必填项)</div>
                        <div class="dCon">
                            <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th scope="row">
                                        <span class="orange">*</span>语言类别
                                    </th>
                                    <td>
                                        <select>
                                            <option class="gray">请选择语言类别</option>
                                        </select>
                                    </td>
                                    <th scope="row">
                                        <span class="orange">*</span>掌握程度
                                    </th>
                                    <td>
                                        <span class="right">
                                            <input type="button" class="btn60_28_gray" value="删 除" />
                                            &nbsp;&nbsp;<input type="button" class="btn60_28" value="保 存" /></span>
                                        <select>
                                            <option class="gray">请选择掌握程度</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        <span class="orange">*</span>读写能力
                                    </th>
                                    <td>
                                        <select>
                                            <option class="gray">请选择语言类别</option>
                                        </select>
                                    </td>
                                    <th scope="row">
                                        <span class="orange">*</span>听说能力
                                    </th>
                                    <td>
                                        <select>
                                            <option class="gray">请选择掌握程度</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                    </th>
                                    <td colspan="3">
                                        <a href="javascript:void(0);" id="place" class="btn28H" style="font-size: 12px;">继续添加</a>
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" class="tableInfo_1" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th scope="row" style="width: 76px;">
                                        <span class="orange">*</span>英语等级
                                    </th>
                                    <td width="140">
                                        <select>
                                            <option class="gray">请选择级别</option>
                                        </select>
                                    </td>
                                    <th scope="row" style="width: 50px;">
                                        TOEFL
                                    </th>
                                    <td width="130">
                                        <input type="text" class="pwdinput" style="width: 100px;" />
                                    </td>
                                    <th scope="row">
                                        GRE
                                    </th>
                                    <td>
                                        <input type="text" class="pwdinput" style="width: 100px;" />
                                    </td>
                                    <td>
                                        <span class="right">
                                            <input type="button" class="btn60_28" value="保 存" /></span>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row" style="width: 76px;">
                                        <span class="orange">*</span>日语等级
                                    </th>
                                    <td width="140">
                                        <select>
                                            <option class="gray">请选择级别</option>
                                        </select>
                                    </td>
                                    <th scope="row" style="width: 50px;">
                                        GMAT
                                    </th>
                                    <td width="130">
                                        <input type="text" class="pwdinput" style="width: 100px;" />
                                    </td>
                                    <th scope="row">
                                        IELTS
                                    </th>
                                    <td>
                                        <input type="text" class="pwdinput" style="width: 100px;" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                            <div class="blank6px">
                            </div>
                        </div>
                    </div>
                    <div class="blank8px">
                    </div>
                    <div class="flowhidden">
                        <div class="dTop">
                            <span class="subTit"></span><strong class="f14 green">证 书</strong>(<span class="orange">*</span>为必填项)</div>
                        <div class="dCon">
                            <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th scope="row">
                                        <span class="orange">*</span>获得时间
                                    </th>
                                    <td>
                                        <span class="right">
                                            <input type="button" class="btn60_28_gray" value="删 除" />
                                            &nbsp;&nbsp;<input type="button" class="btn60_28" value="保 存" /></span>
                                        <select>
                                            <option class="gray">2010</option>
                                        </select>年<select><option class="gray">12</option>
                                        </select>月
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        <span class="orange">*</span>名&nbsp;&nbsp;&nbsp;&nbsp;称
                                    </th>
                                    <td>
                                        <input type="text" class="pwdinput" style="width: 476px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        &nbsp;成&nbsp;&nbsp;&nbsp;&nbsp;绩
                                    </th>
                                    <td>
                                        <input type="text" class="pwdinput" style="width: 476px;" />
                                    </td>
                                </tr>
                            </table>
                            <div class="blank6px">
                            </div>
                        </div>
                    </div>
                    <div class="blank8px">
                    </div>
                    <div class="flowhidden">
                        <div class="dTop">
                            <span class="subTit"></span><strong class="f14 green">奖 项</strong>(<span class="orange">*</span>为必填项)</div>
                        <div class="dCon">
                            <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th scope="row">
                                        <span class="orange">*</span>获得时间
                                    </th>
                                    <td>
                                        <span class="right">
                                            <input type="button" class="btn60_28_gray" value="删 除" />
                                            &nbsp;&nbsp;<input type="button" class="btn60_28" value="保 存" /></span>
                                        <select>
                                            <option class="gray">2010</option>
                                        </select>年<select><option class="gray">12</option>
                                        </select>月
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        <span class="orange">*</span>名&nbsp;&nbsp;&nbsp;&nbsp;称
                                    </th>
                                    <td>
                                        <input type="text" class="pwdinput" style="width: 476px;" />
                                    </td>
                                </tr>
                            </table>
                            <div class="blank6px">
                            </div>
                        </div>
                    </div>
                    <div class="blank8px">
                    </div>
                    <div class="flowhidden">
                        <div class="dTop">
                            <span class="subTit"></span><strong class="f14 green">技 能</strong>(<span class="orange">*</span>为必填项)</div>
                        <div class="dCon">
                            <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th scope="row">
                                        <span class="orange">*</span>名&nbsp;&nbsp;&nbsp;&nbsp;称
                                    </th>
                                    <td width="218">
                                        <input type="text" class="pwdinput" />
                                    </td>
                                    <th scope="row">
                                        <span class="orange">*</span>使用时间
                                    </th>
                                    <td>
                                        <span class="right">
                                            <input type="button" class="btn60_28_gray" value="删 除" />
                                            &nbsp;&nbsp;<input type="button" class="btn60_28" value="保 存" /></span>
                                        <input type="text" class="pwdinput" />
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        <span class="orange">*</span>掌握程度
                                    </th>
                                    <td>
                                        <select>
                                            <option class="gray">请选择程度</option>
                                        </select>
                                    </td>
                                    <th scope="row">
                                    </th>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                            <div class="blank6px">
                            </div>
                        </div>
                    </div>
                    <div class="blank30px">
                    </div>
                    <div class="tc">
                        <a href="#" class="btn94_28">填写完毕</a>
                    </div>
                    <div class="blank30px">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <uc1:Area runat="server" />
    <uc1:Upload runat="server" />

    <script type="text/javascript">
        setUserSidebar("JLGL"); function selectArea(area, id, name) {
            currentarea = area;
            currentid = id; currentname = name; ChooseArea();
        } </script>

</asp:Content>
