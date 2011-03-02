<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="HelpTypeEdit.aspx.cs" Inherits="Admin_HelpTypeEdit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                修改帮助分类</h3>
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
            <li>如果需要修改该分类排序请进入列表页进行上移下移操作</li>
        </ul>
    </div>
</asp:Content>
