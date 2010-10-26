﻿<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" 
    CodeFile="RecruitList.aspx.cs" Inherits="Admin_RecruitList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
    <ul class="Opr">
        <li><a href="RecruitAdd.aspx">添加招聘信息</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">

    <script type="text/javascript" src="js/jquery.tablednd.js"></script>
    
    <script type="text/javascript">
        $(document).ready(function() {
            $("#datas").tableDnD({
                onDrop: function(table, row) {
                    var rows = table.tBodies[0].rows;
                    var recruitId = row.id.replace("row_", "");
                    var nextId = "0";
                    var previewId = "0";
                    var total = rows.length;
                    if (total <= 1)
                        return;
                    for (i = 0; i < rows.length; i++) {
                        rows[i].className = i % 2 == 0 ? "even" : "";
                        if (rows[i].id == "row_" + recruitId) {
                            if (i == 0)
                                nextId = rows[i + 1].id.replace("row_", "");
                            else if (i + 1 == total)
                                previewId = rows[i - 1].id.replace("row_", "");
                            else
                                previewId = rows[i - 1].id.replace("row_", "");
                        }
                    }

                    var url = "RecruitSort.aspx?id=" + recruitId + "&previewid=" + previewId + "&nextid=" + nextId;
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
            window.location = "RecruitList.aspx?type=" + $("#<%=drpType.ClientID %>").val();
        }
        function delRecruits() {
            var list = document.getElementsByTagName("input");
            var selected = false;
            var form0;
            form0 = document.createElement("form");
            form0.method = "POST";
            form0.action = "RecruitsDel.aspx";
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
                alert("请选择招聘信息");
                return;
            }
            var msg = "你确认要删除选定的招聘信息吗?";
            if (confirm(msg)) {
                document.body.appendChild(form0);
                form0.submit();
            }
        }
    </script>
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                招聘管理</h3>
        </div>
        <div class="fi filter">
            类型：
            <asp:DropDownList ID="drpType" onchange="columnchange()" runat="server">
                <asp:ListItem Value="1" Text="实习生招聘"></asp:ListItem>
                <asp:ListItem Value="2" Text="毕业生招聘"></asp:ListItem>
                <asp:ListItem Value="3" Text="兼职招聘"></asp:ListItem>
                <asp:ListItem Value="4" Text="企业招聘"></asp:ListItem> 
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
                            地区编号
                        </th>
                        <th>
                            公司名称
                        </th>
                        <th>
                            职位名
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
                        <tr align="center" class="editalt" id="row_<%# Eval("fdRecrID")%>">
                            <td style="width: 30px;">
                                <input type="checkbox" name="ids" value="<%# Eval("fdRecrID")%>" />
                            </td>
                            <td style="text-align: left;" class="dragTd" title="拖动排序">
                                <a href="<%#Eval("fdRecrPath") %>" target="_blank">
                                    <%#Eval("fdRecrTitle")%></a>
                            </td>
                            <td>
                                <%#Eval("fdRecrAreaID")%>
                            </td>
                            <td>
                                <%#Eval("fdRecrCompany")%>
                            </td>
                            <td>
                                <%#Eval("fdRecrJob")%>
                            </td>
                            <td>
                                <%#Eval("fdRecrCreateAt")%>
                            </td>
                            <td>
                                <a href="RecruitEdit.aspx?id=<%# Eval("fdRecrID")%>">修改</a> <a href="RecruitDel.aspx?id=<%# Eval("fdRecrID")%>"
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
        <button onclick="delRecruits()" style="height: 28px;" type="button">
            批量删除</button>
    </div>
    <div>
        <ul class="Help">
            <li>招聘列表根据招聘排序从大到小排序。</li></ul>
    </div>
</asp:Content>

