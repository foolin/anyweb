<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AwarEdit.aspx.cs" Inherits="User_AwarEdit" %>

<form action="/User/AwarSave.aspx?awarid=<%=bean.fdAwarID %>&type=edit"
id="awar_form_<%=bean.fdAwarID %>" method="post">
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
                <input type="button" id="btn_awar_del" class="btn60_28_gray" value="删 除" onclick="delinfo('awar',<%=bean.fdAwarID %>,'btn_awar_del','awar_<%=bean.fdAwarID %>')" />
                &nbsp;&nbsp;<input type="button" id="btn_awar_save" class="btn60_28" value="保 存"
                    onclick="awar_save('awar_form_<%=bean.fdAwarID %>')" /></span>
            <select id="Awar_Year" name="Awar_Year">
                <option selected="selected" value="0">年</option>
                <%for( int i = DateTime.Now.Year; i >= 1940; i-- )
                  { %>
                <option value="<%=i%>" <%=bean.fdAwarDate.Year==i?"selected=\"selected\"":"" %>>
                    <%=i%></option>
                <%} %>
            </select>
            <select id="Awar_Month" name="Awar_Month">
                <option selected="selected" value="0">月</option>
                <%for( int i = 1; i <= 12; i++ )
                  { %>
                <option value="<%=i%>" <%=bean.fdAwarDate.Month==i?"selected=\"selected\"":"" %>>
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
            <input type="text" id="Awar_Name" name="Awar_Name" class="pwdinput" style="width: 476px;"
                maxlength="50" value="<%=bean.fdAwarName %>" />
        </td>
    </tr>
</table>
<div class="blank6px">
</div>
</form>
