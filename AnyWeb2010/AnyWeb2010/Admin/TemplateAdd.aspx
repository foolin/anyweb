<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="TemplateAdd.aspx.cs" Inherits="Admin_TemplateAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
    <script type="text/javascript">
        function check() {
            if ($("#<%=drpType.ClientID %>").val() == 4) {
                if ($("#<%=txtPath.ClientID %>").val() == "") {
                    return false;
                }
                else if ($("#<%=txtPath.ClientID %>").val().substring(0, 1) != "/") {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
        }
        function changetype(obj) {
            if (obj == 4) {
                $("#divPath").show();
            }
            else {
                $("#divPath").hide();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                添加模版</h3>
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
                    <asp:ListItem Value="1">首页模版</asp:ListItem>
                    <asp:ListItem Value="2">内容模版</asp:ListItem>
                    <asp:ListItem Value="3">嵌套模版</asp:ListItem>
                    <asp:ListItem Value="4">扩展模版</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="fi" id="divPath" style="display:none">
                <label>
                    访问地址：</label>
                <asp:TextBox ID="txtPath" MaxLength="100" Width="400px" runat="server" CssClass="text"></asp:TextBox>
                (例如:index,不能以“/”开头,且不能与已有模版重复) 
                <span class="required">*</span>
                <sw:Validator ID="Validator2" ControlID="txtPath" ValidateType="Custom" Expression="check()" ErrorText="请输入正确的访问地址"
                    ErrorMessage="请输入正确的访问地址" runat="server">
                </sw:Validator>
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

