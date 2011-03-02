<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="HelpEdit.aspx.cs" Inherits="Admin_HelpEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">

    <script type="text/javascript" src="/tiny_mce/tiny_mce.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                修改帮助信息</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    分类：</label>
                <asp:DropDownList ID="compType" DataValueField="fdTypeID" DataTextField="fdTypeName"
                    runat="server">
                </asp:DropDownList>
                <span class="required">*</span>
                <sw:Validator ID="Validator1" ControlID="compType" ValidateType="Required" ErrorText="请选择分类"
                    ErrorMessage="请选择分类" runat="server">
                </sw:Validator>
            </div>
            <div class="fi even">
                <label>
                    问题：</label>
                <asp:TextBox ID="compQuestion" MaxLength="100" Width="400px" runat="server" CssClass="text"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator2" ControlID="compQuestion" ValidateType="Required" ErrorText="请输入问题"
                    ErrorMessage="请输入问题" runat="server">
                </sw:Validator>
            </div>
            <div class="fi">
                <label>
                    回答：</label>
                <div class="cont">
                    <sw:TinyMce ID="compAnswer" runat="server" />
                </div>
                <sw:Validator ID="Validator3" ControlID="compAnswer" ValidateType="Required" ErrorText="请输入回答"
                    ErrorMessage="请输入回答" runat="server">
                </sw:Validator>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存" OnClick="btnOk_Click" CssClass="submit">
                </asp:Button>
                <a href="HelpList.aspx">返回列表</a>
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
