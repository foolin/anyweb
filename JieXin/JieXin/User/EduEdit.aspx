<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EduEdit.aspx.cs" Inherits="User_EduEdit" %>

<div id="Edu_<%=bean.fdEducID %>">
    <form action="/User/EduSave.aspx?eduid=<%=bean.fdEducID %>&type=edit" id="Edu_form_<%=bean.fdEducID %>"
    method="post">
    <table>
        <tbody>
            <tr>
                <td>
                </td>
                <td>
                    <span style="display: none;" id="errorMsg_2_1">
                        <img height="15" width="16" src="http://img01.51jobcdn.com/im/2009/my/folder/icon_error.gif"
                            alt="" />&nbsp;&nbsp;请选择时间!</span><span style="display: none;" id="errorMsg_2_2"><img
                                height="15" width="16" src="http://img01.51jobcdn.com/im/2009/my/folder/icon_error.gif"
                                alt="" />&nbsp;&nbsp;结束时间不能小于起始时间!</span>
                </td>
            </tr>
            <tr>
                <td>
                    <span>* </span>时间
                </td>
                <td>
                    <select id="FromYear" name="FromYear">
                        <option value="0">年</option>
                        <%for (int i = DateTime.Now.Year; i >= 1940; i--)
                          { %>
                        <option value="<%=i%>" <%=bean.fdEducBegin.Year==i?"selected=\"selected\"":"" %>>
                            <%=i%></option>
                        <%} %>
                    </select>
                    <select id="FromMonth" name="FromMonth">
                        <option selected="selected" value="0">月</option>
                        <%for (int i = 1; i <= 12; i++)
                          { %>
                        <option value="<%=i%>" <%=bean.fdEducBegin.Month==i?"selected=\"selected\"":"" %>>
                            <%=i%></option>
                        <%} %>
                    </select>
                    到
                    <select id="ToYear" name="ToYear">
                        <option value="0">年</option>
                        <%for (int i = DateTime.Now.Year + 5; i >= 1940; i--)
                          { %>
                        <option value="<%=i%>" <%=bean.fdEducEnd.Year==2099?"":bean.fdEducEnd.Year==i?"selected=\"selected\"":"" %>>
                            <%=i%></option>
                        <%} %>
                    </select>
                    <select id="ToMonth" name="ToMonth">
                        <option value="0">月</option>
                        <%for (int i = 1; i <= 12; i++)
                          { %>
                        <option value="<%=i%>" <%=bean.fdEducEnd.Year==2099?"":bean.fdEducEnd.Month==i?"selected=\"selected\"":"" %>>
                            <%=i%></option>
                        <%} %>
                    </select>
                    (后两项不填表示至今)
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <span style="display: none;" id="errorMsg_2_3">
                        <img height="15" width="16" src="http://img01.51jobcdn.com/im/2009/my/folder/icon_error.gif"
                            alt="" />&nbsp;&nbsp;请输入学校名称（限50个汉字）</span>
                </td>
            </tr>
            <tr>
                <td>
                    <span>*</span> 学校
                </td>
                <td>
                    <input type="text" maxlength="100" value="<%=bean.fdEducSchool %>" id="SchoolName"
                        style="width: 353px;" name="SchoolName" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <span style="display: none;" id="errorMsg_2_4">
                        <img height="15" width="16" src="http://img01.51jobcdn.com/im/2009/my/folder/icon_error.gif"
                            alt="" />&nbsp;&nbsp;请选择或者手动填写专业名称（限50个汉字）</span>
                </td>
            </tr>
            <tr>
                <td>
                    <span>* </span>专业
                </td>
                <td>
                    <input type="button" style="cursor: pointer;" value="选择/修改" id="btnSubMajor" /><input
                        type="hidden" value="<%=bean.fdEducSpeciality %>" id="SubMajor" name="SubMajor" />&nbsp;&nbsp;<input
                            type="text" maxlength="100" value="<%=bean.fdEducSpeciality==0?bean.fdEducOtherSpecialty:"若无合适选项请在此处填写" %>"
                            id="MoreMajor" name="MoreMajor" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <span style="display: none;" id="errorMsg_2_5">
                        <img height="15" width="16" src="http://img01.51jobcdn.com/im/2009/my/folder/icon_error.gif"
                            alt="" />&nbsp;&nbsp;请选择学历！</span>
                </td>
            </tr>
            <tr>
                <td>
                    <span>* </span>学历
                </td>
                <td>
                    <select id="Degree" name="Degree">
                        <option value="">请选择 </option>
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
                <td>
                    专业描述
                </td>
                <td>
                    <textarea id="EduDetail" cols="10" rows="6" name="EduDetail"><%=bean.fdEducIntro %></textarea><br />
                    <span>填写您所学专业包括什么课程，您的毕业设计等等</span>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <img style="cursor: pointer;" onclick="Edu_save('Edu_form_<%=bean.fdEducID %>');"
                        src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_save1.gif" alt="" />
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</div>
