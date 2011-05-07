﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/CenterPopup.master"
    AutoEventWireup="true" CodeFile="SiteEdit.aspx.cs" Inherits="Admin_Content_SiteEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="Server">
    修改站点
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="optionhead"></div>
    <div class="popmbd">
        <table>
            <colgroup>
                <col style="width: 80px; vertical-align: top; padding-top: 3px;" />
                <col style="font-weight: normal" />
            </colgroup>
            <tr>
                <th>
                    站点名称：
                </th>
                <td>
                    <asp:TextBox ID="txtName" Width="300px" CssClass="text" runat="server" MaxLength="50"></asp:TextBox>
                    <sw:Validator ID="val2" ControlID="txtName" ValidateType="Required" ErrorMessage="请填写站点名称"
                        runat="server">
                    </sw:Validator>
                </td>
            </tr>
            <tr>
                <th>
                    访问域名：
                </th>
                <td>
                    <asp:TextBox ID="txtUrl" runat="server" CssClass="text" Width="300px" MaxLength="50">http://</asp:TextBox>
                    <sw:Validator ID="val1" ControlID="txtUrl" ValidateType="Required" ErrorMessage="请填写访问域名"
                        runat="server">
                    </sw:Validator>
                </td>
            </tr>
            <tr>
                <th>
                    目录名称：
                </th>
                <td>
                    <asp:Label ID="lblPath" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    站点描述：
                </th>
                <td>
                    <asp:TextBox ID="txtDesc" Width="300px" CssClass="text" TextMode="MultiLine" Height="100px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div class="popmft">
        <button id="Saving" type="button" style="display:none;" disabled="disabled">正在保存</button>
        <button id="btnStart" type="submit">
            保存站点</button>
        <button type="button" onclick="parent.disablePopup()">
            取消退出</button>
    </div>
</asp:Content>
