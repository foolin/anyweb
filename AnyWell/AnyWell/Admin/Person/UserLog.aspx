<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/InnerList.master"
    AutoEventWireup="true" CodeFile="UserLog.aspx.cs" Inherits="Admin_Person_UserLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <script type="text/javascript">
        function setLogOrder(field, orderby) {
            var url = "?field=" + field;
            if (orderby)
                url += "&orderby=1";
            else
                url += "&orderby=0";
            window.location.href = url;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div id="noDatas" runat="server" visible="false" class="nodatas">
        未找到操作日志</div>
    <div class="datas">
        <table id="datatable">
            <asp:Repeater ID="repLogs" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th class="edit">
                                序号
                            </th>
                            <th style="width: 150px;">
                                事件名称
                            </th>
                            <th>
                                <a href="javascript:<%=getOrderJs("fdLogType")%>" title="点击按照操作类型排序">操作类型</a> <span
                                    class="<%=getOrderCssClass("fdLogType") %>"></span>
                            </th>
                            <th style="width: 100px;">
                                <a href="javascript:<%=getOrderJs("fdLogCreateAt")%>" title="点击按照操作时间排序">操作时间</a>
                                <span class="<%=getOrderCssClass("fdLogCreateAt") %>"></span>
                            </th>
                            <th style="width: 100px;">
                                IP
                            </th>
                            <th>
                                描述
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
                            <%#Eval( "fdLogName" )%>
                        </td>
                        <td style="width: 100px; text-align: center;">
                            <%#Eval( "TypeName" )%>
                        </td>
                        <td style="width: 100px; text-align: center;">
                            <%# Eval( "fdLogCreateAt", "{0:yy-MM-dd HH:mm}" )%>
                        </td>
                        <td>
                            <%#Eval( "fdLogIP" )%>
                        </td>
                        <td>
                            <%#Eval( "fdLogDesc" )%>
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
                        <span class="record">共<strong><asp:Literal ID="litRecords" runat="server">0</asp:Literal></strong>个操作日志</span>
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
    <div class="operation"id="LogOpr">
    <h3 class="opr-mhd">
        <a href="javascript:showFolder('LogOpr')">
            <img src="../images/icons/arrow2.gif" /></a>文档操作任务</h3>
    <div class="opr-mbd">
        <ul>
            <li class="delFile"><a href="javascript:clearPersonLog();">清空日志</a></li>
        </ul>
    </div>
</div>
</asp:Content>
