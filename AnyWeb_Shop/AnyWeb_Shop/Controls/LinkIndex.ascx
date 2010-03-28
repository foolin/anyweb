<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinkIndex.ascx.cs" Inherits="Controls_LinkIndex" %>
<div class="box">
    <div class="title">
        <div class="txt">
            友情链接</div>
        <div class="ico">
            <img src="Images/box1_title_rbg.gif" width="66" height="33" /></div>
    </div>
    <div class="content">
        <ul class="indexLink">
            <asp:Repeater ID="repLink" runat="server">
                <ItemTemplate>
                    <li><a href="<%#Eval("LinkUrl") %>">
                        <%#Eval("Name")%></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
