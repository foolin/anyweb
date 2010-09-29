<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="KeyWordAdd.aspx.cs" Inherits="Admin_KeyWordAdd" Title="添加关键字" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm">
        <div class="mhd">
            <h3>
                添加关键词</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    关键词：</label>
                <asp:TextBox ID="txtName" MaxLength="50" runat="server" CssClass="text" Width="80px"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator2" ControlID="txtName" ValidateType="Required" ErrorText="关键词不能为空"
                    ErrorMessage="关键词不能为空" runat="server">
                </sw:Validator>
            </div>
            <div class="fi even">
                <label>
                    排序：</label>
                <asp:TextBox ID="txtSort" MaxLength="9" Text="0" runat="server" CssClass="text" Width="80px"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator1" ControlID="txtSort" ValidateType="Required" ErrorText="请输入排序"
                    ErrorMessage="请输入排序" runat="server">
                </sw:Validator>
                <sw:Validator ID="Validator4" ControlID="txtSort" ValidateType="DataType" DataType="Integer"
                    ErrorText="请输入正确的排序" ErrorMessage="请输入正确的排序" runat="server">
                </sw:Validator>
            </div>
            <div>
                <label>
                    是否显示：</label>
                <input type="checkbox" id="chkStatus" runat="server" checked="checked" />显示
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="Button1" runat="server" Text="保存" CssClass="submit" OnClick="btnOk_Click">
                </asp:Button>
                <a href="KeyWordList.aspx">返回列表</a>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>添加前台热门搜索关键词</li>
            <li>排序为“0”时将由系统自动生成。</li>
        </ul>
    </div>
</asp:Content>
