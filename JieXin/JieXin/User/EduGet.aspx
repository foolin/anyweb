<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EduGet.aspx.cs" Inherits="User_EduGet" %>

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
                <a href="javascript:void(0);" id="place" class="btn28H" style="font-size: 12px;" onclick="ChooseMajor(this, 'major', 'Edu_SpecialityID', 'Edu_Speciality', '选择/修改')">选择/修改</a>
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
