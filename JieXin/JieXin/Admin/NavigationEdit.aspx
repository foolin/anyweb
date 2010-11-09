<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="NavigationEdit.aspx.cs" Inherits="Admin_NavigationEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">

    <script type="text/javascript">
        function ChangeType(IsLoad) {
            switch ($("#<%=drpType.ClientID %>").val()) {
                case "1":
                case "2":
                case "3":
                case "4":
                    $("#divColumn").hide();
                    $("#divRecruit").hide();
                    $("#divSite").hide();
                    $("#divTitle").attr("class", "fi");
                    $("#divLink").hide();
                    if(!IsLoad)
                        $("#<%=txtTitle.ClientID %>").val($("#<%=drpType.ClientID %>").find("option:selected").text());
                    break;
                case "5":
                    $("#divColumn").show().attr("class", "fi");
                    $("#divRecruit").hide();
                    $("#divSite").hide();
                    $("#divTitle").attr("class", "fi even");
                    $("#divLink").hide();
                    if (!IsLoad)
                        $("#<%=txtTitle.ClientID %>").val($("#<%=drpColumn.ClientID %>").find("option:selected").text());
                    break;
                case "6":
                    $("#divColumn").hide();
                    $("#divRecruit").show().attr("class", "fi");
                    $("#divSite").hide();
                    $("#divTitle").attr("class", "fi even");
                    $("#divLink").hide();
                    if (!IsLoad)
                        $("#<%=txtTitle.ClientID %>").val($("#<%=drpRecruit.ClientID %>").find("option:selected").text());
                    break;
                case "7":
                    $("#divColumn").hide();
                    $("#divRecruit").hide();
                    $("#divSite").show().attr("class", "fi");
                    $("#divTitle").attr("class", "fi even");
                    $("#divLink").hide();
                    if (!IsLoad)
                        $("#<%=txtTitle.ClientID %>").val($("#<%=drpSite.ClientID %>").find("option:selected").text());
                    break;
                case "8": ;
                    $("#divColumn").hide();
                    $("#divRecruit").hide();
                    $("#divSite").hide();
                    $("#divTitle").attr("class", "fi");
                    $("#divLink").show().attr("class", "fi even");
                    if (!IsLoad)
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

        function ChangeRecruit() {
            $("#<%=txtTitle.ClientID %>").val($("#<%=drpRecruit.ClientID %>").find("option:selected").text());
        }

        function ChangeSite() {
            $("#<%=txtTitle.ClientID %>").val($("#<%=drpSite.ClientID %>").find("option:selected").text());
        }

        function CheckLink() 
        {
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
        
        $(document).ready(function() {
            ChangeType(true);
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
                    <asp:ListItem Value="1" Text="首页"></asp:ListItem>
                    <asp:ListItem Value="2" Text="我的杰信"></asp:ListItem>
                    <asp:ListItem Value="3" Text="职位搜索"></asp:ListItem>   
                    <asp:ListItem Value="4" Text="最新公告"></asp:ListItem>   
                    <asp:ListItem Value="5" Text="文章栏目"></asp:ListItem>                
                    <asp:ListItem Value="6" Text="招聘"></asp:ListItem>
                    <asp:ListItem Value="7" Text="基本信息"></asp:ListItem>
                    <asp:ListItem Value="8" Text="自定义链接"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div id="divColumn" class="fi" style="display:none" onchange="ChangeColumn()">
                <label>
                    文章栏目：</label>
                <asp:DropDownList ID="drpColumn" runat="server">
                </asp:DropDownList>
            </div>
            <div id="divRecruit" class="fi" style="display:none">
                <label>
                    招聘类型：</label>
                <asp:DropDownList ID="drpRecruit" runat="server" onchange="ChangeRecruit()">
                    <asp:ListItem Text="最新招聘" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="校园招聘" Value="0"></asp:ListItem>
                    <asp:ListItem Text="实习生招聘" Value="1"></asp:ListItem>
                    <asp:ListItem Text="兼职招聘" Value="2"></asp:ListItem>
                    <asp:ListItem Text="毕业生招聘" Value="3"></asp:ListItem>
                    <asp:ListItem Text="知名企业招聘" Value="5"></asp:ListItem>
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
                <sw:Validator ID="Validator2" ControlID="txtLink" ValidateType="Custom" ErrorText="请输入正确的导航链接"
                    ErrorMessage="请输入正确的导航链接" Expression="CheckLink()" runat="server">
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
