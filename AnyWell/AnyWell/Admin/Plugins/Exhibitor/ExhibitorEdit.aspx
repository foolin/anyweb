<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/CenterPopup.master" AutoEventWireup="true" CodeFile="ExhibitorEdit.aspx.cs" Inherits="Admin_Plugins_Exhibitor_ExhibitorEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" Runat="Server">
    修改展商
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="optionhead">
    </div>
    <div class="popmbd">
        <table>
            <colgroup>
                <col style="width: 80px; vertical-align: top; padding-top: 3px;" />
                <col style="font-weight: normal" />
            </colgroup>
            <tr>
                <th>
                    站点：
                </th>
                <td>
                    <asp:DropDownList ID="drpSite" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    类型
                </th>
                <td>
                    <asp:DropDownList ID="drpType" runat="server">
                        <asp:ListItem Value="1">黑色家电</asp:ListItem>
                        <asp:ListItem Value="2">白色家电</asp:ListItem>
                        <asp:ListItem Value="3">小家电</asp:ListItem>
                        <asp:ListItem Value="4">厨房及浴室家电</asp:ListItem>
                        <asp:ListItem Value="5">家电配件</asp:ListItem>
                        <asp:ListItem Value="6">水家电</asp:ListItem>
                        <asp:ListItem Value="7">服务及刊物</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    公司名称：
                </th>
                <td>
                    <asp:TextBox ID="txtName" runat="server" CssClass="text" Width="300" MaxLength="50"></asp:TextBox>
                    <sw:Validator ID="val1" ControlID="txtName" ValidateType="Required" ErrorMessage="请填写公司名"
                        runat="server">
                    </sw:Validator>
                </td>
            </tr>
            <tr>
                <th>
                    英文名称：
                </th>
                <td>
                    <asp:TextBox ID="txtEnName" Width="300" CssClass="text" runat="server" MaxLength="100"></asp:TextBox>
                    <sw:Validator ID="Validator1" ControlID="txtEnName" ValidateType="DataType" DataType="English" ErrorMessage="英文名称格式错误"
                        runat="server">
                    </sw:Validator>
                </td>
            </tr>
            <tr>
                <th>
                    展位号：
                </th>
                <td>
                    <asp:TextBox ID="txtNumber" Width="100" CssClass="text" runat="server" MaxLength="25"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    网址：
                </th>
                <td>
                    <asp:TextBox ID="txtUrl" Width="300" CssClass="text" runat="server" MaxLength="90" Text="http://"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    描述：
                </th>
                <td>
                    <asp:TextBox ID="txtDesc" Width="300" Height="50" TextMode="MultiLine" CssClass="text" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div class="popmft">
        <button id="Saving" type="button" style="display: none;" disabled="disabled">
            正在保存</button>
        <button id="btnStart" type="submit">
            保存展商</button>
        <button type="button" onclick="parent.disablePopup()">
            取消退出</button>
    </div>
</asp:Content>

