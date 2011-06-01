<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/List.master" AutoEventWireup="true"
    CodeFile="ExhibitorList.aspx.cs" Inherits="Admin_Exhibitor_ExhibitorList" %>

<%@ Register Src="../Control/ExhibitorOperation.ascx" TagName="ExhibitorOperation" TagPrefix="uc1" %>
<%@ Register Src="../Control/ColumnInfo.ascx" TagName="ColumnInfo" TagPrefix="uc1" %>
<%@ Register Src="../Control/ExhibitorFooter.ascx" TagName="ExhibitorFooter" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <script type="text/javascript" src="../JS/jquery.tablednd.js"></script>

    <script type="text/javascript">
        var selStatus = false;
        $(function() {
            $("#datatable").tableDnD({
                onDrop: function(table, row) {
                    var rows = table.tBodies[0].rows;
                    var articleId = row.id.replace("row_", "");
                    var nextId = "0";
                    var previewId = "0";
                    var total = rows.length;
                    if (total <= 1) return;
                    var startIndex = <%=PN1.PageSize*(PN1.PageIndex-1)+1%>;
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
                        $(rows[i]).find("td:first").html(startIndex + i);
                    }

                    var url = "../Ajax/ExhibitorSort.aspx?id=" + articleId + "&previewid=" + previewId + "&nextid=" + nextId;
                    $.ajax({
                        url: url,
                        cache: false,
                        success: function(result) {
                            if (result.length > 0) {
                                alert(result);
                                window.location.href = window.location.href;
                            }
                        }
                    });
                }
            });
            
            $("#datatable tbody tr").hover(function(){
                $(this).addClass("hover"); 
            },function(){
                $(this).removeClass("hover");
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="Server">
    <ul>
        <li style="color: #000; font-size: 12px; font-weight: normal;">
            <input id="chkChildren" type="checkbox" <%=QS("getch")=="1"?"checked=\"checked\"":"" %>
                onchange="showChildren(<%=QS("cid") %>,this.checked)" /><label for="chkChildren">级联显示下级展商</label></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div id="noDatas" runat="server" visible="false" class="nodatas">
        未找到展商，<a href="ExhibitorAdd.aspx?cid=<%=CurrentColumn.fdColuID %>" target="exhibitor">点击这里</a>新建一个展商</div>
    <div class="datas">
        <table id="datatable">
            <asp:Repeater ID="repExhibitors" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th class="edit">
                                序号
                            </th>
                            <th>
                                <a href="javascript:<%=getOrderJs("fdExhiName") %>" title="点击按照公司名称排序">公司名称</a>
                                <span class="<%=getOrderCssClass("fdExhiName") %>"></span>
                            </th>
                            <th>
                                <a href="javascript:<%=getOrderJs("fdExhiEnName") %>" title="点击按照英文名称排序">英文名称</a>
                                <span class="<%=getOrderCssClass("fdExhiEnName") %>"></span>
                            </th>
                            <th>
                                <a href="javascript:<%=getOrderJs("fdExhiCreateAt")%>" title="点击按照创建时间排序">创建时间</a>
                                <span class="<%=getOrderCssClass("fdExhiCreateAt") %>"></span>
                            </th>
                            <th>
                                <a href="javascript:<%=getOrderJs("fdColuName")%>" title="点击按照栏目名排序">所在栏目</a> <span
                                    class="<%=getOrderCssClass("fdColuName") %>"></span>
                            </th>
                            <th style="width: 43px">
                                <a href="javascript:<%=getOrderJs("fdExhiStatus")%>" title="点击按照状态排序">状态</a> <span
                                    class="<%=getOrderCssClass("fdExhiStatus") %>"></span>
                            </th>
                            <th class="edit">
                                修改
                            </th>
                            <th class="edit">
                                <a href="javascript:selectAll()" title="选中列表中所有展商">全选</a>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr id="row_<%#Eval("fdExhiID")%>" class="<%# Container.ItemIndex % 2 == 0 ? "" : "even" %>">
                        <td class="dragTd" title="点击拖动排序">
                            <%#Eval("fdAutoID")%>
                        </td>
                        <td oncontextmenu="return parent.showExhibitorMenu(this,<%#Eval("fdExhiID") %>,<%#Eval("fdExhiColuID") %>,event);">
                            <a href="ExhibitorEdit.aspx?id=<%#Eval("fdExhiID") %>" target="exhibitor">
                                <%#Eval( "fdExhiName" )%></a>
                        </td>
                        <td>
                            <%#Eval( "fdExhiEnName" )%>
                        </td>
                        <td style="width: 100px; text-align: center;">
                            <%# Eval( "fdExhiCreateAt", "{0:yy-MM-dd HH:mm}" )%>
                        </td>
                        <td style="width: 100px; text-align: center;">
                            <a href="ExhibitorList.aspx?cid=<%#Eval("Column.fdColuID") %>">
                                <%#Eval("Column.fdColuName")%></a>
                        </td>
                        <td>
                            <%#Eval( "Status" )%>
                        </td>
                        <td>
                            <a href="ExhibitorEdit.aspx?id=<%#Eval("fdExhiID")%>" title="点击修改展商" target="exhibitor">
                                <img src="../images/icons/icon04.gif" alt="" /></a>
                        </td>
                        <td>
                            <input type="checkbox" name="ids" value="<%# Eval("fdExhiID")%>" class="checkbox" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                </FooterTemplate>
            </asp:Repeater>
            <tfoot id="tableFooter" runat="server">
                <tr>
                    <td colspan="8">
                        <span class="record">共<strong><asp:Literal ID="litRecords" runat="server">0</asp:Literal></strong>个展商</span>
                        <ul class="pager">
                            <sw:PageNaver ID="PN1" runat="server" PageSize="20" StyleID="2">
                            </sw:PageNaver>
                        </ul>
                    </td>
                </tr>
            </tfoot>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphOpr" runat="Server">
    <uc1:ExhibitorOperation runat="server" />
    <uc1:ColumnInfo runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" runat="Server">
    <uc1:ExhibitorFooter runat="server" />

    <script type="text/javascript">
        selectFooter("Exhibitor");
    </script>

</asp:Content>
