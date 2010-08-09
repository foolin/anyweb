<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="AdminAdd.aspx.cs" Inherits="Admin_AdminAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                添加用户</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    登录帐号：</label>
                <asp:TextBox ID="txtAcc" MaxLength="50" runat="server" CssClass="text"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator5" ControlID="txtAcc" ValidateType="Required" ErrorText="请输入登录帐号"
                    ErrorMessage="请输入登录帐号" runat="server">
                </sw:Validator>
            </div>
            <div class="fi even">
                <label>
                    用户名称：</label>
                <asp:TextBox ID="txtName" MaxLength="50" runat="server" CssClass="text"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator3" ControlID="txtName" ValidateType="Required" ErrorText="请输入用户名称"
                    ErrorMessage="请输入用户名称" runat="server">
                </sw:Validator>
            </div>
            <div class="fi">
                <label>
                    登录密码：</label>
                <asp:TextBox ID="txtPwd" MaxLength="50" runat="server" CssClass="text" TextMode="Password"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator1" ControlID="txtPwd" ValidateType="Required" ErrorText="请输入登录密码"
                    ErrorMessage="请输入登录密码" runat="server">
                </sw:Validator>
            </div>
            <div class="fi even">
                <label>
                    用户级别：</label>
                <div class="cont">
                    <asp:RadioButton ID="radio1" runat="server" GroupName="level" Text="超管" CssClass="checkbox" />
                    <asp:RadioButton ID="radio2" runat="server" GroupName="level" Text="普通" Checked="true"
                        CssClass="checkbox" />
                </div>
            </div>
            <div class="fi" id="purviewArea" runat="server">
                <label>
                    用户权限：</label>
                <div class="cont">
                    <asp:Repeater ID="repPurviews" runat="server">
                        <ItemTemplate>
                            <div style="margin-bottom: 15px;">
                                <label class="checkbox">
                                    <input type="checkbox" name="purviews" value="<%#Eval("ID")%>" onclick="checkChildren(this)" /><strong><%#Eval("Name")%></strong></label>
                                <div style="">
                                    <asp:Repeater ID="repChildren" runat="server" DataSource='<%#Eval("Children")%>'
                                        OnItemDataBound="repChildren_OnItemDataBound">
                                        <ItemTemplate>
                                            <label class="checkbox">
                                                <input type="checkbox" name="purviews" value="<%#Eval("ID")%>" /><%#Eval("Name")%></label>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>

            <script type="text/javascript">
                        function checkChildren(box)
                        {
                                $(box).parent("label").parent("div").find("div input").attr("checked",$(box).attr("checked"));
                        }
            </script>

            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存用户" OnClick="btnOk_Click" CssClass="submit">
                </asp:Button>
                <a href="adminlist.aspx">返回列表</a>
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
