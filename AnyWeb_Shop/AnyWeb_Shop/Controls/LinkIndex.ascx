<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinkIndex.ascx.cs" Inherits="Controls_LinkIndex" %>
<div class="title">
    友情链接</div>
<div class="content">
    <ul>
        <asp:Repeater ID="repLink" runat="server">
            <ItemTemplate>
            <li><a href="<%#Eval("LinkUrl") %>" target="_blank"><%#Eval("Name")%></a></li>
        </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
