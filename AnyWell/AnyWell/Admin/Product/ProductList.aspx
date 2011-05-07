<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/List.master" AutoEventWireup="true"
    CodeFile="ProductList.aspx.cs" Inherits="Admin_Product_ProductList" %>

<%@ Register Src="../Control/ProductOperation.ascx" TagName="ProductOperation" TagPrefix="uc1" %>
<%@ Register Src="../Control/ColumnInfo.ascx" TagName="ColumnInfo" TagPrefix="uc1" %>
<%@ Register Src="../Control/ProductFooter.ascx" TagName="ProductFooter" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <script type="text/javascript" src="../JS/jquery.tablednd.js"></script>

    <script type="text/javascript">
        var selStatus = false;
        $(function() {
            $("#datatable").tableDnD({
                onDrop: function(table, row) {
                    var rows = table.tBodies[0].rows;
                    var productId = row.id.replace("row_", "");
                    var nextId = "0";
                    var previewId = "0";
                    var total = rows.length;
                    if (total <= 1) return;
                    var startIndex = <%=PN1.PageSize*(PN1.PageIndex-1)+1%>;
                    for (i = 0; i < rows.length; i++) {
                        rows[i].className = i % 2 == 0 ? "even" : "";
                        if (rows[i].id == "row_" + productId) {
                            if (i == 0)
                                nextId = rows[i + 1].id.replace("row_", "");
                            else if (i + 1 == total)
                                previewId = rows[i - 1].id.replace("row_", "");
                            else
                                previewId = rows[i - 1].id.replace("row_", "");
                        }
                        $(rows[i]).find("td:first").html(startIndex + i);
                    }

                    var url = "../Ajax/ProductSort.aspx?id=" + productId + "&previewid=" + previewId + "&nextid=" + nextId;
                    $.ajax({
                        url: url,
                        cache: false,
                        success: function(result) {
                            if (result.length > 0) {
                                alert(result);
                                window.location.href.reload();
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
                onchange="showChildren(<%=QS("cid") %>,this.checked)" /><label for="chkChildren">级联显示下级产品</label></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div id="noDatas" runat="server" visible="false" class="nodatas">
        未找到产品，<a href="ProductAdd.aspx?cid=<%=CurrentColumn.fdColuID %>" target="product">点击这里</a>新建一个产品</div>
    <div class="datas">
        <table id="datatable">
            <asp:Repeater ID="repArticles" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th class="edit">
                                序号
                            </th>
                            <th>
                                <a href="javascript:<%=getOrderJs("fdProdName") %>" title="点击按照产品名称排序">产品名称</a>
                                <span class="<%=getOrderCssClass("fdProdName") %>"></span>
                            </th>
                            <th>
                                <a href="javascript:<%=getOrderJs("fdProdCreateAt")%>" title="点击按照创建时间排序">创建时间</a>
                                <span class="<%=getOrderCssClass("fdProdCreateAt") %>"></span>
                            </th>
                            <th>
                                <a href="javascript:<%=getOrderJs("fdColuName")%>" title="点击按照栏目名排序">所属栏目</a> <span
                                    class="<%=getOrderCssClass("fdColuName") %>"></span>
                            </th>
                            <th class="edit">
                                修改
                            </th>
                            <th class="edit">
                                <a href="javascript:selectAll()" title="选中列表中所有产品">全选</a>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr id="row_<%#Eval("fdProdID")%>" class="<%# Container.ItemIndex % 2 == 0 ? "" : "even" %>">
                        <td class="dragTd" title="点击拖动排序">
                            <%#Eval("fdAutoID")%>
                        </td>
                        <td oncontextmenu="return parent.showProductMenu(this,<%#Eval("fdProdID") %>,<%#Eval("fdProdColuID") %>,event);">
                            <a href="ProductEdit.aspx?id=<%#Eval("fdProdID") %>" target="product">
                                <%#( int ) Eval( "fdProdType" ) == 1 ? "<span style=\"color:red;font-size:12px;font-weight:bold;\">【引】</span>" : ""%><%#Eval( "fdProdName" )%></a>
                        </td>
                        <td style="width: 100px; text-align: center;">
                            <%# Eval( "fdProdCreateAt", "{0:yy-MM-dd HH:mm}" )%>
                        </td>
                        <td style="width: 100px; text-align: center;">
                            <a href="ProductList.aspx?cid=<%#Eval("Column.fdColuID") %>">
                                <%#Eval("Column.fdColuName")%></a>
                        </td>
                        <td>
                            <a href="ProductEdit.aspx?id=<%#Eval("fdProdID")%>" title="点击修改产品" target="product">
                                <img src="../images/icons/icon04.gif" alt="" /></a>
                        </td>
                        <td>
                            <input type="checkbox" name="ids" value="<%# Eval("fdProdID")%>" class="checkbox" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                </FooterTemplate>
            </asp:Repeater>
            <tfoot id="tableFooter" runat="server">
                <tr>
                    <td colspan="6">
                        <span class="record">共<strong><asp:Literal ID="litRecords" runat="server">0</asp:Literal></strong>个产品</span>
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
    <uc1:ProductOperation runat="server" />
    <uc1:ColumnInfo ID="ColumnInfo1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" runat="Server">
    <uc1:ProductFooter runat="server" />

    <script type="text/javascript">
        selectFooter("Product");
    </script>

</asp:Content>
