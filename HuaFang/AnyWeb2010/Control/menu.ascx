<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu.ascx.cs" Inherits="Control_menu" %>
<div class="nav relate navIndex">
    <div class="ls">
    </div>
    <div id="menu" class="ms">
        <asp:Repeater ID="repColumn" runat="server" EnableViewState="False">
            <ItemTemplate>
                <a href="column.aspx?id=<%#Eval("fdColuID") %>" rel="dropmenu<%#Eval("fdColuID") %>"><%#Eval("fdColuName")%></a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="rs">
    </div>
</div>
<asp:Repeater ID="repParent" runat="server" EnableViewState="False">
    <ItemTemplate>
        <div id="dropmenu<%#Eval("fdColuID") %>" class="dropmenudiv">
            <asp:Repeater ID="repChild" runat="server" DataSource='<%#Eval("Children") %>' EnableViewState="False">
                <ItemTemplate>
                    <a href="column.aspx?id=<%#Eval("fdColuID") %>">
                        <%#Eval("fdColuName")%></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </ItemTemplate>
</asp:Repeater>
<script type="text/javascript">
    cssdropdown.startchrome("menu");
</script>

