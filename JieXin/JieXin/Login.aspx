<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="AnyWell_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="inner">
        <div class="box_754">
            <div class="tit gray">
                <a href="/index.aspx">首页</a> > <span class="green">个人会员登录</span>
            </div>
            <div class="loginPage innerPad">
                <div class="Info">
                    <div class="TipHead">
                        <a href="#" class="Link logLink ohtxt">登录</a> <a href="#" class="Link regLink ohtxt">
                            注册</a>
                        <div class="btnArea tc">
                            <a href="/Search.aspx" class="btn28H">职位搜索</a> <a href="/c/54.aspx" class="btn28H">求职指南</a>
                        </div>
                    </div>
                    <div class="TipBtm">
                        <h3>
                            贴心提示:
                        </h3>
                        <p>
                            很多非常好的工作机会也许都来不及出现在招聘信息中，就已经给了那些填写简历的注册用户。</p>
                        <span class="blank20px"></span>
                        <h3>
                            求职注意:
                        </h3>
                        <p>
                            非法黑中介收取报名费；虚假的"高薪招聘"，巧立名目收取各类押金……求职者要时刻睁大眼睛，谨防招聘骗局！</p>
                    </div>
                </div>
                <div class="loginBox">
                    <div class="loginTop">
                    </div>
                    <div class="loginCon">
                        <div class="loginHead gray">
                            <div class="headBg">
                                <strong class="f14">个人会员登录</strong> 如果您是个人会员，请先登录.
                            </div>
                        </div>
                        <div class="formDiv">
                            <div class="Logpad Alter">
                                <div class="blank15px">
                                </div>
                                <form runat="server" id="form1" onsubmit="return checkForm()">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <th scope="row" width="63">
                                            会员名：
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtUserName" runat="server" CssClass="loginInput_in" MaxLength="20"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th scope="row">
                                            密码：
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtPassword" runat="server" CssClass="loginInput_in" TextMode="Password" MaxLength="20"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th scope="row" height="45">
                                            &nbsp;
                                        </th>
                                        <td>
                                            <label for="<%=autoLogin.ClientID %>">
                                                <input type="checkbox" id="autoLogin" runat="server" class="jz" />自动登录</label>
                                            <a href="#" target="_blank" class="blue">忘记密码</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th scope="row" height="40">
                                            &nbsp;
                                        </th>
                                        <td height="40">
                                            <input type="submit" class="btn96_35" value="登录" />
                                        </td>
                                    </tr>
                                </table>
                                </form>
                            </div>
                            <div class="blank8px">
                            </div>
                            <div class="lh22 Logpad">
                                <p class="lh22">
                                    <strong>>还没申请？</strong><br />
                                    马上申请并填写简历，轻松获得更好的工作机会
                                </p>
                                <div class="blank15px">
                                </div>
                                <p class="tc">
                                    <a href="/Register.aspx" class="btn160_45">申请成为新会员</a>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="loginBtm">
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function checkForm() {
            var error = "";
            if (!$("#<%=txtUserName.ClientID %>").val()) {
                error = "会员名不能为空！\n";
            }
            if (!$("#<%=txtPassword.ClientID %>").val()) {
                error += "密码不能为空！\n";
            }
            if (error.length > 0) {
                alert(error);
                return false;
            }else {
                return true;
            }
        }
    </script>

</asp:Content>
