<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="MemberInfo.aspx.cs" Inherits="Admin_MemberInfo" Title="会员信息详情" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                会员信息详情</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    登陆邮箱：</label>
                <%=member.fdMembEmail%>
            </div>
            <div class="fi even">
                <label>
                    昵称：</label>
                <%=member.fdMembName %>
            </div>
            <div class="fi">
                <label>
                    状态：</label>
                <%=member.fdMembStatus == 1 ? "正常" : "<span style='color:red'>锁定</span>"%>
            </div>
            <div class="fi even">
                <label>
                    真实姓名：</label>
                <%=member.fdMembTrueName %>
            </div>
            <div class="fi">
                <label>
                    头像：</label>
                <div>
                    <img width="<%=AnyWeb.AW.Configs.GeneralConfigs.GetConfig().MemberAvatorWidth %>"
                        height="<%=AnyWeb.AW.Configs.GeneralConfigs.GetConfig().MemberAvatorHeight %>"
                        src="<%=member.fdMembAvator %>" /></div>
            </div>
            <div class="fi even">
                <label>
                    性别：</label>
                <%=member.fdMembSex == 0 ? "未知" : member.fdMembSex == 1?"男":"女"%>
            </div>
            <div class="fi">
                <label>
                    生日：</label>
                <%= member.fdMembBirthday%>
            </div>
            <div class="fi even">
                <label>
                    地址：</label>
                <%=member.fdMembAddress %>
            </div>
            <div class="fi">
                <label>
                    邮政编码：</label>
                <%=member.fdMembPostcode %>
            </div>
            <div class="fi even">
                <label>
                    手机：</label>
                <%=member.fdMembMobile %>
            </div>
            <div class="fi">
                <label>
                    电话：</label>
                <%=member.fdMembPhone%>
            </div>
            <div class="fi even">
                <label>
                    QQ：</label>
                <%=member.fdMembQQ%>
            </div>
            <div class="fi">
                <label>
                    MSN：</label>
                <%=member.fdMembMSN%>
            </div>
            <div class="fi even">
                <label>
                    其他联系方式：</label>
                <%=member.fdMembOtherContact%>
            </div>
            <div class="fi">
                <label>
                    省市地区：</label>
                <select id="drpProvince" disabled="disabled" name="drpProvince">
                </select>省<select id="drpCity" disabled="disabled" name="drpCity"></select>市<select
                    id="drpArea" disabled="disabled" name="drpArea"></select>区
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

            <div class="fi even">
                <label>
                    积分：</label>
                <%=member.fdMembPoint %>
            </div>
            <div class="fi">
                <label>
                    密码提示问题：</label>
                <%=member.fdMembPwdQuestion %>
            </div>
            <div class="fi even">
                <label>
                    密码回答问题：</label>
                <%=member.fdMembPwdAnswer %>
            </div>
            <div class="fi">
                <label>
                    注册时间：</label>
                <%=member.fdMembRegAt.ToString("yyyy年MM月dd日 HH时mm分ss秒")%>
            </div>
            <div class="fi even">
                <label>
                    最后登录：</label>
                登陆IP:<%=member.fdMembLoginIP %>，登陆时间:<%=member.fdMembLoginAt.ToString("yyyy年MM月dd日 HH时mm分ss秒")%>。
            </div>
            <div class="fi">
                <label>
                    更新时间：</label>
                <%=member.fdMembLoginAt.ToString("yyyy年MM月dd日 HH时mm分ss秒")%>
            </div>
            <div class="fi fiBtns">
                <input type="button" class="submit" onclick="window.location='MemberEdit.aspx?id=<%=member.fdMembID %>'"
                    value="编辑" />
                <a href="MemberList.aspx">返回列表</a>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>该页显示会员信息详情</li>
        </ul>
    </div>
</asp:Content>
