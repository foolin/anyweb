<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RewardsEdit.aspx.cs" Inherits="User_RewardsEdit" %>

<form action="/User/RewardsSave.aspx?rewid=<%=bean.fdRewaID %>&type=edit" id="rew_form_<%=bean.fdRewaID %>"
method="post">
<table class="tableInfo" width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <th scope="row">
        </th>
        <td>
            <span class="tipW red hidden" id="errorMsg_Date_1">请选择时间！</span> <span class="tipW red hidden"
                id="errorMsg_Date_2">结束时间不能小于起始时间！</span>
        </td>
    </tr>
    <tr>
        <th scope="row">
            <span class="orange">*</span>时&nbsp;&nbsp;&nbsp;&nbsp;间
        </th>
        <td>
            <span class="right">
                <input type="button" id="btn_rew_del" class="btn60_28_gray" value="删 除" onclick="delinfo('rew',<%=bean.fdRewaID %>,'btn_rew_del','rew_<%=bean.fdRewaID %>')" />
                &nbsp;&nbsp;<input type="button" id="btn_rew_save" class="btn60_28" value="保 存" onclick="rew_save('rew_form_<%=bean.fdRewaID %>')" /></span>
            <select id="Rew_FromYear" name="Rew_FromYear">
                <option selected="selected" value="0">年</option>
                <%for( int i = DateTime.Now.Year; i >= 1940; i-- )
                  { %>
                <option value="<%=i%>" <%=bean.fdRewaBegin.Year==i?"selected=\"selected\"":"" %>>
                    <%=i%></option>
                <%} %>
            </select>
            <select id="Rew_FromMonth" name="Rew_FromMonth">
                <option selected="selected" value="0">月</option>
                <%for( int i = 1; i <= 12; i++ )
                  { %>
                <option value="<%=i%>" <%=bean.fdRewaBegin.Month==i?"selected=\"selected\"":"" %>>
                    <%=i%></option>
                <%} %>
            </select>
            到
            <select id="Rew_ToYear" name="Rew_ToYear">
                <option selected="selected" value="0">年</option>
                <%for( int i = DateTime.Now.Year; i >= 1940; i-- )
                  { %>
                <option value="<%=i%>" <%=bean.fdRewaEnd.Year!=1900&&bean.fdRewaEnd.Year==i?"selected=\"selected\"":"" %>>
                    <%=i%></option>
                <%} %>
            </select>
            <select id="Rew_ToMonth" name="Rew_ToMonth">
                <option selected="selected" value="0">月</option>
                <%for( int i = 1; i <= 12; i++ )
                  { %>
                <option value="<%=i%>" <%=bean.fdRewaEnd.Year!=1900&&bean.fdRewaEnd.Month==i?"selected=\"selected\"":"" %>>
                    <%=i%></option>
                <%} %>
            </select>
            <span class="lgray">(后两项不填表示至今)</span>
        </td>
    </tr>
    <tr>
        <th scope="row">
        </th>
        <td>
            <span class="tipW red hidden" id="errorMsg_Name">奖项不能为空！</span>
        </td>
    </tr>
    <tr>
        <th scope="row">
            <span class="orange">*</span>奖&nbsp;&nbsp;&nbsp;&nbsp;项
        </th>
        <td>
            <input type="text" id="Rew_Name" name="Rew_Name" class="pwdinput" style="width: 296px;"
                maxlength="50" value="<%=bean.fdRewaName %>" />
        </td>
    </tr>
    <tr>
        <th scope="row">
            &nbsp;级&nbsp;&nbsp;&nbsp;&nbsp;别
        </th>
        <td>
            <input type="text" id="Rew_Level" name="Rew_Level" class="pwdinput" style="width: 296px;"
                maxlength="50" value="<%=bean.fdRewaLevel %>" />
        </td>
    </tr>
    <tr>
        <th scope="row">
        </th>
        <td>
            <input type="checkbox" <%=bean.fdRewaIsShow==0?"checked=\"checked\"":"" %> id="Rew_IsShow"
                name="Rew_IsShow" value="0" />
            <label for="Rew_IsShow">
                <span class="lgray">将此奖项显示在我的简历中 </span>
            </label>
        </td>
    </tr>
</table>
<div class="blank12px">
</div>
</form>
