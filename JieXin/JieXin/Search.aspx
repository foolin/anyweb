<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Search.aspx.cs" Inherits="Search" %>

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
                            <a href="javascript:void(0);" onclick="ChooseArea(this,'ChooseArea','areaId','area','选择地区')" id="AreaName" class="btn28H left">
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
                                <aw:KeyWordList runat="server" TopCount="21" CacheName="SEARCH">
                                    <ItemTemplate>
                                        <a href="/search.aspx?key=<%#Eval("fdKeyWName") %>">
                                            <%#Eval( "fdKeyWName" )%></a> |
                                    </ItemTemplate>
                                </aw:KeyWordList>
                            </dd>
                        </dl>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <uc1:Area runat="server" />
</asp:Content>
