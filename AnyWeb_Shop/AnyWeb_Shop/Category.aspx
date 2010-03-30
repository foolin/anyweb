<%@ Page Title="商品分类" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Category.aspx.cs" Inherits="Web_Category" %>

<%@ Register Src="~/Controls/CategoryInner.ascx" TagName="CategoryInner" TagPrefix="cate" %>
<%@ Register Src="~/Controls/GoodsByCate.ascx"TagName="GoodsByCate" TagPrefix="cate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">

 		<div class="col2MainSider">
            <cate:CategoryInner ID="CategoryInner1" runat="server" />
        <!-- end 2colMainSider -->
        </div>
        
        <div class="col2MainContent">
            <cate:GoodsByCate ID="GoodsByCate1" runat="server" />
        <!-- end 2colMainContent -->
        </div>
        <div class="clear"></div>
        <script type="text/javascript">
            SetTitleCss(2);
        </script>
    
</asp:Content>
