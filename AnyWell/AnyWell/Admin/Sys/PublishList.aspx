<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/InnerList.master"
    AutoEventWireup="true" CodeFile="PublishList.aspx.cs" Inherits="Admin_Sys_PublishList" %>

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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div id="noDatas" runat="server" visible="false" class="nodatas">
        未找到发布日志</div>
    <div class="datas">
        <table id="datatable">
            <asp:Repeater ID="repPublish" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th class="edit">
                                序号
                            </th>
                            <th>
                                名称
                            </th>
                            <th>
                                类型
                            </th>
                            <th>
                                状态
                            </th>
                            <th>
                                发布者
                            </th>
                            <th>
                                开始时间
                            </th>
                            <th>
                                发布用时
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
                            <%#Eval( "fdPublName" )%>
                        </td>
                        <td align="center">
                            <%#Eval( "PublishTypeName" )%>
                        </td>
                        <td align="center">
                            <%#( int ) Eval( "fdPublStatus" ) == 0 ? "未运行" : ( int ) Eval( "fdPublStatus" ) == 1 ? "执行中" : ( int ) Eval( "fdPublStatus" ) == 2 ? "发布成功" : ( int ) Eval( "fdPublStatus" ) == 4 ? "已删除" : "<a title='点击查看错误信息' href='javascript:showPublishError(" + Eval( "fdPublID" ) + ")' style='color:red'>发布失败</a>"%>
                        </td>
                        <td>
                            <%#Eval( "Creater.fdAdmiName" )%>
                        </td>
                        <td style="width: 100px; text-align: center;">
                            <%# Eval( "fdPublStartAt", "{0:yy-MM-dd HH:mm:ss}" )%>
                        </td>
                        <td style="width: 100px; text-align: center;">
                            <%#Eval( "PublishTime" )%>
                        </td>
                        <td>
                            <input type="checkbox" name="ids" value="<%# Eval("fdPublID")%>" class="checkbox" />
                        </td>
                    </tr>
                    <tr id="error_<%#Eval("fdPublID") %>" style="display: none; color: Red;">
                        <td colspan="8">
                            <%#Eval( "fdPublError" )%>
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
                        <span class="record">共<strong><asp:Literal ID="litRecords" runat="server">0</asp:Literal></strong>条记录</span>
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
    <div class="operation" id="PublishOpr">
        <h3 class="opr-mhd">
            <a href="javascript:showFolder('PublishOpr')">
                <img src="../images/icons/arrow2.gif" /></a>发布操作任务</h3>
        <div class="opr-mbd">
            <ul>
                <li class="delFile"><a href="javascript:deletePublish();">删除日志</a></li>
                <li class="delFile"><a href="javascript:clearPublish();">清空日志</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
