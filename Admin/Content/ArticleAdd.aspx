<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ArticleAdd.aspx.cs" Inherits="Content_ArticleAdd" Title="添加文章" %>

<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="navmenu">
        <dl>
            <dt>操作菜单</dt>
            <dd>
                <a href="/Content/ArticleAdd.aspx">添加文章</a></dd>
            <dd>
                <a href="/Content/ArticleList.aspx">文章列表</a></dd>
        </dl>
        <dl>
            <dt>使用帮助</dt>
            <dd>
                <ul>
                    <li>添加文章内容。</li>
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
                        <td align="right">
                            文章标题：</td>
                        <td>
                            <asp:TextBox ID="txtTitle" runat="server" Width="200" MaxLength="50" require="1"
                                errmsg="请输入文章标题"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">
                            文章内容：</td>
                        <td class="editor">
                            <div style="border: solid 1px gray;" colspan="2">
                            <ftb:FreeTextBox ID="edtContent" runat="Server" ToolbarLayout="bold,italic,underline,strikethrough,removeformat,wordclean;fontfacesmenu,fontsizesmenu,FontForeColorPicker,fontforecolorsmenu,fontbackcolorsmenu;justifyleft,justifyright,justifycenter,justifyfull|bulletedlist,numberedlist,indent,outdent;cut,copy,paste,delete;undo,redo;createlink,unlink,insertimagefromgallery,profileupload,insertmedia,inserttable,insertrule;print" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>文章排序：</td>
                        <td><asp:TextBox ID="txtOrder" runat="server" Text="0" Width="50"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>其它选项：</td>
                        <td><asp:CheckBox ID="chkTop" runat="server" Text="置顶" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnAddUser" runat="server" Text="保存用户" OnClick="btnAddArticle_Click" />
                            <a href="ColumnList.aspx">取消</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
