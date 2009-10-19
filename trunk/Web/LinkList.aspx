<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="LinkList.aspx.cs" Inherits="LinkList" Title="友情链接" %>
<%@ Register Src="Controls/CompanyNav.ascx" TagName="CompanyNav" TagPrefix="uc1" %>
<%@ Register Src="Controls/Contact.ascx" TagName="Contact" TagPrefix="uc1" %>
<%@ Register TagPrefix="cc1" Namespace="Studio.Web" Assembly="Studio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="container">
            <div class="column-sider">
                <!--栏目-->
                <uc1:companynav id="CompanyNav1" runat="server"></uc1:companynav>
                <!--栏目-->
                <div class="boxA">
                    <uc1:Contact ID="Contact1" runat="server" />
                </div>
            </div>
            <div class="column-main">
                <div class="box">
                    <div class="box-title">
                        <span class="titletxt">--==友情链接==--</span>
                    </div>
                    <div class="box-content">
                        <div class="picLinks" style="text-align:center;">
                            <asp:Repeater ID="repImage" runat="server">
                                <ItemTemplate>
                                    <a href="<%#Eval("LinkUrl") %>" target="_blank">
                                        <img src="<%#Eval("LinkImage") %>" class="img"  width="170" height="80" alt="<%#Eval("LinkName") %>" /></a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div> 
                </div>
            </div>
            <!-- column-main end -->
        </div>
        <!--container end -->
    </div>
    <!-- main end -->
</asp:Content>

