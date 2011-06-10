<%@ Control Language="C#" AutoEventWireup="true" CodeFile="33.ascx.cs" Inherits="Contorls_Exhibitor_Search_33" %>
<div id="noDatas" runat="server" visible="false" class="nodatas">
    未找到展商
</div>
<table width="100%" class="formTable_3" border="0" cellspacing="0" cellpadding="0">
    <asp:Repeater ID="rep" runat="server">
        <HeaderTemplate>
            <tr>
                <th scope="col">
                    公司名称
                </th>
                <th scope="col">
                    英文名称
                </th>
                <th scope="col" width="50">
                    展位号
                </th>
                <th scope="col">
                    网址
                </th>
                <th scope="col">
                    简介
                </th>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="<%# Container.ItemIndex % 2 == 1 ? "" : "even" %>">
                <td style="width: 160px;">
                    <%#Eval("fdExhiName") %>
                </td>
                <td style="width: 160px;">
                    <%#Eval("fdExhiEnName") %>
                </td>
                <td>
                    <%#Eval("fdExhiNumber") %>
                </td>
                <td style="width: 160px;">
                    <a href="<%#Eval("fdExhiUrl") %>" target="_blank">
                        <%#Eval("fdExhiUrl") %></a>
                </td>
                <td>
                    <%#Eval( "fdExhiDesc" )%>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>
<div class="blank20px">
</div>
<div class="tc lblue">
    <aw:Pager ID="PN1" runat="server" StyleID="5" PageSize="1">
    </aw:Pager>
</div>
