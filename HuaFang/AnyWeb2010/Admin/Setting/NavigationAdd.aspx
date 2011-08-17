<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="NavigationAdd.aspx.cs" Inherits="Admin_NavigationAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <script type="text/javascript">
        function ChangeType() {
            switch ($("#<%=drpType.ClientID %>").val()) {
                case "1":
                    $("#divColumn").hide();
                    $("#divSite").hide();
                    $("#divTitle").attr("class", "fi");
                    $("#divLink").hide();
                    $("#divLibrary").hide();
                    $("#<%=txtTitle.ClientID %>").val($("#<%=drpType.ClientID %>").find("option:selected").text());
                    break;
                case "2":
                    $("#divColumn").show().attr("class", "fi");
                    $("#divSite").hide();
                    $("#divTitle").attr("class", "fi even");
                    $("#divLink").hide();
                    $("#divLibrary").hide();
                    $("#<%=txtTitle.ClientID %>").val($("#<%=drpColumn.ClientID %>").find("option:selected").text());
                    break;
                case "3":
                    $("#divColumn").hide();
                    $("#divSite").show().attr("class", "fi");
                    $("#divTitle").attr("class", "fi even");
                    $("#divLink").hide();
                    $("#divLibrary").hide();
                    $("#<%=txtTitle.ClientID %>").val($("#<%=drpSite.ClientID %>").find("option:selected").text());
                    break;
                case "4":
                    $("#divColumn").hide();
                    $("#divSite").hide();
                    $("#divTitle").attr("class", "fi even");
                    $("#divLink").hide();
                    $("#divLibrary").show();
                    $("#<%=txtTitle.ClientID %>").val($("#<%=drpLibrary.ClientID %>").find("option:selected").text());
                    break;
                case "5": ;
                    $("#divColumn").hide();
                    $("#divSite").hide();
                    $("#divLibrary").hide();
                    $("#divTitle").attr("class", "fi");
                    $("#divLink").show().attr("class", "fi even");
                    $("#<%=txtTitle.ClientID %>").val($("#<%=drpType.ClientID %>").find("option:selected").text());
                    break;
            }
        }

        function ChangeColumn() {
            var name = $("#<%=drpColumn.ClientID %>").find("option:selected").text();
            if (name.indexOf("----") != -1) {
                name = name.substr(name.indexOf("----") + 4);
            }
            $("#<%=txtTitle.ClientID %>").val(name);
        }

        function ChangeSite() {
            $("#<%=txtTitle.ClientID %>").val($("#<%=drpSite.ClientID %>").find("option:selected").text());
        }

        function ChangeLibrary() {
            $("#<%=txtTitle.ClientID %>").val($("#<%=drpLibrary.ClientID %>").find("option:selected").text());
        }

        function CheckLink() {
            if ($("#divLink").css("display") != "none") {
                var url = /^http:\/\/[A-Za-z0-9\-]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/;
                if (url.test($("#<%=txtLink.ClientID %>").val())) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return true;
            }
        }
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
                    <asp:ListItem Value="1" Text="首页"></asp:ListItem>
                    <asp:ListItem Value="2" Text="文章栏目"></asp:ListItem>                
                    <asp:ListItem Value="3" Text="基本信息"></asp:ListItem>
                    <asp:ListItem Value="4" Text="两库信息"></asp:ListItem>
                    <asp:ListItem Value="5" Text="自定义链接"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div id="divColumn" class="fi" style="display:none">
                <label>
                    文章栏目：</label>
                <asp:DropDownList ID="drpColumn" runat="server" onchange="ChangeColumn()">
                </asp:DropDownList>
            </div>
            <div id="divSite" class="fi" style="display:none">
                <label>
                    信息类型：</label>
                <asp:DropDownList ID="drpSite" runat="server" onchange="ChangeSite()">
                    <asp:ListItem Text="关于我们" Value="1"></asp:ListItem>
                    <asp:ListItem Text="版权声明" Value="2"></asp:ListItem>
                    <asp:ListItem Text="联系我们" Value="3"></asp:ListItem>
                    <asp:ListItem Text="地址" Value="4"></asp:ListItem>
                    <asp:ListItem Text="电话" Value="5"></asp:ListItem>
                    <asp:ListItem Text="备案" Value="6"></asp:ListItem>
                    <asp:ListItem Text="企业介绍" Value="7"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div id="divLibrary" class="fi" style="display:none">
                <label>
                    两库：</label>
                <asp:DropDownList ID="drpLibrary" runat="server" onchange="ChangeLibrary()">
                    <asp:ListItem Text="名人库" Value="1"></asp:ListItem>
                    <asp:ListItem Text="品牌库" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div id="divTitle" class="fi even">
                <label>
                    导航文字：</label>
                <asp:TextBox ID="txtTitle" MaxLength="100" runat="server" CssClass="text" Text="首页"></asp:TextBox>
                <sw:Validator ID="Validator1" ControlID="txtTitle" ValidateType="Required" ErrorText="请输入导航文字"
                    ErrorMessage="请输入导航文字" runat="server">
                </sw:Validator>
            </div>
            <div id="divLink" class="fi" style="display:none;">
                <label>
                    导航链接：</label>
                <asp:TextBox ID="txtLink" MaxLength="200" runat="server" CssClass="text" Text="http://"></asp:TextBox>
                <sw:Validator ID="Validator2" ControlID="txtLink" ValidateType="Custom" ErrorText="请输入正确的导航链接" ErrorMessage="请输入正确的导航链接" Expression="CheckLink()" runat="server">
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
