﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TagTopGet.aspx.cs" Inherits="Admin_TagTopGet" %>

<asp:repeater id="compRep" runat="server">
    <ItemTemplate>
        <dd>
            <a href="javascript:void(0);" onclick="AreaName(this,1);"><%#Eval("fdTagName") %></a></dd>
    </ItemTemplate>
</asp:repeater>
