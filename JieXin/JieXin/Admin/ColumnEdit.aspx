﻿<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="ColumnEdit.aspx.cs" Inherits="Admin_ColumnEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                修改新闻栏目</h3>
        </div>
        <div class="mbd">
            <div class="fi even">
                <label>
                    父级栏目：</label>
                <asp:DropDownList ID="drpParent" runat="server">
                </asp:DropDownList>
                <sw:Validator ID="Validator2" ControlID="drpParent" ValidateType="Required" ErrorText="请选择父级栏目"
                    ErrorMessage="请选择父级栏目" runat="server">
                </sw:Validator>
            </div>
            <div class="fi">
                <label>
                    栏目名称：</label>
                <asp:TextBox ID="txtName" MaxLength="100" runat="server" CssClass="text"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator1" ControlID="txtName" ValidateType="Required" ErrorText="请输入栏目名"
                    ErrorMessage="请输入栏目名" runat="server">
                </sw:Validator>
            </div>
            <div class="fi even">
                <label>
                    栏目描述：</label>
                <asp:TextBox ID="txtDesc" MaxLength="200" Width="400px" Height="120px" TextMode="MultiLine"
                    runat="server" CssClass="text"></asp:TextBox>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存" CssClass="submit" OnClick="btnOk_Click">
                </asp:Button>
                <a href="ColumnList.aspx">返回列表</a>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>如果栏目图片为空，在前台将会自动显示该父级栏目的图片</li>
        </ul>
    </div>
</asp:Content>
