<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RightSide2.ascx.cs" Inherits="Controls_RightSide2" %>
<div class="Default-item">
    <div class="title-bar title-bar2">
        <h2 class="cs-clear">
            <p class="title-ch cs-fl">
                <span>近期热点</span></p>
        </h2>
    </div>
    <div class="Pho_Cap_Recom">
        <asp:Repeater ID="repHot1" runat="server">
            <ItemTemplate>
                <a href="<%#Eval("fdArtiPath") %>" class="PhoCap-a">
                    <img src="<%#Eval("fdArtiPic") %>" /></a>
                <h3>
                    <a href="<%#Eval("fdArtiPath") %>">
                        <%#Eval( "fdArtiTitle" )%></a></h3>
            </ItemTemplate>
        </asp:Repeater>
        <ul class="list-disc">
            <asp:Repeater ID="repHot2" runat="server">
                <ItemTemplate>
                    <li><a href="<%#Eval("fdArtiPath") %>">
                        <%#Eval( "fdArtiTitle" )%></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
