<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="FavoriteList.aspx.cs" Inherits="User_FavoriteList" %>

<%@ Register Src="~/Control/UserSidebar.ascx" TagName="UserSidebar" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="resumePage">
        <uc1:UserSidebar ID="UserSidebar1" runat="server" />
        <div class="content column">
            <div class="tit gray">
                <a href="/Index.aspx">首页</a> > <a href="/User/Index.aspx">个人会员</a> > <span class="green">
                    职位收藏夹</span></div>
            <div class="MemCon">
                <div class="blank12px">
                </div>
                <div class="Res670">
                    <div class="lh22 flowhidden">
                    </div>
                    <div class="blank10px">
                    </div>
                    <div>
                        <table class="tabsty" width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <th scope="col">
                                    收藏日期
                                </th>
                                <th scope="col">
                                    职位名称
                                </th>
                                <th scope="col">
                                    公司名称
                                </th>
                                <th scope="col">
                                    工作地点
                                </th>
                                <th scope="col">
                                    操作
                                </th>
                            </tr>
                            <asp:Repeater ID="rep" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%#Eval( "fdFavoCreateAt", "{0:yyyy-MM-dd}" )%>
                                        </td>
                                        <td>
                                            <a href="/r/<%#Eval("Recruit.fdRecrID") %>.aspx" target="_blank">
                                                <%#Eval( "Recruit.fdRecrJob" )%></a>
                                        </td>
                                        <td>
                                            <a href="/r/<%#Eval("Recruit.fdRecrID") %>.aspx" target="_blank">
                                                <%#Eval( "Recruit.fdRecrCompany" )%></a>
                                        </td>
                                        <td>
                                            <%#Eval( "Recruit.fdRecrAreaName" )%>
                                        </td>
                                        <td>
                                            <a href="FavoriteDel.aspx?id=<%#Eval("fdFavoID") %>" onclick="return confirm('是否确认删除该职位？');">删除</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <div class="pageStyle tr">
                        <sw:PageNaver ID="PN1" runat="server" StyleID="5" PageSize="20">
                        </sw:PageNaver>
                    </div>
                    <div class="blank30px">
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        setUserSidebar("ZWSC");
    </script>

</asp:Content>
