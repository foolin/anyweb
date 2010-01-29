<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="TemplateList.aspx.cs" Inherits="Admin_TemplateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
    <ul class="Opr">
        <li><a href="TemplateAdd.aspx">添加模版</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                模版管理</h3>
        </div>
        <div class="fi filter">
            模版类型：<asp:DropDownList ID="drpType" onchange="window.location='TemplateList.aspx?type='+this.value"
                runat="server">
                <asp:ListItem Value="0">所有模版</asp:ListItem>
                <asp:ListItem Value="1">内容模版</asp:ListItem>
                <asp:ListItem Value="2">嵌套模版</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="mbd">
            <table>
                <thead>
                    <tr>
                        <th>
                            模版名称
                        </th>
                        <th>
                            模版类型
                        </th>
                        <th>
                            创建时间
                        </th>
                        <th class="end">
                            操 作
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="repTemplate" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <tr align="center" class="editalt">
                            <td style="text-align: left;">
                                <%#Eval("fdTempName")%>
                            </td>
                            <td>
                                <%#Eval("fdTempTypeStr") %>
                            </td>
                            <td>
                                <%#Eval("fdTempCreateAt","{0:yyyy-MM-dd HH:mm}")%>
                            </td>
                            <td>
                                <a href="TemplateEdit.aspx?id=<%# Eval("fdTempID")%>">修改</a> <a href="TemplateDel.aspx?id=<%# Eval("fdTempID")%>"
                                    onclick="return confirm('您确定要删除吗?')">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <div class="smtPager">
                <sw:PageNaver ID="PN1" runat="server" StyleID="2" PageSize="20">
                </sw:PageNaver>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li></li>
        </ul>
    </div>
</asp:Content>

