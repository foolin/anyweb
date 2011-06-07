﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/Content.master" AutoEventWireup="true"
    CodeFile="ArticleAdd.aspx.cs" Inherits="Admin_Content_ArticleAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="Server">
    添加文档

    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%=txtContent.ClientID %>_txt").height(document.documentElement.clientHeight - 130);
            $("#<%=txtTextContent.ClientID %>").height(document.documentElement.clientHeight - 130);
            $("#<%=radioIsAuthor.ClientID %> input:eq(0)").click(function() {
                $("#rowSource").css("display", "none");
                $("#rowLink").css("display", "none");
            });

            $("#<%=radioIsAuthor.ClientID %> input:eq(1)").click(function() {
                $("#rowSource").css("display", "");
                $("#rowLink").css("display", "");
            });
        });

        function AutoDesc(val) {
            if (!val) {
                $("#<%=txtDesc.ClientID %>").show();
            } else {
                $("#<%=txtDesc.ClientID %>").hide();
            }
        }

        function disableButton() {
            $("#<%=btnSaveAndContinue.ClientID %>").hide();
            $("#<%=btnSave.ClientID %>").hide();
            $("#Saving").show();
            return true;
        }

        function enableButton() {
            $("#<%=btnSaveAndContinue.ClientID %>").show();
            $("#<%=btnSave.ClientID %>").show();
            $("#Saving").hide();
        }
        
        function setFile(path) {
            if (path) {
                $("#fileLink").attr("href", "/Files/Article/Files/" + path);
                $("#txtFile").val("/Files/Article/Files/" + path);
                $("#fileLink").show();
            }
        }

        function setPic(path) {
            if (path) {
                $("#picLink").attr("href", "/Files/Article/Pictures/S_" + path);
                $("#txtPic").val("/Files/Article/Pictures/S_" + path);
                $("#picLink").show(); 
            }
        }

        function delPic() {
            if (confirm("确定删除该图片？")) {
                $("#picLink").attr("href", "");
                $("#txtPic").val("");
                $("#picLink").hide();
            }
            return false;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <ul>
        <li>文档标题：
            <asp:TextBox ID="txtTitle" runat="server" Width="300" CssClass="text" MaxLength="255"></asp:TextBox>
            <sw:Validator ID="val1" ControlID="txtTitle" ValidateType="Required" ErrorMessage="请填写文档标题"
                runat="server">
            </sw:Validator>
            类型：
            <asp:DropDownList ID="drpType" runat="server" onchange="selectArticleType(this.value)">
                <asp:ListItem Value="0">HTML</asp:ListItem>
                <asp:ListItem Value="1">文本</asp:ListItem>
                <asp:ListItem Value="2">链接</asp:ListItem>
                <asp:ListItem Value="3">文件</asp:ListItem>
            </asp:DropDownList>
        </li>
        <li>所属栏目：<asp:Label ID="lblColumn" runat="server"></asp:Label></li>
        <li id="type0">
            <sw:TinyMce ID="txtContent" runat="server" />
        </li>
        <li id="type1" style="display: none;">
            <asp:TextBox ID="txtTextContent" runat="server" TextMode="MultiLine" Width="98%"></asp:TextBox>
        </li>
        <li id="type2" style="display: none;">链接地址：<asp:TextBox ID="txtLink" CssClass="text"
            Width="300" runat="server" MaxLength="500"></asp:TextBox>
        </li>
        <li id="type3" style="display: none;">文件上传：
            <sw:Uploader ID="fileUploader" UploadPage="/Admin/Ajax/FileUpload.ashx" FilePath="/Files/Article/Files/" JavascriptCompleteFunction="setFile" MultiSelect="false" runat="server"></sw:Uploader>
            <a id="fileLink" href="" target="_blank" style="position:absolute;display:none;"><img src="../images/icons/rar.gif" alt="" /></a>
            <input type="hidden" id="txtFile" name="txtFile" />
        </li>
    </ul>
    <div class="mft">
        <button id="Saving" type="button" style="display:none;" disabled="disabled">正在保存</button>
        <asp:Button ID="btnSaveAndContinue" CssClass="button" runat="server" Text="保存继续" OnClick="btnSaveAndContinue_Click" />
        <asp:Button ID="btnSave" CssClass="button" runat="server" Text="保存退出" OnClick="btnSave_Click" />
        <button type="button" onclick="window.close()">
            取消退出</button>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphOpr" runat="Server">
    <div class="operation" id="folder_desc">
        <h3 class="opr-mhd">
            <a href="javascript:showFolder('folder_desc')">
                <img src="../images/icons/arrow2.gif" /></a>文档摘要</h3>
        <div class="opr-mbd">
            <ul>
                <li>
                    <asp:CheckBox ID="chkDesc" runat="server" Text="自动生成摘要" CssClass="checkbox" Checked="true"
                        onclick="AutoDesc(this.checked);" />
                    <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" CssClass="textarea"
                        Width="225" Height="120" Style="display: none"></asp:TextBox>
                </li>
            </ul>
        </div>
    </div>
    <div class="operation" id="folder_options">
        <h3 class="opr-mhd">
            <a href="javascript:showFolder('folder_options')">
                <img src="../images/icons/arrow2.gif" /></a>高级选项</h3>
        <div class="opr-mbd">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr id="rowIsAuthor">
                    <td>
                        是否原创：
                    </td>
                    <td>
                        <asp:RadioButtonList ID="radioIsAuthor" CssClass="radio" runat="server" RepeatLayout="Flow"
                            RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True">原创</asp:ListItem>
                            <asp:ListItem>转载</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        副标题：
                    </td>
                    <td>
                        <asp:TextBox ID="txtSubTitle" runat="server" CssClass="text" MaxLength="100" Width="165px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        文档图片：
                    </td>
                    <td>
                        <sw:Uploader ID="PicUploader" UploadPage="/Admin/Ajax/ArticlePicUpload.ashx" FilePath="/Files/Article/Pictures/" Filter="Images (*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp)|*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp" JavascriptCompleteFunction="setPic" MultiSelect="false" runat="server"></sw:Uploader>
                        <a id="picLink" href="" target="_blank" title="查看图片(右键删除图片)" style="position:absolute;margin-top:5px 0;display:none;" oncontextmenu="return delPic();"><img src="../images/icons/col_Album.gif" alt="" /></a>
                        <input type="hidden" id="txtPic" name="txtPic" />
                    </td>
                </tr>
                <tr style="display: none;" id="rowSource">
                    <td>
                        文档来源：
                    </td>
                    <td>
                        <div>
                            <asp:TextBox runat="server" ID="txtFrom" CssClass="text" MaxLength="50" Width="165px"></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        文档作者：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFromAuthor" CssClass="text" MaxLength="50" Width="165px"></asp:TextBox>
                    </td>
                </tr>
                <tr id="rowLink" style="display: none;">
                    <td>
                        文档链接：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFromLink" CssClass="text" MaxLength="255" Width="165px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        撰写时间：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCreateAt" CssClass="text" MaxLength="50" Width="165px" onclick="calendar(this)"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        文档排序：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtSort" CssClass="text" MaxLength="10" Width="50px" Text="0"></asp:TextBox>
                        为0则系统自动生成。
                    </td>
                </tr>
                <tr>
                    <td>
                        其他设置：
                    </td>
                    <td>
                        <asp:CheckBox ID="chkEnableComment" runat="server" CssClass="checkbox" Text="允许评论"
                            Checked="true" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>