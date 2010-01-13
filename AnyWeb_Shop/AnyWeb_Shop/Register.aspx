<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="Server">
    <style type="text/css">
        <!-- 
        .col-sider
        {
            float: left;
            width: 20%;
        }
        .col-main
        {
            float: right;
            width: 75%;
        }
        .container
        {
            padding-left: 5px;
            background: #FFF;
        }
        table.regForm
        {
            width: 100%;
            line-height: 30px;
            border-collapse: collapse;
            border: 1px solid #9ed96b;
            background: #FFF;
        }
        table.regForm .title
        {
            height: 20px;
            line-height: 20px;
            background: #9ed96b url(images/boxA_title_bg.jpg) repeat-x;
            font-size: 14px;
            font-weight: bold;
            color: #090;
            text-align: center;
        }
        table.regForm td
        {
            padding-top: 5px;
            padding-bottom: 5px;
        }
        .regForm input
        {
            border: solid 1px #aaa;
            padding: 3px 3px;
        }
        --></style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="main">
        <div class="col-sider">
            <!-- 栏目 -->
            <div class="category">
                <div class="title">
                    栏目导航</div>
                <div class="content">
                    <ul>
                        <li><a href="#Login.aspx">登录</a></li>
                        <li><a href="#Register.aspx">注册</a></li>
                        <li><a href="#LostPassword.aspx">找回密码？</a></li>
                        <li><a href="#Help.aspx">用户帮助</a></li>
                    </ul>
                    <div class="clear">
                    </div>
                </div>
                <!-- content end -->
            </div>
            <!-- category end -->
        </div>
        <!-- col-sider -->
        <div class="col-main">
            <div class="container">
                <table class="regForm">
                    <tr>
                        <td colspan="3" class="title">
                            注册用户
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="right">
                            登录名：
                        </td>
                        <td width="50%">
                            <input type="text" class="inputtext" name="txtUserName" id="txtUserName" onblur="ExistName(this);" />
                        </td>
                        <td width="30%">
                            <div id="txtUserNameMsg">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            密码：
                        </td>
                        <td>
                            <input class="inputtext" type="password" name="txtPassWord" id="txtPassWord" onblur="checkPass(this);" />
                        </td>
                        <td valign="top">
                            <div id="txtPassWordMsg">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            确认密码：
                        </td>
                        <td>
                            <input class="inputtext" type="password" name="txtConfirmPass" id="txtConfirmPass"
                                onblur="checkSurePass(this);" />
                        </td>
                        <td valign="top">
                            <div id="txtConfirmPassMsg">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            电子邮件：
                        </td>
                        <td>
                            <input class="inputtext" type="text" name="txtEmail" id="txtEmail" onblur="ExistEmail(this);" />
                        </td>
                        <td valign="top">
                            <div id="txtEmailMsg">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center" style="text-align: center">
                            <input type="submit" name="btnRegister" value="注册" />
                            <input type="reset" name="btnReset" value="重置" />
                        </td>
                    </tr>
                </table>
            </div>
            <!-- container end -->
        </div>
        <!-- col-main end -->
        <div class="clear">
        </div>
    </div>
    <!-- main end -->
    <script type="text/javascript">
        SetTitleCss(3);
    </script>
</asp:Content>
