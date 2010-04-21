<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="FlashList.aspx.cs" Inherits="Admin_FlashList" Title="首页轮换幻灯图片管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <ul class="Opr">
        <li><a href="FlashAdd.aspx">添加图片</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                幻灯图片</h3>
        </div>
        <div class="mbd">
            <table>
                <thead>
                    <tr>
                        <th>
                            名称
                        </th>
                        <th>
                            图片
                        </th>
                        <th>
                            链接
                        </th>
                        <th class="end">
                            操 作
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="compRep" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <tr align="center" class="editalt">
                            <td>
                                <%#Eval("fdFlasName")%>
                            </td>
                            <td>
                                <a href="<%#Eval("fdFlasPicture")%>" target="_blank">
                                    <img src="<%#Eval("fdFlasPicture")%>" width="100" height="65" /></a>
                            </td>
                            <td>
                                <a href="<%#Eval("fdFlasUrl")%>" target="_blank">
                                    <%#Eval("fdFlasUrl")%></a>
                            </td>
                            <td>
                                <a href="FlashEdit.aspx?id=<%# Eval("fdFlasID")%>">修改</a> <a href="FlashSort.aspx?type=up&id=<%# Eval("fdFlasID")%>">
                                    排前</a> <a href="FlashSort.aspx?type=down&id=<%# Eval("fdFlasID")%>">排后</a> <a href="FlashDel.aspx?id=<%# Eval("fdFlasID")%>"
                                        onclick="return confirm('您确定要删除吗?')">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>图片应小于500k，jpg或gif格式。建议为<%=AnyWeb.AW.Configs.GeneralConfigs.GetConfig().FlashWidth%>x<%=AnyWeb.AW.Configs.GeneralConfigs.GetConfig().FlashHeight%>像素。</li>
        </ul>
    </div>
</asp:Content>
