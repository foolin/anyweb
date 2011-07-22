<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="LibraryList.aspx.cs" Inherits="Admin_LibraryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <ul class="Opr">
        <li><a href="LibraryAdd.aspx">添加名人/品牌</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">

    <script type="text/javascript" src="/Admin/js/jquery.tablednd.js"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $("#datas").tableDnD({
                onDrop: function(table, row) {
                    var rows = table.tBodies[0].rows;
                    var Id = row.id.replace("row_", "");
                    var nextId = "0";
                    var previewId = "0";
                    var total = rows.length;
                    if (total <= 1)
                        return;
                    for (i = 0; i < rows.length; i++) {
                        rows[i].className = i % 2 == 0 ? "even" : "";
                        if (rows[i].id == "row_" + Id) {
                            if (i == 0)
                                nextId = rows[i + 1].id.replace("row_", "");
                            else if (i + 1 == total)
                                previewId = rows[i - 1].id.replace("row_", "");
                            else
                                previewId = rows[i - 1].id.replace("row_", "");
                        }
                    }

                    var url = "LibrarySort.aspx?id=" + Id + "&previewid=" + previewId + "&nextid=" + nextId;
                    $.get(url, "", function(htm) { });
                }
            });
        });
        
        function Change() {
            var url = "?library=" + document.getElementById("<%=drpLibrary.ClientID %>").value
                    + "&firstLetter=" + document.getElementById("<%=drpFirstLetter.ClientID %>").value;
            window.location = url;
        }

        function SelectAll(v) {
            var list = document.getElementsByTagName("input");
            for (var i = 0; i < list.length; i++) {
                if (list[i].name == "ids" && list[i].type == "checkbox") {
                    list[i].checked = v;
                }
            }
        }

        function delLibrarys() {
            var list = document.getElementsByTagName("input");
            var selected = false;
            var form0;
            form0 = document.createElement("form");
            form0.method = "POST";
            form0.action = "LibrarysDel.aspx";
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
                alert("请选择信息");
                return;
            }
            var msg = "你确认要删除选定的信息吗?";
            if (confirm(msg)) {
                document.body.appendChild(form0);
                form0.submit();
            }
        }
    </script>

    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                两库管理</h3>
        </div>
        <div class="fi filter">
            分类：
            <asp:DropDownList ID="drpLibrary" runat="server" onchange="Change()">
                <asp:ListItem Text="名人库" Value="1"></asp:ListItem>
                <asp:ListItem Text="品牌库" Value="2"></asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="drpFirstLetter" runat="server" onchange="Change()">
                <asp:ListItem Text="A" Value="0"></asp:ListItem>
                <asp:ListItem Text="B" Value="1"></asp:ListItem>
                <asp:ListItem Text="C" Value="2"></asp:ListItem>
                <asp:ListItem Text="D" Value="3"></asp:ListItem>
                <asp:ListItem Text="E" Value="4"></asp:ListItem>
                <asp:ListItem Text="F" Value="5"></asp:ListItem>
                <asp:ListItem Text="G" Value="6"></asp:ListItem>
                <asp:ListItem Text="H" Value="7"></asp:ListItem>
                <asp:ListItem Text="I" Value="8"></asp:ListItem>
                <asp:ListItem Text="J" Value="9"></asp:ListItem>
                <asp:ListItem Text="K" Value="10"></asp:ListItem>
                <asp:ListItem Text="L" Value="11"></asp:ListItem>
                <asp:ListItem Text="M" Value="12"></asp:ListItem>
                <asp:ListItem Text="N" Value="13"></asp:ListItem>
                <asp:ListItem Text="O" Value="14"></asp:ListItem>
                <asp:ListItem Text="P" Value="15"></asp:ListItem>
                <asp:ListItem Text="Q" Value="16"></asp:ListItem>
                <asp:ListItem Text="R" Value="17"></asp:ListItem>
                <asp:ListItem Text="S" Value="18"></asp:ListItem>
                <asp:ListItem Text="T" Value="19"></asp:ListItem>
                <asp:ListItem Text="U" Value="20"></asp:ListItem>
                <asp:ListItem Text="V" Value="21"></asp:ListItem>
                <asp:ListItem Text="W" Value="22"></asp:ListItem>
                <asp:ListItem Text="X" Value="23"></asp:ListItem>
                <asp:ListItem Text="Y" Value="24"></asp:ListItem>
                <asp:ListItem Text="Z" Value="25"></asp:ListItem>
                <asp:ListItem Text="其他" Value="26"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="mbd">
            <table id="datas">
                <thead>
                    <tr>
                        <th style="width: 30px;">
                            <input type="checkbox" class="checkbox" onclick="SelectAll(this.checked)" title="全选" />
                        </th>
                        <th align="center">
                            名称
                        </th>
                        <th align="center">
                            英文名称
                        </th>
                        <th align="center">
                            介绍
                        </th>
                        <th align="center">
                            操作
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="repLibrary" runat="server"  EnableViewState="False">
                    <ItemTemplate>
                        <tr align="center" class="editalt" id="row_<%# Eval("fdLibrID")%>">
                            <td style="width: 30px;">
                                <input type="checkbox" name="ids" value="<%# Eval("fdLibrID")%>" />
                            </td>
                            <td align="center" class="dragTd" title="拖动排序">
                                <%#Eval("fdLibrName")%>
                            </td>
                            <td align="center">
                                <%#Eval("fdLibrEnName")%>
                            </td>
                            <td align="center">
                                <%#Eval("fdLibrDesc")%>
                            </td>
                            <td align="center">
                                <a href="LibraryEdit.aspx?id=<%#Eval("fdLibrID") %>" title="修改信息">修改</a> <a href="LibraryDel.aspx?id=<%#Eval("fdLibrID") %>"
                                    onclick="return confirm('确定要删除信息？')" title="删除信息">删除</a>
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
        <button onclick="delLibrarys()" style="height: 28px;" type="button">
            批量删除</button>
    </div>
</asp:Content>
