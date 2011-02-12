<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="CategoryEdit.aspx.cs" Inherits="Admin_CategoryEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                修改分类</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    上级分类：</label>
                <asp:DropDownList ID="drpParent" runat="server">
                    <asp:ListItem Value="">请选择</asp:ListItem>
                    <asp:ListItem Value="0">没有上级分类</asp:ListItem>
                </asp:DropDownList>
                <span class="required">*</span>
                <sw:Validator ID="Validator1" ControlID="drpParent" ValidateType="Required" ErrorText="请选择上级分类"
                    ErrorMessage="请选择上级分类" runat="server">
                </sw:Validator>
            </div>
            <div class="fi even">
                <label>
                    分类名称：</label>
                <asp:TextBox ID="txtName" MaxLength="50" runat="server" CssClass="text"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator5" ControlID="txtName" ValidateType="Required" ErrorText="请输入分类名称"
                    ErrorMessage="请输入分类名称" runat="server">
                </sw:Validator>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存分类" OnClick="btnOk_Click" CssClass="submit">
                </asp:Button>
                <a href="categorylist.aspx">返回列表</a>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>访问路径不能重复，允许使用英文或数字的组合，不允许使用符合或纯数字，可设置为商品的英文单词，例如"mobile",则商城前台可以通过"/category-mobile.aspx"访问该分类列表.</li>
            <li>只有一级分类才允许顶部导航显示</li>
            <li>具有子分类的分类不能改变父级</li>
        </ul>
    </div>
</asp:Content>
