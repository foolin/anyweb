<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="LibraryEdit.aspx.cs" Inherits="Admin_LibraryEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <iframe style="width: 0px; height: 0px;" id="ifrSelf" name="ifrSelf"></iframe>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <style type="text/css">
        .images li
        {
            float: left;
            margin-right: 8px;
            margin-top: 8px;
            text-align: center;
            width: 100px;
            height: 100px;
            cursor: pointer;
            border: 1px #ccc solid;
        }
        .images li.on
        {
            background: url(/admin/images/goods_lst_bg.jpg);
        }
        .images li img
        {
            width: 70px;
            height: 70px;
            border: 0px solid #ccc;
            margin-top: 5px;
            margin-bottom: 4px;
        }
        .images li button
        {
            border: 0;
            background: 0;
        }
        .imagelist li
        {
            height: 150px;
        }
    </style>

    <script type="text/javascript">
        function setPicture(path) {
            if (path.length > 0) {
                path = "/Files/Librarys/" + path;
                $("#img").attr("src", path).parent("li").show();
                $("#imgPath").val(path);
            }
        }
        function delPicture(obj) {
            if (confirm("确定要删除图片？")) {
                if (obj) {
                    $(obj).parent("li").remove();
                } else {
                    $("#imgPath").val("");
                    $("#img").attr("src", "").parent("li").hide();
                }
            }
        }
        function changeType(val) {
            if (val == 1) {
                $("#celebrity").show();
            } else {
                $("#celebrity").hide();
            }
        }
    </script>

    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                修改名人/品牌</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    分类：</label>
                <asp:DropDownList ID="drpLibrary" runat="server" onchange="changeType(this.value);">
                    <asp:ListItem Text="名人库" Value="1"></asp:ListItem>
                    <asp:ListItem Text="品牌库" Value="2"></asp:ListItem>
                </asp:DropDownList>
                <span id="celebrity" style="<%=bean.fdLibrType==1?"":"display:none"%>">
                    <label class="checkbox">
                        <input type="checkbox" name="celebrityType" value="1" <%=bean.fdLibrCelebrityType1==1?"checked=\"checked\"":"" %> />明星库</label>
                    <label class="checkbox">
                        <input type="checkbox" name="celebrityType" value="2" <%=bean.fdLibrCelebrityType2==1?"checked=\"checked\"":"" %> />潮人库</label>
                    <label class="checkbox">
                        <input type="checkbox" name="celebrityType" value="3" <%=bean.fdLibrCelebrityType3==1?"checked=\"checked\"":"" %> />大师库</label>
                    <label class="checkbox">
                        <input type="checkbox" name="celebrityType" value="4" <%=bean.fdLibrCelebrityType4==1?"checked=\"checked\"":"" %> />超模库</label>
                    <label class="checkbox">
                        <input type="checkbox" name="celebrityType" value="5" <%=bean.fdLibrCelebrityType5==1?"checked=\"checked\"":"" %> />圈中人</label>
                </span>
            </div>
            <div class="fi even">
                <label>
                    名称：</label>
                <asp:TextBox ID="txtLibrName" Width="400px" runat="server" CssClass="text" MaxLength="100"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator1" ControlID="txtLibrName" ValidateType="Required" ErrorText="请输入名称"
                    ErrorMessage="请输入名称" runat="server">
                </sw:Validator>
            </div>
            <div class="fi">
                <label>
                    英文名称：</label>
                <asp:TextBox ID="txtLibrEnName" Width="400px" runat="server" CssClass="text" MaxLength="100"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator2" ControlID="txtLibrEnName" ValidateType="Required" ErrorText="请输入英文名称"
                    ErrorMessage="请输入英文名称" runat="server">
                </sw:Validator>
            </div>
            <div class="fi even">
                <label>
                    图片：</label>
                <div class="cont">
                    <sw:Uploader ID="PicUploader" UploadPage="/Admin/Ajax/LibraryPicUpload.ashx" FilePath="/Files/Librarys/"
                        MaxSizeToUpload="2097152" Filter="Images (*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp)|*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp"
                        JavascriptCompleteFunction="setPicture" MultiSelect="false" runat="server">
                    </sw:Uploader>
                    <div id="divUpload">
                    </div>
                    <span id="results"></span>
                    <div class="images">
                        <ul>
                            <li <%=string.IsNullOrEmpty(bean.fdLibrPic)?"style=\"display: none;\"":"" %>>
                                <img id="img" src="<%=bean.fdLibrPic %>" alt="" />
                                <button type="button" onclick="delPicture();">
                                    删除</button>
                            </li>
                        </ul>
                        <input type="hidden" id="imgPath" name="imgPath" value="<%=bean.fdLibrPic %>" />
                    </div>
                </div>
            </div>
            <div class="fi">
                <label>
                    首字母：</label>
                <asp:DropDownList ID="drpFirstLetter" runat="server">
                    <asp:ListItem Text="A" Value="0"></asp:ListItem>
                    <asp:ListItem Text="B" Value="1"></asp:ListItem>
                    <asp:ListItem Text="C" Value="2"></asp:ListItem>
                    <asp:ListItem Text="D" Value="3"></asp:ListItem>
                    <asp:ListItem Text="E" Value="4"></asp:ListItem>
                    <asp:ListItem Text="F" Value="5"></asp:ListItem>
                    <asp:ListItem Text="G" Value="6"></asp:ListItem>
                    <asp:ListItem Text="H" Value="7"></asp:ListItem>
                    <asp:ListItem Text="I" Value="8"></asp:ListItem>
                    <asp:ListItem Text="J" Value="9"></asp:ListItem>
                    <asp:ListItem Text="K" Value="10"></asp:ListItem>
                    <asp:ListItem Text="L" Value="11"></asp:ListItem>
                    <asp:ListItem Text="M" Value="12"></asp:ListItem>
                    <asp:ListItem Text="N" Value="13"></asp:ListItem>
                    <asp:ListItem Text="O" Value="14"></asp:ListItem>
                    <asp:ListItem Text="P" Value="15"></asp:ListItem>
                    <asp:ListItem Text="Q" Value="16"></asp:ListItem>
                    <asp:ListItem Text="R" Value="17"></asp:ListItem>
                    <asp:ListItem Text="S" Value="18"></asp:ListItem>
                    <asp:ListItem Text="T" Value="19"></asp:ListItem>
                    <asp:ListItem Text="U" Value="20"></asp:ListItem>
                    <asp:ListItem Text="V" Value="21"></asp:ListItem>
                    <asp:ListItem Text="W" Value="22"></asp:ListItem>
                    <asp:ListItem Text="X" Value="23"></asp:ListItem>
                    <asp:ListItem Text="Y" Value="24"></asp:ListItem>
                    <asp:ListItem Text="Z" Value="25"></asp:ListItem>
                    <asp:ListItem Text="其他" Value="26"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="fi even">
                <label>
                    介绍：</label>
                <div class="cont">
                    <asp:TextBox ID="txtLibrDesc" TextMode="MultiLine" Width="100%" Height="300px" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="fi">
                <label>
                    排序：</label>
                <asp:TextBox ID="txtLibrOrder" runat="server" Text="0" CssClass="text" Width="80"></asp:TextBox>
                <span class="required">*</span> <span>排序数字越大，呈现位置越靠前。</span>
                <sw:Validator ID="Validator3" ControlID="txtLibrSort" ValidateType="Required" ErrorText="请输入排序"
                    ErrorMessage="请输入排序" runat="server">
                </sw:Validator>
                <sw:Validator ID="Validator4" ControlID="txtLibrSort" ValidateType="DataType" DataType="Integer"
                    ErrorText="请输入正确的排序" ErrorMessage="请输入正确的排序" runat="server">
                </sw:Validator>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存" CssClass="submit" OnClick="btnOk_Click">
                </asp:Button>
                <a href="LibraryList.aspx">返回列表</a>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>排序为“0”时将由系统自动生成。</li>
        </ul>
    </div>

    <script type="text/javascript" src="/tiny_mce/tiny_mce.js"></script>

    <script type="text/javascript">
        tinyMCE.init({
            mode: "exact",
            verify_html: false,
            elements: "<%=txtLibrDesc.ClientID%>",
            theme: "advanced",
            language: "zh",
            convert_urls: false,
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
