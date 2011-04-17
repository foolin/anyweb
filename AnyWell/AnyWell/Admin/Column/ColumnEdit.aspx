<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/CenterPopup.master"
    AutoEventWireup="true" CodeFile="ColumnEdit.aspx.cs" Inherits="Admin_Content_ColumnEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script type="text/javascript">
        function setIcon(path) {
            if (path) {
                path = "/Files/Column/" + "S_" + path;
                $("#ColIcon #img1").attr("src", path);
                $("#ColIcon #iconPath").val(path);
                $("#ColIcon").show();
            }
        }
        function setPic(path) {
            if (path) {
                path = "/Files/Column/" + "S_" + path;
                $("#ColPic #img").attr("src", path);
                $("#ColPic #picPath").val(path);
                $("#ColPic").show();
            }
        }
        function delIcon() {
            if (confirm("确定删除该图片？")) {
                $("#ColIcon #img1").attr("src", "");
                $("#ColIcon #iconPath").val("");
                $("#ColIcon").hide();
            }
        }
        function delPic() {
            if (confirm("确定删除该图片？")) {
                $("#ColPic #img").attr("src", "");
                $("#ColPic #picPath").val("");
                $("#ColPic").hide();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="Server">
    修改栏目
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="blank20px">
    </div>
    <div class="optionhead">
        <div id="option1" class="selected" onclick="selectOption('option','optiondiv',1);">
            常规</div>
        <div id="option2" onclick="selectOption('option','optiondiv',2);">
            高级</div>
    </div>
    <div class="popmbd">
        <table id="optiondiv1">
            <colgroup>
                <col style="width: 80px; vertical-align: top; padding-top: 3px;" />
                <col style="font-weight: normal" />
            </colgroup>
            <tr>
                <th>
                    上级栏目：
                </th>
                <td>
                    <asp:Label ID="lblParent" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    栏目名称：
                </th>
                <td>
                    <asp:TextBox ID="txtName" Width="300px" CssClass="text" runat="server" MaxLength="50"></asp:TextBox>
                    <sw:Validator ID="val2" ControlID="txtName" ValidateType="Required" ErrorMessage="请填写栏目名称"
                        runat="server">
                    </sw:Validator>
                </td>
            </tr>
            <tr>
                <th>
                    栏目类型：
                </th>
                <td>
                    <asp:Label ID="lblType" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    栏目说明：
                </th>
                <td>
                    <asp:TextBox ID="txtDesc" Width="300px" CssClass="text" TextMode="MultiLine" Height="100px"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table id="optiondiv2" style="display: none">
            <colgroup>
                <col style="width: 80px; vertical-align: top; padding-top: 3px;" />
                <col style="font-weight: normal" />
            </colgroup>
            <tr>
                <th>
                    栏目大图：
                </th>
                <td>
                    <sw:Uploader ID="PicUploader" UploadPage="/Admin/Ajax/ColumnPicUpload.ashx" FilePath="/Files/Column/" MaxSizeToUpload="2097152" Filter="Images (*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp)|*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp" JavascriptCompleteFunction="setPic" MultiSelect="false" runat="server"></sw:Uploader>
                    <span>（120×120）</span>
                </td>
            </tr>
            <tr>
                <th>
                    栏目小图：
                </th>
                <td>
                    <sw:Uploader ID="IconUploader" UploadPage="/Admin/Ajax/ColumnIconUpload.ashx" FilePath="/Files/Column/" MaxSizeToUpload="2097152" Filter="Images (*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp)|*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp" JavascriptCompleteFunction="setIcon" MultiSelect="false" runat="server"></sw:Uploader>
                    <span>（32×32）</span>
                </td>
            </tr>
            <tr>
                <th>
                    图片预览：
                </th>
                <td>
                    <div class="imageview">
                        <ul>
                            <li id="ColIcon" <%=string.IsNullOrEmpty(bean.fdColuIcon)?"style=\"display: none;\"":"" %>>
                                <img id="img1" src="<%=bean.fdColuIcon %>" alt="" />
                                <input type="hidden" id="iconPath" name="iconPath" value="<%=bean.fdColuIcon %>" />
                                <button type="button" onclick="delIcon();" title="删除图片">
                                    (小图)删除</button>
                            </li>
                            <li id="ColPic" <%=string.IsNullOrEmpty(bean.fdColuPict)?"style=\"display: none;\"":"" %>>
                                <img id="img" src="<%=bean.fdColuPict %>" alt="" />
                                <input type="hidden" id="picPath" name="picPath" value="<%=bean.fdColuPict %>" />
                                <button type="button" onclick="delPic();" title="删除图片">
                                    (大图)删除</button>
                            </li>
                        </ul>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div class="popmft">
        <button id="Saving" type="button" style="display:none;" disabled="disabled">正在保存</button>
        <button id="btnStart" type="submit">
            保存栏目</button>
        <button type="button" onclick="parent.disablePopup()">
            取消退出</button>
    </div>
</asp:Content>
