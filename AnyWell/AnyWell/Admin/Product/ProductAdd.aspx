<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/Content.master" AutoEventWireup="true"
    CodeFile="ProductAdd.aspx.cs" Inherits="Admin_Product_ProductAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="Server">
    添加产品
    
    <script type="text/javascript">
        $(function() {
            $("#<%=txtContent.ClientID %>_txt").height(document.documentElement.clientHeight - 130);
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

        function setPic(path) {
            if (path) {
                $("#picLink").attr("href", "/Files/Product/Pictures/S_" + path);
                $("#txtPic").val("/Files/Product/Pictures/S_" + path);
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
        <li>产品名称：
            <asp:TextBox ID="txtName" runat="server" Width="300" CssClass="text" MaxLength="100"></asp:TextBox>
            <sw:Validator ID="val1" ControlID="txtName" ValidateType="Required" ErrorMessage="请填写文档标题"
                runat="server">
            </sw:Validator>
        </li>
        <li>所属栏目：<asp:Label ID="lblColumn" runat="server"></asp:Label></li>
        <li id="type0">
            <sw:TinyMce ID="txtContent" runat="server" />
        </li>
    </ul>
    <div class="mft">
        <button id="Saving" type="button" style="display: none;" disabled="disabled">
            正在保存</button>
        <asp:Button ID="btnSaveAndContinue" CssClass="button" runat="server" Text="保存继续"
            OnClick="btnSaveAndContinue_Click" />
        <asp:Button ID="btnSave" CssClass="button" runat="server" Text="保存退出" OnClick="btnSave_Click" />
        <button type="button" onclick="window.close()">
            取消退出</button>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphOpr" runat="Server">
    <div class="operation" id="folder_desc">
        <h3 class="opr-mhd">
            <a href="javascript:showFolder('folder_desc')">
                <img src="../images/icons/arrow2.gif" /></a>产品描述</h3>
        <div class="opr-mbd">
            <ul>
                <li>
                    <asp:CheckBox ID="chkDesc" runat="server" Text="自动生成描述" CssClass="checkbox" Checked="true"
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
                <tr>
                    <td>
                        产品型号：
                    </td>
                    <td>
                        <asp:TextBox ID="txtCode" runat="server" CssClass="text" MaxLength="50" Width="165px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        产品图片：
                    </td>
                    <td>
                        <sw:Uploader ID="PicUploader" UploadPage="/Admin/Ajax/ProductPicUpload.ashx" FilePath="/Files/Product/Pictures/"
                            Filter="Images (*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp)|*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp"
                            JavascriptCompleteFunction="setPic" MultiSelect="false" runat="server">
                        </sw:Uploader>
                        <a id="picLink" href="" target="_blank" title="查看图片(右键删除图片)" style="position: absolute;
                            margin-top: 5px 0; display: none;" oncontextmenu="return delPic();">
                            <img src="../images/icons/col_Album.gif" alt="" /></a>
                        <input type="hidden" id="txtPic" name="txtPic" />
                    </td>
                </tr>
                <tr>
                    <td>
                        创建时间：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCreateAt" CssClass="text" MaxLength="50" Width="165px"
                            onclick="calendar(this)"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        产品排序：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtSort" CssClass="text" MaxLength="10" Width="50px"
                            Text="0"></asp:TextBox>
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
