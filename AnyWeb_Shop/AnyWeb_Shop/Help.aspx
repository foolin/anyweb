<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Help.aspx.cs" Inherits="Help" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="Server">
    <style type="text/css">
        <!-- 
        .col-sider
        {
            float: left;
            width: 25%;
        }
        .col-main
        {
            float: right;
            width: 75%;
        }
        .container
        {
            padding-left: 5px;
            background: #FFF;
        }
        table.regForm
        {
            width: 100%;
            line-height: 30px;
            border-collapse: collapse;
            border: 1px solid #9ed96b;
            background: #FFF;
        }
        table.regForm .title
        {
            height: 20px;
            line-height: 20px;
            background: #9ed96b url(images/boxA_title_bg.jpg) repeat-x;
            font-size: 14px;
            font-weight: bold;
            color: #090;
            text-align: center;
        }
        table.regForm td
        {
            padding-top: 5px;
            padding-bottom: 5px;
        }
        .regForm input
        {
            border: solid 1px #aaa;
            padding: 3px 3px;
        }
        --></style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="main">
        <div class="col-sider">
            <!-- 栏目 -->
            <div class="category">
                <div class="title">
                    帮助导航</div>
                <div class="content">
                    <ul>
                        <asp:Repeater ID="repHelp" runat="server">
                            <ItemTemplate>
                                <li><a href="Help.aspx?id=<%#Eval("ID") %>">
                                    <%#Eval("Title") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="clear">
                    </div>
                </div>
                <!-- content end -->
            </div>
            <!-- category end -->
        </div>
        <!-- col-sider -->
        <div class="col-main">
            <div class="container">
                <table class="regForm">
                    <tr>
                        <td colspan="3" class="title">
                            <%=Article.Title %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=Article.Content %>
                        </td>
                    </tr>
                </table>
            </div>
            <!-- container end -->
        </div>
        <!-- col-main end -->
        <div class="clear">
        </div>
    </div>
    <!-- main end -->
</asp:Content>
