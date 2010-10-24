<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="subBanner">
        <a href="#" target="_blank">
            <img src="images/subbanner.jpg" width="953" height="90" /></a>
    </div>
    <div class="blank8px">
    </div>
    <div class="flowhidden">
        <div class="box_217 mar12 left">
            <div class="colA">
                <div class="tit">
                    <h2>
                        公告栏</h2>
                    <span class="more"><a href="Notice.aspx">更多>></a></span>
                </div>
                <div class="con">
                    <div class="pad10">
                        <ul class="listA">
                            <aw:NoticeList runat="server" TopCount="4" CacheName="INDEX">
                                <ItemTemplate>
                                    <li><span class="date">
                                        <%#Eval("fdNotiCreateAt","{0:yyyy-MM-dd}") %></span>• <a href="/n/<%#Eval("fdNotiID") %>.aspx"
                                            title="<%# Eval("fdNotiTitle") %>">
                                            <%# Eval("fdNotiTitle") %></a></li>
                                </ItemTemplate>
                            </aw:NoticeList>
                        </ul>
                    </div>
                </div>
                <div class="btm">
                </div>
            </div>
            <div class="blank12px">
            </div>
            <div class="colA">
                <div class="tit">
                    <h2>
                        最新动态</h2>
                    <span class="more"><a href="/c/44.aspx">更多>></a></span>
                </div>
                <div class="con">
                    <div class="pad10">
                        <ul class="listA">
                            <aw:ArticleList runat="server" ColumnID="44" TopCount="8" CacheName="ZXDT">
                                <ItemTemplate>
                                    <li><span class="date">
                                        <%#Eval("fdArtiCreateAt","{0:yyyy-MM-dd}") %></span>• <a href="/a/<%#Eval("fdArtiID") %>"
                                            title="<%#Eval("fdArtiTitle") %>">
                                            <%#Eval("fdArtiTitle") %></a></li>
                                </ItemTemplate>
                            </aw:ArticleList>
                        </ul>
                    </div>
                </div>
                <div class="btm">
                </div>
            </div>
        </div>
        <div class="box_434 left">
            <div class="midCol">
                <div class="con">
                    <div class="loginArea">
                        <div class="loginForm">
                            <div class="logTop">
                                <strong>个人服务</strong>&nbsp;&nbsp;Job Seekers
                            </div>
                            <div class="logCon">
                                <!--登录前-->
                                <table width="90%" class="loginTable hidden" align="center" border="0" cellspacing="0"
                                    cellpadding="0">
                                    <tr>
                                        <td align="right">
                                            会员名：
                                        </td>
                                        <td>
                                            <input type="text" class="loginInput" />
                                        </td>
                                        <td rowspan="2">
                                            <input type="button" class="btn46H" value="登录" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            密码：
                                        </td>
                                        <td>
                                            <input type="password" class="loginInput" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td colspan="2">
                                            <label for="autoLogin">
                                                <input type="checkbox" id="autoLogin" class="jz" name="" />自动登录</label>
                                            <a href="#" target="_blank" class="blue">忘记密码</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" class="tc" height="50">
                                            <a href="#" target="_blank" class="btn28H">新会员注册</a> <a href="#" target="_blank"
                                                class="btn28H">填写简历</a>
                                        </td>
                                    </tr>
                                </table>
                                <!--登录前 结束-->
                                <!--登录后-->
                                <table width="90%" class="loginTable" align="center" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="tc">
                                            matchbox18，欢迎您！
                                        </td>
                                        <td rowspan="2">
                                            <input type="button" class="btn46H" value="退出" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tc">
                                            <a href="#" target="_blank" class="blue">修改简历</a> <a href="#" target="_blank" class="blue">
                                                忘记密码</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" class="tc" height="50">
                                            <a href="#" target="_blank" class="btn28H">我的杰信</a> <a href="#" target="_blank" class="btn28H">
                                                填写简历</a>
                                        </td>
                                    </tr>
                                </table>
                                <!--登录后 结束-->
                            </div>
                            <div class="logBtm">
                            </div>
                        </div>
                        <div class="loginPic">
                            <img src="images/pic_1.jpg" width="179" height="212" />
                        </div>
                    </div>
                    <div class="chCondtion">
                        <div class="search">
                            <div id="topTabs" class="topTabs gray">
                                <a href="javascript:void(0);" class="cur" onclick="Changetag('全文',0);">全文</a> <a
                                    href="javascript:void(0);" onclick="Changetag('职位名',1);">职位名</a> <a href="javascript:void(0);"
                                        class="nobor" onclick="Changetag('公司名',2);">公司名</a>
                            </div>
                            <div class="btmInt">
                                <span class="wrapSpan left">
                                    <input type="text" id="keyword" class="keyword" style="color: #B5B5B5; font-weight: bold;"
                                        value="请输入关键字" onclick="if(this.defaultValue==this.value){this.value='';this.style.color='#000';this.style.fontWeight='normal';}"
                                        onblur="if(this.value==''){this.value = this.defaultValue;this.style.color='#B5B5B5';this.style.fontWeight='bold';}" /></span>
                                <a href="javascript:void(0);" onclick="ChooseArea();" id="AreaName" class="btn28H left">
                                    选择地区</a>
                                <input type="button" class="btn48_28 left" value="" onclick="searchName();" />
                                <input type="hidden" value="全文" id="tagName" />
                            </div>
                        </div>
                        <div class="recomPos">
                            <dl>
                                <dt>热门关键词搜索:</dt>
                                <dd class="blue">
                                    <a href="#" target="_blank">首席大技术官</a> | <a href="#" target="_blank">首席信息主管</a>
                                    | <a href="#" target="_blank">高技术总监</a> | <a href="#" target="_blank">技术经理</a><br />
                                    <a href="#" target="_blank">高技术经理</a> | <a href="#" target="_blank">信息技术主管</a> |
                                    <a href="#" target="_blank">信息技术专员</a> | <a href="#" target="_blank">产品经理</a><br />
                                    <a href="#" target="_blank">项目经理</a> | <a href="#" target="_blank">区域项目主管</a> |
                                    <a href="#" target="_blank">研发主执行</a> | <a href="#" target="_blank">协调沟通专员</a>
                                    <br />
                                    <a href="#" target="_blank">研发工程师</a> | <a href="#" target="_blank">高级软件工程师</a>
                                    | <a href="#" target="_blank">软件工程</a> | <a href="#" target="_blank">硬件工程师</a>
                                </dd>
                            </dl>
                        </div>
                    </div>
                </div>
                <div class="btm">
                </div>
            </div>
        </div>
        <div class="box_278 right">
            <div class="colA latestNew">
                <div class="tit">
                    <h2>
                        企业介绍</h2>
                    <span class="more"><a href="/c/45.aspx">更多>></a></span>
                </div>
                <div class="con relate">
                    <div class="pad10 ">
                        <p class="brief">
                            &nbsp;&nbsp;&nbsp;&nbsp;我社在经营传统业务的同时紧跟市场发展潮流，抓紧机遇，进行二次创业。杰信公司便是我社二次创业的产物，我社在原有的资源基础上进行整合及有效利用，创办杰信公司开拓人力资源领域方向的相关业务。杰信公司的业务包括：人事代理、人才招聘、企业咨询、培训、劳务派遣、代理劳动关系手续办理（劳动年审、社会保险办理等）等相关业务。</p>
                        <ul class="imgArea">
                            <aw:ADList runat="server" TypeID="6" CacheName="INDEX6">
                                <ItemTemplate>
                                    <li><a href="<%#Eval("fdAdLink") %>" target="_blank">
                                        <img src="<%#Eval("fdAdPic") %>" width="110" height="77" /></a></li>
                                </ItemTemplate>
                            </aw:ADList>
                        </ul>
                        <div class="blank12px">
                        </div>
                    </div>
                </div>
                <div class="btm">
                </div>
            </div>
        </div>
    </div>
    <div class="blank8px">
    </div>
    <div class="box_953 campus flowhidden">
        <div class="topA">
        </div>
        <div class="conA">
            <div class="box_283 colB left">
                <div class="tit">
                    <h2>
                        实习生招聘</h2>
                    <span class="more"><a href="/search.aspx?type=1">更多>></a></span>
                </div>
                <div class="con pad10">
                    <ul class="listA">
                        <aw:RecruitList runat="server" TypeID="1" CacheName="INDEX1">
                            <ItemTemplate>
                                <li><span class="date">
                                    <%#Eval("fdRecrCreateAt","{0:yyyy-MM-dd}") %></span>•<a href="/r/<%#Eval("fdRecrID") %>.aspx"
                                        title="<%#Eval("fdRecrTitle") %>"><%#Eval("fdRecrTitle") %></a></li>
                            </ItemTemplate>
                        </aw:RecruitList>
                    </ul>
                </div>
            </div>
            <div class="box_283 colB left">
                <div class="tit">
                    <h2>
                        毕业生招聘</h2>
                    <span class="more"><a href="/search.aspx?type=2">更多>></a></span>
                </div>
                <div class="con pad10">
                    <ul class="listA">
                        <aw:RecruitList ID="RecruitList1" runat="server" TypeID="2" CacheName="INDEX2">
                            <ItemTemplate>
                                <li><span class="date">
                                    <%#Eval("fdRecrCreateAt","{0:yyyy-MM-dd}") %></span>•<a href="/r/<%#Eval("fdRecrID") %>.aspx"
                                        title="<%#Eval("fdRecrTitle") %>"><%#Eval("fdRecrTitle") %></a></li>
                            </ItemTemplate>
                        </aw:RecruitList>
                    </ul>
                </div>
            </div>
            <div class="box_283 colB left">
                <div class="tit">
                    <h2>
                        兼职招聘</h2>
                    <span class="more"><a href="/search.aspx?type=3">更多>></a></span>
                </div>
                <div class="con pad10">
                    <ul class="listA">
                        <aw:RecruitList ID="RecruitList2" runat="server" TypeID="3" CacheName="INDEX3">
                            <ItemTemplate>
                                <li><span class="date">
                                    <%#Eval("fdRecrCreateAt","{0:yyyy-MM-dd}") %></span>•<a href="/r/<%#Eval("fdRecrID") %>.aspx"
                                        title="<%#Eval("fdRecrTitle") %>"><%#Eval("fdRecrTitle") %></a></li>
                            </ItemTemplate>
                        </aw:RecruitList>
                    </ul>
                </div>
            </div>
            <div class="blank15px">
            </div>
            <div class="box_918 colB">
                <div class="tit">
                    <h2>
                        合作院校</h2>
                </div>
                <div class="con">
                    <ul class="picList" id="scroll_2">
                        <aw:ADList runat="server" TypeID="4" CacheName="INDEX4">
                            <ItemTemplate>
                                <li><a href="<%#Eval("fdAdLink") %>" target="_blank">
                                    <img src="<%#Eval("fdAdPic") %>" width="110" height="77" /></a></li>
                            </ItemTemplate>
                        </aw:ADList>
                    </ul>
                </div>
            </div>
            <div class="blank20px">
            </div>
        </div>
        <div class="btmA">
        </div>
    </div>
    <div class="blank8px">
    </div>
    <div class="subBanner">
        <aw:ADList runat="server" TypeID="7" CacheName="INDEX7">
            <ItemTemplate>
                <a href="<%#Eval("fdAdLink") %>" target="_blank">
                    <img src="<%#Eval("fdAdPic") %>" width="950" height="55" /></a>
            </ItemTemplate>
        </aw:ADList>
    </div>
    <div class="blank8px">
    </div>
    <div class="flowhidden">
        <ul class="marks threeMarks">
            <aw:ADList runat="server" TypeID="1" CacheName="INDEX1" TopCount="15">
                <ItemTemplate>
                    <li><a href="<%#Eval("fdAdLink") %>" target="_blank" title="<%#Eval("fdAdName") %>">
                        <img src="<%#Eval("fdAdPic") %>" width="308" height="95" /></a></li>
                </ItemTemplate>
            </aw:ADList>
        </ul>
        <ul class="marks fiveMarks">
            <aw:ADList runat="server" TypeID="2" CacheName="INDEX2" TopCount="25">
                <ItemTemplate>
                    <li><a href="<%#Eval("fdAdLink") %>" target="_blank" title="<%#Eval("fdAdName") %>">
                        <img src="<%#Eval("fdAdPic") %>" width="180" height="30" /></a></li>
                </ItemTemplate>
            </aw:ADList>
        </ul>
        <ul class="marks tenMarks">
            <aw:ADList ID="ADList1" runat="server" TypeID="3" CacheName="INDEX3" TopCount="30">
                <ItemTemplate>
                    <li><a href="<%#Eval("fdAdLink") %>" target="_blank" title="<%#Eval("fdAdName") %>">
                        <img src="<%#Eval("fdAdPic") %>" width="85" height="30" /></a></li>
                </ItemTemplate>
            </aw:ADList>
        </ul>
    </div>
    <div class="blank8px">
    </div>
    <div class="famCom colA">
        <div class="tit">
            <h2>
                知名企业招聘</h2>
            <span class="more"><a href="#" target="_blank">更多>></a></span>
        </div>
        <div class="con flowhidden">
            <div class="pad10">
                <div class="flowhidden">
                    <div class="blank12px">
                    </div>
                    <ul class="listA">
                        <aw:RecruitList ID="RecruitList4" runat="server" TypeID="5" CacheName="INDEX5">
                            <ItemTemplate>
                                <li><span class="date">
                                    <%#Eval("fdRecrCreateAt","{0:yyyy-MM-dd}") %></span>• <a href="/r/<%#Eval("fdRecrID") %>.aspx"
                                        title="<%#Eval("fdRecrTitle") %>" target="_blank">
                                        <%#Eval("fdRecrTitle") %></a></li>
                            </ItemTemplate>
                        </aw:RecruitList>
                    </ul>
                </div>
            </div>
        </div>
        <div class="btm">
        </div>
    </div>
    <div class="blank8px">
    </div>
    <div class="fourCol flowhidden">
        <div class="box_231 fg colA">
            <div class="tit">
                <h2>
                    劳动法规</h2>
                <span class="more"><a href="/c/52.aspx">更多>></a></span>
            </div>
            <div class="con">
                <div class="pad10">
                    <div class="brief_pw">
                        <img src="images/img_5.jpg" class="img" width="60" height="60" />
                        <aw:Column ColumnID="52" runat="server">
                            <ItemTemplate>
                                <%#Studio.Web.WebAgent.GetLeft((string)Eval( "fdColuDescription" ),33,true)%>
                            </ItemTemplate>
                        </aw:Column>
                    </div>
                    <ul class="listA">
                        <aw:ArticleList ColumnID="52" TopCount="5" runat="server" CacheName="INDEX52">
                            <ItemTemplate>
                                <li>• <a href="/a/<%#Eval("fdArtiID") %>.aspx" title="<%#Eval("fdArtiTitle") %>">
                                    <%#Eval("fdArtiTitle") %></a></li>
                            </ItemTemplate>
                        </aw:ArticleList>
                    </ul>
                </div>
            </div>
            <div class="btm">
            </div>
        </div>
        <div class="box_231 zx colA">
            <div class="tit">
                <h2>
                    职场资讯</h2>
                <span class="more"><a href="/c/53.aspx">更多>></a></span>
            </div>
            <div class="con">
                <div class="pad10">
                    <div class="brief_pw">
                        <img src="images/img_6.jpg" class="img" width="60" height="60" />
                        <aw:Column ID="Column1" ColumnID="53" runat="server">
                            <ItemTemplate>
                                <%#Studio.Web.WebAgent.GetLeft((string)Eval( "fdColuDescription" ),33,true)%>
                            </ItemTemplate>
                        </aw:Column>
                    </div>
                    <ul class="listA">
                        <aw:ArticleList ColumnID="53" TopCount="5" runat="server" CacheName="INDEX53">
                            <ItemTemplate>
                                <li>• <a href="/a/<%#Eval("fdArtiID") %>.aspx" title="<%#Eval("fdArtiTitle") %>">
                                    <%#Eval("fdArtiTitle") %></a></li>
                            </ItemTemplate>
                        </aw:ArticleList>
                    </ul>
                </div>
            </div>
            <div class="btm">
            </div>
        </div>
        <div class="box_231 jq colA">
            <div class="tit">
                <h2>
                    求职技巧</h2>
                <span class="more"><a href="/c/54.aspx">更多>></a></span>
            </div>
            <div class="con">
                <div class="pad10">
                    <div class="brief_pw">
                        <img src="images/img_7.jpg" class="img" width="60" height="60" />
                        <aw:Column ID="Column2" ColumnID="54" runat="server">
                            <ItemTemplate>
                                <%#Studio.Web.WebAgent.GetLeft((string)Eval( "fdColuDescription" ),33,true)%>
                            </ItemTemplate>
                        </aw:Column>
                    </div>
                    <ul class="listA">
                        <aw:ArticleList ID="ArticleList1" ColumnID="54" TopCount="5" runat="server" CacheName="INDEX54">
                            <ItemTemplate>
                                <li>• <a href="/a/<%#Eval("fdArtiID") %>.aspx" title="<%#Eval("fdArtiTitle") %>">
                                    <%#Eval("fdArtiTitle") %></a></li>
                            </ItemTemplate>
                        </aw:ArticleList>
                    </ul>
                </div>
            </div>
            <div class="btm">
            </div>
        </div>
        <div class="box_231 zd colA">
            <div class="tit">
                <h2>
                    简历指导</h2>
                <span class="more"><a href="/c/55.aspx">更多>></a></span>
            </div>
            <div class="con">
                <div class="pad10">
                    <div class="brief_pw">
                        <img src="images/img_8.jpg" class="img" width="60" height="60" />
                        <aw:Column ID="Column3" ColumnID="55" runat="server">
                            <ItemTemplate>
                                <%#Studio.Web.WebAgent.GetLeft((string)Eval( "fdColuDescription" ),33,true)%>
                            </ItemTemplate>
                        </aw:Column>
                    </div>
                    <ul class="listA">
                        <aw:ArticleList ID="ArticleList2" ColumnID="55" TopCount="5" runat="server" CacheName="INDEX55">
                            <ItemTemplate>
                                <li>• <a href="/a/<%#Eval("fdArtiID") %>.aspx" title="<%#Eval("fdArtiTitle") %>">
                                    <%#Eval("fdArtiTitle") %></a></li>
                            </ItemTemplate>
                        </aw:ArticleList>
                    </ul>
                </div>
            </div>
            <div class="btm">
            </div>
        </div>
    </div>
    <div class="blank8px">
    </div>
    <div class="box_953 peixun flowhidden">
        <div class="topA">
        </div>
        <div class="conA">
            <div class="box_200 colB left">
                <div class="tit">
                    <h2>
                        户外拓展
                    </h2>
                    <span class="more"><a href="/c/47.aspx">更多>></a></span>
                </div>
                <div class="con">
                    <div class="brief_pw">
                        <img src="images/img_9.jpg" class="img" width="60" height="60" />
                        <aw:Column ID="Column4" ColumnID="47" runat="server">
                            <ItemTemplate>
                                <%#Studio.Web.WebAgent.GetLeft((string)Eval( "fdColuDescription" ),33,true)%>
                            </ItemTemplate>
                        </aw:Column>
                    </div>
                    <ul class="listA">
                        <aw:ArticleList ID="ArticleList3" ColumnID="47" TopCount="5" runat="server" CacheName="INDEX47">
                            <ItemTemplate>
                                <li>• <a href="/a/<%#Eval("fdArtiID") %>.aspx" title="<%#Eval("fdArtiTitle") %>">
                                    <%#Eval("fdArtiTitle") %></a></li>
                            </ItemTemplate>
                        </aw:ArticleList>
                    </ul>
                </div>
            </div>
            <div class="box_200 colB left">
                <div class="tit">
                    <h2>
                        个人充电</h2>
                    <span class="more"><a href="/c/48.aspx">更多>></a></span>
                </div>
                <div class="con">
                    <div class="brief_pw">
                        <img src="images/img_10.jpg" class="img" width="60" height="60" />
                        <aw:Column ID="Column5" ColumnID="48" runat="server">
                            <ItemTemplate>
                                <%#Studio.Web.WebAgent.GetLeft((string)Eval( "fdColuDescription" ),33,true)%>
                            </ItemTemplate>
                        </aw:Column>
                    </div>
                    <ul class="listA">
                        <aw:ArticleList ID="ArticleList4" ColumnID="48" TopCount="5" runat="server" CacheName="INDEX48">
                            <ItemTemplate>
                                <li>• <a href="/a/<%#Eval("fdArtiID") %>.aspx" title="<%#Eval("fdArtiTitle") %>">
                                    <%#Eval("fdArtiTitle") %></a></li>
                            </ItemTemplate>
                        </aw:ArticleList>
                    </ul>
                </div>
            </div>
            <div class="box_200 colB left">
                <div class="tit">
                    <h2>
                        企业培训</h2>
                    <span class="more"><a href="/c/49.aspx">更多>></a></span>
                </div>
                <div class="con">
                    <div class="brief_pw">
                        <img src="images/img_11.jpg" class="img" width="60" height="60" />
                        <aw:Column ID="Column6" ColumnID="49" runat="server">
                            <ItemTemplate>
                                <%#Studio.Web.WebAgent.GetLeft((string)Eval( "fdColuDescription" ),33,true)%>
                            </ItemTemplate>
                        </aw:Column>
                    </div>
                    <ul class="listA">
                        <aw:ArticleList ID="ArticleList5" ColumnID="49" TopCount="5" runat="server" CacheName="INDEX49">
                            <ItemTemplate>
                                <li>• <a href="/a/<%#Eval("fdArtiID") %>.aspx" title="<%#Eval("fdArtiTitle") %>">
                                    <%#Eval("fdArtiTitle") %></a></li>
                            </ItemTemplate>
                        </aw:ArticleList>
                    </ul>
                </div>
            </div>
            <div class="box_200 colB left">
                <div class="tit">
                    <h2>
                        劳动技能培训</h2>
                    <span class="more"><a href="/c/50.aspx">更多>></a></span>
                </div>
                <div class="con">
                    <div class="brief_pw">
                        <img src="images/img_12.jpg" class="img" width="60" height="60" />
                        <aw:Column ID="Column7" ColumnID="50" runat="server">
                            <ItemTemplate>
                                <%#Studio.Web.WebAgent.GetLeft((string)Eval( "fdColuDescription" ),33,true)%>
                            </ItemTemplate>
                        </aw:Column>
                    </div>
                    <ul class="listA">
                        <aw:ArticleList ID="ArticleList6" ColumnID="50" TopCount="5" runat="server" CacheName="INDEX50">
                            <ItemTemplate>
                                <li>• <a href="/a/<%#Eval("fdArtiID") %>.aspx" title="<%#Eval("fdArtiTitle") %>">
                                    <%#Eval("fdArtiTitle") %></a></li>
                            </ItemTemplate>
                        </aw:ArticleList>
                    </ul>
                </div>
            </div>
            <div class="blank15px">
            </div>
            <div class="box_918 colB">
                <div class="tit">
                    <h2>
                        专题图片</h2>
                    <span class="more"></span>
                </div>
                <div class="con">
                    <ul class="picList" id="scroll_1">
                        <aw:ADList runat="server" TypeID="5" CacheName="INDEX5">
                            <ItemTemplate>
                                <li><a href="<%#Eval("fdAdLink") %>" target="_blank">
                                    <img src="<%#Eval("fdAdPic") %>" width="110" height="77" /></a></li>
                            </ItemTemplate>
                        </aw:ADList>
                    </ul>
                </div>
            </div>
            <div class="blank20px">
            </div>
        </div>
        <div class="btmA">
        </div>
    </div>

    <script type="text/javascript">
        var scrollPic_02 = new ScrollPic();
        scrollPic_02.scrollContId = "scroll_2"; //内容容器ID
        scrollPic_02.arrLeftId = ""; //左箭头ID
        scrollPic_02.arrRightId = ""; //右箭头ID

        scrollPic_02.frameWidth = 918; //显示框宽度
        scrollPic_02.pageWidth = 130; //翻页宽度

        scrollPic_02.speed = 10; //移动速度(单位毫秒，越小越快)
        scrollPic_02.space = 10; //每次移动像素(单位px，越大越快)
        scrollPic_02.autoPlay = true; //自动播放
        scrollPic_02.autoPlayTime = 3; //自动播放间隔时间(秒)

        var scrollid = document.getElementById("scroll_2");
        var imglen = scrollid.getElementsByTagName("img").length;
        if (imglen > 6) {
            scrollPic_02.initialize(); //初始化
        }
        else
        { }
    </script>

    <script type="text/javascript">
        var scrollPic_01 = new ScrollPic();
        scrollPic_01.scrollContId = "scroll_1"; //内容容器ID
        scrollPic_01.arrLeftId = ""; //左箭头ID
        scrollPic_01.arrRightId = ""; //右箭头ID

        scrollPic_01.frameWidth = 918; //显示框宽度
        scrollPic_01.pageWidth = 130; //翻页宽度

        scrollPic_01.speed = 10; //移动速度(单位毫秒，越小越快)
        scrollPic_01.space = 10; //每次移动像素(单位px，越大越快)
        scrollPic_01.autoPlay = true; //自动播放
        scrollPic_01.autoPlayTime = 3; //自动播放间隔时间(秒)

        var scrollid = document.getElementById("scroll_1");
        var imglen = scrollid.getElementsByTagName("img").length;
        if (imglen > 6) {
            scrollPic_01.initialize(); //初始化
        }
        else
        { }
    </script>

    <div class="choArea" id="ChooseArea">
        <div class="top">
            <i class="iTit">请选择工作地点</i> <span class="topRight white">[<a href="javascript:void(0);"
                onclick="AreaName(this);">不限</a>]&nbsp;&nbsp; <a href="javascript:void(0);" onclick="closeWindow('ChooseArea')">
                    <img src="images/icon_close.gif" width="15" height="15" /></a> </span>
        </div>
        <div class="con gray">
            <h3>
                主要城市：</h3>
            <dl>
                <dt>华北东北：</dt>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">北京</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">天津</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">大连</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">沈阳</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">长春</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">哈尔滨</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">石家庄</a></dd>
            </dl>
            <dl>
                <dt>华东地区：</dt>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">上海</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">南京</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">苏州</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">杭州</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">宁波</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">合肥</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">福州</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">济南</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">青岛</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">南昌</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">无锡</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">常州</a></dd>
            </dl>
            <dl>
                <dt>华南华中：</dt>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">广州</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">深圳</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">东莞</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">武汉</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">长沙</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">郑州</a></dd>
            </dl>
            <dl>
                <dt>西北西南：</dt>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">西安</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">成都</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">重庆</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this);">昆明</a></dd>
            </dl>
            <h3>
                所有省份：</h3>
            <dl>
                <dt>华东东北：</dt>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,0);">河北省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,1);">山西省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,2);">内蒙古</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,3);">辽宁省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,4);">吉林省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,5);">黑龙江省</a></dd>
            </dl>
            <dl>
                <dt>华东地区：</dt>
                <dd>
                    <a href="javascript:void(0);" class="prov">江苏省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov">浙江省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov">安徽省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov">福建省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov">江西省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov">山东省</a></dd>
            </dl>
            <dl>
                <dt>华南华中：</dt>
                <dd>
                    <a href="javascript:void(0);" class="prov">广东省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov">广西省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov">海南省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov">河南省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov">湖北省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov">湖南省</a></dd>
            </dl>
            <dl>
                <dt>西北西南：</dt>
                <dd>
                    <a href="javascript:void(0);" class="prov">陕西省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov">甘肃省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov">青海省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov">宁夏</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov">新疆</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov">四川省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov">贵州省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov">云南省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov">西藏</a></dd>
            </dl>
            <dl>
                <dt>其它：</dt>
                <dd>
                    <a href="javascript:void(0);">香港</a></dd>
                <dd>
                    <a href="javascript:void(0);">澳门</a></dd>
                <dd>
                    <a href="javascript:void(0);">台湾</a></dd>
                <dd>
                    <a href="javascript:void(0);">国外</a></dd>
            </dl>
            <span class="blank5px"></span>
        </div>
        <div class="btm">
        </div>
    </div>

    <script type="text/javascript">
        //调用弹出方法：
        function ChooseArea() {
            showMsgBox('ChooseArea', 538, 366) //参数说明：层ID, 层宽度，层高度
        }
        function AreaName(obj) {
            var AreaName = document.getElementById("AreaName");
            if (!AreaName) return false;
            AreaName.innerHTML = obj.innerHTML;
            closeWindow("ChooseArea");
        }
        var areas = new Array();
        areas[0] = new Array("广州1", "深圳", "惠州", "汕头", "珠海", "佛山", "中山", "东莞", "韶关", "江门", "湛江", "肇庆", "溥远", "潮州", "河源", "揭阳", "茂名", "汕尾", "顺德", "梅州", "开平", "阳江", "云浮");
        areas[1] = new Array("广州2", "深圳", "惠州", "汕头", "珠海", "佛山", "中山", "东莞", "韶关", "江门", "湛江", "肇庆", "溥远", "潮州", "河源", "揭阳", "茂名", "汕尾", "顺德", "梅州", "开平", "阳江", "云浮");
        areas[2] = new Array("广州3", "深圳", "惠州", "汕头", "珠海", "佛山", "中山", "东莞", "韶关", "江门", "湛江", "肇庆", "溥远", "潮州", "河源", "揭阳", "茂名", "汕尾", "顺德", "梅州", "开平", "阳江", "云浮");
        areas[3] = new Array("广州4", "深圳", "惠州", "汕头", "珠海", "佛山", "中山", "东莞", "韶关", "江门", "湛江", "肇庆", "溥远", "潮州", "河源", "揭阳", "茂名", "汕尾", "顺德", "梅州", "开平", "阳江", "云浮");
        areas[4] = new Array("广州5", "深圳", "惠州", "汕头", "珠海", "佛山", "中山", "东莞", "韶关", "江门", "湛江", "肇庆", "溥远", "潮州", "河源", "揭阳", "茂名", "汕尾", "顺德", "梅州", "开平", "阳江", "云浮");
        areas[5] = new Array("广州6", "深圳", "惠州", "汕头", "珠海", "佛山", "中山", "东莞", "韶关", "江门", "湛江", "肇庆", "溥远", "潮州", "河源", "揭阳", "茂名", "汕尾", "顺德", "梅州", "开平", "阳江", "云浮");


        function overDetail(obj, num) {
            var strHtml = "";
            var objParent = obj.parentNode;
            var subArea = document.getElementById("subArea_" + num);
            if (!subArea) {
                subArea = document.createElement("div");
                subArea.id = "subArea_" + num;
                subArea.className = "subArea";
                if (!areas[num]) { return false; }
                strHtml += "<h4>" + obj.innerHTML + "</h4>"
                for (var i = 0; i < areas[num].length; i++) {
                    strHtml += "<span><a href='javascript:void(0);' onclick='AreaName(this);'>" + areas[num][i] + "</a></span>";
                }
                subArea.innerHTML = strHtml;
                objParent.appendChild(subArea);

            }
            subArea.onmouseover = function() {
                this.parentNode.className = "relate cur";
                this.style.display = "block";
            }
            subArea.onmouseout = function() {
                this.parentNode.className = "";
                this.style.display = "none";
            }
            objParent.onmouseout = function() {
                this.className = "";
                subArea.style.display = "none";
            }
            objParent.className = "relate cur";
            subArea.style.display = "block";

        }
        //function outDetail(obj){
        //	if(!obj.parentNode)return false;
        //	obj.parentNode.style.display = "none";	
        //}
        function Changetag(words, num) {
            var topTabs = document.getElementById("topTabs");
            var tagName = document.getElementById("tagName");
            tagName.value = words;
            var aArray = topTabs.getElementsByTagName("a");
            for (var i = 0; i < aArray.length; i++) {
                if (i == aArray.length - 1) {
                    aArray[i].className = "nobor";
                } else {
                    aArray[i].className = "";
                }
            }
            aArray[num].className = "cur";
        }

        function searchName() {
            var tagName = document.getElementById("tagName").value;
            var keyword = document.getElementById("keyword").value;
            if (keyword == document.getElementById("keyword").defaultValue) { keyword = ""; }
            var AreaName = document.getElementById("AreaName").innerHTML;
            if (AreaName == "选择地区") { AreaName = ""; }
            alert("条件一：" + tagName + " 条件二：" + keyword + " 条件三：" + AreaName);
        }
    </script>

</asp:Content>
