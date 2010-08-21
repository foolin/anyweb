<%@ Control Language="C#" AutoEventWireup="true" CodeFile="rightclpt.ascx.cs" Inherits="Control_rightclpt" %>
<div class="related">
    <ul>
        <asp:Repeater ID="repRelation" runat="server">
            <ItemTemplate>
                <li>
                    <h3>
                        <a href="<%#Eval("fdRelaLink") %>">
                            <%#Eval("fdRelaTitle")%></a></h3>
                    <p>
                        <%#Eval("fdRelaDesc") %></p>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
