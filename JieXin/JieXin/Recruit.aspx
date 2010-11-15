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
                        <a href="javascript:void(0)" class="btn94_28 right" onclick="SelectResume()" class="btn94_28 right">
                            立即申请</a>
                        <%=bean.fdRecrTitle %>
                    </h1>
                </div>
                <div class="detCon">
                    <h2>
                        <%=bean.fdRecrCompany %></h2>
                    <strong class="blue">职位：</strong>
                    <br />
                    <%=bean.fdRecrJob %>
                    <br />
                    <strong class="blue">工作地点：</strong>
                    <br />
                    <%=bean.fdRecrAreaName %>
                    <div>
                        <strong class="blue">职位描述</strong><span class="blank12px"></span>
                        <%=bean.fdRecrContent %>
                    </div>
                </div>
                <div class="blank12px">
                </div>
                <div class="right">
                    <a href="javascript:void(0);" onclick="SelectResume()" class="btn94_28 right">立即申请</a>
                </div>
            </div>
        </div>
    </div>
    <div id="Apply_Resume" class="choArea">
        <div class="top">
            <i class="iTit">投递简历</i> <span class="topRight white"><a onclick="closeWindow('Apply_Resume')"
                href="javascript:void(0);">
                <img height="15" width="15" src="/images/icon_close.gif"></a> </span>
        </div>
        <div class="con gray">
            <table style="width: 100%; text-align: center;">
                <tr>
                    <td>
                        <br />
                        <br />
                        <%if( this.LoginUser == null )
                          {%>
                        <a href="/Login.aspx?back=<%=Request.RawUrl %>">请先登录！</a>
                        <%}
                          else if( this.resuList.Count == 0 )
                          { %>
                        简历不存在，<a href="/User/ResuInit.aspx" style="color: #0166B4;">添加简历？</a>
                        <%}
                          else
                          { %>
                        简历：
                        <select id="drpResume">
                            <asp:Repeater ID="repResu" runat="server">
                                <ItemTemplate>
                                    <option value="<%#Eval("fdResuID") %>">
                                        <%#Eval("fdResuName") %></option>
                                </ItemTemplate>
                            </asp:Repeater>
                        </select>
                        <input type="button" id="btn_apply" value="立即申请" onclick="ApplyResume(<%=bean.fdRecrID %>)" />
                        <%} %>
                        <br />
                        <br />
                    </td>
                </tr>
            </table>
            <span class="blank5px"></span>
        </div>
        <div class="btm">
        </div>
    </div>
</asp:Content>
