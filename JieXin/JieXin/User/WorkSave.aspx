<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkSave.aspx.cs" Inherits="User_WorkSave" %>

<table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <th scope="row">
            &nbsp;时&nbsp;&nbsp;&nbsp;&nbsp;间
        </th>
        <td colspan="3">
            <span class="right">&nbsp;&nbsp;<input type="button" id="btn_work_save" class="btn60_28"
                value="修 改" onclick="editinfo('work',<%=bean.fdWorkID %>,'btn_work_save','work_<%=bean.fdWorkID %>')" />
            </span>
            <%=bean.fdWorkBegin.ToString( "yyyy年M月" )%>
            到
            <%if( bean.fdWorkEnd.Year != 1900 )
              {%>
            <%=bean.fdWorkEnd.ToString( "yyyy年M月" )%>
            <%}
              else
              { %>
            至今
            <%} %>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;公&nbsp;&nbsp;&nbsp;&nbsp;司
        </th>
        <td>
            <%=bean.fdWorkName %>
        </td>
        <th scope="row">
            &nbsp;行&nbsp;&nbsp;&nbsp;&nbsp;业
        </th>
        <td>
            <%=bean.fdWorkIndustry %>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;公司规模
        </th>
        <td>
            <%=getDimensionString(bean.fdWorkDimension)%>
        </td>
        <th scope="row">
            &nbsp;公司性质
        </th>
        <td>
            <%=getCompanyTypeString( bean.fdWorkType )%>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;部&nbsp;&nbsp;&nbsp;&nbsp;门
        </th>
        <td>
            <%=bean.fdWorkDepartment %>
        </td>
        <th scope="row">
            &nbsp;职&nbsp;&nbsp;&nbsp;&nbsp;位
        </th>
        <td>
            <%if( bean.fdWorkJobID == 0 )
              {%>
            <%=bean.fdWorkOtherJob%>
            <%}
              else
              { %>
            <%=bean.fdWorkJob%>
            <%} %>
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
                        <%=bean.fdWorkIntro.Replace("\n","<br />") %>
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
            <%=bean.fdWorkIsOverSeas==0?"是":"否" %>
        </td>
        <th scope="row">
        </th>
        <td>
        </td>
    </tr>
</table>
<div class="blank12px">
</div>
