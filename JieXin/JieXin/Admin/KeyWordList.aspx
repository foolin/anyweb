<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="KeyWordList.aspx.cs" Inherits="Admin_KeyWordList" Title="搜索关键字管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
    <ul class="Opr">
        <li><a href="KeyWordList.aspx?s=1" <%= status == 1 ? "class='on'" : "" %>>显示</a></li>
        <li><a href="KeyWordList.aspx?s=2" <%= status == 2 ? "class='on'" : "" %>>不显示</a></li>
        <li><a href="KeyWordList.aspx?s=-1" <%= status == -1 ? "class='on'" : "" %>>全部</a></li>
        <li><a href="KeyWordAdd.aspx">添加关键字</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
<script type="text/javascript" src="js/jquery.tablednd.js"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $("#datas").tableDnD({
                onDrop: function(table, row) {
                    var rows = table.tBodies[0].rows;
                    var articleId = row.id.replace("row_", "");
                    var nextId = "0";
                    var previewId = "0";
                    var total = rows.length;
                    if (total <= 1)
                        return;
                    for (i = 0; i < rows.length; i++) {
                        rows[i].className = i % 2 == 0 ? "even" : "";
                        if (rows[i].id == "row_" + articleId) {
                            if (i == 0)
                                nextId = rows[i + 1].id.replace("row_", "");
                            else if (i + 1 == total)
                                previewId = rows[i - 1].id.replace("row_", "");
                            else
                                previewId = rows[i - 1].id.replace("row_", "");
                        }
                    }

                    var url = "KeyWordsSort.aspx?id=" + articleId + "&previewid=" + previewId + "&nextid=" + nextId;
                    $.get(url, "", function(htm) { });
                }
            });
        });
        function SelectAll(v) {
            var list = document.getElementsByTagName("input");
            for (var i = 0; i < list.length; i++) {
                if (list[i].name == "ids" && list[i].type == "checkbox") {
                    list[i].checked = v;
                }
            }
        }
        function delKeyWords() {
            var list = document.getElementsByTagName("input");
            var selected = false;
            var form0;
            form0 = document.createElement("form");
            form0.method = "POST";
            form0.action = "KeyWordsDel.aspx";
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
                alert("请选择关键词");
                return;
            }
            var msg = "你确认要删除选定的关键词吗?";
            if (confirm(msg)) {
                document.body.appendChild(form0);
                form0.submit();
            }
        }
    </script>

    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                热门搜索</h3>
        </div>
        <div class="mbd">
            <table id="datas">
                <thead>
                    <tr>
                        <th style="width: 30px;">
                            <input type="checkbox" class="checkbox" onclick="SelectAll(this.checked)" title="全选" />
                        </th>
                        <th>
                            关键词
                        </th>
                        <th>
                            创建时间
                        </th>
                        <th class="end">
                            操 作
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="compRep" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <tr align="center" class="editalt" id="row_<%# Eval("fdKeyWID")%>">
                            <td style="width: 30px;">
                                <input type="checkbox" name="ids" value="<%# Eval("fdKeyWID")%>" />
                            </td>
                            <td style="text-align: left;" class="dragTd" title="拖动排序">
                                <%#Eval("fdKeyWName")%><%# (int)Eval("fdKeyWIsShow")==2 ? "<span style='color:red'> (不显示)</span>" : "" %>
                            </td>
                            <td>
                                <%#Eval("fdKeyWCreateAt","{0:yyyy-MM-dd HH:mm}")%>
                            </td>
                            <td>
                                <a href="KeyWordEdit.aspx?id=<%#Eval("fdKeyWID") %>">修改</a>
                                        <a href="KeyWordDel.aspx?id=<%#Eval("fdKeyWID") %>" onclick="return confirm('您确定要删除吗?')">删除</a>
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
        <button onclick="delKeyWords()" style="height: 28px;" type="button">
            批量删除</button>
    </div>
    <div>
        <ul class="Help">
            <li>该页显示所有搜索关键词列表，按排序降序排列，可在修改内设置排序号和关键字是否在前台热门搜索处显示。</li>
        </ul>
    </div>
</asp:Content>

