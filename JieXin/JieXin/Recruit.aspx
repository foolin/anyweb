<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Recruit.aspx.cs" Inherits="Recruit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="inner">
        <div class="box_754">
            <div class="tit gray">
                <a href="/Index.aspx">首页</a> > <a href="/RecruitList.aspx">职位</a> > <span class="green">
                    <%=bean.fdRecrTitle %></span>
            </div>
            <div class="innerPad detailInfo">
                <div class="Jobhead">
                    <h1>
                        <%=bean.fdRecrTitle %></h1>
                    <a href="#" class="btn94_28 right">立即申请</a>
                </div>
                <div class="detCon">
                    <h2>
                        <%=bean.fdRecrCompany %></h2>
                    <h2>
                        <%=bean.fdRecrJob %></h2>
                    <div>
                        <strong class="blue">职位描述</strong><span class="blank12px"></span> 
                        <%=bean.fdRecrContent %>
                    </div>
                </div>
                <div class="blank12px">
                </div>
                <div class="right">
                    <a href="#" class="btn94_28 right">立即申请</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
