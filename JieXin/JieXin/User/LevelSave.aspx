<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LevelSave.aspx.cs" Inherits="User_LevelSave" %>

<table width="100%" class="tableInfo_1" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <th scope="row" style="width: 76px;">
            &nbsp;英语等级
        </th>
        <td width="140">
            <%=getEnLevelString( resume.fdResuEnLevel )%>
        </td>
        <th scope="row" style="width: 50px;">
            TOEFL
        </th>
        <td width="130">
            <%=resume.fdResuTOEFL==0?"":resume.fdResuTOEFL.ToString() %>
        </td>
        <th scope="row">
            GRE
        </th>
        <td>
            <%=resume.fdResuGRE==0?"":resume.fdResuGRE.ToString() %>
        </td>
        <td>
            <span class="right">
                <input type="button" id="btn_level_save" class="btn60_28" value="修 改" onclick="editinfo('level',<%=resume.fdResuID %>,'btn_level_save','level')" /></span>
        </td>
    </tr>
    <tr>
        <th scope="row" style="width: 76px;">
            &nbsp;日语等级
        </th>
        <td width="140">
            <%=getJpLevelString(resume.fdResuJpLevel) %>
        </td>
        <th scope="row" style="width: 50px;">
            GMAT
        </th>
        <td width="130">
            <%=resume.fdResuGMAT==0?"":resume.fdResuGMAT.ToString() %>
        </td>
        <th scope="row">
            IELTS
        </th>
        <td>
            <%=resume.fdResuIELTS==0?"":resume.fdResuIELTS.ToString() %>
        </td>
        <td>
        </td>
    </tr>
</table>
<div class="blank6px">
</div>
