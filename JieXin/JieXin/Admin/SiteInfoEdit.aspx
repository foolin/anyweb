<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="SiteInfoEdit.aspx.cs" Inherits="Admin_SiteInfoEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <script type="text/javascript" src="/tiny_mce/tiny_mce.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                修改基本信息</h3>
        </div>
        <div class="mbd">
            <div class="fi even">
                <label>
                    标题：</label>
                <asp:TextBox ID="txtTitle" MaxLength="100" Width="400px" runat="server" CssClass="text" ReadOnly="true"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator2" ControlID="txtTitle" ValidateType="Required" ErrorText="请输入标题"
                    ErrorMessage="请输入标题" runat="server">
                </sw:Validator>
            </div>
            <div class="fi">
                <label>
                    内容：</label>
                <div class="cont">
                    <sw:TinyMce ID="txtContent" runat="server" />
                </div>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存" OnClick="btnOk_Click" CssClass="submit">
                </asp:Button>
                <a href="SiteInfoList.aspx">返回列表</a>
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
