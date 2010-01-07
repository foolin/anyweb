<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="ShopArticleList.aspx.cs" Inherits="ShopArticleList" Title="商城文章管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <li>商城文章是商城对用户的一些说明介绍，包括三类：购物指南，常见问题，帮助中心。有修改操作。</li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    商城指南列表</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                <table class="iList iArticle">
                    <thead>
                        <tr>
                            <th>
                                指南标题
                            </th>
                            <th>
                                所属类别
                            </th>
                            <th>
                                是否显示
                            </th>
                            <th class="end">
                                操作
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="repCategory" runat="server" DataSourceID="ods3">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <a href='/Help.aspx?id=<%#Eval("ID")%>' target="_blank">
                                            <%#Eval("Title") %></a>
                                    </td>
                                    <td>
                                        <%#Eval( "OfCategory.Name" )%>
                                    </td>
                                    <td>
                                        <%#(bool)Eval("IsShow")?"是":"否" %>
                                    </td>
                                    <td>
                                        <a href="ShopArticleEdit.aspx?aid=<%#Eval("ID")%>">修改</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                </form>
                <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetSysArticleList" TypeName="Common.Agent.ArticleAgent">
                </asp:ObjectDataSource>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
