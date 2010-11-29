﻿<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="RecruitEdit.aspx.cs" Inherits="Admin_RecruitEdit" %>

<%@ Register Src="Control/Area.ascx" TagName="Area" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">

    <script type="text/javascript" src="js/area.js"></script>
    <script type="text/javascript" src="js/function.js"></script>

    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                修改招聘</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    所属类别：</label>
                <asp:DropDownList ID="drpType" runat="server">
                    <asp:ListItem Value="4" Text="企业招聘"></asp:ListItem>
                    <asp:ListItem Value="1" Text="实习生招聘"></asp:ListItem>
                    <asp:ListItem Value="2" Text="毕业生招聘"></asp:ListItem>
                    <asp:ListItem Value="3" Text="兼职招聘"></asp:ListItem>
                    <asp:ListItem Value="5" Text="知名企业招聘"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="fi even">
                <label>
                    招聘标题：</label>
                <asp:TextBox ID="txtTitle" MaxLength="100" Width="400px" runat="server" CssClass="text"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator1" ControlID="txtTitle" ValidateType="Required" ErrorText="请输入标题"
                    ErrorMessage="请输入标题" runat="server">
                </sw:Validator>
            </div>
            <div class="fi even">
                <label>
                    地区：</label>
                <a href="javascript:void(0);" onclick="ChooseArea();" id="AreaName" class="choAreabtn">
                    <%=recruit.fdRecrAreaID==0?"选择地区":recruit.fdRecrAreaName%></a>
                <asp:TextBox ID="txtAreaID" runat="server" Style="display: none"></asp:TextBox>
                <asp:TextBox ID="txtAreaName" runat="server" Style="display: none"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator2" ControlID="txtAreaName" ValidateType="Required" ErrorText="请输择地区"
                    ErrorMessage="请输择地区" runat="server">
                </sw:Validator>
            </div>
            <div class="fi even">
                <label>
                    公司名称：</label>
                <asp:TextBox ID="txtCompany" MaxLength="100" Width="400px" runat="server" CssClass="text"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator3" ControlID="txtCompany" ValidateType="Required" ErrorText="请输入公司名称"
                    ErrorMessage="请输入公司名称" runat="server">
                </sw:Validator>
            </div>
            <div class="fi even">
                <label>
                    职位名称：</label>
                <asp:TextBox ID="txtJob" MaxLength="100" Width="400px" runat="server" CssClass="text"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator4" ControlID="txtJob" ValidateType="Required" ErrorText="请输入职位名称"
                    ErrorMessage="请输入职位名称" runat="server">
                </sw:Validator>
            </div>
            <div class="fi">
                <label>
                    招聘内容：</label>
                <div class="cont">
                    <asp:TextBox ID="txtContent" TextMode="MultiLine" Width="100%" Height="300px" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="fi even">
                <label>
                    招聘排序：</label>
                <asp:TextBox ID="txtSort" runat="server" CssClass="text" Width="80"></asp:TextBox>
                <span class="required">*</span> <span>排序数字越大，呈现位置越靠前。</span>
                <sw:Validator ID="Validator5" ControlID="txtSort" ValidateType="Required" ErrorText="请输入招聘排序"
                    ErrorMessage="请输入招聘排序" runat="server">
                </sw:Validator>
                <sw:Validator ID="Validator6" ControlID="txtSort" ValidateType="DataType" DataType="Integer"
                    ErrorText="请输入正确的招聘排序" ErrorMessage="请输入正确的招聘排序" runat="server">
                </sw:Validator>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存" CssClass="submit" OnClick="btnOk_Click">
                </asp:Button>
                <a href="RecruitList.aspx">返回列表</a>
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
    <uc1:Area runat="server" />

    <script type="text/javascript" src="../tiny_mce/tiny_mce.js"></script>

    <script type="text/javascript">
        tinyMCE.init({
            mode: "exact",
            verify_html: false,
            elements: "<%=txtContent.ClientID%>",
            theme: "advanced",
            language: "zh",
            plugins: "safari,pagebreak,style,layer,table,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,profile,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,pageseparator,iboximage",
            content_css: "/tiny_mce/css/content.css",
            template_external_list_url: "/tiny_mce/lists/template_list.js",
            external_link_list_url: "/tiny_mce/lists/link_list.js",
            external_image_list_url: "/tiny_mce/lists/image_list.js",
            media_external_list_url: "/tiny_mce/lists/media_list.js",
            template_replace_values: {
                username: "Some User",
                staffid: "991234"
            }
        });
    </script>

</asp:Content>
