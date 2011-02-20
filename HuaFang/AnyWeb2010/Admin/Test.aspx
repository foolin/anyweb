<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Admin_Test" %>

<%@ Register Src="Control/TagSelect.ascx" TagName="TagSelect" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
    <uc1:TagSelect runat="server" />
</asp:Content>

