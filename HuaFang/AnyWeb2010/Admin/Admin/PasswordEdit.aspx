<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="PasswordEdit.aspx.cs" Inherits="Admin_PasswordEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                修改密码</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    旧密码：</label>
                <asp:TextBox ID="txtOld" MaxLength="50" runat="server" CssClass="text" TextMode="Password"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator3" ControlID="txtOld" ValidateType="Required" ErrorText="请输入旧密码"
                    ErrorMessage="请输入旧密码" runat="server">
                </sw:Validator>
            </div>
            <div class="fi even">
                <label>
                    新密码：</label>
                <asp:TextBox ID="txtNew" MaxLength="50" runat="server" CssClass="text" TextMode="Password"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator2" ControlID="txtNew" ValidateType="Required" ErrorText="请输入新密码"
                    ErrorMessage="请输入新密码" runat="server">
                </sw:Validator>
            </div>
            <div class="fi">
                <label>
                    密码确认：</label>
                <asp:TextBox ID="txtConfirm" MaxLength="50" runat="server" CssClass="text" TextMode="Password"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator1" ControlID="txtConfirm" ValidateType="Custom" Expression="checkConfirmPwd()"
                    ErrorText="两次密码输入不相同" ErrorMessage="两次密码输入不相同" runat="server">
                </sw:Validator>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存密码" OnClick="btnOk_Click" CssClass="submit">
                </asp:Button>
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

    <script type="text/javascript">
        function checkConfirmPwd()
        {
            if($("#<%=txtConfirm.ClientID%>").val() == "")
                return false;
            else if($("#<%=txtConfirm.ClientID%>").val() == $("#<%=txtNew.ClientID%>").val())
                return true;
            else
                return false;
        }
    </script>

</asp:Content>
