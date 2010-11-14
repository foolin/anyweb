<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SkillSave.aspx.cs" Inherits="User_SkillSave" %>

<table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <th scope="row">
            &nbsp;名&nbsp;&nbsp;&nbsp;&nbsp;称
        </th>
        <td width="218">
            <%=bean.fdSkilName %>
        </td>
        <th scope="row">
            &nbsp;使用时间
        </th>
        <td>
            <span class="right">&nbsp;&nbsp;<input type="button" id="btn_skill_edit" class="btn60_28"
                value="修 改" onclick="editinfo('skill',<%=bean.fdSkilID %>,'btn_skill_edit','skill_<%=bean.fdSkilID %>')" /></span>
            <%=bean.fdSkilMonth %>月
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;掌握程度
        </th>
        <td>
            <%=getSkillLevelString(bean.fdSkilLevel)%>
        </td>
        <th scope="row">
        </th>
        <td>
        </td>
    </tr>
</table>
<div class="blank6px">
</div>
