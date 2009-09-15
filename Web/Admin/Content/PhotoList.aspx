<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="PhotoList.aspx.cs" Inherits="Admin_Content_PhotoList" Title="Untitled Page" %>
<%@ Register TagPrefix="cc1" Namespace="Studio.Web" Assembly="Studio" %>
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
                    <li>图片排序数字越小图片越靠前。</li>
                    <li>图片删除将不能恢复。</li>
                </ul>
            </dd>
        </dl>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    图片管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id="main_content">
        <div id="content">
            <div class="NewsList">
                <table width="100%" cellspacing="0" border="0">
                    <tr bgcolor="#E6F2FF">
                        <td>
                            名称</td>
                        <td>
                            图片</td>
                        <td>
                            描述</td>
                        <td>
                            排序</td>
                        <td>
                            操作</td>
                    </tr>
                    <asp:Repeater ID="drpPhoto" runat="server">
                        <ItemTemplate>
                            <tr onmouseover="this.style.background='#E6F2FF';" onmouseout="this.style.background='#FFFFFF'" style="height:60px;">
                                <td>
                                    <%#Eval("PhotName")%>
                                </td>
                                <td>
                                    <a href="<%#Eval("PhotPath")%>" target="_blank" title="点击查看大图片"><img src="<%#Eval("PhotPath")%>" width="150" height="100" class="img" alt="<%#Eval("PhotName")%>" /></a>
                                    </td>
                                <td>
                                    <%#Eval("PhotDesc") %>
                                </td>
                                <td>
                                    <%#Eval("PhotOrder")%>
                                </td>
                                <td>
                                    <a href="PhotoEdit.aspx?id=<%#Eval("PhotID") %>" title="修改图片信息">修改</a> <a href="PhotoDel.aspx?id=<%#Eval("PhotID") %>"
                                        onclick="return confirm('确定要删除图片？')" title="删除图片">删除</a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <div class="pagebar">
                    <cc1:PageNaver ID="PN1" runat="server" StyleID="1">
                    </cc1:PageNaver>
                </div>
            </div>
        </div>
    </div>   
</asp:Content>

