<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EduSave.aspx.cs" Inherits="User_EduSave" %>
<table>
    <tbody>
        <tr>
            <td>
                时间
            </td>
            <td>
                <%=bean.fdEducBegin.ToString("yyyy年M月") %>
                到
                <%if (bean.fdEducEnd.Year != 2099)
                  {%>
                <%=bean.fdEducEnd.ToString("yyyy年M月")%>
                <%}
                  else
                  { %>
                至今
                <%} %>
            </td>
        </tr>
        <tr>
            <td>
                学校
            </td>
            <td>
                <%=bean.fdEducSchool %>
            </td>
        </tr>
        <tr>
            <td>
                专业
            </td>
            <td>
                <%if (bean.fdEducSpeciality == 0)
                  {%>
                <%=bean.fdEducOtherSpecialty%>
                <%} %>
            </td>
        </tr>
        <tr>
            <td>
                学历
            </td>
            <td>
                <%=getDegreeStr(bean.fdEducDegree)%>
            </td>
        </tr>
        <tr>
            <td>
                专业描述
            </td>
            <td>
                <%=bean.fdEducIntro %>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <img style="cursor: pointer;" onclick="Edu_edit('Edu_form_<%=bean.fdEducID %>');"
                    src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_modify.gif" alt="" />
            </td>
        </tr>
    </tbody>
</table>
