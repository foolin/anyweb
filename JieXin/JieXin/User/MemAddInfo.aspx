<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MemAddInfo.aspx.cs" Inherits="User_Default" %>

<%@ Register Src="~/Control/UserSidebar.ascx" TagName="UserSidebar" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="resumePage">
    	<uc1:UserSidebar runat="server" />
        <div class="content column">
        	<div class="tit gray"><a href="/Index.aspx">首页</a> > <a href="/User/Index.aspx">个人会员</a> > <span class="green">
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
                            <td>
                                <asp:RadioButton ID="Radio1" runat="server" Text="男" GroupName="sex" />
                                <asp:RadioButton ID="Radio2" runat="server" Text="女" GroupName="sex" />
                            </td>
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
                                <asp:DropDownList ID="drpIdenID"  runat="server">
                                    <asp:ListItem Value="0" Text="请选择证件"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="身份证"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="军人证"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="香港身份证"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="其他"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row"><span class="brown">*</span>证件号</th>
                            <td>
                                <asp:TextBox ID="txtIdenNum" runat="server" CssClass="reginput" MaxLength="50"></asp:TextBox>
                            </td>
                            <td>
                                <span class="tipW" style="display:none" id="Error_IdenNum">证件号不能为空！</span>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row"><span class="brown">*</span>居 住 地</th>
                            <td>
                                <a href="javascript:void(0);" id="Address" class="btn28H" style="font-size:12px;">
                                选择/修改</a>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row"><span class="brown">*</span>求职状态</th>
                            <td>
                                <asp:DropDownList ID="drpCurrSitu"  runat="server">
                                    <asp:ListItem Value="0" Text="请选择求职状态" ></asp:ListItem>
                                    <asp:ListItem Value="1" Text="目前正在找工作" ></asp:ListItem>
                                    <asp:ListItem Value="2" Text="半年内无换工作的计划" ></asp:ListItem>
                                    <asp:ListItem Value="3" Text="一年内无换工作的计划" ></asp:ListItem>
                                    <asp:ListItem Value="4" Text="观望有好的机会再考虑" ></asp:ListItem>
                                    <asp:ListItem Value="5" Text="我暂时不想找工作" ></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row">&nbsp;民 族</th>
                            <td>
                                <asp:DropDownList ID="drpNation"  runat="server">
                                    <asp:ListItem Value="0" Text="请选择民族"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row">&nbsp;毕业时间</th>
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
                            <th scope="row">&nbsp; 政治面貌</th>
                            <td>
                                <asp:DropDownList ID="drpPolSta"  runat="server">
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
                                <asp:DropDownList ID="drpDegree"  runat="server">
                                    <asp:ListItem Value="0" Text="请选择教育程度"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="初中"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="高中"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="中技"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="中专"></asp:ListItem>
                                    <asp:ListItem Value="5" Text="大专"></asp:ListItem>
                                    <asp:ListItem Value="6" Text="本科"></asp:ListItem>
                                    <asp:ListItem Value="7" Text="MBA"></asp:ListItem>
                                    <asp:ListItem Value="8" Text="硕士"></asp:ListItem>
                                    <asp:ListItem Value="9" Text="博士"></asp:ListItem>
                                    <asp:ListItem Value="10" Text="其他"></asp:ListItem>
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
                            <th scope="row">&nbsp;手机号码</th>
                            <td>
                                <asp:TextBox ID="txtMobPhoNum1" runat="server" CssClass="reginput" style="width:40px"></asp:TextBox>-
                                <asp:TextBox ID="txtMobPhoNum2" runat="server" CssClass="reginput" style="width:111px;"></asp:TextBox>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row">&nbsp;公司电话</th>
                            <td>
                                <asp:TextBox ID="txtComPhoNum1" runat="server" CssClass="reginput" style="width:40px" ></asp:TextBox>-
                                <asp:TextBox ID="txtComPhoNum2" runat="server" CssClass="reginput" style="width:40px" ></asp:TextBox>-
                                <asp:TextBox ID="txtComPhoNum3" runat="server" CssClass="reginput" style="width:61px" ></asp:TextBox>-
                                <asp:TextBox ID="txtComPhoNum4" runat="server" CssClass="reginput" style="width:40px" ></asp:TextBox>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row">&nbsp;家庭电话</th>
                            <td>
                                <asp:TextBox ID="txtFamPhoNum1" runat="server" CssClass="reginput" style="width:40px" ></asp:TextBox>-
                                <asp:TextBox ID="txtFamPhoNum2" runat="server" CssClass="reginput" style="width:40px" ></asp:TextBox>-
                                <asp:TextBox ID="txtFamPhoNum3" runat="server" CssClass="reginput" style="width:61px" ></asp:TextBox>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row" style="height:32px;"> &nbsp;户 口</th>
                            <td><a href="javascript:void(0);" id="hukou" class="btn28H" style="font-size:12px;">
                                选择/修改</a></td>
                          </tr>
                          <tr>
                            <th scope="row" style="height:32px;"><span class="brown">*</span>国家地区</th>
                            <td><a href="javascript:void(0);" id="contry" class="btn28H" style="font-size:12px;">
                                选择/修改</a></td>
                          </tr>
                          <tr>
                            <th scope="row">&nbsp;身 高</th>
                            <td>
                                <asp:TextBox ID="txtHeight" runat="server" CssClass="reginput" MaxLength="100"></asp:TextBox>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row">&nbsp;邮 编</th>
                            <td>
                                <asp:TextBox ID="txtPostCode" runat="server" CssClass="reginput" MaxLength="100"></asp:TextBox>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row">&nbsp;地 址</th>
                            <td>
                                <asp:TextBox ID="txtConAddr" runat="server" CssClass="reginput" MaxLength="100"></asp:TextBox>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row">&nbsp;婚姻状况</th>
                            <td>
                                <asp:DropDownList ID="drpMarry"  runat="server">
                                    <asp:ListItem Value="0" Text="请选择婚姻状况"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="未婚"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="已婚"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                          </tr>
                          <tr>
                            <th scope="row">&nbsp;个人主页</th>
                            <td>
                                <asp:TextBox ID="txtWebsite" runat="server" CssClass="reginput" MaxLength="100"></asp:TextBox>
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
            var idenNum = $.trim($("#<%=txtIdenNum.ClientID %>").val());
            
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

            if (!idenNum) {
                $("#Error_IdenNum").show();
                error = false;
            } else {
                $("#Error_IdenNum").hide();
            }

            
            return error;
        }
    </script>
    <script type="text/javascript">
        setUserSidebar("JBXX");
    </script>
</asp:Content>

