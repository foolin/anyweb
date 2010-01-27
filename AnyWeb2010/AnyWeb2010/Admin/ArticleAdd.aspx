<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="ArticleAdd.aspx.cs" Inherits="Admin_ArticleAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                添加新闻</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    新闻标题：</label>
                <asp:TextBox ID="txtTitle" MaxLength="100" Width="400px" runat="server" CssClass="text"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator1" ControlID="txtTitle" ValidateType="Required" ErrorText="请输入标题"
                    ErrorMessage="请输入标题" runat="server">
                </sw:Validator>
            </div>
            <div class="fi even">
                <label>
                    所属栏目：</label>
                <asp:DropDownList ID="drpColumn" DataTextField="fdColuName" DataValueField="fdColuID"
                    runat="server">
                </asp:DropDownList>
                <span class="required">*</span>
                <sw:Validator ID="Validator2" ControlID="drpColumn" ValidateType="Required" ErrorText="请选择所属栏目"
                    ErrorMessage="请选择所属栏目" runat="server">
                </sw:Validator>
            </div>
            <div class="fi">
                <label>
                    新闻内容：</label>
                <div class="cont">
                    <asp:TextBox ID="txtContent" TextMode="MultiLine" Width="100%" Height="300px" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存" CssClass="submit" OnClick="btnOk_Click">
                </asp:Button>
                <a href="NewsList.aspx">返回列表</a>
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

    <script type="text/javascript" src="../tiny_mce/tiny_mce.js"></script>

    <script type="text/javascript">
        tinyMCE.init({
        mode : "exact",
        elements : "<%=txtContent.ClientID%>",
        theme : "advanced",
        language : "zh",
        plugins : "safari,pagebreak,style,layer,table,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,profile,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,pageseparator,iboximage",
        content_css : "/tiny_mce/css/content.css",
        template_external_list_url : "/tiny_mce/lists/template_list.js",
        external_link_list_url : "/tiny_mce/lists/link_list.js",
        external_image_list_url : "/tiny_mce/lists/image_list.js",
        media_external_list_url : "/tiny_mce/lists/media_list.js",
        template_replace_values : {
        username : "Some User",
        staffid : "991234"
        }
        });
    </script>

</asp:Content>
