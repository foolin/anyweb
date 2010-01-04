<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Index.aspx.cs"
    Inherits="Index" Title="广州市天河沙河供销社合作网" %>

<%@ Register Src="Controls/Contact.ascx" TagName="Contact" TagPrefix="uc5" %>

<%@ Register Src="Controls/LinkList.ascx" TagName="LinkList" TagPrefix="uc4" %>

<%@ Register Src="Controls/ImagesCtl.ascx" TagName="ImagesCtl" TagPrefix="uc3" %>

<%@ Register Src="Controls/ArticleList.ascx" TagName="ArticleList" TagPrefix="uc2" %>

<%@ Register Src="Controls/Notice.ascx" TagName="Notice" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="container">
            <div class="column-sider">
                <!--栏目-->
                <div class="boxA" style="height:190px; overflow:hidden;">
                    <uc1:Notice ID="Notice1" runat="server" />
                </div>
                <!--栏目-->
                <div class="boxA" style="height:180px; overflow:hidden;">
                    <div class="box-title">
                        <span class="titletxt">--== 网站导航 ==--</span></div>
                    <div class="box-content">
                        <ul class="li-slide">
                            <li><a href="Company.aspx">供销社介绍</a></li><li><a href="Department.aspx">部门架构</a>
                            </li><li><a href="Leadership.aspx">领导分工</a></li>
                            <li><a href="GoodsSell.aspx">商品销售</a></li>
                            <li><a href="LkdMarket.aspx">龙口东市场</a></li>
                            <li><a href="HR.aspx">人力资源</a></li>
                        </ul>
                    </div>
                </div>
                <!--栏目-->
                <div class="boxA" style="height:183px; overflow:hidden;">
                    <uc5:Contact ID="Contact1" runat="server" />
                </div>
            </div>
            <div class="column-main">
                <!-- subcontainer  start -->
                <div class="subcontainer">
                    <div class="subcolumn-A">
                        <!--栏目-->
                        <div class="box fixh-A">
                            <uc2:ArticleList ID="Article1" ColumnID="1" runat="server" />
                        </div>
                        <!--栏目End-->
                    </div>
                    <!-- subcolumn-A end -->
                    <div class="subcolumn-B">
                        <!--栏目-->
                        <div class="box fixh-A">
                            <uc3:ImagesCtl ID="ImagesCtl1" runat="server" />
                        </div>
                        <!--栏目End-->
                    </div>
                    <!-- subcolumn-B end -->
                    <div class="clear">
                    </div>
                </div>
                <!-- subcontainer end -->
                <!-- subcontainer  start -->
                <div class="subcontainer">
                    <div class="subcolumn-A">
                        <!--栏目-->
                        <div class="box fixh-B">
                            <uc2:ArticleList ID="ArticleList1" ColumnID="2" runat="server" />
                        </div>
                    </div>
                    <!--subcolumn-C end-->
                    <div class="subcolumn-B">
                        <!--栏目-->
                        <div class="box fixh-B">
                            <uc2:ArticleList ID="ArticleList2" ColumnID="3" runat="server" />
                        </div>
                    </div>
                    <!--subcolumn-C end-->
                </div>
                <!-- subcontainer end -->
            </div>
            <!-- column-main end -->
        </div>
        <!--container end -->
        <!-- container  start -->
        <div class="container">
            <div class="column-P3">
                <!--栏目-->
                <div class="box fixh-intro" onmouseover="this.style.background='#f2fee2';" onmouseout="this.style.background='#FFFFFF'">
                    <div class="box-title">
                        <span class="titletxt">--== 商品销售 ==--</span></div>
                    <div class="box-content">
                        广州市天河区沙河供销合作社成立于一九五三年，是广州市天河区供销联社下属的分支机构之一。我社一直致力于为城乡企业、居民服务，诚信守法经营，拥有良好的社会信誉。我社现时的经营业务范围主要有：物业租赁及管理、龙口东市场经营及管理、广州市杰信人力资源有限公司经营及管理、商品经营等。
                    </div>
                </div>
            </div>
            <!-- column-P3 end-->
            <div class="column-P3">
                <!--栏目-->
                <div class="box fixh-intro" onmouseover="this.style.background='#f2fee2';" onmouseout="this.style.background='#FFFFFF'">
                    <div class="box-title">
                        <span class="titletxt">--== 龙口东市场 ==--</span></div>
                    <div class="box-content">
                        龙口东农贸市场位于龙口东路133号，占地面积1700平方米，于二○○一年一月起由我社自主经营。二○○四年九月，在市、区政府和上级领导的大力支持下，投入资金二百万元，完成了升级改造工作。场内有档口70个，场外铺位10个，场内各项设施基本配套齐全，设有六大安全出口，配备食品检验室，软、硬件设备全部按工商、公安、消防、环保等部门的要求，建立健全各项规章制度，以规范管理，提高经营效益。
                    </div>
                </div>
            </div>
            <!-- column-P3 end-->
            <div class="column-P3">
                <!--栏目-->
                <div class="box fixh-intro" onmouseover="this.style.background='#f2fee2';" onmouseout="this.style.background='#FFFFFF'">
                    <div class="box-title">
                        <span class="titletxt">--== 人力资源 ==--</span></div>
                    <div class="box-content">
                        我社在经营传统业务的同时紧跟市场发展潮流，抓紧机遇，进行二次创业。杰信公司便是我社二次创业的产物，我社在原有的资源基础上进行整合及有效利用，创办杰信公司开拓人力资源领域方向的相关业务。杰信公司的业务包括：人事代理、人才招聘、企业咨询、培训、劳务派遣、代理劳动关系手续办理（劳动年审、社会保险办理等）等相关业务。
                    </div>
                </div>
            </div>
            <!-- column-P3 end-->
        </div>
        <!-- container end -->
        <!-- container  start -->
        <div class="container">
            <div class="hr-IE7bug">
            </div>
            <!--栏目-->
            <div class="boxA">
                <uc4:LinkList id="LinkList1" runat="server"></uc4:LinkList>
            </div>
        </div>
        <!-- container end -->
    </div>
    <!-- main end -->
</asp:Content>