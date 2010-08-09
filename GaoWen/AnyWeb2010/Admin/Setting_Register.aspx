<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="Setting_Register.aspx.cs" Inherits="Admin_Setting_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                用户注册</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    注册开关：</label>
                <div class="cont">
                    <asp:CheckBox ID="boxEnable" runat="server" Text="允许" CssClass="checkbox" /></div>
            </div>
            <div class="fi even">
                <label>
                    注册协议：</label>
                <asp:TextBox ID="txtAgreement" runat="server" CssClass="text" Height="120px" Width="400px"
                    TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="fi">
                <label>
                    Email 允许地址：</label>
                <asp:TextBox ID="txtEmailEnable" runat="server" CssClass="text" Height="120px" Width="400px"
                    TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="fi even">
                <label>
                    Email 禁止地址：</label>
                <asp:TextBox ID="txtEmailBlocked" runat="server" CssClass="text" Height="120px" Width="400px"
                    TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="fi">
                <label>
                    手机注册：</label>
                <div class="cont">
                    <asp:CheckBox ID="boxMobileReg" runat="server" Text="允许" CssClass="checkbox" /></div>
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
            <li></li>
        </ul>
    </div>
</asp:Content>
