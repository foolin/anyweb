<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserList.aspx.cs" Inherits="Setting_UserList" Title="用户列表" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="navmenu">
        <dl>
            <dt>操作菜单</dt>
            <dd>
                <a href="/Setting/UserAdd.aspx">添加用户</a></dd>
            <dd>
                <a href="/Setting/UserList.aspx">用户列表</a></dd>
            <dd>
                <a href="/Setting/LockedUserList.aspx">冻结用户列表</a></dd>
            <dd>
                <a href="/Setting/UserInfo.aspx">修改个人信息</a></dd>
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
                                    <a href="LockUser.aspx?id=<%#Eval("UserID") %>" onclick="return confirm('确定要冻结该用户？')" title="冻结用户">冻结</a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <div style="color:green; padding:10px 5px;">提示：若要删除用户，则必须先操作冻结用户，然后才能在冻结用户列表中删除用户。</div>
            </div>
        </div>
    </div>
</asp:Content>
