<%@ Control Language="C#" AutoEventWireup="true" CodeFile="rightclpt.ascx.cs" Inherits="Control_rightclpt" %>
<div class="colTitle">
</div>
<div class="colContent">
    <div class="text">
        <ul>
            <asp:Repeater ID="repRelation" runat="server">
                <ItemTemplate>
                    <li><a href="<%#Eval("fdRelaLink") %>">
                        <%#Eval("fdRelaTitle")%></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
<div class="colButtomCorner">
</div>
