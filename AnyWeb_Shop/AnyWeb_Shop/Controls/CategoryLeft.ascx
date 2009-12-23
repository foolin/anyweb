<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CategoryLeft.ascx.cs"
    Inherits="Controls_CategoryLeft" %>
<div class="category">
    <div class="title">
        商品分类</div>
    <div class="content">
        <asp:Repeater ID="repCate" runat="server" OnItemDataBound="repCategory_ItemDataBound">
            <ItemTemplate>
                <h3>
                    <a href="Category.aspx?cid=<%#Eval("ID") %>"><%#Eval("Name")%></a></h3>
                <div class="line">
                    <asp:Repeater ID="repChiled" runat="server">
                        <ItemTemplate>
                            <span><a href="Category.aspx?cid=<%#Eval("ID") %>"><%#Eval("Name")%></a></span>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="clear">
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
