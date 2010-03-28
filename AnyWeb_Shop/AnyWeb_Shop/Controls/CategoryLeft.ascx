<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CategoryLeft.ascx.cs"
    Inherits="Controls_CategoryLeft" %>
<div class="box">
    <div class="title">
        <div class="txt">
            商品分类</div>
        <div class="ico">
            <img src="Images/box1_title_rbg.gif" width="66" height="33" /></div>
    </div>
    <div class="contentB">
        <asp:Repeater ID="repCate" runat="server" OnItemDataBound="repCategory_ItemDataBound">
            <ItemTemplate>
                <h4>
                    <a href="Category.aspx?cid=<%#Eval("ID") %>">
                        <%#Eval("Name")%></a></h4>
                <div class="link">
                    <asp:Repeater ID="repChiled" runat="server">
                        <ItemTemplate>
                            <a href="Category.aspx?cid=<%#Eval("ID") %>">
                                <%#Eval("Name")%></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
