<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="ArticleMove.aspx.cs" Inherits="Content_ArticleMove" Title="文章移动栏目" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    文档移动
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="navmenu">
        <dl>
            <dt>操作菜单</dt>
            <dd>
                <a href="/Admin/Content/ArticleAdd.aspx">添加文档</a></dd>
            <dd>
                <a href="/Admin/Content/ArticleList.aspx">文档列表</a></dd>
            <dd>
                <a href="/Admin/Content/ArticleRecycle.aspx">文档回收站</a></dd>
        </dl>
        <dl>
            <dt>使用帮助</dt>
            <dd>
                <ul>
                    <li>修改文章内容。</li>
                    <li>文章排序数字越大文章越靠前。</li>
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
                            文章栏目：</td>
                        <td width="85%" align="left">
                            <asp:DropDownList ID="drpColumn" runat="server" DataTextField="ColuName" DataValueField="ColuID">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnAddUser" runat="server" Text="确定移动" OnClick="btnSaveArticle_Click" />
                            <a href="ArticleList.aspx">取消</a>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblids" runat="server" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
