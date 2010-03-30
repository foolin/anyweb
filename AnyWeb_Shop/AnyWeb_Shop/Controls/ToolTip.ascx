<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ToolTip.ascx.cs" Inherits="Controls_ToolTip" %>
<div id="tooltip" class="tooltips">
<div id="toolContent" class="toolContent">
    <asp:Repeater ID="repCate" runat="server" OnItemDataBound="repCategory_ItemDataBound">
        <ItemTemplate>
            <h4>
                <a href="Category.aspx?cid=<%#Eval("ID") %>" class="abc">
                    <%#Eval("Name")%></a></h4>
            <div class="link">
                <asp:Repeater ID="repChiled" runat="server">
                    <ItemTemplate>
                        <a href="Category.aspx?cid=<%#Eval("ID") %>" >
                            <%#Eval("Name")%></a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
</div>
