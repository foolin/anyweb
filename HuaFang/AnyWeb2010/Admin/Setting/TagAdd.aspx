<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="TagAdd.aspx.cs" Inherits="Admin_TagAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                添加标签</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    标签：</label>
                <asp:TextBox ID="txtTitle" MaxLength="50" Width="200px" runat="server" CssClass="text"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator1" ControlID="txtTitle" ValidateType="Required" ErrorText="请输入标签"
                    ErrorMessage="请输入标签" runat="server">
                </sw:Validator>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存" CssClass="submit" OnClick="btnOk_Click">
                </asp:Button>
                <a href="TagList.aspx">返回列表</a>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>

