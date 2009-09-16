﻿<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="LinkAdd.aspx.cs" Inherits="Layout_LinkAdd" Title="添加链接" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    添加链接
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="navmenu">
        <dl>
            <dt>操作菜单</dt>
            <dd>
                <a href="/Admin/Layout/LinkAdd.aspx">添加链接</a></dd>
            <dd>
                <a href="/Admin/Layout/LinkList.aspx">链接列表</a></dd>
        </dl>
        <dl>
            <dt>使用帮助</dt>
            <dd>
                <ul>
                    <li>链接URL必须以http://开头。</li>
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
                            链接名称：</td>
                        <td width="85%" align="left">
                            <asp:TextBox ID="txtLinkName" runat="server" Width="200" MaxLength="50" require="1" errmsg="请输入链接名称" ToolTip="最多50个字符"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            链接URL：</td>
                        <td>
                            <asp:TextBox ID="txtLinkUrl" runat="server" Width="200" MaxLength="200" require="1" errmsg="链接URL格式不正确" datatype="url" ToolTip="最多200个字符" Text="http://"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trupload">
                        <td align="right">
                            链接图片：</td>
                        <td>
                            <asp:FileUpload ID="imgupload" runat="server" Width="275" /></td>
                    </tr>
                    <tr>
                        <td align="right">
                            链接排序：</td>
                        <td>
                            <asp:TextBox ID="txtLinkSort" runat="server" Width="50" require="1" errmsg="排序格式不正确" datatype="number" Text="0"></asp:TextBox> （必须为数字）
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