<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RewardsSave.aspx.cs" Inherits="User_RewardsSave" %>

<table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <th scope="row">
            <strong class="green">奖励</strong>
        </th>
        <td>
            <span class="right">&nbsp;&nbsp;<input type="button" id="btn_rew_edit" class="btn60_28"
                value="修 改" onclick="editinfo('rew',<%=bean.fdRewaID %>,'btn_rew_edit','rew_<%=bean.fdRewaID %>')" /></span>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;时&nbsp;&nbsp;&nbsp;&nbsp;间
        </th>
        <td>
            <%=bean.fdRewaBegin.ToString( "yyyy年M月" )%>
            到
            <%if( bean.fdRewaEnd.Year != 1900 )
              {%>
            <%=bean.fdRewaEnd.ToString( "yyyy年M月" )%>
            <%}
              else
              { %>
            至今
            <%} %>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;奖&nbsp;&nbsp;&nbsp;&nbsp;项
        </th>
        <td>
            <%=bean.fdRewaName %>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;级&nbsp;&nbsp;&nbsp;&nbsp;别
        </th>
        <td>
            <%=bean.fdRewaLevel %>
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;简历显示
        </th>
        <td>
            <%=bean.fdRewaIsShow==0?"是":"否" %>
        </td>
    </tr>
</table>
<div class="blank12px">
</div>
