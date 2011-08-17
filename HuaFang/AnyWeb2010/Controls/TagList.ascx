<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TagList.ascx.cs" Inherits="Controls_TagList" %>
<div class="product-list">
    <div class="product-con cs-clear">
        <asp:Repeater ID="repTag" runat="server">
            <ItemTemplate>
                <a href="/t/<%#Eval("fdTagID") %>.aspx" title="<%#Eval( "fdTagName" )%>" <%#(int)Eval("fdTagHightLight")==1?"class=\"col1\"":"" %>>
                    <%#Eval( "fdTagName" )%></a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="product-point">
    </div>
</div>
