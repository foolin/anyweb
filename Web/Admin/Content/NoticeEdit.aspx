<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="NoticeEdit.aspx.cs" Inherits="Admin_Content_NoticeEdit" Title="修改流动通知" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div id="navmenu">
        <dl>
            <dt>操作菜单</dt>
            <dd>
                <a href="/Admin/Content/ArticleList.aspx">添加通知</a></dd>
            <dd>
                <a href="/Admin/Content/NoticeList.aspx">通知列表</a></dd>
        </dl>
        <dl>
            <dt>使用帮助</dt>
            <dd>
                <ul>
                    <li>排序数字越大通知越靠前。</li>
                </ul>
            </dd>
        </dl>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    添加流动通知
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main_content">
        <div id="content">
            <div class="tableForm">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="15%" align="right">
                            通知标题：</td>
                        <td width="85%" align="left">
                            <asp:TextBox ID="txtTitle" runat="server" ReadOnly="true"></asp:TextBox>
                    </tr>
                    <tr>
                        <td align="right">
                            通知排序：</td>
                        <td>
                            <asp:TextBox ID="txtOrder" runat="server" Width="50" MaxLength="50" require="1" datatype="number"
                                errmsg="通知排序格式不正确"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnAddNotice" runat="server" Text="保存通知" OnClick="btnAddNotice_Click" />
                            <a href="javascript:history.back();">取消</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

