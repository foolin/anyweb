<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SkillEdit.aspx.cs" Inherits="User_SkillEdit" %>

<form action="/User/SkillSave.aspx?skillid=<%=bean.fdSkilID %>&type=edit"
id="skill_form_<%=bean.fdSkilID %>" method="post">
<table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <th scope="row">
        </th>
        <td>
            <span class="tipW red hidden" id="errorMsg_Name">名称不能为空！</span>
        </td>
        <th scope="row">
        </th>
        <td>
            <span class="tipW red hidden" id="errorMsg_Month_1">使用时间不能为空！</span> <span class="tipW red hidden"
                id="errorMsg_Month_2">请正确输入数字！</span>
        </td>
    </tr>
    <tr>
        <th scope="row">
            <span class="orange">*</span>名&nbsp;&nbsp;&nbsp;&nbsp;称
        </th>
        <td width="218">
            <input type="text" id="Skill_Name" name="Skill_Name" class="pwdinput" maxlength="50" value="<%=bean.fdSkilName %>" />
        </td>
        <th scope="row">
            <span class="orange">*</span>使用时间
        </th>
        <td>
            <span class="right">
                <input type="button" id="btn_skill_del" class="btn60_28_gray" value="删 除" onclick="delinfo('skill',<%=bean.fdSkilID %>,'btn_skill_del','skill_<%=bean.fdSkilID %>')" />
                &nbsp;&nbsp;<input type="button" id="btn_skill_save" class="btn60_28" value="保 存"
                    onclick="skill_save('skill_form_<%=bean.fdSkilID %>')" /></span>
            <input type="text" id="Skill_Month" name="Skill_Month" class="pwdinput" style="width: 40px"
                maxlength="3" value="<%=bean.fdSkilMonth %>" />月
        </td>
    </tr>
    <tr>
        <th scope="row">
        </th>
        <td>
            <span class="tipW red hidden" id="errorMsg_Level">请选择掌握程度！</span>
        </td>
        <th scope="row">
        </th>
        <td>
        </td>
    </tr>
    <tr>
        <th scope="row">
            <span class="orange">*</span>掌握程度
        </th>
        <td>
            <select id="Skill_Level" name="Skill_Level">
                <option value="0"  <%=bean.fdSkilLevel==0?"selected=\"selected\"":"" %>>请选择掌握程度</option>
                <option value="1" <%=bean.fdSkilLevel==1?"selected=\"selected\"":"" %>>精通</option>
                <option value="2" <%=bean.fdSkilLevel==2?"selected=\"selected\"":"" %>>熟练</option>
                <option value="3" <%=bean.fdSkilLevel==3?"selected=\"selected\"":"" %>>一般</option>
                <option value="4" <%=bean.fdSkilLevel==4?"selected=\"selected\"":"" %>>了解</option>
            </select>
        </td>
        <th scope="row">
        </th>
        <td>
        </td>
    </tr>
</table>
<div class="blank6px">
</div>
</form>
