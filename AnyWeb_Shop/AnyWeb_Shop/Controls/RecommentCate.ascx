<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecommentCate.ascx.cs" Inherits="Controls_RecommentCate" %>
<div class="category">
    <div class="title">
        商品分类</div>
    <div class="content">
        <asp:Repeater ID="repCate" runat="server" OnItemDataBound="repCategory_ItemDataBound">
            <ItemTemplate>
                <h3>
                    <a href="Recomment.aspx?cid=<%#Eval("ID") %>"><%#Eval("Name")%></a></h3>
                <ul>
                    <asp:Repeater ID="repChiled" runat="server">
                        <ItemTemplate>
                            <li><a href="Recomment.aspx?cid=<%#Eval("ID") %>"><%#Eval("Name")%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                 <div class="clear"></div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>