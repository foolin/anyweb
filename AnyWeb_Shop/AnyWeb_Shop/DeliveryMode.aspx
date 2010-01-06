<%@ Page Title="配送信息" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DeliveryMode.aspx.cs" Inherits="DeliveryMode" %>
<%@ Register Src="~/Controls/CategoryInner.ascx" TagName="CategoryInner" TagPrefix="cate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" Runat="Server">
    <link href="/public/goods_details.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="main">
        <div class="col-sider">
            <cate:categoryinner ID="Categoryinner1" runat="server" />
        </div>
        <!-- col-sider end -->
        <div class="col-main">
            <div class="box">
                <div class="box">
                    <div class="title">
                        配送信息</div>
                </div>
                <!-- gRight -->
                <div class="gDetails">
                    <asp:Repeater ID="repMode" runat="server">
                        <ItemTemplate>
                            <h2><%#Eval("Title")%></h2>
                            <%#Eval("Content")%>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <!-- container end -->
        </div>
        <!-- col-main -->
        <div class="clear">
        </div>
    </div>
    <!-- main end -->
</asp:Content>

