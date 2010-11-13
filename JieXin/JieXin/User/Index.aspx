<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Index.aspx.cs" Inherits="User_Index" %>

<%@ Register Src="~/Control/UserSidebar.ascx" TagName="UserSidebar" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="resumePage">
        <uc1:UserSidebar runat="server" />
        <div class="content column">
            <div class="tit gray">
                <a href="/Index.aspx">首页</a> > <a href="/User/Index.aspx">个人会员</a> > <span class="green">
                    简历管理</span></div>
            <div class="MemCon">
                <div class="blank12px">
                </div>
                <div class="Res670">
                    <div class="lh22 flowhidden">
                        <span class="left">您好，<span class="orange"><%=this.LoginUser.fdUserAccount %></span>，您目前共有
                            <span class="orange">
                                <%=resuCount%></span> 份简历</span> <span class="right">您最近一次更新简历的时间是
                                    <%=lastUpdate==DateTime.Parse("1900-01-01")?"":lastUpdate.ToString("yyyy-MM-dd") %></span>
                    </div>
                    <div class="blank10px">
                    </div>
                    <div>
                        <table class="tabsty" width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <th scope="col">
                                    简历名称
                                </th>
                                <th scope="col">
                                    浏览次数
                                </th>
                                <th scope="col">
                                    操作
                                </th>
                            </tr>
                            <asp:Repeater ID="rep" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <a href="#" class="green line">
                                                <%#Eval( "fdResuName" )%></a>
                                        </td>
                                        <td>
                                            <%#Eval( "fdResuViewCount" )%>
                                        </td>
                                        <td>
                                            <a href="ResuEdit.aspx?id=<%#Eval("fdResuID") %>" class="green line">修改</a> <a href="ResuView.aspx?id=<%#Eval("fdResuID") %>"
                                                class="green line">预览</a> <a href="ResuDel.aspx?id=<%#Eval("fdResuID") %>" class="green line"
                                                    onclick="return confirm('您确定要删除吗?')">删除</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <div class="blank30px">
                    </div>
                    <a href="ResuInit.aspx" class="btn94_28">创建新的简历</a>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        setUserSidebar("JLGL");
    </script>

</asp:Content>
