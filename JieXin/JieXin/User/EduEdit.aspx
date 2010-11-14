<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EduEdit.aspx.cs" Inherits="User_EduEdit" %>

<form action="/User/EduSave.aspx?eduid=<%=bean.fdEducID %>&type=edit" id="edu_form_<%=bean.fdEducID %>"
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
                <input type="button" id="btn_edu_del" class="btn60_28_gray" value="删 除" onclick="delinfo('edu',<%=bean.fdEducID %>,'btn_edu_del','edu_<%=bean.fdEducID %>')" />
                &nbsp;&nbsp;<input type="button" id="btn_edu_save" class="btn60_28" value="保 存" onclick="edu_save('edu_form_<%=bean.fdEducID %>')" /></span>
            <select id="Edu_FromYear" name="Edu_FromYear">
                <option selected="selected" value="0">年</option>
                <%for( int i = DateTime.Now.Year; i >= 1940; i-- )
                  { %>
                <option value="<%=i%>" <%=bean.fdEducBegin.Year==i?"selected=\"selected\"":"" %>>
                    <%=i%></option>
                <%} %>
            </select>
            <select id="Edu_FromMonth" name="Edu_FromMonth">
                <option selected="selected" value="0">月</option>
                <%for( int i = 1; i <= 12; i++ )
                  { %>
                <option value="<%=i%>" <%=bean.fdEducBegin.Month==i?"selected=\"selected\"":"" %>>
                    <%=i%></option>
                <%} %>
            </select>
            到
            <select id="Edu_ToYear" name="Edu_ToYear">
                <option selected="selected" value="0">年</option>
                <%for( int i = DateTime.Now.Year; i >= 1940; i-- )
                  { %>
                <option value="<%=i%>" <%=bean.fdEducEnd.Year!=1900&&bean.fdEducEnd.Year==i?"selected=\"selected\"":"" %>>
                    <%=i%></option>
                <%} %>
            </select>
            <select id="Edu_ToMonth" name="Edu_ToMonth">
                <option selected="selected" value="0">月</option>
                <%for( int i = 1; i <= 12; i++ )
                  { %>
                <option value="<%=i%>" <%=bean.fdEducEnd.Year!=1900&&bean.fdEducEnd.Month==i?"selected=\"selected\"":"" %>>
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
                maxlength="50" value="<%=bean.fdEducSchool %>" />
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
            <a href="javascript:void(0);" id="place" class="btn28H" style="font-size: 12px;" onclick="ChooseMajor(this, 'major', 'Edu_SpecialityID', 'Edu_Speciality', '选择/修改')">
                <%=bean.fdEducSpecialityID==0?"选择/修改":bean.fdEducSpeciality%></a>
            <input type="text" id="Edu_OtherSpeciality" name="Edu_OtherSpeciality" class="pwdinput"
                value="<%=bean.fdEducOtherSpecialty==""?"若无合适项，请在此填写":bean.fdEducOtherSpecialty %>"
                <%=bean.fdEducOtherSpecialty==""?"style=\"color: #999;\"":"" %> maxlength="20"
                onclick="if('若无合适项，请在此填写'==this.value){this.value='';this.style.color='#000';}"
                onblur="if(this.value==''){this.value = '若无合适项，请在此填写';this.style.color='#999';}" />
            <input type="hidden" id="Edu_SpecialityID" name="Edu_SpecialityID" value="<%=bean.fdEducSpecialityID %>" />
            <input type="hidden" id="Edu_Speciality" name="Edu_Speciality" value="<%=bean.fdEducSpeciality %>" />
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
                <option value="0" <%=bean.fdEducDegree==0?"selected=\"selected\"":"" %>>请选择学历</option>
                <option value="1" <%=bean.fdEducDegree==1?"selected=\"selected\"":"" %>>初中</option>
                <option value="2" <%=bean.fdEducDegree==2?"selected=\"selected\"":"" %>>高中</option>
                <option value="3" <%=bean.fdEducDegree==3?"selected=\"selected\"":"" %>>中技</option>
                <option value="4" <%=bean.fdEducDegree==4?"selected=\"selected\"":"" %>>中专</option>
                <option value="5" <%=bean.fdEducDegree==5?"selected=\"selected\"":"" %>>大专</option>
                <option value="6" <%=bean.fdEducDegree==6?"selected=\"selected\"":"" %>>本科</option>
                <option value="7" <%=bean.fdEducDegree==7?"selected=\"selected\"":"" %>>MBA</option>
                <option value="8" <%=bean.fdEducDegree==8?"selected=\"selected\"":"" %>>硕士</option>
                <option value="9" <%=bean.fdEducDegree==9?"selected=\"selected\"":"" %>>博士</option>
                <option value="10" <%=bean.fdEducDegree==10?"selected=\"selected\"":"" %>>其他</option>
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
                        <textarea id="Edu_Intro" name="Edu_Intro" class="txtArea" onkeyup="str_limit('edu_<%=bean.fdEducID %>',this.value,'Edu_IntroLength')"
                            onchange="str_limit('edu_<%=bean.fdEducID %>',this.value,'Edu_IntroLength')"><%=bean.fdEducIntro %></textarea>
                    </td>
                </tr>
                <tr style="color: #999;">
                    <td width="286">
                        填写您所学专业包括什么课程，您的毕业设计等等
                    </td>
                    <td align="right" width="209">
                        限2000个中文字，已输入<span class="orange" id="Edu_IntroLength"><%=bean.fdEducIntro.Length %></span>个字
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
            <input type="radio" name="forlen" value="0" <%=bean.fdEducIsOverSeas==0?"checked=\"checked\"":"" %> />是
            <input type="radio" name="forlen" value="1" <%=bean.fdEducIsOverSeas==1?"checked=\"checked\"":"" %> />否
        </td>
    </tr>
</table>
<div class="blank12px">
</div>
</form>
