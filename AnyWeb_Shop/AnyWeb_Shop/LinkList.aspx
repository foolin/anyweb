<%@ Page Title="友情链接" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LinkList.aspx.cs" Inherits="Web_LinkList" %>
<%@ Register Src="~/Controls/CategoryInner.ascx" TagName="CategoryInner" TagPrefix="cate" %>
<%@ Register Src="~/Controls/LinkList.ascx" TagName="LinkList" TagPrefix="link" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">

 		<div class="col2MainSider">
            <cate:CategoryInner ID="CategoryInner1" runat="server" />
        <!-- end 2colMainSider -->
        </div>
        
        <div class="col2MainContent">
            <link:LinkList ID="LinkList1" runat="server" />
        <!-- end 2colMainContent -->
        </div>
        <div class="clear"></div>
        
</asp:Content>

