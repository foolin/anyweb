<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecommdIndex.ascx.cs"
    Inherits="Controls_RecommdIndex" %>
<div class="title">
    热荐商品</div>
<asp:Repeater ID="repRecomment" runat="server" OnItemDataBound="repCategory_ItemDataBound">
    <ItemTemplate>
        <asp:Repeater ID="repGood" runat="server">
            <ItemTemplate>
                <div class="goods">
                    <!-- Index Item -->
                    <div class="index-item">
                        <div class="pic">
                            <a href="Good.aspx?gid=<%#Eval("ID") %>">
                                <img width="125" height="95" src="<%#(string)Eval( "image" )=="" ? "../images/wait.jpg":(string)Eval( "image" ) %>"
                                    border="0" alt="<%#Eval("GoodsName")%>" /></a>
                        </div>
                        <div class="name">
                            <a href="Good.aspx?gid=<%#Eval("ID") %>">
                                <%#Eval("GoodsName")%></a>
                        </div>
                    </div>
            </ItemTemplate>
        </asp:Repeater>
        <ul class="items">
            <asp:Repeater ID="repList" runat="server">
                <ItemTemplate>
                    <li><a href="Good.aspx?gid=<%#Eval("ID") %>" title="<%#Eval("GoodsName")%>">
                        <%#Eval("GoodsName")%></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        </div>
    </ItemTemplate>
</asp:Repeater>
<!-- goods end-->
<div class="clear">
</div>
