<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="HelpTypeAdd.aspx.cs" Inherits="Admin_HelpTypeAdd" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                添加帮助分类</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    分类名称：</label>
                <asp:TextBox ID="txtName" MaxLength="100" runat="server" CssClass="text"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator5" ControlID="txtName" ValidateType="Required" ErrorText="请输入分类名称"
                    ErrorMessage="请输入分类名称" runat="server">
                </sw:Validator>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存分类" OnClick="btnOk_Click" CssClass="submit">
                </asp:Button>
                <a href="HelpTypeList.aspx">返回列表</a>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>该页实现帮助分类的添加</li>
        </ul>
    </div>
</asp:Content>
