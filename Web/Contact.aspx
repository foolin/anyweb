<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" Title="联系方式" %>

<%@ Register Src="Controls/CompanyNav.ascx" TagName="CompanyNav" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="location">您的位置： <a href="Index.aspx">首页</a> → 联系方式</div>
    <div class="main">
        <div class="container">
            <div class="column-sider">
                <!--栏目-->
                    <uc1:companynav id="CompanyNav1" runat="server"></uc1:companynav>
                <!--栏目-->
            </div>
            <div class="column-main">
            
            
            
                <div class="article"> 
                    <h3 class="art-title"> 
                        联系方式
                    </h3> 
                    <div class="art-info"> 
                        [字体： <a href="javascript:fontZoomMax()">大</a> <a href="javascript:fontZoomMid()">中</a> <a href="javascript:fontZoomMin()">小</a> ] &nbsp;[<a href="javascript:window.print()">打印</a> ] &nbsp;[<a href="javascript:window.close()">关闭</a>]
                        <script language="javascript" type="text/javascript" src="/JS/fontzoom.js"></script>
                    </div> 
                    <!-- art-info end --> 
                    <div class="art-content" id="art-content"> 
                        <ul>
                            <li>天河物业租赁及管理业务（联系电话：87599910）</li>
                        </ul>
                        <p>我社物业包括：广州市梅花园、沙河大街、龙口东路、元岗、登峰、水荫路、杨箕、石牌、五山等约55个点</p>
                        <ul>
                            <li>天河区龙口东市场经营及管理业务（联系电话：85266182）</li>
                        </ul>
                        <p>天河区龙口东农贸市场位于天河区龙口东路133号，占地面积1700平方米，于二零零一年一月起由我社自主经营。</p>
                        <ul>
                            <li>商品经营（联系电话：85266182）</li>
                        </ul>
                        <p>我社充分发挥供销社供销渠道广，经营优质商品的优势，秉承“信誉立足、品质取胜、用心服务、创新致远”的宗旨，不断开拓商品经营模式、完善配送服务，竭诚为客户服务。</p>
                        <ul>
                            <li>广州市杰信人力资源有限公司经营及管理（联系电话：87590122）</li>
                        </ul>
                        <p>杰信公司的业务包括：人事代理、人才招聘、企业咨询、培训、劳务派遣、代理劳动关系手续办理（劳动年审、社会保险办理等）等相关业务。</p>
                    </div> 
                    <!-- art-content end --> 
                </div> 
                <!-- article end --> 
                
                

             </div>
            <!-- column-main end -->
        </div>
        <!--container end -->
    </div>
    <!-- main end -->
</asp:Content>

