<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="LinkAdd.aspx.cs" Inherits="Layout_LinkAdd" Title="添加连接" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="navmenu">
        <dl>
            <dt>操作菜单</dt>
            <dd>
                <a href="/Layout/LinkAdd.aspx">添加连接</a></dd>
            <dd>
                <a href="/Layout/LinkList.aspx">连接列表</a></dd>
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
                            链接名称：</td>
                        <td width="85%" align="left">
                            <asp:TextBox ID="txtLinkName" runat="server" Width="150" MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            连接URL：</td>
                        <td>
                            <asp:TextBox ID="txtLinkUrl" runat="server" Width="300"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            连接图片：</td>
                        <td>
                            <asp:TextBox ID="txtLinkImage" runat="server" Width="300"></asp:TextBox> （若是文字链接请留空）</td>
                    </tr>
                    <tr>
                        <td align="right">
                            连接排序：</td>
                        <td>
                            <asp:TextBox ID="txtLinkSort" runat="server" Width="100"></asp:TextBox> （必须为数字）
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnAddLink" runat="server" Text="添加链接" OnClick="btnAddLink_Click" />
                            <a href="LinkList.aspx">取消</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

</asp:Content>
