<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="MappingEdit.aspx.cs" Inherits="Admin_MappingEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                添加映射</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    模版名称：</label>
                <asp:TextBox ID="txtName" MaxLength="100" Width="400px" runat="server" CssClass="text"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator1" ControlID="txtName" ValidateType="Required" ErrorText="请输入模版名称"
                    ErrorMessage="请输入模版名称" runat="server">
                </sw:Validator>
            </div>
            <div class="fi even">
                <label>
                    访问路径：</label>
                <div class="cont">
                    <asp:TextBox ID="txtPath" Width="400px" runat="server" CssClass="text"></asp:TextBox>
                    <span class="required">*</span>
                    <sw:Validator ID="Validator2" ControlID="txtPath" ValidateType="Required" ErrorText="请输入访问路径"
                    ErrorMessage="请输入访问路径" runat="server">
                </sw:Validator>
                </div>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存" CssClass="submit" OnClick="btnOk_Click">
                </asp:Button>
                <a href="MappingList.aspx">返回列表</a>
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

