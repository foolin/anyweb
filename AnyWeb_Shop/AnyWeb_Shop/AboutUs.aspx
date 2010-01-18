<%@ Page Title="关于我们" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AboutUs.aspx.cs" Inherits="Web_AboutUs" %>
<%@ Register Src="~/Controls/CategoryInner.ascx" TagName="CategoryInner" TagPrefix="cate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="Server">
    <link href="/public/goods_details.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="main">
        <div class="col-sider">
            <cate:categoryinner runat="server" />
        </div>
        <!-- col-sider end -->
        <div class="col-main">

                <div class="box">
                    <div class="title">
                        关于我们</div>
                    <div class="gDetails">
                        <%=ShopInfo.AboutUs %>
                    </div>
                </div>
                <!-- gRight -->
            </div>
            <!-- container end -->
        </div>
        <!-- col-main -->
        <div class="clear">
        </div>
    </div>
    <!-- main end -->
</asp:Content>
