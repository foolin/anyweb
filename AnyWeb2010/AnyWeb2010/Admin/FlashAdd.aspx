<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="FlashAdd.aspx.cs" Inherits="Admin_FlashAdd" Title="添加幻灯图片" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                添加图片</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    图片名称：</label>
                <asp:TextBox ID="txtName" MaxLength="100" runat="server" CssClass="text"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator5" ControlID="txtName" ValidateType="Required" ErrorText="请输入图片名称"
                    ErrorMessage="请输入图片名称" runat="server">
                </sw:Validator>
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
                <asp:FileUpload ID="fileUpload" runat="server" CssClass="text" Width="400px" />
                <span class="required">*</span>
                <sw:Validator ID="Validator2" ControlID="fileUpload" ValidateType="Required" ErrorText="请上传图片文件"
                    ErrorMessage="请上传图片文件" runat="server">
                </sw:Validator>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存图片" OnClick="btnOk_Click" CssClass="submit">
                </asp:Button>
                <a href="FlashList.aspx">返回列表</a>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>图片应小于500k，jpg或gif格式。建议为<%=AnyWeb.AW.Configs.GeneralConfigs.GetConfig().FlashWidth%>x<%=AnyWeb.AW.Configs.GeneralConfigs.GetConfig().FlashHeight%>像素。</li>
        </ul>
    </div>
</asp:Content>
