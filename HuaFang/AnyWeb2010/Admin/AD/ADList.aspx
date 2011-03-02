<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="ADList.aspx.cs" Inherits="Admin_ADList" Title="首页轮换幻灯图片管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
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
                                <%#Eval("fdAdName")%>
                            </td>
                            <td>
                                <a href="<%#Eval("fdAdPic")%>" target="_blank">
                                    <img src="<%#Eval("fdAdPic")%>" width="100" height="65" /></a>
                            </td>
                            <td>
                                <a href="<%#Eval("fdAdLink")%>" target="_blank">
                                    <%#Studio.Web.WebAgent.GetLeft((string)Eval("fdAdLink"),50)%></a>
                            </td>
                            <td>
                                <a href="ADEdit.aspx?id=<%# Eval("fdAdID")%>">修改</a>
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
            <li>图片应小于500k，jpg或gif格式。建议为<%=AnyWell.Configs.GeneralConfigs.GetConfig().FlashWidth%>x<%=AnyWell.Configs.GeneralConfigs.GetConfig().FlashHeight%>像素。</li>
        </ul>
    </div>
</asp:Content>
