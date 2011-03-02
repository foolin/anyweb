<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="BrandAdd.aspx.cs" Inherits="Admin_BrandAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                添加品牌</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    上级品牌：</label>
                <asp:DropDownList ID="drpParent" runat="server">
                    <asp:ListItem Value="">请选择</asp:ListItem>
                    <asp:ListItem Value="0">没有上级品牌</asp:ListItem>
                </asp:DropDownList>
                <span class="required">*</span>
                <sw:Validator ID="Validator1" ControlID="drpParent" ValidateType="Required" ErrorText="请选择上级品牌"
                    ErrorMessage="请选择上级品牌" runat="server">
                </sw:Validator>
            </div>
            <div class="fi even">
                <label>
                    品牌名称：</label>
                <asp:TextBox ID="txtName" MaxLength="50" runat="server" CssClass="text"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator5" ControlID="txtName" ValidateType="Required" ErrorText="请输入品牌编号"
                    ErrorMessage="请输入品牌编号" runat="server">
                </sw:Validator>
            </div>
            <div class="fi">
                <label>
                    品牌图片：</label>
                <asp:FileUpload ID="filePicture" runat="server" CssClass="text" Width="400px" />
            </div>
            <div class="fi even">
                <label>
                    品牌介绍：</label>
                <asp:TextBox ID="txtIntro" MaxLength="2000" runat="server" CssClass="text" Height="180px"
                    Width="400px"></asp:TextBox>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存品牌" OnClick="btnOk_Click" CssClass="submit">
                </asp:Button>
                <a href="brandlist.aspx">返回列表</a>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>图片应小于500k，jpg或gif格式。建议为166x56像素。</li>
        </ul>
    </div>
</asp:Content>
