﻿<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="NoticeList.aspx.cs" Inherits="NoticeList" Title="流动通知" %>
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
                        <span class="titletxt">--==流动通知==--</span>
                    </div>
                    <div class="box-content">
                        <table>
                            <asp:Repeater ID="repNotice" runat="server">
                                <ItemTemplate>
                                   <tr>
                                       <td>
                                           <a href="article.aspx?id=<%#Eval("NotiArtiID") %>" title="<%#Eval("Title") %>"><%#Studio.Web.WebAgent.GetLeft(Eval("Title").ToString(), 20)%></a></td>
                                       <td style="width:120px; color:Gray;"><%#Eval("NotiCreateAt", "{0:yyyy-MM-dd HH:mm}")%></td>
                                   </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        <div class="pagebar">
                            <cc1:PageNaver ID="PN1" runat="server" StyleID="1"></cc1:PageNaver>
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