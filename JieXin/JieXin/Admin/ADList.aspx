<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="ADList.aspx.cs" Inherits="Admin_ADList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">

    <script type="text/javascript" src="js/jquery.tablednd.js"></script>

    <script type="text/javascript">
        function columnchange() 
        {
            window.location = "ADList.aspx?type=" + $("#<%=drpType.ClientID %>").val();
        }
    </script>

    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                广告管理</h3>
        </div>
        <div class="fi filter">
            类型：
            <asp:DropDownList ID="drpType" onchange="columnchange()" runat="server">
                <asp:ListItem Value="6" Text="企业介绍"></asp:ListItem>
                <asp:ListItem Value="7" Text="动态标语"></asp:ListItem>
                <asp:ListItem Value="8" Text="移动广告"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="mbd">
            <table id="datas">
                <thead>
                    <tr>
                        <th>
                            标题
                        </th>
                        <th>
                            图片
                        </th>
                        <th class="end">
                            操 作
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="compRep" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <tr align="center" class="editalt">
                            <td style="text-align: left;">
                                <a href="<%#Eval("fdAdLink") %>" target="_blank">
                                    <%#Eval("fdAdName")%></a>
                            </td>
                            <td>
                                <%# (string)Eval("fdAdPic") != ""?string.Format("<a href=\"{0}\" target=\"_blank\"><img src=\"{0}\" alt=\"\" width=\"100\" height=\"65\" /></a>",Eval("fdAdPic")):"" %>
                            </td>
                            <td>
                                <a href="ADEdit.aspx?id=<%# Eval("fdAdID")%>">修改</a>
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

