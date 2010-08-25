<%@ Page Title="" Language="C#" MasterPageFile="~/Inner.master" AutoEventWireup="true"
    CodeFile="NoticeList.aspx.cs" Inherits="NoticeList" %>

<%@ Register TagPrefix="cc1" Namespace="Studio.Web" Assembly="Studio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="ConBox column">
        <div class="tit">
            <h2>
                <asp:Literal ID="litTitle" runat="server"></asp:Literal></h2>
        </div>
        <div class="blank10px">
        </div>
        <div class="newsList">
            <ul>
                <asp:Repeater ID="repNotice" runat="server">
                    <ItemTemplate>
                        <li><span class="right">
                            <%#Eval("NotiCreateAt", "{0:yyyy-MM-dd HH:mm}")%></span><a href="article.aspx?id=<%#Eval("NotiArtiID") %>"
                                title="<%#Eval("Title") %>"><%#Studio.Web.WebAgent.GetLeft(Eval("Title").ToString(), 42,true)%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="blank12px">
        </div>
        <div class="newsList_page">
            <cc1:PageNaver ID="PN1" runat="server" StyleID="2" PageSize="16">
            </cc1:PageNaver>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function() { selMenu("SY"); });
    </script>

</asp:Content>
