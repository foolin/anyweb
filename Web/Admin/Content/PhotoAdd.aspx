<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="PhotoAdd.aspx.cs" Inherits="Admin_Content_PhotoAdd" Title="添加图片" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div id="navmenu">
        <dl>
            <dt>操作菜单</dt>
            <dd>
                <a href="/Admin/Content/PhotoAdd.aspx">上传图片</a></dd>
            <dd>
                <a href="/Admin/Content/PhotoList.aspx">图片列表</a></dd>
        </dl>
        <dl>
            <dt>使用帮助</dt>
            <dd>
                <ul>
                    <li>图片排序数字越大图片越靠前。</li>
                    <li>图片删除将不能恢复。</li>
                </ul>
            </dd>
        </dl>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    添加图片
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main_content">
        <div id="content">
            <div class="tableForm">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="15%" align="right">
                            图片类别：</td>
                        <td width="85%" align="left">
                            <asp:DropDownList ID="type" runat="server">
                                <asp:ListItem Text="首页幻灯片" Value="1"></asp:ListItem>
                                <asp:ListItem Text="网上菜篮子" Value="2"></asp:ListItem>
                                <asp:ListItem Text="知名合作企业" Value="3"></asp:ListItem>
                                <asp:ListItem Text="先进单位" Value="4"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" align="right">
                            图片名称：</td>
                        <td width="85%" align="left">
                            <asp:TextBox ID="txtPhotName" runat="server" Width="200" MaxLength="50" require="1" errmsg="请输入图片名称" ToolTip="最多50个字符"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            链接地址：</td>
                        <td>
                            <asp:TextBox ID="txtPhotUrl" runat="server" Width="400" MaxLength="200" require="1" errmsg="请输入图片链接地址" ToolTip="最多200个字符" Text="http://" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trupload">
                        <td align="right">
                            上传图片：</td>
                        <td>
                            <asp:FileUpload ID="imgupload" runat="server" Width="275" /></td>
                    </tr>
                    <tr>
                        <td align="right">
                            图片排序：</td>
                        <td>
                            <asp:TextBox ID="txtPhotOrder" runat="server" Width="50" require="1" errmsg="排序格式不正确" datatype="number" Text="0"></asp:TextBox> （必须为数字）
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding-left:40px;">
                            <asp:Button ID="btnAddPhoto" runat="server" Text="添加图片" OnClick="btnAddPhoto_Click" />
                            <a href="javascript:history.back();">取消</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

