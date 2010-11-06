<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Index.aspx.cs" Inherits="User_Index" %>

<%@ Register Src="~/Control/UserSidebar.ascx" TagName="UserSidebar" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="resumePage">
        <uc1:UserSidebar runat="server" />
        <div class="content column">
            <div class="tit gray">
                <a href="#">首页</a> > <a href="#">个人会员</a> > <span class="green">会员管理</span></div>
            <div class="MemCon">
                <div class="blank12px">
                </div>
                <div class="Res670">
                    <img src="../images/img_personPhoto.png" width="90" height="110" class="imgBor" />
                    <div class="blank8px">
                    </div>
                    <div class=" lh24">
                        <input type="file" class="" />
                        <input type="button" class="btn94_28" value="上传" />
                        <span class="orange">支持格式(gif,png,jpg,jpeg,bmp)</span>
                    </div>
                    <div class="lh24">
                        <input type="checkbox" id="display" name="confirm" />
                        <label for="display">
                            将此照片显示在我的简历中</label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        setUserSidebar("JLGL");
    </script>
</asp:Content>
