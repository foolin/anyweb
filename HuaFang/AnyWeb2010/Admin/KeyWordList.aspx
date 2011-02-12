<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="KeyWordList.aspx.cs" Inherits="Admin_KeyWordList" Title="搜索关键字管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <ul class="Opr">
        <li><a href="KeyWordList.aspx?s=1" <%= status == 1 ? "class='on'" : "" %>>显示</a></li>
        <li><a href="KeyWordList.aspx?s=0" <%= status == 0 ? "class='on'" : "" %>>不显示</a></li>
        <li><a href="KeyWordList.aspx?s=-1" <%= status == -1 ? "class='on'" : "" %>>全部</a></li>
        <li><a href="KeyWordAdd.aspx">添加关键字</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">

    <script type="text/javascript" src="js/jquery.tablednd.js"></script>

    <script type="text/javascript">
        //    $(document).ready(function() {
        //        $("#datas").tableDnD({
        //            onDrop: function(table, row) {
        //                //debugger;
        //                var rows = table.tBodies[0].rows;
        //                var keyWID = row.id.replace("row_", "");
        //                var nextId = "0";
        //                var previewId = "0";
        //                var total = rows.length;
        //                if (total <= 1)
        //                    return;
        //                for (i = 0; i < rows.length; i++) {
        //                    rows[i].className = i % 2 == 0 ? "even" : "";
        //                    if (rows[i].id == "row_" + keyWID) {
        //                        if (i == 0)
        //                            nextId = rows[i + 1].id.replace("row_", "");
        //                        else if (i + 1 == total)
        //                            previewId = rows[i - 1].id.replace("row_", "");
        //                        else
        //                            previewId = rows[i - 1].id.replace("row_", "");
        //                    }
        //                }

        //                var url = "KeyWordsSort.aspx?id=" + keyWID + "&previewid=" + previewId + "&nextid=" + nextId;
        //                $.get(url, "", function(htm) { });

        //            }
        //        });
        //    });
    </script>

    <style type="text/css">
        .pbd .part .Mod .mbd table thead tr th
        {
            line-height: normal;
        }
        .pbd .part .Mod .mbd .smtPager span input
        {
            height: auto;
            line-height: 15px;
            margin: 0;
            padding: 1px;
            vertical-align: middle;
        }
        .tDnD_whileDrag td
        {
            color: #999;
        }
    </style>
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                搜索关键字管理</h3>
        </div>
        <div class="mbd">
            <table id="datas">
                <thead>
                    <tr>
                        <th>
                            关键字
                        </th>
                        <th>
                            排序号
                        </th>
                        <th>
                            创建时间
                        </th>
                        <th class="end">
                            操 作
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="repKeyWord" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <tr align="center" class="editalt" id="row_<%# Eval("fdKeyWID")%>">
                            <td class="dragTd">
                                <%#Eval("fdKeyWName")%><%# (int)Eval("fdKeyWIsShow")==0 ? "<span style='color:red'> (不显示)</span>" : "" %>
                            </td>
                            <td>
                                <%#Eval("fdKeyWSort")%>
                            </td>
                            <td>
                                <%#Eval("fdKeyWCreateAt","{0:yyyy-MM-dd HH:mm}")%>
                            </td>
                            <td>
                                <a href="KeyWordEdit.aspx?id=<%#Eval("fdKeyWID") %>">修改</a> <a href="KeyWordDel.aspx?id=<%#Eval("fdKeyWID") %>"
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
            <li>该页显示所有搜索关键字列表，按搜索次数降序排列，可在修改内设置排序号和关键字是否在前台热门搜索处显示。</li>
        </ul>
    </div>
</asp:Content>
