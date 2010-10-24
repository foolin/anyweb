<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="ADEdit.aspx.cs" Inherits="Admin_ADEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">

    <script type="text/javascript" src="js/ajaxfileupload.js"></script>

    <script type="text/javascript">
        function uploadPictures() {
            $.ajaxFileUpload(
                   {
                       url: "ADPicUpload.aspx",            //需要链接到服务器地址
                       secureuri: false,
                       fileElementId: "<%=fileImage.ClientID%>",                        //文件选择框的id属性
                       dataType: 'script',                                     //服务器返回的格式，可以是json
                       success: function(data, status)            //相当于java中try语句块的用法
                       {
                           var r = data.toString();
                           var msg = r.substring(2);
                           if (r.substr(0, 1) == "0") {
                               $("#imgColumn").attr("src", msg);
                               $("#imgUrl").attr("value", msg);
                               $("#images").show();
                               $('#results').html("上传成功");
                               $('#results').css("color", "green");
                           }
                           else {
                               $('#results').html(r.substring(2));
                               $('#results').css("color", "red");
                           }
                       },
                       error: function(data, status, e)            //相当于java中catch语句块的用法
                       {
                           $('#results').html('上传失败');
                           $('#results').css("color", "red");
                       }
                   }

               );
        }
        function delPicture(lnk) {
            var url = "ADPicDel.aspx?path=" + $("#imgUrl").val();
            $.get(url, "", function(htm) { });

            $("#images").hide();
            $("#imgColumn").attr("src", "");
            $("#imgUrl").attr("value", "");
        }
    </script>

    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                修改广告</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    广告名称：</label>
                <asp:Literal ID="txtName" runat="server"></asp:Literal>
            </div>
            <div class="fi even">
                <label>
                    图片：</label>
                <div class="cont">
                    <asp:FileUpload ID="fileImage" runat="server" CssClass="text" Width="185" />&nbsp;
                    <button onclick="uploadPictures()" style="height: 20px;" type="button">
                        上传图片</button>
                    <span id="results"></span>
                    <style type="text/css">
                        #images li
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
                        #images li.on
                        {
                            background: url(images/goods_lst_bg.jpg);
                        }
                        #images li img
                        {
                            width: 70px;
                            height: 70px;
                            border: 0px solid #ccc;
                            margin-top: 5px;
                            margin-bottom: 4px;
                        }
                        #images li button
                        {
                            border: 0;
                            background: 0;
                            cursor: pointer;
                        }
                    </style>
                    <div id="images" style="display: <%=hasPic?"":"none"%>">
                        <ul>
                            <li>
                                <img id="imgColumn" alt="" src="<%=picUrl %>" />
                                <input id="imgUrl" type="hidden" name="pics" value="<%=picUrl %>" />
                                <button onclick="delPicture(this);" type="button">
                                    删除</button></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="fi">
                <label>
                    链接：</label>
                <asp:TextBox ID="txtLink" MaxLength="200" runat="server" CssClass="text" Text="http://"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator2" ControlID="txtLink" ValidateType="Required" ErrorText="请输入企业链接"
                    ErrorMessage="请输入企业链接" runat="server">
                </sw:Validator>
                <sw:Validator ID="Validator5" ControlID="txtLink" ValidateType="DataType" DataType="Url" ErrorText="企业链接格式错误"
                    ErrorMessage="企业链接格式错误" runat="server">
                </sw:Validator>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存" CssClass="submit" OnClick="btnOk_Click">
                </asp:Button>
                <a href="javascript:history.back()">返回列表</a>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>企业介绍规格：110*77</li>
            <li>动态标语规格：950*55</li>
            <li>移动广告规格：120*250</li>
        </ul>
    </div>
</asp:Content>
