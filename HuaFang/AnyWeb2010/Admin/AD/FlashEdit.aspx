<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="FlashEdit.aspx.cs" Inherits="Admin_FlashEdit" Title="修改幻灯图片" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                修改图片</h3>
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
                <div class="cont">
                    <asp:FileUpload ID="fileUpload" Width="400px" runat="server" CssClass="text" /><br />
                    <asp:Image ID="imgPicture" runat="server" Width="100px" Height="65px" /></div>
            </div>
            <div class="fi even">
                <label>
                    图片描述：</label>
                <div class="cont">
                    <asp:TextBox ID="txtDesc" TextMode="MultiLine" Width="400px" Height="150px" runat="server"></asp:TextBox>
                    <span>图片描述不得超过200字。</span>
                    <sw:Validator ID="Validator3" ControlID="txtDesc" ValidateType="MaxLength" MaxLength="200"
                        ErrorText="图片描述不得超过200字" ErrorMessage="图片描述不得超过200字" runat="server">
                    </sw:Validator>
                </div>
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
            <li>图片应小于150k，jpg或gif格式。建议为690x375像素。</li>
        </ul>
    </div>
</asp:Content>
