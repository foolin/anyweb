<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="TagList.aspx.cs" Inherits="Admin_TagList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <ul class="Opr">
        <li><a href="TagAdd.aspx">添加标签</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">

    <script type="text/javascript">
        function SelectAll(v) {
            var list = document.getElementsByTagName("input");
            for (var i = 0; i < list.length; i++) {
                if (list[i].name == "ids" && list[i].type == "checkbox") {
                    list[i].checked = v;
                }
            }
        }
        function search() {
            window.location = "TagList.aspx?key=" + $("#<%=txtKey.ClientID %>").val();
        }
        function delArticles() {
            var list = document.getElementsByTagName("input");
            var selected = false;
            var form0;
            form0 = document.createElement("form");
            form0.method = "POST";
            form0.action = "TagsDel.aspx";
            for (var i = 0; i < list.length; i++) {
                if (list[i].name == "ids" && list[i].type == "checkbox" && list[i].checked) {
                    input1 = document.createElement("input");
                    input1.type = "hidden";
                    input1.name = "ids";
                    input1.value = list[i].value;
                    form0.appendChild(input1);
                    selected = true;
                }
            }
            if (selected == false) {
                alert("请选择标签");
                return;
            }
            var msg = "你确认要删除选定的标签吗?";
            if (confirm(msg)) {
                document.body.appendChild(form0);
                form0.submit();
            }
        }
    </script>

    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                文章管理</h3>
        </div>
        <div class="fi filter">
            标签：<asp:TextBox ID="txtKey" runat="server" MaxLength="50"></asp:TextBox>
            <input type="button" onclick="search()" value="搜索" />
        </div>
        <div class="mbd">
            <table id="datas">
                <thead>
                    <tr>
                        <th style="width: 30px;">
                            <input type="checkbox" class="checkbox" onclick="SelectAll(this.checked)" title="全选" />
                        </th>
                        <th>
                            标签
                        </th>
                        <th class="end">
                            操 作
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="compRep" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <tr align="center" class="editalt">
                            <td style="width: 30px;">
                                <input type="checkbox" name="ids" value="<%# Eval("fdTagID")%>" />
                            </td>
                            <td style="text-align: left;" class="dragTd">
                                </a>
                                <%#Eval("fdTagName")%>（<a href="TagArticleList.aspx?id=<%#Eval("fdTagID") %>&back=<%#Request.Url.PathAndQuery.Replace("pid","pageindex") %>">文章：<%#Eval("fdArtiCount") %></a>）（<a
                                    href="TagGoodList.aspx?id=<%#Eval("fdTagID") %>&back=<%#Request.Url.PathAndQuery.Replace("pid","pageindex") %>">商品：<%#Eval("fdGoodCount") %></a>）
                            </td>
                            <td>
                                <a href="TagEdit.aspx?id=<%# Eval("fdTagID")%>">修改</a> <a href="TagDel.aspx?id=<%# Eval("fdTagID")%>"
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
        <button onclick="delArticles()" style="height: 28px;" type="button">
            批量删除</button>
    </div>
    <div>
        <ul class="Help">
        </ul>
    </div>
</asp:Content>
