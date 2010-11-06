<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MemPhoto.aspx.cs" Inherits="User_MemPhoto" %>

<%@ Register Src="~/Control/UserSidebar.ascx" TagName="UserSidebar" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../js/ajaxfileupload.js"></script>

    <div class="resumePage">
        <uc1:UserSidebar runat="server" />
        <div class="content column">
            <div class="tit gray">
                <a href="/Index.aspx">首页</a> > <a href="/User/Index.aspx">个人会员</a> > <span class="green">
                    形象照片管理</span></div>
            <div class="MemCon">
                <div class="blank12px">
                </div>
                <div class="Res670">
                    <img id="userphoto" width="90" height="110" class="imgBor" alt="" src="<%=LoginUser.fdUserPhoto==""?"../images/img_personPhoto.png":LoginUser.fdUserPhoto %>" />
                    <div class="blank8px">
                    </div>
                    <div class=" lh24">
                        <input type="file" class="" id="fileImage" name="fileImage" />
                        <input type="button" class="btn94_28" value="上传" onclick="uploadPhoto()" />
                        <span class="orange">支持格式(gif,png,jpg,jpeg,bmp)</span>
                    </div>
                    <div class="lh24">
                        <input type="checkbox" id="PhotoShow" onclick="setPhotoShow(this.checked)" <%=LoginUser.fdUserPhotoIsShow==1?"checked=\"checked\"":"" %> />
                        <label for="display">
                            将此照片显示在我的简历中</label>
                    </div>
                    <br />
                    <div style="color: Red; display: none" id="results">
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function uploadPhoto() {
            $("#results").html("正在上传...").show().css("color", "red");
            $.ajaxFileUpload(
                   {
                       url: "PhotoUpload.aspx",
                       secureuri: false,
                       fileElementId: "fileImage",
                       dataType: 'script',
                       success: function(data, status) {
                           var r = data.toString();
                           var msg = r.substring(2);
                           if (r.substr(0, 1) == "0") {
                               $("#userphoto").attr("src", msg);
                               $('#results').html("上传成功!").css("color", "green");
                           }
                           else {
                               $('#results').html(r.substring(2)).css("color", "red");
                           }
                       },
                       error: function(data, status, e) {
                           $('#results').html('上传失败！').css("color", "red");
                       }
                   });
        }
        function setPhotoShow(v) {
            $("#results").html("正在保存...").show();
            var show = v ? 1 : 0;
            $.ajax({
                url: "SetPhoto.aspx",
                data: "show=" + show,
                cache: false,
                success: function(data) {
                    var r = data.toString();
                    var msg = r.substring(2);
                    if (r.substr(0, 1) == "0") {
                        $("#results").html(msg).css("color", "green");
                    } else {
                        $("#results").html(msg).css("color", "red");
                    }
                },
                error: function() {
                    $("#results").html("系统繁忙，请稍候再试！").css("color", "red");
                }
            });
        }
    </script>

    <script type="text/javascript">
        setUserSidebar("XXZP");
    </script>

</asp:Content>
