<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="CompanyADList.aspx.cs" Inherits="Admin_CompanyADList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <ul class="Opr">
        <li><a href="CompanyADAdd.aspx">添加企业图片</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">

    <script type="text/javascript" src="js/jquery.tablednd.js"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $("#datas").tableDnD({
                onDrop: function(table, row) {
                    var type = $("#<%=drpType.ClientID %>").val();
                    var rows = table.tBodies[0].rows;
                    var adId = row.id.replace("row_", "");
                    var nextId = "0";
                    var previewId = "0";
                    var total = rows.length;
                    if (total <= 1)
                        return;
                    for (i = 0; i < rows.length; i++) {
                        rows[i].className = i % 2 == 0 ? "even" : "";
                        if (rows[i].id == "row_" + adId) {
                            if (i == 0)
                                nextId = rows[i + 1].id.replace("row_", "");
                            else if (i + 1 == total)
                                previewId = rows[i - 1].id.replace("row_", "");
                            else
                                previewId = rows[i - 1].id.replace("row_", "");
                        }
                    }

                    var url = "ADSort.aspx?type=" + type + "&id=" + adId + "&previewid=" + previewId + "&nextid=" + nextId;
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
            window.location = "CompanyADList.aspx?type=" + $("#<%=drpType.ClientID %>").val();
        }
        function delCompanyADs() {
            var list = document.getElementsByTagName("input");
            var selected = false;
            var form0;
            form0 = document.createElement("form");
            form0.method = "POST";
            form0.action = "CompanyADsDel.aspx";
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
                alert("请选择企业图片");
                return;
            }
            var msg = "你确认要删除选定的企业图片吗?";
            if (confirm(msg)) {
                document.body.appendChild(form0);
                form0.submit();
            }
        }
    </script>

    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                企业图片管理</h3>
        </div>
        <div class="fi filter">
            类型：
            <asp:DropDownList ID="drpType" onchange="columnchange()" runat="server">
                <asp:ListItem Value="1" Text="大型企业图片"></asp:ListItem>
                <asp:ListItem Value="2" Text="中型企业图片"></asp:ListItem>
                <asp:ListItem Value="3" Text="小型企业图片"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="mbd">
            <table id="datas">
                <thead>
                    <tr>
                        <th style="width: 30px;">
                            <input type="checkbox" class="checkbox" onclick="SelectAll(this.checked)" title="全选" />
                        </th>
                        <th>
                            标题
                        </th>
                        <th>
                            图片
                        </th>
                        <th class="end">
                            操 作
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="compRep" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <tr align="center" class="editalt" id="row_<%# Eval("fdAdID")%>">
                            <td style="width: 30px;">
                                <input type="checkbox" name="ids" value="<%# Eval("fdAdID")%>" />
                            </td>
                            <td style="text-align: left;" class="dragTd" title="拖动排序">
                                <a href="<%#Eval("fdAdLink") %>" target="_blank">
                                    <%#Eval("fdAdName")%></a>
                            </td>
                            <td>
                                <%# (string)Eval("fdAdPic") != ""?string.Format("<a href=\"{0}\" target=\"_blank\"><img src=\"{0}\" alt=\"\" width=\"100\" height=\"65\" /></a>",Eval("fdAdPic")):"" %>
                            </td>
                            <td>
                                <a href="CompanyADEdit.aspx?id=<%# Eval("fdAdID")%>">修改</a> <a href="CompanyADDel.aspx?id=<%# Eval("fdAdID")%>"
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
        <button onclick="delCompanyADs()" style="height: 28px;" type="button">
            批量删除</button>
    </div>
    <div>
        <ul class="Help">
            <li>大型企业图片规格：308*95</li>
            <li>中型企业图片规格：180*30</li>
            <li>小型企业图片规格：85*30</li>
        </ul>
    </div>
</asp:Content>
