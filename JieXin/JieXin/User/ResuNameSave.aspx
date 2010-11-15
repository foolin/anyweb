<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResuNameSave.aspx.cs" Inherits="User_ResuNameSave" %>

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
