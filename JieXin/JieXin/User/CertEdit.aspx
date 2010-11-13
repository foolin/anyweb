﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CertEdit.aspx.cs" Inherits="User_CertEdit" %>

<form action="/User/CertSave.aspx?id=<%=QS("id") %>&certid=<%=bean.fdCertID %>&type=edit"
id="cert_form_<%=bean.fdCertID %>" method="post">
<table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <th scope="row">
        </th>
        <td>
            <span class="tipW red hidden" id="errorMsg_Date">请选择时间！</span>
        </td>
    </tr>
    <tr>
        <th scope="row">
            <span class="orange">*</span>获得时间
        </th>
        <td>
            <span class="right">
                <input type="button" id="btn_cert_del" class="btn60_28_gray" value="删 除" onclick="delinfo('cert',<%=bean.fdCertID %>,'btn_cert_del','cert_<%=bean.fdCertID %>')" />
                &nbsp;&nbsp;<input type="button" id="btn_cert_save" class="btn60_28" value="保 存"
                    onclick="cert_save('cert_form_<%=bean.fdCertID %>')" /></span>
            <select id="Cert_Year" name="Cert_Year">
                <option selected="selected" value="0">年</option>
                <%for( int i = DateTime.Now.Year; i >= 1940; i-- )
                  { %>
                <option value="<%=i%>" <%=bean.fdCertDate.Year==i?"selected=\"selected\"":"" %>>
                    <%=i%></option>
                <%} %>
            </select>
            <select id="Cert_Month" name="Cert_Month">
                <option selected="selected" value="0">月</option>
                <%for( int i = 1; i <= 12; i++ )
                  { %>
                <option value="<%=i%>" <%=bean.fdCertDate.Month==i?"selected=\"selected\"":"" %>>
                    <%=i%></option>
                <%} %>
            </select>
        </td>
    </tr>
    <tr>
        <th scope="row">
        </th>
        <td>
            <span class="tipW red hidden" id="errorMsg_Name">名称不能为空！</span>
        </td>
    </tr>
    <tr>
        <th scope="row">
            <span class="orange">*</span>名&nbsp;&nbsp;&nbsp;&nbsp;称
        </th>
        <td>
            <input type="text" id="Cert_Name" name="Cert_Name" class="pwdinput" style="width: 476px;"
                maxlength="50" value="<%=bean.fdCertName %>" />
        </td>
    </tr>
    <tr>
        <th scope="row">
        </th>
        <td>
            <span class="tipW red hidden" id="errorMsg_Scores">请正确输入分数！</span>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;成&nbsp;&nbsp;&nbsp;&nbsp;绩
        </th>
        <td>
            <input type="text" id="Cert_Scores" name="Cert_Scores" class="pwdinput" style="width: 476px;"
                maxlength="3" value="<%=bean.fdCertScore==0?"":bean.fdCertScore.ToString() %>" />
        </td>
    </tr>
</table>
<div class="blank6px">
</div>
</form>
