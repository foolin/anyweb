<%@ Page Language="C#" MasterPageFile="~/Admin/Master/CenterPopup.master"
    AutoEventWireup="true" CodeFile="SubscribeAdd.aspx.cs" Inherits="Admin_Plugins_Subscribe_Subscribe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="Server">
    添加订阅
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
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
                    公司名称：
                </th>
                <td>
                    <asp:TextBox ID="txtCompany" runat="server" CssClass="text" Width="200" MaxLength="50"></asp:TextBox>
                    <sw:Validator ID="val1" ControlID="txtName" ValidateType="Required" ErrorMessage="请填写公司名"
                        runat="server">
                    </sw:Validator>
                </td>
            </tr>
            <tr>
                <th>
                    姓氏：
                </th>
                <td>
                    <asp:TextBox ID="txtSurname" Width="200" CssClass="text" runat="server" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    名称：
                </th>
                <td>
                    <asp:TextBox ID="txtName" Width="200" CssClass="text" runat="server" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    电子邮件：
                </th>
                <td>
                    <asp:TextBox ID="txtEmail" Width="200" CssClass="text" runat="server" MaxLength="50" ></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div class="popmft">
        <button id="Saving" type="button" style="display: none;" disabled="disabled">
            正在保存</button>
        <button id="btnStart" type="submit">
            保存订阅</button>
        <button type="button" onclick="parent.disablePopup()">
            取消退出</button>
    </div>
</asp:Content>

