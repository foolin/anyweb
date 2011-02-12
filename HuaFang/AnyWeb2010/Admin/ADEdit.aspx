<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="ADEdit.aspx.cs" Inherits="Admin_ADEdit" Title="修改首页广告" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                修改首页广告</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    广告名称：</label>
                <asp:TextBox ID="txtName" MaxLength="100" runat="server" CssClass="text" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="fi even">
                <label>
                    链接地址：</label>
                <asp:TextBox ID="txtUrl" MaxLength="200" runat="server" CssClass="text"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator1" ControlID="txtUrl" ValidateType="Required" ErrorText="请输入链接地址"
                    ErrorMessage="请输入链接地址" runat="server">
                </sw:Validator>
            </div>
            <div class="fi">
                <label>
                    图片文件：</label>
                <div class="cont">
                    <asp:FileUpload ID="fileUpload" Width="400px" runat="server" CssClass="text" /><br />
                    <asp:Image ID="imgPicture" runat="server" Width="100px" Height="65px" /></div>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存图片" OnClick="btnOk_Click" CssClass="submit">
                </asp:Button>
                <a href="ADList.aspx">返回列表</a>
            </div>
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
