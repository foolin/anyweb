﻿<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserList.aspx.cs" Inherits="Setting_UserList" Title="用户列表" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    用户管理
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="navmenu">
        <dl>
            <dt>操作菜单</dt>
            <dd>
                <a href="/Admin/Setting/UserAdd.aspx">添加用户</a></dd>
            <dd>
                <a href="/Admin/Setting/UserList.aspx">用户列表</a></dd>
            <dd>
                <a href="/Admin/Setting/UserInfo.aspx">修改个人信息</a></dd>
        </dl>
        <dl>
            <dt>使用帮助</dt>
            <dd>
                <ul>
                    <li>管理后台登陆用户</li>
                </ul>
            </dd>
        </dl>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content">
        <div id="content">
            <div class="NewsList">
                <table width="100%" cellspacing="0" border="0">
                    <tr bgcolor="#E6F2FF">
                        <td>
                            用户帐号</td>
                        <td>
                            中文名/昵称</td>
                        <td>
                            操作</td>
                    </tr>
                    <asp:Repeater ID="repUser" runat="server">
                        <ItemTemplate>
                            <tr onmouseover="this.style.background='#E6F2FF';" onmouseout="this.style.background='#FFFFFF'">
                                <td><%#Eval("UserAcc")%>
                                </td>
                                <td>
                                    <%#Eval("UserName") %></td>
                                <td>
                                    <a href="UserEdit.aspx?id=<%#Eval("UserID") %>" title="修改用户信息">修改</a>
                                    <a href="UserDel.aspx?id=<%#Eval("UserID") %>" onclick="return confirm('确定要删除该用户？')" title="删除用户">删除</a></td></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
