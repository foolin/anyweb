<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SkillGet.aspx.cs" Inherits="User_SkillGet" %>

<div id="skill_<%=skillID %>">
    <form action="/User/SkillSave.aspx?id=<%=QS("id") %>&skillid=<%=skillID %>&type=add"
    id="skill_form_<%=skillID %>" method="post">
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
                <input type="text" id="Skill_Name" name="Skill_Name" class="pwdinput" maxlength="50" />
            </td>
            <th scope="row">
                <span class="orange">*</span>使用时间
            </th>
            <td>
                <span class="right">
                    <input type="button" id="btn_skill_del" class="btn60_28_gray" value="删 除" onclick="delinfo('skill',<%=skillID %>,'btn_skill_del','skill_<%=skillID %>')" />
                    &nbsp;&nbsp;<input type="button" id="btn_skill_save" class="btn60_28" value="保 存"
                        onclick="skill_save('skill_form_<%=skillID %>')" /></span>
                <input type="text" id="Skill_Month" name="Skill_Month" class="pwdinput" style="width: 40px"
                    maxlength="3" />月
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
                    <option value="0" selected="selected">请选择掌握程度</option>
                    <option value="1">精通</option>
                    <option value="2">熟练</option>
                    <option value="3">一般</option>
                    <option value="4">了解</option>
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
</div>
