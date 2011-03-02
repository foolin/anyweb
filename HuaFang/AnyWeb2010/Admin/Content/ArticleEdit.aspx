<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="ArticleEdit.aspx.cs" Inherits="Admin_ArticleEdit" %>

<%@ Register Src="~/Admin/Control/TagSelect.ascx" TagName="TagSelect" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <iframe style="width: 0px; height: 0px;" id="ifrSelf" name="ifrSelf"></iframe>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">

    <script type="text/javascript">
        var child = new Array;
        <asp:Literal ID="litJs" runat="server"></asp:Literal>
        function columnChange(){
            var i, index;
            index = document.getElementById("<%=drpColumn.ClientID %>").selectedIndex;
            var objChild = document.getElementById("<%=drpChild.ClientID %>");
            var iCount = child[index].length;
            for (i = objChild.options.length - 1; i >= 0; i--) {
                objChild.remove(i);
            }
            var option = document.createElement("OPTION");
            option.value = "0";
            option.text = "不选择二级栏目";
            objChild.options.add(option);
            for (i = 0; i <= iCount - 1; i++) {
                var option = document.createElement("OPTION");
                option.value = child[index][i].substring(0,child[index][i].indexOf(":"));
                option.text = child[index][i].substring(child[index][i].indexOf(":")+1,child[index][i].length);
                objChild.options.add(option);
            }
        }
    </script>

    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                修改文章</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    文章标题：</label>
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
                    runat="server" onchange="columnChange()">
                </asp:DropDownList>
                <asp:DropDownList ID="drpChild" runat="server">
                </asp:DropDownList>
            </div>
            <div class="fi">
                <label>
                    文章内容：</label>
                <div class="cont">
                    <asp:TextBox ID="txtContent" Width="100%" Height="300px" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="fi even">
                <label>
                    文章摘要：</label>
                <div class="cont">
                    <asp:TextBox ID="txtDesc" TextMode="MultiLine" Width="400px" Height="150px" runat="server"
                        CssClass="textarea"></asp:TextBox>
                    <span>文章摘要不得超过1000字,如果留空，系统自动生成摘要。</span>
                    <sw:Validator ID="Validator2" ControlID="txtDesc" ValidateType="MaxLength" MaxLength="1000"
                        ErrorText="文章摘要不得超过1000字" ErrorMessage="文章摘要不得超过1000字" runat="server">
                    </sw:Validator>
                </div>
            </div>
            <div class="fi">
                <label>
                    文章标签：</label>
                <div class="cont">
                    <a href="javascript:void(0);" id="btnTag" onclick="ChooseTag();" class="choAreabtn"
                        title="<%=GetTags("选择/修改")%>">
                        <%=GetTags( "选择/修改" )%></a> <span>使用逗号分隔不同标签, 最多可输入5个。</span>
                    <input type="hidden" id="tags" name="tags" value="<%=GetTags("")%>" />
                </div>
            </div>
            <div class="fi even">
                <label>
                    文章排序：</label>
                <asp:TextBox ID="txtSort" runat="server" Text="0"></asp:TextBox>
                <span class="required">*</span> <span>排序数字越大，呈现位置越靠前。</span>
                <sw:Validator ID="Validator3" ControlID="txtSort" ValidateType="Required" ErrorText="请输入文章排序"
                    ErrorMessage="请输入文章排序" runat="server">
                </sw:Validator>
                <sw:Validator ID="Validator4" ControlID="txtSort" ValidateType="DataType" DataType="Integer"
                    ErrorText="请输入正确的文章排序" ErrorMessage="请输入正确的文章排序" runat="server">
                </sw:Validator>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存" CssClass="submit" OnClick="btnOk_Click">
                </asp:Button>
                <a href="javascript:history.back();">返回列表</a>
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
    <uc1:TagSelect ID="TagSelect1" runat="server" />

    <script type="text/javascript" src="/tiny_mce/tiny_mce.js"></script>

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
