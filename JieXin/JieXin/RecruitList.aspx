<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RecruitList.aspx.cs" Inherits="AnyWell_RecruitList" %>

<%@ Register Src="Control/Area.ascx" TagName="Area" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="inner">
        <div class="box_754">
            <div class="tit gray">
                <a href="/index.aspx">首页</a> > <span class="green">职位搜索</span>
            </div>
            <div class="searchJob">
                <div class="chCondtion">
                    <div class="search">
                        <div id="topTabs" class="topTabs gray">
                            <a href="javascript:void(0);" onclick="Changetag(0);" class="<%=QS("tag")==""||QS("tag")=="0"?"cur":"" %>">
                                全文</a> <a href="javascript:void(0);" onclick="Changetag(1);" class="<%=QS("tag")=="1"?"cur":"" %>">
                                    职位名</a> <a href="javascript:void(0);" onclick="Changetag(2);" class="<%=QS("tag")=="2"?"cur":"nobor" %>">
                                        公司名</a>
                        </div>
                        <div class="btmInt">
                            <span class="wrapSpan left">
                                <input type="text" id="keyword" class="keyword" <%=QS("key")==""?"style=\"color: #B5B5B5; font-weight: bold;\"":"" %>
                                    value="<%=QS("key")==""?"请输入关键字":QS("key") %>" onclick="if('请输入关键字'==this.value){this.value='';this.style.color='#000';this.style.fontWeight='normal';}"
                                    onblur="if(this.value==''){this.value = '请输入关键字';this.style.color='#B5B5B5';this.style.fontWeight='bold';}" /></span>
                            <a href="javascript:void(0);" onclick="ChooseArea(this,'ChooseArea','areaId','area','选择地区')"
                                id="AreaName" class="btn28H left">
                                <%=QS( "area" ) == "" ? "选择地区" : QS( "area" )%></a>
                            <input type="button" class="btn48_28 left" value="" onclick="searchName();" />
                            <input type="hidden" value="<%=QS("tag")==""?"0":QS("tag") %>" id="tagName" />
                            <input type="hidden" value="<%=QS("areaid")==""?"":QS("areaid") %>" id="areaId" />
                            <input type="hidden" value="<%=QS("area")==""?"":QS("area") %>" id="area" />
                        </div>
                    </div>
                    <div class="recomPos">
                        <dl>
                            <dt>热门关键词搜索:</dt>
                            <dd class="blue">
                                <aw:KeyWordList ID="KeyWordList1" runat="server" TopCount="21" CacheName="SEARCH">
                                    <ItemTemplate>
                                        <a href="/search.aspx?key=<%#Eval("fdKeyWName") %>">
                                            <%#Eval( "fdKeyWName" )%></a> |
                                    </ItemTemplate>
                                </aw:KeyWordList>
                            </dd>
                        </dl>
                    </div>
                </div>
                <div class="Joblist">
                    <div class="listHead">
                        <label for="all">
                            <input type="checkbox" id="all" onclick="SelectAll(this.checked)" name="job" style="margin: -1px 0px -2px 0px;" />&nbsp;&nbsp;<span>全部选中</span></label>&nbsp;<a
                                href="javascript:void(0);" class="btn94_28" onclick="SelectResume(0)">申请选中的职位</a>&nbsp;<a
                                    href="javascript:void(0);" class="btn28H" style="font-size: 12px;" onclick="AddFavorite()"
                                    id="favorite">收藏选中职位</a>
                    </div>
                    <div class="dList" id="jobList">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <asp:Repeater ID="rep" runat="server">
                                <ItemTemplate>
                                    <tr class="<%# Container.ItemIndex % 2 == 1 ? "" : "even" %>">
                                        <th>
                                            <input type="checkbox" name="job" value="<%# Eval("fdRecrID")%>" />
                                        </th>
                                        <td style="width:240px;padding-left:10px;">
                                            <a href="/r/<%# Eval("fdRecrID")%>.aspx" target="_blank" class="fbold">
                                                <%#Eval( "fdRecrTitle" )%></a>
                                        </td>
                                        <td style="width:160px;padding-left:10px;">
                                            <a href="/r/<%# Eval("fdRecrID")%>.aspx" target="_blank" class="blue">
                                                <%#Eval("fdRecrCompany") %></a>
                                        </td>
                                        <td style="width:130px;padding-left:10px;">
                                            <a href="/r/<%# Eval("fdRecrID")%>.aspx" target="_blank" class="blue">
                                                <%#Eval("fdRecrJob") %></a>
                                        </td>
                                        <td style="width:60px;" align="center">
                                            <%#Eval("fdRecrAreaName") %>
                                        </td>
                                        <td class="date">
                                            <%#Eval("fdRecrCreateAt","{0:yyyy-MM-dd}") %>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <div class="pageStyle tr">
                        <sw:PageNaver ID="PN1" runat="server" StyleID="5" PageSize="12">
                        </sw:PageNaver>
                    </div>
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
                        简历不存在，<a href="/User/ResuInit.aspx" style="color:#0166B4;">添加简历？</a>
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
                        <input type="button" id="btn_apply" value="立即申请" onclick="ApplyResume(0)" />
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

    <script type="text/javascript">
        function SelectAll(v) {
            var list = $("#jobList input");
            $("#jobList input").each(function() {
                if ($(this).attr("name") == "job" && $(this).attr("type") == "checkbox") {
                    $(this).attr("checked", v);
                }
            });
        }
    </script>

    <uc1:Area runat="server" />
</asp:Content>
