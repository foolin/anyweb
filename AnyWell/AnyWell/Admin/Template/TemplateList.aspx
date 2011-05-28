<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/List.master" AutoEventWireup="true"
    CodeFile="TemplateList.aspx.cs" Inherits="Admin_Content_TemplateList" %>

<%@ Register Src="../Control/TemplateOperation.ascx" TagName="TemplateOperation" TagPrefix="uc1" %>
<%@ Register Src="../Control/SiteInfo.ascx" TagName="SiteInfo" TagPrefix="uc1" %>
<%@ Register Src="../Control/SiteFooter.ascx" TagName="SiteFooter" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <script type="text/javascript">
        var selStatus = false;
        function search() {
            var url = "?id=<%=CurrentSite.fdSiteID %>";
            url += "&type=" + <%=!string.IsNullOrEmpty(QS("type").Trim())?QS("type").Trim():"''" %>;
            url += "&key=" + $("#txtKey").val();
            window.location.href = url;
            return false;
        }
        
        function setTemplateOrder(field, orderby){
            var url = "?id=<%=CurrentSite.fdSiteID %>";
            url += "&type=" + <%=!string.IsNullOrEmpty(QS("type").Trim())?QS("type").Trim():"''" %>;
            url += "&key=" + $("#txtKey").val();
            url += "&field=" + field;
            url += "&orderby=" + orderby;
            window.location.href = url;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="Server">
    <form onsubmit="return search();">
    <ul>
        <li <%=string.IsNullOrEmpty(QS("type").Trim())?"class=\"selected\"":"" %>><a href="?id=<%=CurrentSite.fdSiteID %>">
            所有模板</a></li>
        <li <%=QS("type").Trim()=="4"?"class=\"selected\"":"" %>><a href="?id=<%=CurrentSite.fdSiteID %>&type=4">
            首页模板</a></li>
        <li <%=QS("type").Trim()=="1"?"class=\"selected\"":"" %>><a href="?id=<%=CurrentSite.fdSiteID %>&type=1">
            栏目模板</a></li>
        <li <%=QS("type").Trim()=="2"?"class=\"selected\"":"" %>><a href="?id=<%=CurrentSite.fdSiteID %>&type=2">
            内容模板</a></li>
        <li <%=QS("type").Trim()=="3"?"class=\"selected\"":"" %>><a href="?id=<%=CurrentSite.fdSiteID %>&type=3">
            嵌套模板</a></li>
        <li style="color: #000; font-size: 12px; font-weight: normal;">模板名称：<input id="txtKey"
            type="text" class="text" value="<%=QS("key") %>" /><input type="submit" value="搜索"
                class="button" /></li>
    </ul>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div id="noDatas" runat="server" visible="false" class="nodatas">
        未找到模板，<a href="TemplateAdd.aspx?sid=<%=CurrentSite.fdSiteID %>" target="template">点击这里</a>新建一个模板</div>
    <div class="datas">
        <table id="datatable">
            <asp:Repeater ID="repTemplate" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th class="edit">
                                序号
                            </th>
                            <th>
                                <a href="javascript:<%=getOrderJs("fdTempName") %>" title="点击按照文档标题排序">文档标题</a>
                                <span class="<%=getOrderCssClass("fdTempName") %>"></span>
                            </th>
                            <th>
                                <a href="javascript:<%=getOrderJs("fdTempCreateAt")%>" title="点击按照创建时间排序">创建时间</a>
                                <span class="<%=getOrderCssClass("fdTempCreateAt") %>"></span>
                            </th>
                            <th>
                                <a href="javascript:<%=getOrderJs("fdTempType")%>" title="点击按照模板类型排序">模板类型</a> <span
                                    class="<%=getOrderCssClass("fdTempType") %>"></span>
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
                            <a href="TemplateEdit.aspx?sid=<%#Eval("fdTempSiteID") %>&id=<%#Eval("fdTempID") %>" target="template">
                                <%#Eval("fdTempName")%></a>
                        </td>
                        <td style="width: 100px; text-align: center;">
                            <%# Eval( "fdTempCreateAt","{0:yy-MM-dd HH:mm}" )%>
                        </td>
                        <td style="width: 100px; text-align: center;">
                            <%#Eval("TempTypeName")%>
                        </td>
                        <td>
                            <a href="TemplateEdit.aspx?sid=<%#Eval("fdTempSiteID") %>&id=<%#Eval("fdTempID")%>" title="点击修改模板" target="template">
                                <img src="../images/icons/icon04.gif" alt="" /></a>
                        </td>
                        <td>
                            <input type="checkbox" name="ids" value="<%# Eval("fdTempID")%>" class="checkbox" />
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
                        <span class="record">共<strong><asp:Literal ID="litRecords" runat="server">0</asp:Literal></strong>个模板</span>
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
    <uc1:TemplateOperation runat="server" />
    <uc1:SiteInfo runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" runat="Server">
    <uc1:SiteFooter runat="server" />

    <script type="text/javascript">
        selectFooter("Template");
    </script>

</asp:Content>
