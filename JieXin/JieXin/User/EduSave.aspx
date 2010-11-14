<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EduSave.aspx.cs" Inherits="User_EduSave" %>

<table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <th scope="row">
            &nbsp;时&nbsp;&nbsp;&nbsp;&nbsp;间
        </th>
        <td>
            <span class="right">&nbsp;&nbsp;<input type="button" id="btn_edu_save" class="btn60_28" value="修 改"
                onclick="editinfo('edu',<%=bean.fdEducID %>,'btn_edu_save','edu_<%=bean.fdEducID %>')" /></span>
            <%=bean.fdEducBegin.ToString("yyyy年M月") %>
            到
            <%if( bean.fdEducEnd.Year != 1900 )
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
        <th scope="row">
            &nbsp;学&nbsp;&nbsp;&nbsp;&nbsp;校
        </th>
        <td>
            <%=bean.fdEducSchool %>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;专&nbsp;&nbsp;&nbsp;&nbsp;业
        </th>
        <td>
            <%if( bean.fdEducSpecialityID == 0 )
              {%>
            <%=bean.fdEducOtherSpecialty%>
            <%}
              else
              { %>
            <%=bean.fdEducSpeciality%>
            <%} %>
        </td>
    </tr>
    <tr>
        <th scope="row">
            <span class="orange">*</span>学&nbsp;&nbsp;&nbsp;&nbsp;历
        </th>
        <td>
            <%=getDegreeString(bean.fdEducDegree)%>
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
                        <%=bean.fdEducIntro %>
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
            <%=bean.fdEducIsOverSeas==0?"是":"否" %>
        </td>
    </tr>
</table>
<div class="blank12px">
</div>
