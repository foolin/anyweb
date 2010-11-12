<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PositionSave.aspx.cs" Inherits="User_PositionSave" %>

<table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <th scope="row">
            <strong class="green">职务</strong>
        </th>
        <td>
            <span class="right">&nbsp;&nbsp;<input type="button" id="btn_pos_edit" class="btn60_28"
                value="修 改" onclick="editinfo('pos',<%=bean.fdPosiID %>,'btn_pos_edit','pos_<%=bean.fdPosiID %>')" /></span>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;时&nbsp;&nbsp;&nbsp;&nbsp;间
        </th>
        <td>
            <%=bean.fdPosiBegin.ToString( "yyyy年M月" )%>
            到
            <%if( bean.fdPosiEnd.Year != 1900 )
              {%>
            <%=bean.fdPosiEnd.ToString( "yyyy年M月" )%>
            <%}
              else
              { %>
            至今
            <%} %>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;职务名称
        </th>
        <td>
            <%=bean.fdPosiName %>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;单位名称
        </th>
        <td>
            <%=bean.fdPosiOrg %>
        </td>
    </tr>
    <tr>
        <th scope="row" valign="top">
            &nbsp;职务描述
        </th>
        <td>
            <%=bean.fdPosiIntro %>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;简历显示
        </th>
        <td>
            <%=bean.fdPosiIsShow==0?"是":"否" %>
        </td>
    </tr>
</table>
<div class="blank12px">
</div>
