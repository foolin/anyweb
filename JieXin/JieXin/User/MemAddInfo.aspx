<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MemAddInfo.aspx.cs" Inherits="User_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="resumePage">
    	<div class="sidebar" style="height:1300px;">
        	<div class="bg column gray">
            	<ul>
                	<li><a href="#">简历管理</a></li>
                    <li class="cur"><a href="#">基本信息管理</a></li>
                    <li><a href="#">形象照片管理</a></li>
                    <li><a href="#">密码管理</a></li>
                    <li><a href="#">邮箱管理</a></li>
                </ul>
            </div>
        </div>
        <div class="content column">
        	<div class="tit gray"><a href="#">首页</a> &gt; <a href="#">个人会员</a> &gt; <span class="green">
                会员管理</span></div>
            <div class="MemCon">
            	<div class="blank12px"></div>
                <div class="Res670">
                    <form runat="server" id="form1" onsubmit="return checkRegister()">
                    <div class="blank8px"></div>
                    <div class="modifypwd lh24">
						<table width="540" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <th scope="row"><span class="brown">*</span>姓 名</th>
                            <td>
                                <asp:TextBox ID="txtName" runat="server" CssClass="reginput" MaxLength="50"></asp:TextBox>
                            </td>
                            <td>
                                <span class="tipW" style="display:none" id="Error_Name">姓名不能为空！</span>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row"><span class="brown">*</span>性 别</th>
                            <td>男<input type="radio" name="sex" value="男" checked="checked" /> 女<input type="radio" value="女" name="sex" /> </td>
                          </tr>
                          <tr>
                            <th scope="row"><span class="brown">*</span>出生日期</th>
                                <td>
                                    <asp:DropDownList ID="drpBirYear"  runat="server">
                                        <asp:ListItem Value="0" Text="请选择年份"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="drpBirMonth"  runat="server">
                                        <asp:ListItem Value="0" Text="请选择月份"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="drpBirDay"  runat="server">
                                        <asp:ListItem Value="0" Text="请选择日期"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                          </tr>
                          <tr>
                            <th scope="row"><span class="brown">*</span>工作年限</th>
                            <td>
                                <asp:DropDownList ID="drpExp"  runat="server">
                                    <asp:ListItem Value="0" Text="请选择年限"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="1年以下"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="1-2年"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="2-5年"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="5-10年"></asp:ListItem>
                                    <asp:ListItem Value="5" Text="10年以上"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row"><span class="brown">*</span>证件类型</th>
                            <td>
                                <asp:DropDownList ID="drpCardCate"  runat="server">
                                    <asp:ListItem Value="0" Text="请选择证件"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="身份证"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="学生证"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="军官证"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row"><span class="brown">*</span>证件号</th>
                            <td>
                                <asp:TextBox ID="txtCardID" runat="server" CssClass="reginput" MaxLength="50"></asp:TextBox>
                            </td>
                            <td>
                                <span class="tipW" style="display:none" id="Error_CardID">证件号不能为空！</span>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row"><span class="brown">*</span>居 住 地</th>
                            <td>
                                <a href="javascript:void(0);" id="place" class="btn28H" style="font-size:12px;">
                                选择/修改</a>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row"><span class="brown">*</span>求职状态</th>
                            <td>
                                <asp:DropDownList ID="DropDownList3"  runat="server">
                                    <asp:ListItem Value="0" Text="请选择求职状态"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row">民 族</th>
                            <td>
                                <asp:DropDownList ID="drpNati"  runat="server">
                                    <asp:ListItem Value="0" Text="请选择民族"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row">毕业时间</th>
                            <td>
                                <asp:DropDownList ID="drpGraYear"  runat="server">
                                    <asp:ListItem Value="0" Text="请选择年份"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="drpGraMonth"  runat="server">
                                    <asp:ListItem Value="0" Text="请选择月份"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="drpGraDay"  runat="server">
                                    <asp:ListItem Value="0" Text="请选择日期"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row">政治面貌</th>
                            <td>
                                <asp:DropDownList ID="DropDownList8"  runat="server">
                                    <asp:ListItem Value="0" Text="请选择政治面貌"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="群众"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="团员"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="党员"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row"><span class="brown">*</span>教育程度</th>
                            <td>
                                <asp:DropDownList ID="DropDownList9"  runat="server">
                                    <asp:ListItem Value="0" Text="请选择教育程度"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="小学"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="初中"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="高中"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="专科"></asp:ListItem>
                                    <asp:ListItem Value="5" Text="本科"></asp:ListItem>
                                    <asp:ListItem Value="6" Text="硕士"></asp:ListItem>
                                    <asp:ListItem Value="7" Text="博士"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row"><span class="brown">*</span>Email</th>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="reginput" MaxLength="100"></asp:TextBox>
                            </td>
                            <td>
                                <span class="tipW" style="display:none" id="Error_Email">邮箱不能为空！</span>
                                <span class="tipW" style="display:none" id="Error_Email2">邮箱格式不正确！</span>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row"><span class="brown">*</span>联系方式</th>
                            <td class="brown">(请至少填写一项) </td>
                            <td>
                                <span class="tipW" style="display:none" id="Error_PhoNum">至少要填写一项联系方式！</span>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row">手机号码</th>
                            <td>
                                <asp:TextBox ID="txtMobPhoNum1" runat="server" CssClass="reginput" style="width:40px"></asp:TextBox>-
                                <asp:TextBox ID="txtMobPhoNum2" runat="server" CssClass="reginput" style="width:111px;"></asp:TextBox>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row">公司电话</th>
                            <td>
                                <asp:TextBox ID="txtComPhoNum1" runat="server" CssClass="reginput" style="width:40px" ></asp:TextBox>-
                                <asp:TextBox ID="txtComPhoNum2" runat="server" CssClass="reginput" style="width:40px" ></asp:TextBox>-
                                <asp:TextBox ID="txtComPhoNum3" runat="server" CssClass="reginput" style="width:61px" ></asp:TextBox>-
                                <asp:TextBox ID="txtComPhoNum4" runat="server" CssClass="reginput" style="width:40px" ></asp:TextBox>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row">家庭电话</th>
                            <td>
                                <asp:TextBox ID="txtFamPhoNum1" runat="server" CssClass="reginput" style="width:40px" ></asp:TextBox>-
                                <asp:TextBox ID="txtFamPhoNum2" runat="server" CssClass="reginput" style="width:40px" ></asp:TextBox>-
                                <asp:TextBox ID="txtFamPhoNum3" runat="server" CssClass="reginput" style="width:61px" ></asp:TextBox>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row" style="height:32px;">户 口</th>
                            <td><a href="javascript:void(0);" id="hukou" class="btn28H" style="font-size:12px;">
                                选择/修改</a></td>
                          </tr>
                          <tr>
                            <th scope="row" style="height:32px;"><span class="brown">*</span>国家地区</th>
                            <td><a href="javascript:void(0);" id="contry" class="btn28H" style="font-size:12px;">
                                选择/修改</a></td>
                          </tr>
                          <tr>
                            <th scope="row">身 高</th>
                            <td>
                                <asp:TextBox ID="txtHeight" runat="server" CssClass="reginput" MaxLength="100"></asp:TextBox>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row">邮 编</th>
                            <td>
                                <asp:TextBox ID="txtPostcode" runat="server" CssClass="reginput" MaxLength="100"></asp:TextBox>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row">地 址</th>
                            <td>
                                <asp:TextBox ID="txtAddr" runat="server" CssClass="reginput" MaxLength="100"></asp:TextBox>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row">婚姻状况</th>
                            <td>
                                <asp:DropDownList ID="drpMarr"  runat="server">
                                    <asp:ListItem Value="0" Text="请选择婚姻状况"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="未婚"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="已婚"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row">个人主页</th>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="reginput" MaxLength="100"></asp:TextBox>
                            </td>
                          </tr>
                        </table>
                    </div>
                    <div class="blank12px"></div>
                    <div class="lh24">
                    	<input type="submit" class="btn94_28" value="保 存" />
                    </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function checkRegister() {
            var error = true;
            var mailValid = /^\w+([-+.]\w+)*@\w+([-.]\\w+)*\.\w+([-.]\w+)*$/;
            var mail = $.trim($("#<%=txtEmail.ClientID %>").val());
            var name = $.trim($("#<%=txtName.ClientID %>").val());
            var cardid = $.trim($("#<%=txtCardID.ClientID %>").val());
            var mobPhoNum = $.trim($("#<%=txtMobPhoNum1.ClientID %>").val()+$("#<%=txtMobPhoNum1.ClientID %>").val());
            var comPhoNum = $.trim($("#<%=txtComPhoNum1.ClientID %>").val()+$("#<%=txtComPhoNum2.ClientID %>").val()+$("#<%=txtComPhoNum3.ClientID %>").val()+$("#<%=txtComPhoNum4.ClientID %>").val());
            var famPhoNum = $.trim($("#<%=txtFamPhoNum1.ClientID %>").val()+$("#<%=txtFamPhoNum2.ClientID %>").val()+$("#<%=txtFamPhoNum3.ClientID %>").val());

            if (!mail) {
                $("#Error_Email").show();
                $("#Error_Email2").hide();
            } else if (!mailValid.test(mail)) {
                $("#Error_Email").hide();
                $("#Error_Email2").show();
                error = false;
            } else {
                $("#Error_Email").hide();
                $("#Error_Email2").hide();
            }
            
            if (!name) {
                $("#Error_Name").show();
                error = false;
            } else {
                $("#Error_Name").hide();
            }

            if (!cardid) {
                $("#Error_CardID").show();
                error = false;
            } else {
                $("#Error_CardID").hide();
            }

            if (!mobPhoNum&&!comPhoNum&&!famPhoNum) {
                $("#Error_PhoNum").show();
                error = false;
            } else {
                $("#Error_PhoNum").hide();
            }
            
            return error;
        }
    </script>
</asp:Content>

