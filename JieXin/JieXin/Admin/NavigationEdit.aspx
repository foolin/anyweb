<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="NavigationEdit.aspx.cs" Inherits="Admin_NavigationEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">

    <script type="text/javascript">
        function ChangeType() 
        {
            switch ($("#<%=drpType.ClientID %>").val()) 
            {
                case "1":
                    $("#divColumn").show().attr("class", "fi");
                    $("#divTitle").attr("class", "fi even");
                    $("#divLink").hide();
                    break;
                case "2":
                    $("#divColumn").hide();
                    $("#divTitle").attr("class", "fi");
                    $("#divLink").hide();
                    break;
                case "3": ;
                    $("#divColumn").hide();
                    $("#divTitle").attr("class", "fi");
                    $("#divLink").show().attr("class", "fi even");
                    break;
            }
        }

        function CheckLink() 
        {
            if ($("#divLink").css("display") != "none") 
            {
                if ($("#<%=txtLink.ClientID %>").val().length > 0) 
                {
                    return true;
                } 
                else 
                {
                    return false;
                }
            } 
            else 
            {
                return true;
            }
        }
        
        $(document).ready(function() 
        {
            ChangeType();
        });
    </script>

    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                添加导航栏</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    父级导航栏：</label>
                <asp:DropDownList ID="drpParent" runat="server">
                    <asp:ListItem Value="0">没有父级导航栏</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="fi even">
                <label>
                    导航分类：</label>
                <asp:DropDownList ID="drpType" runat="server" onchange="ChangeType()">
                    <asp:ListItem Value="1" Text="文章栏目"></asp:ListItem>
                    <asp:ListItem Value="2" Text="最新招聘"></asp:ListItem>
                    <asp:ListItem Value="3" Text="自定义链接"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div id="divColumn" class="fi">
                <label>
                    文章栏目：</label>
                <asp:DropDownList ID="drpColumn" runat="server">
                </asp:DropDownList>
            </div>
            <div id="divTitle" class="fi even">
                <label>
                    导航文字：</label>
                <asp:TextBox ID="txtTitle" MaxLength="100" runat="server" CssClass="text"></asp:TextBox>
                <sw:Validator ID="Validator1" ControlID="txtTitle" ValidateType="Required" ErrorText="请输入导航文字"
                    ErrorMessage="请输入导航文字" runat="server">
                </sw:Validator>
            </div>
            <div id="divLink" class="fi" style="display: none;">
                <label>
                    导航链接：</label>
                <asp:TextBox ID="txtLink" MaxLength="200" runat="server" CssClass="text"></asp:TextBox>
                <sw:Validator ID="Validator2" ControlID="txtLink" ValidateType="Custom" ErrorText="请输入导航链接"
                    ErrorMessage="请输入导航链接" Expression="CheckLink()" runat="server">
                </sw:Validator>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存" CssClass="submit" OnClick="btnOk_Click">
                </asp:Button>
                <a href="NavigationList.aspx">返回列表</a>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
