<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PositionGet.aspx.cs" Inherits="User_PositionGet" %>

<div id="pos_<%=posiID %>">
    <form action="/User/PositionSave.aspx?id=<%=QS("id") %>&posid=<%=posiID %>&type=add"
    id="pos_form_<%=posiID %>" method="post">
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
                    <input type="button" id="btn_pos_del" class="btn60_28_gray" value="删 除" onclick="delinfo('pos',<%=posiID %>,'btn_pos_del','pos_<%=posiID %>')" />
                    &nbsp;&nbsp;<input type="button" id="btn_pos_save" class="btn60_28" value="保 存" onclick="pos_save('pos_form_<%=posiID %>')" /></span>
                <select id="Pos_FromYear" name="Pos_FromYear">
                    <option selected="selected" value="0">年</option>
                    <%for( int i = DateTime.Now.Year; i >= 1940; i-- )
                      { %>
                    <option value="<%=i%>">
                        <%=i%></option>
                    <%} %>
                </select>
                <select id="Pos_FromMonth" name="Pos_FromMonth">
                    <option selected="selected" value="0">月</option>
                    <%for( int i = 1; i <= 12; i++ )
                      { %>
                    <option value="<%=i%>">
                        <%=i%></option>
                    <%} %>
                </select>
                到
                <select id="Pos_ToYear" name="Pos_ToYear">
                    <option selected="selected" value="0">年</option>
                    <%for( int i = DateTime.Now.Year; i >= 1940; i-- )
                      { %>
                    <option value="<%=i%>">
                        <%=i%></option>
                    <%} %>
                </select>
                <select id="Pos_ToMonth" name="Pos_ToMonth">
                    <option selected="selected" value="0">月</option>
                    <%for( int i = 1; i <= 12; i++ )
                      { %>
                    <option value="<%=i%>">
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
                <span class="tipW red hidden" id="errorMsg_Name">职务名称不能为空！</span>
            </td>
        </tr>
        <tr>
            <th scope="row">
                <span class="orange">*</span>职务名称
            </th>
            <td>
                <input type="text" id="Pos_Name" name="Pos_Name" class="pwdinput" style="width: 296px;"
                    maxlength="50" />
            </td>
        </tr>
        <tr>
            <th scope="row">
            </th>
            <td>
                <span class="tipW red hidden" id="errorMsg_Org">单位名称不能为空！</span>
            </td>
        </tr>
        <tr>
            <th scope="row">
                <span class="orange">*</span>单位名称
            </th>
            <td>
                <input type="text" id="Pos_Org" name="Pos_Org" class="pwdinput" style="width: 296px;"
                    maxlength="50" />
            </td>
        </tr>
        <tr>
            <th scope="row">
            </th>
            <td>
                <span class="tipW red hidden" id="errorMsg_Intro">输入错误。请控制在2000个汉字以内！</span>
            </td>
        </tr>
        <tr>
            <th scope="row" valign="top">
                &nbsp;职务描述
            </th>
            <td>
                <table width="456" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <textarea id="Pos_Intro" name="Pos_Intro" class="txtArea" onkeyup="str_limit('pos_<%=posiID %>',this.value,'Pos_IntroLength')"
                                onchange="str_limit('pos_<%=posiID %>',this.value,'Pos_IntroLength')"></textarea>
                        </td>
                    </tr>
                    <tr style="color: #999;">
                        <td width="284">
                            限2000个中文字，已输入<span class="orange" id="Pos_IntroLength">0</span>个字
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <th scope="row">
            </th>
            <td>
                <input type="checkbox" checked="checked" value="0" id="Pos_IsShow" name="Pos_IsShow" />
                <label for="Pos_IsShow">
                    <span class="lgray">将此职务信息显示在我的简历中 </span>
                </label>
            </td>
        </tr>
    </table>
    <div class="blank12px">
    </div>
    </form>
</div>
