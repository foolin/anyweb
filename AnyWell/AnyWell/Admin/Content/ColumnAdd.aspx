﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/CenterPopup.master"
    AutoEventWireup="true" CodeFile="ColumnAdd.aspx.cs" Inherits="Admin_Content_ColumnAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="Server">
    添加栏目
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="blank20px"></div>
    <div class="optionhead">
        <div id="option1" class="selected" onclick="selectOption('option','optiondiv',1);">
            常规</div>
        <div id="option2" onclick="selectOption('option','optiondiv',2);">
            高级</div>
    </div>
    <div class="popmbd">
        <table id="optiondiv1">
            <colgroup>
                <col style="width: 80px; vertical-align: top; padding-top: 3px;" />
                <col style="font-weight: normal" />
            </colgroup>
            <tr>
                <th>
                    上级栏目：
                </th>
                <td>
                    <asp:Label ID="lblParent" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    栏目名称：
                </th>
                <td>
                    <asp:TextBox ID="txtName" Width="300px" CssClass="text" runat="server" MaxLength="50"></asp:TextBox>
                    <sw:Validator ID="val2" ControlID="txtName" ValidateType="Required" ErrorMessage="请填写栏目名称"
                        runat="server">
                    </sw:Validator>
                </td>
            </tr>
            <tr>
                <th>
                    栏目类型：
                </th>
                <td>
                    <asp:DropDownList ID="drpType" runat="server">
                        <asp:ListItem Value="0">文档栏目</asp:ListItem>
                        <asp:ListItem Value="1">图片栏目</asp:ListItem>
                        <asp:ListItem Value="2">产品栏目</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    栏目说明：
                </th>
                <td>
                    <asp:TextBox ID="txtDesc" Width="300px" CssClass="text" TextMode="MultiLine" Height="100px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table id="optiondiv2" style="display:none">
            <colgroup>
                <col style="width: 80px; vertical-align: top; padding-top: 3px;" />
                <col style="font-weight: normal" />
            </colgroup>
            <tr>
                <th>
                    栏目大图：
                </th>
                <td>
                    <asp:FileUpload ID="filePicture" runat="server" CssClass="file" /><span>（120×120）</span>
                </td>
            </tr>
            <tr>
                <th>
                    栏目小图：
                </th>
                <td>
                    <asp:FileUpload ID="fileIcon" runat="server" CssClass="file" /><span>（32×32）</span>
                </td>
            </tr>
        </table>
    </div>
    <div class="popmft">
        <button id="btnStart" type="submit">
            保存站点</button>
        <button type="button" onclick="parent.disablePopup()">
            取消退出</button>
    </div>
</asp:Content>
