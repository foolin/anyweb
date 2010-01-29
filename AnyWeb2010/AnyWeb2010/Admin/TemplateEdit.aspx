<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="TemplateEdit.aspx.cs" Inherits="Admin_TemplateEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                修改模版</h3>
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
                    模版类型：</label>
                <asp:DropDownList ID="drpType" runat="server">
                    <asp:ListItem Value="1">内容模版</asp:ListItem>
                    <asp:ListItem Value="2">嵌套模版</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="fi">
                <label>
                    模版内容：</label>
                <div class="cont">
                    <asp:TextBox ID="txtContent" TextMode="MultiLine" Width="100%" Height="300px" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存" CssClass="submit" OnClick="btnOk_Click">
                </asp:Button>
                <a href="TemplateList.aspx">返回列表</a>
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

