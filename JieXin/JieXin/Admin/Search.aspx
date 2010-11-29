<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="Search.aspx.cs" Inherits="Admin_Search" %>

<%@ Register Src="Control/Area2.ascx" TagName="Area2" TagPrefix="uc1" %>
<%@ Register Src="Control/Industry2.ascx" TagName="Industry2" TagPrefix="uc1" %>
<%@ Register Src="Control/Major.ascx" TagName="Major" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">

    <script type="text/javascript" src="js/area.js"></script>

    <script type="text/javascript" src="js/major.js"></script>

    <script type="text/javascript" src="js/function.js"></script>

    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                人才搜索</h3>
        </div>
        <div class="mbd">
            <div class="fi even">
                <label>
                    简历编号：</label>
                <input type="text" id="no" class="text" style="width: 80px" />
                <span id="Error_no" class="invalid" style="display: none">编号格式错误！</span>
            </div>
            <div class="fi">
                <label>
                    搜索类别：</label>
                <select id="type" name="type">
                    <option value="1">全文</option>
                    <option value="2">职务名</option>
                    <option value="3">公司名</option>
                    <option value="4">学校名</option>
                    <option value="5">证书</option>
                    <option value="6">工作经历</option>
                </select>
            </div>
            <div class="fi even">
                <label>
                    关键字：</label>
                <input type="text" id="key" name="key" class="text" value="多关键字用空格隔开" style="color: DarkGray;"
                    onfocus="if(this.value=='多关键字用空格隔开'){this.value='';this.style.color='black';}"
                    onblur="if(this.value==''){this.value='多关键字用空格隔开';this.style.color='DarkGray';}" />
            </div>
            <div class="fi">
                <label>
                    目前居住地：</label>
                <a href="javascript:void(0);" onclick="ChooseArea2(this,'ChooseArea2','addressid','address');"
                    class="choAreabtn">选择/修改</a>
                <input type="hidden" id="addressid" name="addressid" />
                <input type="hidden" id="address" name="address" />
            </div>
            <div class="fi even">
                <label>
                    行业：</label>
                <a href="javascript:void(0);" onclick="ChooseIndustry2(this,'ChooseIndustry2','industryid','industry');"
                    class="choAreabtn">选择/修改</a>
                <input type="hidden" id="industryid" name="industryid" />
                <input type="hidden" id="industry" name="industry" />
            </div>
            <div class="fi">
                <label>
                    工作年限：</label>
                <select id="workfrom" name="workfrom">
                    <option value="0">不限</option>
                    <option value="1">1年以下</option>
                    <option value="2">1-2年</option>
                    <option value="3">2-5年</option>
                    <option value="4">5-10年</option>
                    <option value="5">10年以上</option>
                </select>
                到
                <select id="workto" name="workto">
                    <option value="0">不限</option>
                    <option value="1">1年以下</option>
                    <option value="2">1-2年</option>
                    <option value="3">2-5年</option>
                    <option value="4">5-10年</option>
                    <option value="5">10年以上</option>
                </select>
            </div>
            <div class="fi even">
                <label>
                    学历：</label>
                <select id="edufrom" name="edufrom">
                    <option value="0">不限</option>
                    <option value="1">初中</option>
                    <option value="2">高中</option>
                    <option value="3">中技</option>
                    <option value="4">中专</option>
                    <option value="5">大专</option>
                    <option value="6">本科</option>
                    <option value="7">MBA</option>
                    <option value="8">硕士</option>
                    <option value="9">博士</option>
                    <option value="10">其他</option>
                </select>
                到
                <select id="eduto" name="eduto">
                    <option value="0">不限</option>
                    <option value="1">初中</option>
                    <option value="2">高中</option>
                    <option value="3">中技</option>
                    <option value="4">中专</option>
                    <option value="5">大专</option>
                    <option value="6">本科</option>
                    <option value="7">MBA</option>
                    <option value="8">硕士</option>
                    <option value="9">博士</option>
                    <option value="10">其他</option>
                </select>
            </div>
            <div class="fi">
                <label>
                    年龄：</label>
                <input type="text" id="agefrom" name="agefrom" class="text" style="width: 40px;" />
                到
                <input type="text" id="ageto" name="ageto" class="text" style="width: 40px;" />
                <span id="Error_age" class="invalid" style="display: none">请输入数字！</span>
            </div>
            <div class="fi even">
                <label>
                    性别：</label>
                <select id="sex" class="select">
                    <option value="-1">不限</option>
                    <option value="0">男</option>
                    <option value="1">女</option>
                </select>
            </div>
            <div class="fi">
                <label>
                    目前月薪：</label>
                <select id="saleryfrom">
                    <option value="0">不限</option>
                    <option value="2">1500</option>
                    <option value="3">2000</option>
                    <option value="4">3000</option>
                    <option value="5">4500</option>
                    <option value="6">6000</option>
                    <option value="7">8000</option>
                    <option value="8">10000</option>
                    <option value="9">15000</option>
                    <option value="10">20000</option>
                    <option value="11">30000</option>
                    <option value="12">50000</option>
                </select>
                到
                <select id="saleryto">
                    <option value="0">不限</option>
                    <option value="1">1499</option>
                    <option value="2">1999</option>
                    <option value="3">2999</option>
                    <option value="4">4499</option>
                    <option value="5">5999</option>
                    <option value="6">7999</option>
                    <option value="7">9999</option>
                    <option value="8">14999</option>
                    <option value="9">19999</option>
                    <option value="10">29999</option>
                    <option value="11">49999</option>
                </select>
            </div>
            <div class="fi even">
                <label>
                    专业：</label>
                <a href="javascript:void(0);" onclick="ChooseMajor(this,'ChooseMajor','majorid','major');"
                    class="choAreabtn">选择/修改</a>
                <input type="hidden" id="majorid" name="majorid" />
                <input type="hidden" id="major" name="major" />
            </div>
            <div class="fi">
                <label>
                    简历更新：</label>
                <select id="update">
                    <option value="1">一周内</option>
                    <option value="2">两周内</option>
                    <option value="3">一个月内</option>
                    <option selected="selected" value="4">两个月内</option>
                    <option value="5">六个月内</option>
                    <option value="6">
                        <%=DateTime.Now.Year-1 %>年</option>
                    <option value="7">
                        <%=DateTime.Now.Year-2 %>年</option>
                    <option value="8">
                        <%=DateTime.Now.Year-3 %>年</option>
                </select>
            </div>
            <div class="fi fiBtns">
                <input type="button" value="搜索" class="submit" onclick="resumesearch();" />
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li></li>
        </ul>
    </div>
    <uc1:Area2 runat="server" />
    <uc1:Industry2 runat="server" />
    <uc1:Major runat="server" />

    <script type="text/javascript">
        $(document).ready(function() {
            myfun("industry2_ul", "li");
        });
    </script>

</asp:Content>
