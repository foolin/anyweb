<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="KeyWordAdd.aspx.cs" Inherits="Admin_KeyWordAdd" Title="添加关键字" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                添加关键字</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    关键字：</label>
                <asp:TextBox ID="txtName" MaxLength="6" runat="server" CssClass="text" Width="80px"></asp:TextBox>
                <sw:Validator ID="v1" ControlID="txtName" ValidateType="Required" ErrorText="关键字不能为空"
                    ErrorMessage="关键字不能为空" runat="server">
                </sw:Validator>
            </div>
            <div class="fi even">
                <label>
                    排序号：</label>
                <asp:TextBox ID="txtSort" MaxLength="6" runat="server" CssClass="text" Width="80px"></asp:TextBox>
                <sw:Validator ID="v2" ControlID="txtSort" ValidateType="DataType" DataType="Number"
                    ErrorText="排序号不正确" ErrorMessage="排序号不正确" runat="server">
                </sw:Validator>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存" CssClass="submit" OnClick="btnOk_Click">
                </asp:Button>
                <a href="KeyWordList.aspx">返回列表</a>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>添加前台热门搜索关键字</li>
        </ul>
    </div>
</asp:Content>
