<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" 
CodeFile="LibraryEdit.aspx.cs" Inherits="Admin_LibraryEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                修改名人/品牌</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    分类：</label>
                <asp:DropDownList ID="drpLibrary" runat="server">
                    <asp:ListItem Text="名人库" Value="1"></asp:ListItem>
                    <asp:ListItem Text="品牌库" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="fi">
                <label>
                    名称：</label>
                <asp:TextBox ID="txtLibrName" Width="400px" runat="server" CssClass="text"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator1" ControlID="txtLibrName" ValidateType="Required" ErrorText="请输入名称"
                    ErrorMessage="请输入名称" runat="server">
                </sw:Validator>
            </div>
            <div class="fi">
                <label>
                    英文名称：</label>
                <asp:TextBox ID="txtLibrEnName" Width="400px" runat="server" CssClass="text"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator2" ControlID="txtLibrEnName" ValidateType="Required" ErrorText="请输入英文名称"
                    ErrorMessage="请输入英文名称" runat="server">
                </sw:Validator>
            </div>
            <div class="fi">
                <label>
                    首字母：</label>
                <asp:DropDownList ID="drpFirstLetter" runat="server">
                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                    <asp:ListItem Text="B" Value="B"></asp:ListItem>
                    <asp:ListItem Text="C" Value="C"></asp:ListItem>
                    <asp:ListItem Text="D" Value="D"></asp:ListItem>
                    <asp:ListItem Text="E" Value="E"></asp:ListItem>
                    <asp:ListItem Text="F" Value="F"></asp:ListItem>
                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                    <asp:ListItem Text="H" Value="H"></asp:ListItem>
                    <asp:ListItem Text="I" Value="I"></asp:ListItem>
                    <asp:ListItem Text="J" Value="J"></asp:ListItem>
                    <asp:ListItem Text="K" Value="K"></asp:ListItem>
                    <asp:ListItem Text="L" Value="L"></asp:ListItem>
                    <asp:ListItem Text="M" Value="M"></asp:ListItem>
                    <asp:ListItem Text="N" Value="N"></asp:ListItem>
                    <asp:ListItem Text="O" Value="O"></asp:ListItem>
                    <asp:ListItem Text="P" Value="P"></asp:ListItem>
                    <asp:ListItem Text="Q" Value="Q"></asp:ListItem>
                    <asp:ListItem Text="R" Value="R"></asp:ListItem>
                    <asp:ListItem Text="S" Value="S"></asp:ListItem>
                    <asp:ListItem Text="T" Value="T"></asp:ListItem>
                    <asp:ListItem Text="U" Value="U"></asp:ListItem>
                    <asp:ListItem Text="V" Value="V"></asp:ListItem>
                    <asp:ListItem Text="W" Value="W"></asp:ListItem>
                    <asp:ListItem Text="X" Value="X"></asp:ListItem>
                    <asp:ListItem Text="Y" Value="Y"></asp:ListItem>
                    <asp:ListItem Text="Z" Value="Z"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="fi even">
                <label>
                    介绍：</label>
                <div class="cont">
                    <asp:TextBox ID="txtLibrDesc" TextMode="MultiLine" Width="100%" Height="300px" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="fi even">
                <label>
                    排序：</label>
                <asp:TextBox ID="txtLibrOrder" runat="server" Text="0" CssClass="text" Width="80"></asp:TextBox>
                <span class="required">*</span> <span>排序数字越大，呈现位置越靠前。</span>
                <sw:Validator ID="Validator3" ControlID="txtLibrSort" ValidateType="Required" ErrorText="请输入排序"
                    ErrorMessage="请输入排序" runat="server">
                </sw:Validator>
                <sw:Validator ID="Validator4" ControlID="txtLibrSort" ValidateType="DataType" DataType="Integer"
                    ErrorText="请输入正确的排序" ErrorMessage="请输入正确的排序" runat="server">
                </sw:Validator>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存" CssClass="submit" OnClick="btnOk_Click">
                </asp:Button>
                <a href="LibraryList.aspx">返回列表</a>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>排序为“0”时将由系统自动生成。</li>
        </ul>
    </div>

</asp:Content>



