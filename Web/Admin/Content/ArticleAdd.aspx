﻿<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true"
    CodeFile="ArticleAdd.aspx.cs" Inherits="Content_ArticleAdd" Title="添加文章" ValidateRequest="false" %>
    
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    添加文档
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
                    <li>添加文章内容。</li>
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
                        <td align="right">
                            文章标题：</td>
                        <td>
                            <asp:TextBox ID="txtTitle" runat="server" Width="200" MaxLength="50" require="1"
                                errmsg="请输入文章标题"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            文章内容：</td>
                        <td class="editor">
                            <div style="border: solid 1px gray;" colspan="2">
                            <sw:TinyMce ID="edtContent" runat="server" Height="500px" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">文章排序：</td>
                        <td><asp:TextBox ID="txtOrder" runat="server" Text="0" Width="50" require="1" datatype="number" errmsg="文章排序格式不正确"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnAddArticle" runat="server" Text="保存文章" OnClick="btnAddArticle_Click" />
                            <a href="javascript:history.back();">取消</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
