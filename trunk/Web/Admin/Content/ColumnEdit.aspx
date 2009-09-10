<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="ColumnEdit.aspx.cs" Inherits="Content_ColumnEdit" Title="修改文章栏目" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="navmenu">
        <dl>
            <dt>操作菜单</dt>
            <dd>
                <a href="/Content/ColumnAdd.aspx">添加栏目</a></dd>
            <dd>
                <a href="/Content/ColumnList.aspx">栏目列表</a></dd>
        </dl>
        <dl>
            <dt>使用帮助</dt>
            <dd>
                <ul>
                    <li>修改文章栏目。</li>
                    <li>如果将一级栏目修改为另一个栏目的子栏目，那么该栏目的子栏将自动转为另一个栏目的子栏目。</li>
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
                            栏目名称：</td>
                        <td width="85%" align="left">
                            <asp:TextBox ID="txtName" runat="server" Width="200" MaxLength="50" require="1" errmsg="请输入栏目名称"
                                ToolTip="最多50个字符"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            上级栏目：</td>
                        <td>
                            <asp:DropDownList ID="drpParent" runat="server" DataTextField="ColuName" DataValueField="ColuID">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right">
                            栏目描述：</td>
                        <td>
                            <asp:TextBox ID="txtDesc" runat="server" MaxLength="50" TextMode="MultiLine" Width="200"
                                Height="70"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnAddUser" runat="server" Text="保存" OnClick="btnAddColumn_Click" />
                            <a href="ColumnList.aspx">取消</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
