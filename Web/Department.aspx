<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Department.aspx.cs" Inherits="Department" Title="部门架构" %>

<%@ Register Src="Controls/CompanyNav.ascx" TagName="CompanyNav" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                        部门架构
                    </h3> 
                    <div class="art-info"> 
                        [字体： <a href="javascript:fontZoomMax()">大</a> <a href="javascript:fontZoomMid()">中</a> <a href="javascript:fontZoomMin()">小</a> ] &nbsp;[<a href="javascript:window.print()">打印</a> ] &nbsp;[<a href="javascript:window.close()">关闭</a>]
                        <script language="javascript" type="text/javascript" src="/JS/fontzoom.js"></script>
                    </div> 
                    <!-- art-info end --> 
                    <div class="art-content" id="art-content"> 
                        
		               <p>广州市天河区沙河供销合作社成立于一九五三年，是广州市天河区供销联社下属的分支机构之一。我社一直致力于为城乡企业、居民服务，诚信守法经营，拥有良好的社会信誉。我社现时的经营业务范围主要有：物业租赁及管理、龙口东市场经营及管理、广州市杰信人力资源有限公司经营及管理、商品经营等。我社的组织架构见下图：</p>
		               <p>
		                    <img src="SiteData/Picture/department.jpg"  alt="" />
		               </p>
		               <p>
		               
		               <a href="Company.aspx">详细职能请点击这里>></a>
		               
		               </p>
                 
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

