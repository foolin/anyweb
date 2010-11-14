<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AwarSave.aspx.cs" Inherits="User_AwarSave" %>

<table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <th scope="row">
            &nbsp;获得时间
        </th>
        <td>
            <span class="right">&nbsp;&nbsp;<input type="button" id="btn_awar_edit" class="btn60_28"
                value="修 改" onclick="editinfo('awar',<%=bean.fdAwarID %>,'btn_awar_edit','awar_<%=bean.fdAwarID %>')" /></span>
            <%=bean.fdAwarDate.Year!=1900?bean.fdAwarDate.ToString("yyyy年MM月"):"" %>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;名&nbsp;&nbsp;&nbsp;&nbsp;称
        </th>
        <td>
            <%=bean.fdAwarName %>
        </td>
    </tr>
</table>
<div class="blank6px">
</div>
