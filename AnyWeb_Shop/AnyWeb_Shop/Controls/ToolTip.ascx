<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ToolTip.ascx.cs" Inherits="Controls_ToolTip" %>
<style>
    .tooltip{position:absolute; z-index:9999;width:500px;}
    .tooltip a{color:#186100;font-size:14px;text-decoration:none;}
</style>
<div class="tooltip">
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
