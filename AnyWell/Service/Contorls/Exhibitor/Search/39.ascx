<%@ Control Language="C#" AutoEventWireup="true" CodeFile="39.ascx.cs" Inherits="Contorls_Exhibitor_Search_39" %>
<div id="noDatas" runat="server" visible="false" class="nodatas">
    Not found the exhibitors
</div>
<table width="100%" class="formTable_3" border="0" cellspacing="0" cellpadding="0">
    <asp:Repeater ID="rep" runat="server">
        <HeaderTemplate>
            <tr>
                <th scope="col">
                    Company Name
                </th>
                <th scope="col">
                    English Name
                </th>
                <th scope="col" width="70">
                    Booth Num
                </th>
                <th scope="col">
                    Website
                </th>
                <th scope="col">
                    Description
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
    <aw:Pager ID="PN1" runat="server" StyleID="5" PageSize="20" FirstPageText="First"
        LastPageText="Last" PrePageText="Previous" NextPageText="Next">
    </aw:Pager>
</div>
