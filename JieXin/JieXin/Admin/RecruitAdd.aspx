<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="RecruitAdd.aspx.cs" Inherits="Admin_RecruitAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                添加招聘</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    所属类别：</label>
                <asp:DropDownList ID="drpType" runat="server">
                    <asp:ListItem Value="1" Text="实习生招聘"></asp:ListItem>
                    <asp:ListItem Value="2" Text="毕业生招聘"></asp:ListItem>
                    <asp:ListItem Value="3" Text="兼职招聘"></asp:ListItem>
                    <asp:ListItem Value="4" Text="企业招聘"></asp:ListItem> 
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
                    地区编号：</label>
                <asp:TextBox ID="txtAreaID" runat="server" Text="0" CssClass="text" MaxLength="100" Width="400px"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator2" ControlID="txtAreaID" ValidateType="Required" ErrorText="请输入地区编号"
                    ErrorMessage="请输入地区编号" runat="server">
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
                <asp:TextBox ID="txtSort" runat="server" Text="0" CssClass="text" Width="80"></asp:TextBox>
                <span class="required">*</span>
                <span>排序数字越大，呈现位置越靠前。</span>
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
            <li>招聘排序为“0”时将由系统自动生成。</li>
        </ul>
    </div>

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

