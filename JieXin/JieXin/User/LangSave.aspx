<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LangSave.aspx.cs" Inherits="User_LangSave" %>

<table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <th scope="row">
            &nbsp;语言类别
        </th>
        <td>
            <%=getLangTypeString(bean.fdLangType) %>
        </td>
        <th scope="row">
            &nbsp;掌握程度
        </th>
        <td>
            <span class="right">&nbsp;&nbsp;<input type="button" id="btn_lang_edit" class="btn60_28"
                value="修 改" onclick="editinfo('lang',<%=bean.fdLangID %>,'btn_lang_edit','lang_<%=bean.fdLangID %>')" /></span>
            <%=getLangAbilityString(bean.fdLangMaster) %>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;读写能力
        </th>
        <td>
            <%=getLangAbilityString(bean.fdLangRWAbility)%>
        </td>
        <th scope="row">
            &nbsp;听说能力
        </th>
        <td>
            <%=getLangAbilityString(bean.fdLangLiAbility)%>
        </td>
    </tr>
</table>
<div class="blank6px">
</div>
