<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinkList.ascx.cs" Inherits="Controls_LinkList" %>
<div class="box">
    <div class="title">
        友情链接</div>
    <asp:Repeater ID="repLinks" runat="server">
        <ItemTemplate>
            <div class="goods">
                <dl>
                    <dd>
                        <a href="<%#Eval("LinkUrl") %>">
                            <img src="<%#(string)Eval( "Image" )=="" ? "../images/wait.jpg":(string)Eval( "Image" ) %>"
                                border="0" alt="<%#Eval("Name")%>" /></a></dd>
                </dl>
            </div>
            <!-- goods end -->
        </ItemTemplate>
    </asp:Repeater>
    <div class="clear">
    </div>
    <!-- page end -->
</div>