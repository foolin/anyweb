<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ResuEdit.aspx.cs" Inherits="User_ResuEdit" %>

<%@ Register Src="~/Control/UserSidebar.ascx" TagName="UserSidebar" TagPrefix="uc1" %>
<%@ Register Src="~/Control/Area.ascx" TagName="Area" TagPrefix="uc1" %>
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
        <uc1:UserSidebar ID="UserSidebar1" runat="server" />
        <div class="content">
            <div class="tit gray">
                <a href="/Index.aspx">首页</a> > <a href="/User/Index.aspx">个人会员</a> > <span class="green">
                    修改简历</span></div>
            <div class="MemCon">
                <div class="addResume">
                    <div class="flowhidden">
                        <div class="dTop">
                            <span class="subTit_up" id="resume_up" onclick="object_toggle('resume')" title="收起"
                                style="cursor: pointer"></span><span class="subTit" id="resume_down" onclick="object_toggle('resume')"
                                    title="展开" style="cursor: pointer; display: none"></span><strong class="f14 green">简历信息</strong>(<span
                                        class="orange">*</span>为必填项)</div>
                        <div class="dCon" id="resume">
                            <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th scope="row">
                                        &nbsp;简历名称：
                                    </th>
                                    <td width="218">
                                        <%=bean.fdResuName %>
                                    </td>
                                    <td>
                                        <span class="right">&nbsp;&nbsp;<input type="button" class="btn60_28" id="btn_resu_save"
                                            value="修 改" onclick="editinfo('resume',<%=bean.fdResuID %>,'btn_resu_save','resume')" /></span>
                                    </td>
                                </tr>
                            </table>
                            <div class="blank12px">
                            </div>
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
                            <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="598" valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <th scope="row">
                                                    &nbsp;姓&nbsp;&nbsp;&nbsp;&nbsp;名
                                                </th>
                                                <td width="218">
                                                    <%=bean.fdResuUserName%>
                                                </td>
                                                <th>
                                                    &nbsp;性&nbsp;&nbsp;&nbsp;&nbsp;别
                                                </th>
                                                <td>
                                                    <%=bean.fdResuSex == 0 ? "男" : "女"%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th scope="row">
                                                    &nbsp;出生日期
                                                </th>
                                                <td width="218">
                                                    <%=bean.fdResuBirthday != DateTime.Parse( "1900-01-01" ) ? bean.fdResuBirthday.ToString( "yyyy年M月d日" ) : ""%>
                                                </td>
                                                <th>
                                                    &nbsp;工作年限
                                                </th>
                                                <td>
                                                    <%=getExpString( bean.fdResuExperience )%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th scope="row">
                                                    &nbsp;证件类型
                                                </th>
                                                <td width="218">
                                                    <%=getIdentString( bean.fdResuIdentificationID )%>
                                                </td>
                                                <th>
                                                    &nbsp;证&nbsp;件&nbsp;号
                                                </th>
                                                <td>
                                                    <%=bean.fdResuIdentificationNum%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th scope="row">
                                                    &nbsp;居&nbsp;住&nbsp;地
                                                </th>
                                                <td width="218">
                                                    <%=bean.fdResuAddress%>
                                                </td>
                                                <th>
                                                    &nbsp;Email
                                                </th>
                                                <td>
                                                    <%=bean.fdResuEmail%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th scope="row">
                                                    &nbsp;年&nbsp;&nbsp;&nbsp;&nbsp;薪
                                                </th>
                                                <td width="218">
                                                    <%=getSalaryString( bean.fdResuSalary )%>
                                                </td>
                                                <th>
                                                    &nbsp;币&nbsp;&nbsp;&nbsp;&nbsp;种
                                                </th>
                                                <td>
                                                    <%=getCurrTypeString( bean.fdResuCurrType )%>
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
                                                    <%=getCurrSituString( bean.fdResuCurrentSituation )%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th scope="row">
                                                    &nbsp;手机号码
                                                </th>
                                                <td width="218">
                                                    <%=bean.fdResuMobilePhone%>
                                                </td>
                                                <th>
                                                    &nbsp;公司电话
                                                </th>
                                                <td>
                                                    <%=bean.fdResuCompPhone%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th scope="row">
                                                    &nbsp;家庭电话
                                                </th>
                                                <td width="218">
                                                    <%=bean.fdResuFamiPhone%>
                                                </td>
                                                <th>
                                                    &nbsp;户&nbsp;&nbsp;&nbsp;&nbsp;口
                                                </th>
                                                <td>
                                                    <%=bean.fdResuHouseAddress%>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="38" class="tr">
                                                    <input type="button" class="btn60_28" id="btn_info_save" value="修改" onclick="editinfo('info',<%=bean.fdResuID %>,'btn_info_save','info')" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="<%=bean.fdResuPhoto==""?"../images/img_personPhoto.png":bean.fdResuPhoto %>"
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
                                <a href="javascript:void(0);" onclick="object_toggle('ext_info');return false;">查看更多个人信息<span
                                    id="ext_info_up" style="display: none">↑</span><span id="ext_info_down">↓</span></a></div>
                            <table id="ext_info" width="598" class="tableInfo" style="display: none" border="0"
                                cellspacing="0" cellpadding="0">
                                <tr>
                                    <th scope="row">
                                        &nbsp;国家地区
                                    </th>
                                    <td width="218">
                                        <%=getCountryString( bean.fdResuCountry )%>
                                    </td>
                                    <th>
                                        &nbsp;身&nbsp;&nbsp;&nbsp;&nbsp;高
                                    </th>
                                    <td>
                                        <%=bean.fdResuHeight == 0 ? "" : bean.fdResuHeight.ToString()%>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        &nbsp;邮&nbsp;&nbsp;&nbsp;&nbsp;编
                                    </th>
                                    <td width="218">
                                        <%=bean.fdResuPostCode%>
                                    </td>
                                    <th>
                                        &nbsp;地&nbsp;&nbsp;&nbsp;&nbsp;址
                                    </th>
                                    <td>
                                        <%=bean.fdResuContactAddr%>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        &nbsp;婚姻状况
                                    </th>
                                    <td width="218">
                                        <%=getMarryString( bean.fdResuMarry )%>
                                    </td>
                                    <th>
                                        &nbsp;个人主页
                                    </th>
                                    <td>
                                        <%=bean.fdResuWebsite%>
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
                            <span class="subTit_up" id="eduinfo_up" onclick="object_toggle('eduinfo')" title="收起"
                                style="cursor: pointer"></span><span class="subTit" id="eduinfo_down" onclick="object_toggle('eduinfo')"
                                    title="展开" style="cursor: pointer; display: none"></span><strong class="f14 green">教育经历</strong>(<span
                                        class="orange">*</span>为必填项)</div>
                        <div id="eduinfo" class="dCon">
                            <div id="edu">
                                <asp:Repeater ID="repEdu" runat="server">
                                    <ItemTemplate>
                                        <div id="edu_<%#Eval("fdEducID") %>">
                                            <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;时&nbsp;&nbsp;&nbsp;&nbsp;间
                                                    </th>
                                                    <td>
                                                        <span class="right">&nbsp;&nbsp;<input type="button" id="btn_edu_save" class="btn60_28"
                                                            value="修 改" onclick="editinfo('edu',<%#Eval("fdEducID") %>,'btn_edu_save','edu_<%#Eval("fdEducID") %>')" /></span>
                                                        <%#Eval("fdEducBegin","{0:yyyy年M月}") %>
                                                        到
                                                        <%#( ( DateTime ) Eval( "fdEducEnd" ) ).Year != 1900?Eval("fdEducEnd","{0:yyyy年M月}"):"至今"%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;学&nbsp;&nbsp;&nbsp;&nbsp;校
                                                    </th>
                                                    <td>
                                                        <%#Eval("fdEducSchool") %>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;专&nbsp;&nbsp;&nbsp;&nbsp;业
                                                    </th>
                                                    <td>
                                                        <%#( int ) Eval( "fdEducSpecialityID" ) == 0 ? Eval( "fdEducOtherSpecialty" ) : Eval( "fdEducSpeciality" )%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row">
                                                        <span class="orange">*</span>学&nbsp;&nbsp;&nbsp;&nbsp;历
                                                    </th>
                                                    <td>
                                                        <%#getDegreeString( (int)Eval( "fdEducDegree" ) )%>
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
                                                                    <%#( ( string ) Eval( "fdEducIntro" ) ).Replace( "\n", "<br />" )%>
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
                                                        <%#( int ) Eval( "fdEducIsOverSeas" ) == 0 ? "是" : "否"%>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="blank12px">
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
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
                                <asp:Repeater ID="repRew" runat="server">
                                    <ItemTemplate>
                                        <div id="rew_<%#Eval("fdRewaID") %>">
                                            <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;时&nbsp;&nbsp;&nbsp;&nbsp;间
                                                    </th>
                                                    <td>
                                                        <span class="right">&nbsp;&nbsp;<input type="button" id="btn_rew_edit" class="btn60_28"
                                                            value="修 改" onclick="editinfo('rew',<%#Eval("fdRewaID") %>,'btn_rew_edit','rew_<%#Eval("fdRewaID") %>')" /></span>
                                                        <%#Eval( "fdRewaBegin", "{0:yyyy年M月}" )%>
                                                        到
                                                        <%#( ( DateTime ) Eval( "fdRewaEnd" ) ).Year != 1900 ? Eval( "fdRewaEnd", "{0:yyyy年M月}" ) : "至今"%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;奖&nbsp;&nbsp;&nbsp;&nbsp;项
                                                    </th>
                                                    <td>
                                                        <%#Eval("fdRewaName") %>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;级&nbsp;&nbsp;&nbsp;&nbsp;别
                                                    </th>
                                                    <td>
                                                        <%#Eval("fdRewaLevel") %>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;简历显示
                                                    </th>
                                                    <td>
                                                        <%#( int ) Eval( "fdRewaIsShow" ) == 0 ? "是" : "否"%>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="blank12px">
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class=" lh24">
                                <a href="javascript:void(0);" id="btn_info_add" class="btn28H" style="font-size: 12px;"
                                    onclick="addinfo('rew',<%=QS("id") %>,this);return false;">继续添加</a></div>
                            <div class="blank12px dashLine">
                            </div>
                            <div id="pos">
                                <strong class="green">职务</strong>
                                <asp:Repeater ID="repPos" runat="server">
                                    <ItemTemplate>
                                        <div id="pos_<%#Eval("fdPosiID") %>">
                                            <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;时&nbsp;&nbsp;&nbsp;&nbsp;间
                                                    </th>
                                                    <td>
                                                        <span class="right">&nbsp;&nbsp;<input type="button" id="btn_pos_edit" class="btn60_28"
                                                            value="修 改" onclick="editinfo('pos',<%#Eval("fdPosiID") %>,'btn_pos_edit','pos_<%#Eval("fdPosiID") %>')" /></span>
                                                        <%#Eval( "fdPosiBegin", "{0:yyyy年M月}" )%>
                                                        到
                                                        <%#( ( DateTime ) Eval( "fdPosiEnd" ) ).Year != 1900 ? Eval( "fdPosiEnd", "{0:yyyy年M月}" ) : "至今"%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;职务名称
                                                    </th>
                                                    <td>
                                                        <%#Eval( "fdPosiName" )%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;单位名称
                                                    </th>
                                                    <td>
                                                        <%#Eval( "fdPosiOrg" )%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row" valign="top">
                                                        &nbsp;职务描述
                                                    </th>
                                                    <td>
                                                        <%#( ( string ) Eval( "fdPosiIntro" ) ).Replace( "\n", "<br />" )%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;简历显示
                                                    </th>
                                                    <td>
                                                        <%#( int ) Eval( "fdPosiIsShow" ) == 0 ? "是" : "否"%>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="blank12px">
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
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
                                <asp:Repeater ID="repWork" runat="server">
                                    <ItemTemplate>
                                        <div id="work_<%#Eval("fdWorkID") %>">
                                            <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;时&nbsp;&nbsp;&nbsp;&nbsp;间
                                                    </th>
                                                    <td colspan="3">
                                                        <span class="right">&nbsp;&nbsp;<input type="button" id="btn_work_save" class="btn60_28"
                                                            value="修 改" onclick="editinfo('work',<%#Eval("fdWorkID") %>,'btn_work_save','work_<%#Eval("fdWorkID") %>')" />
                                                        </span>
                                                        <%#Eval( "fdWorkBegin", "{0:yyyy年M月}" )%>
                                                        到
                                                        <%#( ( DateTime ) Eval( "fdWorkEnd" ) ).Year != 1900 ? Eval( "fdWorkEnd", "{0:yyyy年M月}" ) : "至今"%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;公&nbsp;&nbsp;&nbsp;&nbsp;司
                                                    </th>
                                                    <td>
                                                        <%#Eval( "fdWorkName" )%>
                                                    </td>
                                                    <th scope="row">
                                                        &nbsp;行&nbsp;&nbsp;&nbsp;&nbsp;业
                                                    </th>
                                                    <td>
                                                        <%#Eval( "fdWorkIndustry" )%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;公司规模
                                                    </th>
                                                    <td>
                                                        <%#getDimensionString( (int)Eval( "fdWorkDimension" ) )%>
                                                    </td>
                                                    <th scope="row">
                                                        &nbsp;公司性质
                                                    </th>
                                                    <td>
                                                        <%#getCompanyTypeString( ( int ) Eval( "fdWorkType" ) )%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;部&nbsp;&nbsp;&nbsp;&nbsp;门
                                                    </th>
                                                    <td>
                                                        <%#Eval( "fdWorkDepartment" )%>
                                                    </td>
                                                    <th scope="row">
                                                        &nbsp;职&nbsp;&nbsp;&nbsp;&nbsp;位
                                                    </th>
                                                    <td>
                                                        <%#( int ) Eval( "fdWorkJobID" ) == 0 ? Eval( "fdWorkJobID" ) : Eval( "fdWorkJob" )%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row" valign="top">
                                                        &nbsp;工作描述
                                                    </th>
                                                    <td colspan="3">
                                                        <table width="486" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td colspan="2">
                                                                    <%#( ( string ) Eval( "fdWorkIntro" ) ).Replace( "\n", "<br />" )%>
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
                                                        <%#( int ) Eval( "fdWorkIsOverSeas" ) == 0 ? "是" : "否"%>
                                                    </td>
                                                    <th scope="row">
                                                    </th>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="blank12px">
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
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
                            <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <th scope="row">
                                        &nbsp;工作类型
                                    </th>
                                    <td>
                                        <span class="right">&nbsp;&nbsp;<input type="button" class="btn60_28" id="btn_obje_save"
                                            value="修 改" onclick="editinfo('obje',<%=bean.fdResuID %>,'btn_obje_save','obje')" /></span>
                                        <%=getObjeType( bean.fdResuObjeType )%>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        &nbsp;地&nbsp;&nbsp;&nbsp;&nbsp;点
                                    </th>
                                    <td>
                                        <%=bean.fdResuObjeAreaID1 == 0 ? "" : bean.fdResuObjeArea1 + ";"%>
                                        <%=bean.fdResuObjeAreaID2 == 0 ? "" : bean.fdResuObjeArea2 + ";"%>
                                        <%=bean.fdResuObjeAreaID3 == 0 ? "" : bean.fdResuObjeArea3 + ";"%>
                                        <%=bean.fdResuObjeAreaID4 == 0 ? "" : bean.fdResuObjeArea4 + ";"%>
                                        <%=bean.fdResuObjeAreaID5 == 0 ? "" : bean.fdResuObjeArea5 + ";"%>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        &nbsp;行&nbsp;&nbsp;&nbsp;&nbsp;业
                                    </th>
                                    <td>
                                        <%=bean.fdResuObjeIndustryID1 == 0 ? "" : bean.fdResuObjeIndustry1 + ";"%>
                                        <%=bean.fdResuObjeIndustryID2 == 0 ? "" : bean.fdResuObjeIndustry2 + ";"%>
                                        <%=bean.fdResuObjeIndustryID3 == 0 ? "" : bean.fdResuObjeIndustry3 + ";"%>
                                        <%=bean.fdResuObjeIndustryID4 == 0 ? "" : bean.fdResuObjeIndustry4 + ";"%>
                                        <%=bean.fdResuObjeIndustryID5 == 0 ? "" : bean.fdResuObjeIndustry5 + ";"%>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        &nbsp;职&nbsp;&nbsp;&nbsp;&nbsp;能
                                    </th>
                                    <td>
                                        <%=bean.fdResuObjeFuncTypeID1 == 0 ? "" : bean.fdResuObjeFuncType1 + ";"%>
                                        <%=bean.fdResuObjeFuncTypeID2 == 0 ? "" : bean.fdResuObjeFuncType2 + ";"%>
                                        <%=bean.fdResuObjeFuncTypeID3 == 0 ? "" : bean.fdResuObjeFuncType3 + ";"%>
                                        <%=bean.fdResuObjeFuncTypeID4 == 0 ? "" : bean.fdResuObjeFuncType4 + ";"%>
                                        <%=bean.fdResuObjeFuncTypeID5 == 0 ? "" : bean.fdResuObjeFuncType5 + ";"%>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        &nbsp;期望薪水
                                    </th>
                                    <td>
                                        <%=bean.fdResuObjeSalery == 0 ? "面议" : getObjeSaleryString( bean.fdResuObjeSalery ) + "/月"%>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        &nbsp;到岗时间
                                    </th>
                                    <td>
                                        <%=getEntryTimeString( bean.fdResuObjeEntryTime )%>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        &nbsp;部&nbsp;&nbsp;&nbsp;&nbsp;门
                                    </th>
                                    <td>
                                        <%=bean.fdResuObjeDepartment %>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">
                                        &nbsp;公司性质
                                    </th>
                                    <td>
                                        <%=getCompanyTypeString(bean.fdResuObjeCompType)%>
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
                                                    <%=bean.fdResuObjeIntro.Replace( "\n", "<br />" )%>
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
                            <span class="subTit_up" id="langinfo_up" onclick="object_toggle('langinfo')" title="收起"
                                style="cursor: pointer"></span><span class="subTit" id="langinfo_down" onclick="object_toggle('langinfo')"
                                    title="展开" style="cursor: pointer; display: none"></span><strong class="f14 green">语言能力</strong>(<span
                                        class="orange">*</span>为必填项)</div>
                        <div class="dCon" id="langinfo">
                            <div id="lang">
                                <asp:Repeater ID="repLan" runat="server">
                                    <ItemTemplate>
                                        <div id="lang_<%#Eval("fdLangID") %>">
                                            <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;语言类别
                                                    </th>
                                                    <td>
                                                        <%#getLangTypeString( ( int ) Eval( "fdLangType" ) )%>
                                                    </td>
                                                    <th scope="row">
                                                        &nbsp;掌握程度
                                                    </th>
                                                    <td>
                                                        <span class="right">&nbsp;&nbsp;<input type="button" id="btn_lang_edit" class="btn60_28"
                                                            value="修 改" onclick="editinfo('lang',<%#Eval("fdLangID") %>,'btn_lang_edit','lang_<%#Eval("fdLangID") %>')" /></span>
                                                        <%#getLangAbilityString( ( int ) Eval( "fdLangMaster" ) )%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;读写能力
                                                    </th>
                                                    <td>
                                                        <%#getLangAbilityString( ( int ) Eval( "fdLangRWAbility" ) )%>
                                                    </td>
                                                    <th scope="row">
                                                        &nbsp;听说能力
                                                    </th>
                                                    <td>
                                                        <%#getLangAbilityString( ( int ) Eval( "fdLangLiAbility" ) )%>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="blank6px">
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class=" lh24">
                                <a href="javascript:void(0);" id="btn_info_add" class="btn28H" style="font-size: 12px;"
                                    onclick="addinfo('lang',<%=QS("id") %>,this);return false;">继续添加</a></div>
                            <div class="blank6px">
                            </div>
                            <div id="level">
                                <table width="100%" class="tableInfo_1" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <th scope="row" style="width: 76px;">
                                            &nbsp;英语等级
                                        </th>
                                        <td width="140">
                                            <%=getEnLevelString( bean.fdResuEnLevel )%>
                                        </td>
                                        <th scope="row" style="width: 50px;">
                                            TOEFL
                                        </th>
                                        <td width="130">
                                            <%=bean.fdResuTOEFL == 0 ? "" : bean.fdResuTOEFL.ToString()%>
                                        </td>
                                        <th scope="row">
                                            GRE
                                        </th>
                                        <td>
                                            <%=bean.fdResuGRE == 0 ? "" : bean.fdResuGRE.ToString()%>
                                        </td>
                                        <td>
                                            <span class="right">
                                                <input type="button" id="btn_level_save" class="btn60_28" value="修 改" onclick="editinfo('level',<%=bean.fdResuID %>,'btn_level_save','level')" /></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th scope="row" style="width: 76px;">
                                            &nbsp;日语等级
                                        </th>
                                        <td width="140">
                                            <%=getJpLevelString( bean.fdResuJpLevel )%>
                                        </td>
                                        <th scope="row" style="width: 50px;">
                                            GMAT
                                        </th>
                                        <td width="130">
                                            <%=bean.fdResuGMAT == 0 ? "" : bean.fdResuGMAT.ToString()%>
                                        </td>
                                        <th scope="row">
                                            IELTS
                                        </th>
                                        <td>
                                            <%=bean.fdResuIELTS == 0 ? "" : bean.fdResuIELTS.ToString()%>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                                <div class="blank6px">
                                </div>
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
                                <asp:Repeater ID="repCert" runat="server">
                                    <ItemTemplate>
                                        <div id="cert_<%#Eval("fdCertID") %>">
                                            <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;获得时间
                                                    </th>
                                                    <td>
                                                        <span class="right">&nbsp;&nbsp;<input type="button" id="btn_cert_edit" class="btn60_28"
                                                            value="修 改" onclick="editinfo('cert',<%#Eval("fdCertID") %>,'btn_cert_edit','cert_<%#Eval("fdCertID") %>')" /></span>
                                                        <%#Eval( "fdCertDate", "{0:yyyy年MM月}" )%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;名&nbsp;&nbsp;&nbsp;&nbsp;称
                                                    </th>
                                                    <td>
                                                        <%#Eval( "fdCertName" )%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;成&nbsp;&nbsp;&nbsp;&nbsp;绩
                                                    </th>
                                                    <td>
                                                        <%#( int ) Eval( "fdCertScore" ) == 0 ? "" : Eval( "fdCertScore" )%>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="blank6px">
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
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
                                <asp:Repeater ID="repAwar" runat="server">
                                    <ItemTemplate>
                                        <div id="awar_<%#Eval("fdAwarID") %>">
                                            <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;获得时间
                                                    </th>
                                                    <td>
                                                        <span class="right">&nbsp;&nbsp;<input type="button" id="btn_awar_edit" class="btn60_28"
                                                            value="修 改" onclick="editinfo('awar',<%#Eval("fdAwarID") %>,'btn_awar_edit','awar_<%#Eval("fdAwarID") %>')" /></span>
                                                        <%#( ( DateTime ) Eval( "fdAwarDate" ) ).Year != 1900 ? Eval( "fdAwarDate", "{0:yyyy年MM月}" ) : ""%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;名&nbsp;&nbsp;&nbsp;&nbsp;称
                                                    </th>
                                                    <td>
                                                        <%#Eval( "fdAwarName" )%>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="blank6px">
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
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
                                <asp:Repeater ID="repSkill" runat="server">
                                    <ItemTemplate>
                                        <div id="skill_<%#Eval("fdSkilID") %>">
                                            <table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;名&nbsp;&nbsp;&nbsp;&nbsp;称
                                                    </th>
                                                    <td width="218">
                                                        <%#Eval( "fdSkilName" )%>
                                                    </td>
                                                    <th scope="row">
                                                        &nbsp;使用时间
                                                    </th>
                                                    <td>
                                                        <span class="right">&nbsp;&nbsp;<input type="button" id="btn_skill_edit" class="btn60_28"
                                                            value="修 改" onclick="editinfo('skill',<%#Eval("fdSkilID") %>,'btn_skill_edit','skill_<%#Eval("fdSkilID") %>')" /></span>
                                                        <%#Eval( "fdSkilMonth" )%>月
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th scope="row">
                                                        &nbsp;掌握程度
                                                    </th>
                                                    <td>
                                                        <%#getSkillLevelString( ( int ) Eval( "fdSkilLevel" ) )%>
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
                                    </ItemTemplate>
                                </asp:Repeater>
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
    <uc1:Area ID="Area1" runat="server" />
    <uc1:Major ID="Major1" runat="server" />
    <uc1:Industry ID="Industry1" runat="server" />
    <uc1:Industry2 ID="Industry2" runat="server" />
    <uc1:Position ID="Position1" runat="server" />
    <uc1:Position2 ID="Position2" runat="server" />
    <uc1:Upload ID="Upload1" runat="server" />

    <script type="text/javascript">
        setUserSidebar("JLGL"); 
    </script>

    <script type="text/javascript">
        $(document).ready(function() {
            myfun("industry2_ul", "li");
        });
    </script>
</asp:Content>
