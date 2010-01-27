<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="ArticleList.aspx.cs" Inherits="Admin_ArticleList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <ul class="Opr">
        <li><a href="ArticleAdd.aspx?cid=<%=QS("cid")%>">添加新闻</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                新闻管理</h3>
        </div>
        <div class="fi filter">
            栏目：<asp:DropDownList ID="drpColumn" onchange="window.location='ArticleList.aspx?cid='+this.value"
                runat="server">
                <asp:ListItem Value="0">所有栏目</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="mbd">
            <table>
                <thead>
                    <tr>
                        <th>
                            标题
                        </th>
                        <th>
                            栏目
                        </th>
                        <th class="end">
                            操 作
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="compRep" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <tr align="center" class="editalt">
                            <td style="text-align: left;">
                                <%#Eval("fdArtiTitle")%>
                            </td>
                            <td>
                                <%#Eval("Column.fdColuName")%><%#(int)Eval("Column.fdColuShowIndex") == 0 ? "<span style='color:red'>(不在首页显示)</span>" : ""%>
                            </td>
                            <td>
                                <a href="ArticleEdit.aspx?id=<%# Eval("fdArtiID")%>">修改</a> <a href="ArticleDel.aspx?id=<%# Eval("fdArtiID")%>"
                                    onclick="return confirm('您确定要删除吗?')">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <div class="smtPager">
                <sw:PageNaver ID="PN1" runat="server" StyleID="2" PageSize="20">
                </sw:PageNaver>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li></li>
        </ul>
    </div>
</asp:Content>
