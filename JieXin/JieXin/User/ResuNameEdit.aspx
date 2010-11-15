<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResuNameEdit.aspx.cs" Inherits="User_ResuNameEdit" %>

<form action="/User/ResuNameSave.aspx?id=<%=QS("id") %>" id="resume_form" method="post">
<table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <th scope="row">
        </th>
        <td>
            <span class="tipW red hidden" id="errorMsg_Name">简历名称不能为空！</span>
        </td>
    </tr>
    <tr>
        <th scope="row">
            <span class="orange">*</span>简历名称
        </th>
        <td width="218">
            <input id="Resu_Name" name="Resu_Name" class="pwdinput" maxlength="30" type="text"
                value="<%=bean.fdResuName %>" />
        </td>
        <td>
            <span class="right">&nbsp;&nbsp;<input id="btn_resu_save" class="btn60_28" value="保 存"
                onclick="resu_save('resume_form')" type="button"></span>
        </td>
    </tr>
</table>
<div class="blank12px">
</div>
</form>
