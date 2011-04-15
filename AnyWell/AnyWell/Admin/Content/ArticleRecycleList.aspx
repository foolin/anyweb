<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/List.master" AutoEventWireup="true"
    CodeFile="ArticleRecycleList.aspx.cs" Inherits="Admin_Content_ArticleRecycleList" %>

<%@ Register Src="../Control/RecycleOperation.ascx" TagName="RecycleOperation" TagPrefix="uc1" %>
<%@ Register Src="../Control/ColumnInfo.ascx" TagName="ColumnInfo" TagPrefix="uc1" %>
<%@ Register Src="../Control/ColumnFooter.ascx" TagName="ColumnFooter" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <script type="text/javascript">
        var selStatus = false;
        $(function() {
            $("#datatable tbody tr").hover(function() {
                $(this).addClass("hover");
            }, function() {
                $(this).removeClass("hover");
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="Server">
    <ul>
        <li style="color: #000; font-size: 12px; font-weight: normal;">
            <input id="chkChildren" type="checkbox" <%=QS("getch")=="1"?"checked=\"checked\"":"" %>
                onchange="showChildren(<%=QS("cid") %>,this.checked)" /><label for="chkChildren">级联显示下级文档</label></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div id="noDatas" runat="server" visible="false" class="nodatas">
        未找到文档</div>
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
                                <a href="javascript:<%=getOrderJs("fdArtiTitle") %>" title="点击按照文档标题排序">文档标题</a>
                                <span class="<%=getOrderCssClass("fdArtiTitle") %>"></span>
                            </th>
                            <th>
                                <a href="javascript:<%=getOrderJs("fdArtiCreateAt")%>" title="点击按照创建时间排序">创建时间</a>
                                <span class="<%=getOrderCssClass("fdArtiCreateAt") %>"></span>
                            </th>
                            <th>
                                <a href="javascript:<%=getOrderJs("fdColuName")%>" title="点击按照栏目名排序">所在栏目</a> <span
                                    class="<%=getOrderCssClass("fdColuName") %>"></span>
                            </th>
                            <th class="edit">
                                修改
                            </th>
                            <th class="edit">
                                <a href="javascript:selectAll()" title="选中列表中所有文档">全选</a>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="<%# Container.ItemIndex % 2 == 0 ? "" : "even" %>">
                        <td>
                            <%#Eval("fdAutoID")%>
                        </td>
                        <td>
                            <a href="ArticleEdit.aspx?id=<%#Eval("fdArtiID") %>" target="article">
                                <%#( int ) Eval( "fdArtiType" ) == 4 ? "<span style=\"color:red;font-size:12px;font-weight:bold;\">【引】</span>" : ""%><%#Eval("fdArtiTitle")%></a>
                        </td>
                        <td style="width: 100px; text-align: center;">
                            <%# Eval( "fdArtiCreateAt","{0:yy-MM-dd HH:mm}" )%>
                        </td>
                        <td style="width: 100px; text-align: center;">
                            <a href="ArticleList.aspx?cid=<%#Eval("Column.fdColuID") %>">
                                <%#Eval("Column.fdColuName")%></a>
                        </td>
                        <td>
                            <a href="ArticleEdit.aspx?id=<%#Eval("fdArtiID")%>" title="点击修改文档" target="article">
                                <img src="../images/icons/icon04.gif" alt="" /></a>
                        </td>
                        <td>
                            <input type="checkbox" name="ids" value="<%# Eval("fdArtiID")%>" class="checkbox" />
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
                        <span class="record">共<strong><asp:Literal ID="litRecords" runat="server">0</asp:Literal></strong>篇文档</span>
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
    <uc1:RecycleOperation runat="server" />
    <uc1:ColumnInfo runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" runat="Server">
    <uc1:ColumnFooter runat="server" />

    <script type="text/javascript">
        selectFooter("Recycle");
    </script>

</asp:Content>
