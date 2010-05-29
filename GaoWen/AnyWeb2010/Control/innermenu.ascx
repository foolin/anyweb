<%@ Control Language="C#" AutoEventWireup="true" CodeFile="innermenu.ascx.cs" Inherits="Control_innermenu" %>
<div class="pageMenu" id="pageMenu">
    <ul>
        <asp:Repeater ID="repColumn" runat="server" EnableViewState="False">
            <ItemTemplate>
                <li><a href="column.aspx?id=<%#Eval("fdColuID") %>" rel="dropmenu<%#Eval("fdColuID") %>"><%#Eval("fdColuName")%></a></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <div class="clear">
    </div>
</div>

<asp:Repeater ID="repParent" runat="server" EnableViewState="False">
    <ItemTemplate>
        <div id="dropmenu<%#Eval("fdColuID") %>" class="dropmenudiv" style="width: 150px;">
        <asp:Repeater ID="repChild" runat="server" DataSource='<%#Eval("Children") %>' EnableViewState="False">
            <ItemTemplate>
                <a href="column.aspx?id=<%#Eval("fdColuID") %>"><%#Eval("fdColuName")%></a>
            </ItemTemplate>
        </asp:Repeater>
        </div>
    </ItemTemplate>
</asp:Repeater>


<script type="text/javascript">

    cssdropdown.startchrome("pageMenu")

</script>