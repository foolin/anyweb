<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="HR.aspx.cs" Inherits="HR" Title="人力资源" %>

<%@ Register Src="Controls/CompanyNav.ascx" TagName="CompanyNav" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="location">您的位置： <a href="Index.aspx">首页</a> → 人力资源</div>
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
                        广州市杰信人力资源有限公司经营及管理
                    </h3> 
                    <div class="art-info"> 
                        [字体： <a href="javascript:fontZoomMax()">大</a> <a href="javascript:fontZoomMid()">中</a> <a href="javascript:fontZoomMin()">小</a> ] &nbsp;[<a href="javascript:window.print()">打印</a> ] &nbsp;[<a href="javascript:window.close()">关闭</a>]
                        <script language="javascript" type="text/javascript" src="/JS/fontzoom.js"></script>
                    </div> 
                    <!-- art-info end --> 
                    <div class="art-content" id="art-content"> 
                        
		               <p>我社在经营传统业务的同时紧跟市场发展潮流，抓紧机遇，进行二次创业。杰信公司便是我社二次创业的产物，我社在原有的资源基础上进行整合及有效利用，创办杰信公司开拓人力资源领域方向的相关业务。杰信公司的业务包括：人事代理、人才招聘、企业咨询、培训、劳务派遣、代理劳动关系手续办理（劳动年审、社会保险办理等）等相关业务。</p>

                 
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

