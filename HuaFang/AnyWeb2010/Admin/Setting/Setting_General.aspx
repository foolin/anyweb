<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="Setting_General.aspx.cs" Inherits="Admin_Setting_General" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                基本配置</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    网站名称：</label>
                <asp:TextBox ID="txtShopName" runat="server" CssClass="text" require="1" errmsg="请输入商城名称"></asp:TextBox>
            </div>
            <div class="fi even">
                <label>
                    公司名称：</label>
                <asp:TextBox ID="txtCompanyName" runat="server" CssClass="text" require="0" errmsg="请输入公司名称"></asp:TextBox>
            </div>
            <div class="fi">
                <label>
                    地址：</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="text" require="0" errmsg="请输入地址"
                    Width="400px"></asp:TextBox>
            </div>
            <div class="fi even">
                <label>
                    邮编：</label>
                <asp:TextBox ID="txtPostcode" runat="server" CssClass="text" require="0" errmsg="请输入邮编"></asp:TextBox>
            </div>
            <div class="fi">
                <label>
                    电话：</label>
                <asp:TextBox ID="txtTel" runat="server" CssClass="text" require="0" errmsg="请输入电话"></asp:TextBox>
            </div>
            <div class="fi even">
                <label>
                    传真：</label>
                <asp:TextBox ID="txtFax" runat="server" CssClass="text" require="0" errmsg="请输入传真"></asp:TextBox>
            </div>
            <div class="fi">
                <label>
                    手机：</label>
                <asp:TextBox ID="txtMobile" runat="server" CssClass="text" require="0" errmsg="请输入手机"></asp:TextBox>
            </div>
            <div class="fi even">
                <label>
                    QQ：</label>
                <asp:TextBox ID="txtQQ" runat="server" CssClass="text" require="0" errmsg="请输入QQ"></asp:TextBox>
            </div>
            <div class="fi">
                <label>
                    MSN：</label>
                <asp:TextBox ID="txtMsn" runat="server" CssClass="text" require="0" errmsg="请输入MSN"></asp:TextBox>
            </div>
            <div class="fi even">
                <label>
                    邮件：</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="text" require="0" errmsg="请输入邮件"></asp:TextBox>
            </div>
            <div class="fi">
                <label>
                    网站备案代码：</label>
                <asp:TextBox ID="txtIcp" MaxLength="2000" runat="server" CssClass="text" require="1"
                    Height="120px" Width="400px" errmsg="请输入品站备备案" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存配置" OnClick="btnOk_Click" CssClass="submit">
                </asp:Button>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>.</li>
        </ul>
    </div>
</asp:Content>
