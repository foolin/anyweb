<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/Content.master" AutoEventWireup="true"
    CodeFile="ExhibitorAdd.aspx.cs" Inherits="Admin_Exhibitor_ExhibitorAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="Server">
    新建展商

    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%=txtContent.ClientID %>_txt").height(document.documentElement.clientHeight - 130);
        });

        function disableButton() {
            $("#<%=btnSaveAndContinue.ClientID %>").hide();
            $("#<%=btnSave.ClientID %>").hide();
            $("#Saving").show();
            return true;
        }

        function enableButton() {
            $("#<%=btnSaveAndContinue.ClientID %>").show();
            $("#<%=btnSave.ClientID %>").show();
            $("#Saving").hide();
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <ul>
        <li>公司名称：
            <asp:TextBox ID="txtName" runat="server" Width="300" CssClass="text" MaxLength="50"></asp:TextBox>
            <sw:Validator ID="val1" ControlID="txtName" ValidateType="Required" ErrorMessage="请填写公司名称"
                runat="server">
            </sw:Validator>
            类型：
            <asp:DropDownList ID="drpType" runat="server">
                <asp:ListItem Value="1">黑色家电</asp:ListItem>
                <asp:ListItem Value="2">白色家电</asp:ListItem>
                <asp:ListItem Value="3">小家电</asp:ListItem>
                <asp:ListItem Value="4">厨房及浴室家电</asp:ListItem>
                <asp:ListItem Value="5">家电配件</asp:ListItem>
                <asp:ListItem Value="6">水家电</asp:ListItem>
                <asp:ListItem Value="7">服务及刊物</asp:ListItem>
            </asp:DropDownList>
        </li>
        <li>所属栏目：<asp:Label ID="lblColumn" runat="server"></asp:Label></li>
        <li>展商简介：
            <sw:TinyMce ID="txtContent" runat="server" />
        </li>
    </ul>
    <div class="mft">
        <button id="Saving" type="button" style="display: none;" disabled="disabled">
            正在保存</button>
        <asp:Button ID="btnSaveAndContinue" CssClass="button" runat="server" Text="保存继续"
            OnClick="btnSaveAndContinue_Click" />
        <asp:Button ID="btnSave" CssClass="button" runat="server" Text="保存退出" OnClick="btnSave_Click" />
        <button type="button" onclick="window.close()">
            取消退出</button>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphOpr" runat="Server">
    <div class="operation" id="folder_options">
        <h3 class="opr-mhd">
            <a href="javascript:showFolder('folder_options')">
                <img src="../images/icons/arrow2.gif" /></a>高级选项</h3>
        <div class="opr-mbd">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        英文名称：
                    </td>
                    <td>
                        <asp:TextBox ID="txtEnName" runat="server" Width="165" CssClass="text" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        展位号：
                    </td>
                    <td>
                        <asp:TextBox ID="txtNumber" runat="server" Width="165" CssClass="text" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        网址：
                    </td>
                    <td>
                        <asp:TextBox ID="txtUrl" runat="server" Width="165" CssClass="text" MaxLength="200"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        排序：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtSort" CssClass="text" MaxLength="10" Width="50px"
                            Text="0"></asp:TextBox>
                        为0则系统自动生成。
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
