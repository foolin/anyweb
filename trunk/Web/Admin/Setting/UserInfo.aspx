<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserInfo.aspx.cs" Inherits="Setting_UserInfo" Title="修改个人信息" %>

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
                    <li>用户帐号用于个人登录，不可修改。</li>
                    <li>不修改密码，密码输入框留空</li>
                </ul>
            </dd>
        </dl>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main_content">
        <div id="content">
            <div class="tableForm">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="15%" align="right">
                            用户帐号：</td>
                        <td width="85%" align="left">
                            <asp:TextBox ID="txtUserAcc" runat="server" Width="200" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            中文名/昵称：</td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server" Width="200" MaxLength="20" require="1"
                                errmsg="中文名/昵称" ToolTip="最多20个字符"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">
                            旧密码：</td>
                        <td>
                            <asp:TextBox ID="txtUserOldPwd" runat="server" TextMode="Password" Width="200" MaxLength="20"
                                ToolTip="最多20个字符"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            新密码：</td>
                        <td>
                            <asp:TextBox ID="txtUserPwd" runat="server" TextMode="Password" Width="200" MaxLength="20"
                                ToolTip="最多20个字符"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            再输入密码：</td>
                        <td>
                            <asp:TextBox ID="txtUserPwd2" runat="server" TextMode="Password" Width="200" MaxLength="20" ToolTip="最多20个字符"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnAddUser" runat="server" Text="保存个人信息" OnClick="btnAddUser_Click" />
                            <a href="UserList.aspx">取消</a>
                        </td>
                    </tr>
                </table>
                <asp:TextBox ID="txtpassword" runat="server" Visible="false"></asp:TextBox>
            </div>
        </div>
    </div>

</asp:Content>
