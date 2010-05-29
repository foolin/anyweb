<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="RelationList.aspx.cs" Inherits="Admin_RelationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
    <ul class="Opr">
        <li><a href="RelationAdd.aspx">添加信息关联</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
    <script type="text/javascript" src="/public/js/jquery.tablednd.js"></script>
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

                    var url = "RelationSort.aspx?id=" + articleId + "&previewid=" + previewId + "&nextid=" + nextId;
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
        function columnchange() {
            window.location = "RelationList.aspx?id=" + $("#<%=drpColumn.ClientID %>").val() + "&cid=" + $("#<%=drpChildColumn.ClientID %>").val();
        }
        function delRelations() {
            var list = document.getElementsByTagName("input");
            var selected = false;
            var form0;
            form0 = document.createElement("form");
            form0.method = "POST";
            form0.action = "RelationsDel.aspx";
            for (var i = 0; i < list.length; i++) {
                if (list[i].name == "ids" && list[i].type == "checkbox" && list[i].checked) {
                    input1 = document.createElement("input");
                    input1.type = "hidden";
                    input1.name = "ids";
                    input1.value = list[i].value;
                    form0.insertBefore(input1);
                    selected = true;
                }
            }
            if (selected == false) {
                alert("请选择文章");
                return;
            }
            var msg = "你确认要删除选定的文章吗?";
            if (confirm(msg)) {
                document.body.insertBefore(form0);
                form0.submit();
            }
        }
    </script>
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                信息关联管理</h3>
        </div>
        <div class="fi filter">
            栏目：<asp:DropDownList ID="drpColumn" onchange="columnchange()" runat="server">
                <asp:ListItem Value="0">所有栏目</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="drpChildColumn" onchange="columnchange()" runat="server">
                <asp:ListItem Value="0">所有栏目</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="mbd">
            <table id="datas">
                <thead>
                    <tr>
                        <th style="width: 80px">
                            <input type="checkbox" class="checkbox" onclick="SelectAll(this.checked)" title="全选" />
                        </th>
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
                        <tr align="center" class="editalt" id="row_<%# Eval("fdRelaID")%>">
                            <td style="width: 30px;">
                                <input type="checkbox" name="ids" value="<%# Eval("fdRelaID")%>" />
                            </td>
                            <td style="text-align: left;" class="dragTd" title="拖动排序">
                                <a href="<%#Eval("fdRelaLink") %>" target="_blank"><%#Eval("fdRelaTitle")%></a>
                            </td>
                            <td>
                                <%#Eval("Column.fdColuName")%>
                            </td>
                            <td>
                                <a href="RelationEdit.aspx?id=<%# Eval("fdRelaID")%>">修改</a> <a href="RelationDel.aspx?id=<%# Eval("fdRelaID")%>"
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
        <button onclick="delRelations()" style="height: 28px;" type="button">
            批量删除</button>
    </div>
    <div>
        <ul class="Help">
            <li></li>
        </ul>
    </div>
</asp:Content>

