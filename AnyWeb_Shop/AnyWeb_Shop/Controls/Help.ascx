<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Help.ascx.cs" Inherits="Controls_Help" %>
<div class="help-links">
    <ul>
        <asp:Repeater ID="repHelp" runat="server">
            <ItemTemplate>
                <li><a href="Help.aspx?id=<%#Eval("ID") %>"><%#Eval("Title") %></a></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <div class="clear">
    </div>
</div>
