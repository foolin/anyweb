<%@ Page Title="" Language="C#" MasterPageFile="~/Inner.master" AutoEventWireup="true"
    CodeFile="LinkList.aspx.cs" Inherits="LinkList" %>

<%@ Register TagPrefix="cc1" Namespace="Studio.Web" Assembly="Studio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="ConBox column">
        <div class="tit">
            <h2>
                友情链接
            </h2>
        </div>
        <div class="blank10px">
        </div>
        <div class="newsList">
            <form id="Form1" runat="server">
            <asp:DropDownList ID="drpCate" runat="server" style="margin-left:30px;" onchange="change(this)">
                <asp:ListItem Value="1" Text="政府部门网站"></asp:ListItem>
                <asp:ListItem Value="2" Text="省外供销网站"></asp:ListItem>
                <asp:ListItem Value="3" Text="广州市供销合作社"></asp:ListItem>
                <asp:ListItem Value="4" Text="社有企业网站"></asp:ListItem>
            </asp:DropDownList>
            </form>
            <ul>
                <asp:Repeater ID="repLink" runat="server">
                    <ItemTemplate>
                        <li><a href="<%#Eval("LinkUrl") %>" target="_blank">
                            <%#Eval("LinkName") %></a></li>
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
        function change(obj) {
            window.location = "?id=" + obj.value;
        }
    </script>

</asp:Content>
