<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="ColumnEdit.aspx.cs" Inherits="Admin_ColumnEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                修改新闻栏目</h3>
        </div>
        <div class="mbd">
            <div class="fi even">
                <label>
                    父级栏目：</label>
                <asp:DropDownList ID="drpParent" runat="server">
                    <asp:ListItem Value="0">没有上级栏目</asp:ListItem>
                </asp:DropDownList>
                <sw:Validator ID="Validator2" ControlID="drpParent" ValidateType="Required" ErrorText="请选择父级栏目"
                    ErrorMessage="请选择父级栏目" runat="server">
                </sw:Validator>
            </div>
            <div class="fi">
                <label>
                    栏目名称：</label>
                <asp:TextBox ID="txtName" MaxLength="100" runat="server" CssClass="text"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator1" ControlID="txtName" ValidateType="Required" ErrorText="请输入栏目名"
                    ErrorMessage="请输入栏目名" runat="server">
                </sw:Validator>
            </div>
            <div class="fi">
                <label>
                    栏目描述：</label>
                <asp:TextBox ID="txtDesc" MaxLength="200" Width="400px" Height="120px" TextMode="MultiLine"
                    runat="server" CssClass="text"></asp:TextBox>
            </div>
            <div class="fi even">
                <label>
                    首页显示：</label>
                <label style="float: none">
                    <input id="chkShowIndex" name="chkShowIndex" type="checkbox" checked="checked" value="1"
                        runat="server" />显示</label>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存" CssClass="submit" OnClick="btnOk_Click">
                </asp:Button>
                <a href="ColumnList.aspx">返回列表</a>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>访问路径不能重复，允许使用英文或数字的组合，不允许使用符合或纯数字，可设置为栏目的英文单词，例如"market",则商城前台可以通过"/newslist-market.aspx"访问列表.</li>
        </ul>
    </div>
</asp:Content>
