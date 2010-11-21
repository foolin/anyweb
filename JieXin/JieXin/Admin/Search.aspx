<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="Search.aspx.cs" Inherits="Admin_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                人才搜索</h3>
        </div>
        <form>
        <div class="mbd">
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
                <input type="text" id="key" name="key" class="text" />
            </div>
            <div class="fi">
                <label>
                    目前居住地：</label>
                <input type="text" id="address" name="address" class="text" />
            </div>
            <div class="fi even">
                <label>
                    行业：</label>
                <input type="text" id="industry" name="industry" class="text" />
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
            </div>
            <div class="fi even">
                <label>
                    性别：</label>
                <label style="width: 50px;">
                    <input type="radio" name="sex" value="-1" class="radio" checked="checked" />不限</label>
                <label style="width: 40px;">
                    <input type="radio" name="sex" value="0" class="radio" />男</label>
                <label style="width: 40px;">
                    <input type="radio" name="sex" value="1" class="radio" />女</label>
            </div>
            <div class="fi">
                <label>
                    目前月薪：</label>
                <input type="text" id="saleryfrom" name="saleryfrom" class="text" style="width: 40px;" />
                到
                <input type="text" id="saleryto" name="saleryto" class="text" style="width: 40px;" />
            </div>
            <div class="fi even">
                <label>
                    专业：</label>
                <input type="text" id="major" name="major" class="text" />
            </div>
            <div class="fi">
                <label>
                    简历更新：</label>
                <select>
                    <option value="1">一周内</option>
                    <option value="2">两周内</option>
                    <option value="3">一个月内</option>
                    <option selected="selected" value="4">两个月内</option>
                    <option value="5">六个月内</option>
                    <option value="2010">2010年</option>
                    <option value="2009">2009年</option>
                    <option value="2008">2008年</option>
                </select>
            </div>
            <div class="fi fiBtns">
                <input type="submit" value="搜索" class="submit" />
            </div>
        </div>
        </form>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li></li>
        </ul>
    </div>
</asp:Content>
