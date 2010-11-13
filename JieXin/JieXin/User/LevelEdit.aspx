<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LevelEdit.aspx.cs" Inherits="User_LevelEdit" %>

<form action="/User/LevelSave.aspx?id=<%=QS("id") %>" id="level_form" method="post">
<table width="100%" class="tableInfo_1" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <th scope="row">
        </th>
        <td>
            <span class="tipW red hidden" id="errorMsg_EnLevel">请选择英语等级！</span>
        </td>
        <th scope="row">
        </th>
        <td>
            <span class="tipW red hidden" id="errorMsg_TOEFL">请正确输入分数！</span>
        </td>
        <th scope="row">
        </th>
        <td>
            <span class="tipW red hidden" id="errorMsg_GRE">请正确输入分数！</span>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <th scope="row" style="width: 76px;">
            <span class="orange">*</span>英语等级
        </th>
        <td width="140">
            <select id="Level_EnLevel" name="Level_EnLevel">
                <option value="0" <%=bean.fdResuEnLevel==0?"selected=\"selected\"":"" %>>请选择级别</option>
                <option value="1" <%=bean.fdResuEnLevel==1?"selected=\"selected\"":"" %>>未参加</option>
                <option value="2" <%=bean.fdResuEnLevel==2?"selected=\"selected\"":"" %>>未通过</option>
                <option value="3" <%=bean.fdResuEnLevel==3?"selected=\"selected\"":"" %>>英语四级</option>
                <option value="4" <%=bean.fdResuEnLevel==4?"selected=\"selected\"":"" %>>英语六级</option>
                <option value="5" <%=bean.fdResuEnLevel==5?"selected=\"selected\"":"" %>>专业四级</option>
                <option value="6" <%=bean.fdResuEnLevel==6?"selected=\"selected\"":"" %>>专业八级</option>
            </select>
        </td>
        <th scope="row" style="width: 50px;">
            TOEFL
        </th>
        <td width="130">
            <input type="text" id="Level_TOEFL" name="Level_TOEFL" class="pwdinput" style="width: 100px;"
                maxlength="3" value="<%=bean.fdResuTOEFL==0?"":bean.fdResuTOEFL.ToString() %>" />
        </td>
        <th scope="row">
            GRE
        </th>
        <td>
            <input type="text" id="Level_GRE" name="Level_GRE" class="pwdinput" style="width: 100px;"
                maxlength="3" value="<%=bean.fdResuGRE==0?"":bean.fdResuGRE.ToString() %>" />
        </td>
        <td>
            <span class="right">
                <input type="button" id="btn_level_save" class="btn60_28" value="保 存" onclick="level_save('level_form')" /></span>
        </td>
    </tr>
    <tr>
        <th scope="row">
        </th>
        <td>
        </td>
        <th scope="row">
        </th>
        <td>
            <span class="tipW red hidden" id="errorMsg_GMAT">请正确输入分数！</span>
        </td>
        <th scope="row">
        </th>
        <td>
            <span class="tipW red hidden" id="errorMsg_IELTS">请正确输入分数！</span>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <th scope="row" style="width: 76px;">
            &nbsp;日语等级
        </th>
        <td width="140">
            <select id="Level_JpLevel" name="Level_JpLevel">
                <option value="0" <%=bean.fdResuJpLevel==0?"selected=\"selected\"":"" %>>请选择级别</option>
                <option value="1" <%=bean.fdResuJpLevel==1?"selected=\"selected\"":"" %>>无</option>
                <option value="2" <%=bean.fdResuJpLevel==2?"selected=\"selected\"":"" %>>一级</option>
                <option value="3" <%=bean.fdResuJpLevel==3?"selected=\"selected\"":"" %>>二级</option>
                <option value="4" <%=bean.fdResuJpLevel==4?"selected=\"selected\"":"" %>>三级</option>
                <option value="5" <%=bean.fdResuJpLevel==5?"selected=\"selected\"":"" %>>四级</option>
            </select>
        </td>
        <th scope="row" style="width: 50px;">
            GMAT
        </th>
        <td width="130">
            <input type="text" id="Level_GMAT" name="Level_GMAT" class="pwdinput" style="width: 100px;"
                maxlength="3" value="<%=bean.fdResuGMAT==0?"":bean.fdResuGMAT.ToString() %>" />
        </td>
        <th scope="row">
            IELTS
        </th>
        <td>
            <input type="text" id="Level_IELTS" name="Level_IELTS" class="pwdinput" style="width: 100px;"
                maxlength="3" value="<%=bean.fdResuIELTS==0?"":bean.fdResuIELTS.ToString() %>" />
        </td>
        <td>
        </td>
    </tr>
</table>
<div class="blank6px">
</div>
</form>
