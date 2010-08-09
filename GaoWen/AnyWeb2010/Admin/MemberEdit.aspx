<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="MemberEdit.aspx.cs" Inherits="Admin_MemberEdit" Title="修改会员信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                修改会员信息</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    登陆邮箱：</label>
                <asp:TextBox ID="txtEmail" MaxLength="50" Enabled="false" runat="server" CssClass="text" />
            </div>
            <div class="fi even">
                <label>
                    昵称：</label>
                <asp:TextBox ID="txtName" MaxLength="20" runat="server" CssClass="text" />
            </div>
            <div class="fi">
                <label>
                    密码：</label>
                <asp:TextBox ID="txtPassword" TextMode="Password" MaxLength="50" runat="server" CssClass="text" />
                <span style="color: #999">置留空不修改密码</span>
            </div>
            <div class="fi even">
                <label>
                    状态：</label>
                <asp:DropDownList ID="drpStatus" runat="server">
                    <asp:ListItem Value="1">正常</asp:ListItem>
                    <asp:ListItem Value="2">锁定</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="fi">
                <label>
                    真实姓名：</label>
                <asp:TextBox ID="txtTrueName" MaxLength="50" runat="server" CssClass="text" />
            </div>
            <div class="fi even">
                <label>
                    头像：</label>
                <div class="cont">
                    <asp:FileUpload ID="fileAvator" runat="server" CssClass="text" Width="400px" />
                    <div style="padding: 3px;">
                        <asp:Image ID="imgPicture" runat="server" /></div>
                </div>
            </div>
            <div class="fi">
                <label>
                    性别：</label>
                <asp:DropDownList ID="drpSex" runat="server">
                    <asp:ListItem Value="0">未知</asp:ListItem>
                    <asp:ListItem Value="1">男</asp:ListItem>
                    <asp:ListItem Value="2">女</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="fi even">
                <label>
                    生日：</label>
                <asp:TextBox ID="txtBirthday" onclick="setday(this)" MaxLength="50" runat="server"
                    CssClass="text" />
            </div>
            <div class="fi">
                <label>
                    地址：</label>
                <asp:TextBox ID="txtAddress" MaxLength="100" runat="server" CssClass="text" />
            </div>
            <div class="fi even">
                <label>
                    邮政编码：</label>
                <asp:TextBox ID="txtPostCode" MaxLength="10" runat="server" CssClass="text" />
            </div>
            <div class="fi">
                <label>
                    手机：</label>
                <asp:TextBox ID="txtMobile" MaxLength="20" runat="server" CssClass="text" />
            </div>
            <div class="fi even">
                <label>
                    电话：</label>
                <asp:TextBox ID="txtPhone" MaxLength="30" runat="server" CssClass="text" />
            </div>
            <div class="fi">
                <label>
                    QQ：</label>
                <asp:TextBox ID="txtQQ" MaxLength="10" runat="server" CssClass="text" />
            </div>
            <div class="fi even">
                <label>
                    MSN：</label>
                <asp:TextBox ID="txtMSN" MaxLength="50" runat="server" CssClass="text" />
            </div>
            <div class="fi">
                <label>
                    其他联系方式：</label>
                <asp:TextBox ID="txtOtherContact" MaxLength="200" runat="server" CssClass="text" />
            </div>
            <div class="fi even">
                <label>
                    省市地区：</label>
                <select id="drpProvince" name="drpProvince">
                </select>省<select id="drpCity" name="drpCity"></select>市<select id="drpArea" name="drpArea"></select>区
            </div>

            <script type="text/javascript">
                        var arrSelectName = new Array(document.getElementById("drpProvince"),document.getElementById("drpCity"),document.getElementById("drpArea"));
		                var arrList = new Array(<%=RenderAreaJs()%>);
		                var arrDefault = new Array();
		                arrDefault[0] = '<%=member.fdMembProvinceID %>';
		                arrDefault[1] = '<%=member.fdMembCityID %>';
		                arrDefault[2] = '<%=member.fdMembAreaID %>';
		                
		                //无限级分类select函数相关
                        (function (strInitID, arrSelect, arrMatrix, arrDefValue) {
                            function doChange(iIndex) {
                                var iCount = 0;
                                var sParentID = strInitID;
                                if (iIndex > 0) sParentID = arrSelect[iIndex - 1].options[arrSelect[iIndex - 1].selectedIndex].ID;
                                with (arrSelect[iIndex]) {
                                    length = 0;
                                    for (var i = 0; i < arrMatrix.length; i++) {
                                        if (String(arrMatrix[i][1]) == String(sParentID)) {
                                            var oNewOption = new Option(arrMatrix[i][2], arrMatrix[i][3], false, false);
                                            oNewOption.ID = arrMatrix[i][0];
                                            options[iCount++] = oNewOption;
					                        if(arrMatrix[i][3] == arrDefValue[iIndex])options[iCount - 1].selected = true;
                                        };
                                    };
                                    if (iCount == 0) {
                                        var oNull = new Option("--", null, false, true);
                                        oNull.ID = "_0x" + (new Date()).getTime();
                                        options[0] = oNull;
                                    };
                                    if (++iIndex < arrSelect.length) doChange(iIndex);
                                };
                            };
                            if (!arrDefValue) arrDefValue = [];
                            for (var i = 0; i < arrSelect.length - 1; i++) {
                                eval("arrSelect[" + i + "].onchange = function(){ doChange(" + (i + 1) + "); };");
                            }
                            doChange(0);
                            arrDefValue = [];
                        })(0,arrSelectName,arrList,arrDefault);
            </script>

            <div class="fi">
                <label>
                    积分：</label>
                <asp:TextBox ID="txtPoint" MaxLength="50" runat="server" CssClass="text" />
            </div>
            <div class="fi even">
                <label>
                    密码提示问题：</label>
                <asp:TextBox ID="txtQuestion" MaxLength="50" CssClass="text" runat="server" />
            </div>
            <div class="fi">
                <label>
                    密码回答问题：</label>
                <asp:TextBox ID="txtAnswer" MaxLength="50" CssClass="text" runat="server" />
            </div>
            <div class="fi even">
                <label>
                    最后登录：</label>
                登陆IP:<asp:Label ID="lblLoginIP" runat="server" />，登陆时间:<asp:Label ID="lblLoginAt"
                    runat="server" />。
            </div>
            <div class="fi">
                <label>
                    更新时间：</label>
                <asp:Label ID="lblUpdateAt" runat="server" />
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存" OnClick="btnOk_Click" CssClass="submit">
                </asp:Button>
                <a href="MemberList.aspx">返回列表</a>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>该页实现修改会员信息功能</li>
        </ul>
    </div>
</asp:Content>
