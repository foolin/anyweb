<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CertSave.aspx.cs" Inherits="User_CertSave" %>

<table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <th scope="row">
            &nbsp;获得时间
        </th>
        <td>
            <span class="right">&nbsp;&nbsp;<input type="button" id="btn_cert_edit" class="btn60_28"
                value="修 改" onclick="editinfo('cert',<%=bean.fdCertID %>,'btn_cert_edit','cert_<%=bean.fdCertID %>')" /></span>
            <%=bean.fdCertDate.ToString("yyyy年MM月") %>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;名&nbsp;&nbsp;&nbsp;&nbsp;称
        </th>
        <td>
            <%=bean.fdCertName %>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;成&nbsp;&nbsp;&nbsp;&nbsp;绩
        </th>
        <td>
            <%=bean.fdCertScore==0?"":bean.fdCertScore.ToString() %>
        </td>
    </tr>
</table>
<div class="blank6px">
</div>
