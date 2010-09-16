<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EduGet.aspx.cs" Inherits="User_EduGet" %>

<div id="Edu_<%=EduID %>">
    <form action="/User/EduAdd.aspx?id=<%=QS("id") %>&eduid=<%=EduID %>&type=add" id="Edu_form_<%=EduID %>"
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
                        <option selected="selected" value="0">年</option>
                        <%for (int i = DateTime.Now.Year; i >= 1940; i--)
                          { %>
                        <option value="<%=i%>">
                            <%=i%></option>
                        <%} %>
                    </select>
                    <select id="FromMonth" name="FromMonth">
                        <option selected="selected" value="0">月</option>
                        <%for (int i = 1; i <= 12; i++)
                          { %>
                        <option value="<%=i%>">
                            <%=i%></option>
                        <%} %>
                    </select>
                    到
                    <select id="ToYear" name="ToYear">
                        <option selected="selected" value="0">年</option>
                        <%for (int i = DateTime.Now.Year + 5; i >= 1940; i--)
                          { %>
                        <option value="<%=i%>">
                            <%=i%></option>
                        <%} %>
                    </select>
                    <select id="ToMonth" name="ToMonth">
                        <option selected="selected" value="0">月</option>
                        <%for (int i = 1; i <= 12; i++)
                          { %>
                        <option value="<%=i%>">
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
                    <input type="text" maxlength="100" value="" id="SchoolName" style="width: 353px;"
                        name="SchoolName" />
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
                        type="hidden" value="" id="SubMajor" name="SubMajor" />&nbsp;&nbsp;<input type="text"
                            maxlength="100" value="若无合适选项请在此处填写" id="MoreMajor" name="MoreMajor" />
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
                <td>
                    专业描述
                </td>
                <td>
                    <textarea id="EduDetail" cols="10" rows="6" name="EduDetail"></textarea><br />
                    <span>填写您所学专业包括什么课程，您的毕业设计等等</span>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <img style="cursor: pointer;" onclick="Edu_save('Edu_form_add_<%=EduID %>');" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_save1.gif"
                        alt="" />
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</div>
