<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/InnerList.master"
    AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="Admin_User_UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <script type="text/javascript">
        var selStatus = false;
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div id="noDatas" runat="server" visible="false" class="nodatas">
        未找到用户</div>
    <div class="datas">
        <table id="datatable">
            <asp:Repeater ID="repUsers" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th class="edit">
                                序号
                            </th>
                            <th>
                                帐号
                            </th>
                            <th>
                                昵称
                            </th>
                            <th>
                                状态
                            </th>
                            <th>
                                创建时间
                            </th>
                            <th>
                                登录时间
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
                            <%#Eval( "fdAdmiAccount" )%>
                        </td>
                        <td>
                            <%#Eval( "fdAdmiName" )%>
                        </td>
                        <td align="center">
                            <%#Eval("AdminStatus") %>
                        </td>
                        <td style="width: 100px; text-align: center;">
                            <%# Eval( "fdAdmiCreateAt", "{0:yy-MM-dd HH:mm}" )%>
                        </td>
                        <td style="width: 100px; text-align: center;">
                            <%#Eval( "fdAdmiLoginAt", "{0:yyyy-MM-dd}" ) == "1900-01-01" ? "从未登录" : Eval( "fdAdmiLoginAt", "{0:yy-MM-dd HH:mm}" )%>
                        </td>
                        <td>
                            <a href="UserEdit.aspx?id=<%#Eval("fdAdmiID")%>" title="点击修改用户">
                                <img src="../images/icons/icon04.gif" alt="" /></a>
                        </td>
                        <td>
                            <input type="checkbox" name="ids" value="<%# Eval("fdAdmiID")%>" class="checkbox" />
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
                        <span class="record">共<strong><asp:Literal ID="litRecords" runat="server">0</asp:Literal></strong>个用户</span>
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
    <div class="operation" id="UserOpr">
        <h3 class="opr-mhd">
            <a href="javascript:showFolder('UserOpr')">
                <img src="../images/icons/arrow2.gif" /></a>用户操作任务</h3>
        <div class="opr-mbd">
            <ul>
                <li class="new"><a href="UserAdd.aspx">添加用户</a></li>
                <li class="lock"><a href="javascript:lockUser();">锁定用户</a></li>
                <li class="unlock"><a href="javascript:unlockUser();">解锁用户</a></li>
                <li class="delFile"><a href="javascript:deleteUser();">删除用户</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
