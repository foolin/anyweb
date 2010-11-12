<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MemAddInfo.aspx.cs" Inherits="User_MemAddInfo" %>

<%@ Register Src="~/Control/UserSidebar.ascx" TagName="UserSidebar" TagPrefix="uc1" %>
<%@ Register Src="~/Control/Area.ascx" TagName="Area" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="resumePage">
        <uc1:UserSidebar runat="server" />
        <div class="content column">
            <div class="tit gray">
                <a href="/Index.aspx">首页</a> > <a href="/User/Index.aspx">个人会员</a> > <span class="green">
                    会员管理</span></div>
            <div class="MemCon">
                <div class="blank12px">
                </div>
                <div class="Res670">
                    <form runat="server" id="form1" onsubmit="return checkForm()">
                    <div class="blank8px">
                    </div>
                    <div class="modifypwd lh24">
                        <table width="540" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <th scope="row">
                                    <span class="brown">*</span>姓 名
                                </th>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" CssClass="reginput" MaxLength="30"></asp:TextBox>
                                </td>
                                <td>
                                    <span class="tipW" style="display: none" id="Error_Name">姓名不能为空！</span>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">
                                    <span class="brown">*</span>性 别
                                </th>
                                <td>
                                    <asp:RadioButton ID="Radio1" runat="server" Text="男" GroupName="sex" Checked="true" />
                                    <asp:RadioButton ID="Radio2" runat="server" Text="女" GroupName="sex" />
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">
                                    <span class="brown">*</span>出生日期
                                </th>
                                <td>
                                    <asp:DropDownList ID="drpBirYear" runat="server">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="drpBirMonth" runat="server">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="drpBirDay" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <span class="tipW" style="display: none" id="Error_Bir">请选择出生日期！</span> <span class="tipW"
                                        style="display: none" id="Error_Bir_1">请选择正确的出生日期！</span>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">
                                    <span class="brown">*</span>工作年限
                                </th>
                                <td>
                                    <asp:DropDownList ID="drpExp" runat="server">
                                        <asp:ListItem Value="0" Text="请选择年限"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="1年以下"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="1-2年"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="2-5年"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="5-10年"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="10年以上"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <span class="tipW" style="display: none" id="Error_Exp">请选择工作年限！</span>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">
                                    <span class="brown">*</span>证件类型
                                </th>
                                <td>
                                    <asp:DropDownList ID="drpIdenID" runat="server">
                                        <asp:ListItem Value="0" Text="请选择证件"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="身份证"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="军人证"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="香港身份证"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="其他"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <span class="tipW" style="display: none" id="Error_IdenID">请选择证件类型！</span>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">
                                    <span class="brown">*</span>证件号
                                </th>
                                <td>
                                    <asp:TextBox ID="txtIdenNum" runat="server" CssClass="reginput" MaxLength="20"></asp:TextBox>
                                </td>
                                <td>
                                    <span class="tipW" style="display: none" id="Error_IdenNum">证件号不能为空！</span>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">
                                    <span class="brown">*</span>居 住 地
                                </th>
                                <td>
                                    <a href="javascript:void(0);" onclick="selectArea('Address','<%=txtAddressID.ClientID %>','<%=txtAddress.ClientID %>')"
                                        id="Address" class="btn28H" style="font-size: 12px;">
                                        <%=this.LoginUser.fdUserAddress==""?"选择/修改":this.LoginUser.fdUserAddress %></a>
                                    <asp:TextBox ID="txtAddressID" runat="server" Style="display: none"></asp:TextBox>
                                    <asp:TextBox ID="txtAddress" runat="server" Style="display: none"></asp:TextBox>
                                </td>
                                <td>
                                    <span class="tipW" style="display: none" id="Error_Address">请选择居住地！</span>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">
                                    <span class="brown">*</span>求职状态
                                </th>
                                <td>
                                    <asp:DropDownList ID="drpCurrSitu" runat="server">
                                        <asp:ListItem Value="0" Text="请选择求职状态"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="目前正在找工作"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="半年内无换工作的计划"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="一年内无换工作的计划"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="观望有好的机会再考虑"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="我暂时不想找工作"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <span class="tipW" style="display: none" id="Error_CurrSitu">请选择求职状态！</span>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">
                                    &nbsp;毕业时间
                                </th>
                                <td>
                                    <asp:DropDownList ID="drpGraYear" runat="server">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="drpGraMonth" runat="server">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="drpGraDay" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <span class="tipW" style="display: none" id="Error_Gra">请选择正确的毕业时间！</span>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">
                                    &nbsp;政治面貌
                                </th>
                                <td>
                                    <asp:DropDownList ID="drpPolSta" runat="server">
                                        <asp:ListItem Value="0" Text="请选择政治面貌"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="群众"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="团员"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="党员"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">
                                    <span class="brown">*</span>教育程度
                                </th>
                                <td>
                                    <asp:DropDownList ID="drpDegree" runat="server">
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
                                <td>
                                    <span class="tipW" style="display: none" id="Error_Degree">请选择教育程度！</span>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">
                                    &nbsp;联系方式
                                </th>
                                <td class="brown">
                                    (请至少填写一项,只支持数字且数字之间不要用分隔符)
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">
                                    &nbsp;手机号码
                                </th>
                                <td>
                                    <asp:TextBox ID="txtMobPhoNum1" runat="server" CssClass="reginput" Style="width: 40px"
                                        Text="086" MaxLength="5"></asp:TextBox>-
                                    <asp:TextBox ID="txtMobPhoNum2" runat="server" CssClass="reginput" Style="width: 111px;"
                                        Text="手机号码" MaxLength="11"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">
                                    &nbsp;公司电话
                                </th>
                                <td>
                                    <asp:TextBox ID="txtComPhoNum1" runat="server" CssClass="reginput" Style="width: 40px"
                                        Text="086" MaxLength="5"></asp:TextBox>-
                                    <asp:TextBox ID="txtComPhoNum2" runat="server" CssClass="reginput" Style="width: 40px"
                                        Text="区号" MaxLength="5"></asp:TextBox>-
                                    <asp:TextBox ID="txtComPhoNum3" runat="server" CssClass="reginput" Style="width: 61px"
                                        Text="总机号码" MaxLength="8"></asp:TextBox>-
                                    <asp:TextBox ID="txtComPhoNum4" runat="server" CssClass="reginput" Style="width: 40px"
                                        Text="分机" MaxLength="10"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">
                                    &nbsp;家庭电话
                                </th>
                                <td>
                                    <asp:TextBox ID="txtFamPhoNum1" runat="server" CssClass="reginput" Style="width: 40px"
                                        Text="086" MaxLength="5"></asp:TextBox>-
                                    <asp:TextBox ID="txtFamPhoNum2" runat="server" CssClass="reginput" Style="width: 40px"
                                        Text="区号" MaxLength="5"></asp:TextBox>-
                                    <asp:TextBox ID="txtFamPhoNum3" runat="server" CssClass="reginput" Style="width: 61px"
                                        Text="电话号码" MaxLength="8"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row" style="height: 32px;">
                                    &nbsp;户 口
                                </th>
                                <td>
                                    <a href="javascript:void(0);" onclick="selectArea('hukou','<%=txtHouseAddressID.ClientID %>','<%=txtHouseAddress.ClientID %>')"
                                        id="hukou" class="btn28H" style="font-size: 12px;">
                                        <%=this.LoginUser.fdUserHouseAddress==""?"选择/修改":this.LoginUser.fdUserHouseAddress %></a>
                                    <asp:TextBox ID="txtHouseAddressID" runat="server" Style="display: none"></asp:TextBox>
                                    <asp:TextBox ID="txtHouseAddress" runat="server" Style="display: none"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">
                                    <span class="brown">*</span>国家地区
                                </th>
                                <td>
                                    <asp:DropDownList ID="drpCountry" runat="server">
                                        <asp:ListItem Value="0" Text="请选择国家地区"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="大陆"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="香港"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="澳门"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="台湾"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="国外"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <span class="tipW" style="display: none" id="Error_Country">请选择国家地区！</span>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">
                                    &nbsp;身 高
                                </th>
                                <td>
                                    <asp:TextBox ID="txtHeight" runat="server" CssClass="reginput" MaxLength="3" Width="40px"></asp:TextBox>cm
                                </td>
                                <td>
                                    <span class="tipW" style="display: none" id="Error_Height">身高格式不正确！</span>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">
                                    &nbsp;邮 编
                                </th>
                                <td>
                                    <asp:TextBox ID="txtPostCode" runat="server" CssClass="reginput" MaxLength="6"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">
                                    &nbsp;地 址
                                </th>
                                <td>
                                    <asp:TextBox ID="txtConAddr" runat="server" CssClass="reginput" MaxLength="50"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">
                                    &nbsp;婚姻状况
                                </th>
                                <td>
                                    <asp:DropDownList ID="drpMarry" runat="server">
                                        <asp:ListItem Value="0" Text="请选择婚姻状况"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="未婚"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="已婚"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">
                                    &nbsp;个人主页
                                </th>
                                <td>
                                    <asp:TextBox ID="txtWebsite" runat="server" CssClass="reginput" MaxLength="200"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="blank12px">
                    </div>
                    <div class="lh24">
                        <input type="submit" class="btn94_28" value="保 存" />
                    </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <uc1:Area runat="server" />

    <script type="text/javascript">
        function checkForm() {
            var error = true;
            var name = $.trim($("#<%=txtName.ClientID %>").val());
            var biryear = $("#<%=drpBirYear.ClientID %>").val();
            var birMonth = $("#<%=drpBirMonth.ClientID %>").val();
            var birday = $("#<%=drpBirDay.ClientID %>").val();
            var Exp = $("#<%=drpExp.ClientID %>").val();
            var IdenID = $("#<%=drpIdenID.ClientID %>").val();
            var idenNum = $.trim($("#<%=txtIdenNum.ClientID %>").val());
            var Address = $("#<%=txtAddressID.ClientID %>").val();
            var CurrSitu = $("#<%=drpCurrSitu.ClientID %>").val();
            var Degree = $("#<%=drpDegree.ClientID %>").val();
            var Country = $("#<%=drpCountry.ClientID %>").val();
            var Height = $.trim($("#<%=txtHeight.ClientID %>").val());
            var grayear = $("#<%=drpGraYear.ClientID %>").val();
            var graMonth = $("#<%=drpGraMonth.ClientID %>").val();
            var graday = $("#<%=drpGraDay.ClientID %>").val();

            if (!name) {
                $("#Error_Name").show();
                error = false;
            } else {
                $("#Error_Name").hide();
            }

            if (biryear == "0" || birMonth == "0" || birday == "0") {
                $("#Error_Bir").show();
                $("#Error_Bir_1").hide();
                error = false;
            } else if (!isValidDate(biryear, birMonth, birday)) {
                $("#Error_Bir").hide();
                $("#Error_Bir_1").show();
                error = false;
            } else {
                $("#Error_Bir").hide();
                $("#Error_Bir_1").hide();
            }

            if (grayear == "0" && graMonth == "0" && graday == "0") {
                $("#Error_Gra").hide();
            } else if (!isValidDate(grayear, graMonth, graday)) {
                $("#Error_Gra").show();
                error = false;
            }

            if (Exp == "0") {
                $("#Error_Exp").show();
                error = false;
            } else {
                $("#Error_Exp").hide();
            }

            if (IdenID == "0") {
                $("#Error_IdenID").show();
                error = false;
            } else {
                $("#Error_IdenID").hide();
            }

            if (!idenNum) {
                $("#Error_IdenNum").show();
                error = false;
            } else {
                $("#Error_IdenNum").hide();
            }

            if (!Address || Address == "0") {
                $("#Error_Address").show();
                error = false;
            } else {
                $("#Error_Address").hide();
            }

            if (CurrSitu == "0") {
                $("#Error_CurrSitu").show();
                error = false;
            } else {
                $("#Error_CurrSitu").hide();
            }

            if (Degree == "0") {
                $("#Error_Degree").show();
                error = false;
            } else {
                $("#Error_Degree").hide();
            }

            if (Country == "0") {
                $("#Error_Country").show();
                error = false;
            } else {
                $("#Error_Country").hide();
            }

            if (!Height) {
                $("#Error_Height").hide();
            } else {
                if (!parseInt(Height)) {
                    $("#Error_Height").show();
                    error = false;
                } else {
                    $("#Error_Height").hide();
                }
            }

            return error;
        }
        function selectArea(area, id, name) {
            currentarea = area;
            currentid = id;
            currentname = name;
            ChooseArea();
        }
    </script>

    <script type="text/javascript">
        setUserSidebar("JBXX");
    </script>

</asp:Content>
