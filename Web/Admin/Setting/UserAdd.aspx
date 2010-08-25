<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserAdd.aspx.cs" Inherits="Setting_UserAdd" Title="添加用户" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    添加用户
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
                    <li>用户帐号用于个人登录，创建成功后将不可修改。</li>
                    <li>用户帐号格式4-20位字母或数字,必须以字母开头</li>
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
                            <asp:TextBox ID="txtUserAcc" runat="server" Width="200" MaxLength="20" require="1"
                                datatype="account" okmsg="格式正确" errmsg="用户帐号格式不正确" ToolTip="最多20个字符"></asp:TextBox>
                            <button onclick="javascript:checkAcc()" id="btnChk">
                                检查是否可用</button><span id="accMsg">[4-20位字母或数字,必须以字母开头]</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            中文名/昵称：</td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server" Width="200" MaxLength="20" require="1"
                                errmsg="请输入中文名/昵称" ToolTip="最多20个字符"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">
                            密码：</td>
                        <td>
                            <asp:TextBox ID="txtUserPwd" runat="server" TextMode="Password" Width="200" MaxLength="20"
                                require="1" errmsg="密码不能为空" ToolTip="最多20个字符"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            再输入密码：</td>
                        <td>
                            <asp:TextBox ID="txtUserPwd2" runat="server" TextMode="Password" Width="200" MaxLength="20" require="1" errmsg="密码不能为空" ToolTip="最多20个字符"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnAddUser" runat="server" Text="保存用户" OnClick="btnAddUser_Click" />
                            <a href="UserList.aspx">取消</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function checkAcc()
		{
			var accCtl = document.getElementById("<%=txtUserAcc.ClientID %>");
			var msgCtl = document.getElementById("accMsg");
			var btnCtl = document.getElementById("btnChk");
			var acc = accCtl.value;
			
			if( accCtl.error && accCtl.error !="")
			{
				alert(accCtl.error);
				return;
			}
			
			var ajax = new Ajax();
			ajax.Execute( "/ajax/checkacc.aspx?acc=" + acc, checkResult, btnCtl, msgCtl);
		}
		
		function checkResult(){}
    </script>

</asp:Content>
