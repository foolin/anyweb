<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="LeaderContact.aspx.cs" Inherits="LeaderContact" Title="领导电话" %>

<%@ Register Src="Controls/CompanyNav.ascx" TagName="CompanyNav" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="location">您的位置： <a href="Index.aspx">首页</a> → 领导电话</div>
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
                        领导联系方式
                    </h3> 
                    <div class="art-info"> 
                        [字体： <a href="javascript:fontZoomMax()">大</a> <a href="javascript:fontZoomMid()">中</a> <a href="javascript:fontZoomMin()">小</a> ] &nbsp;[<a href="javascript:window.print()">打印</a> ] &nbsp;[<a href="javascript:window.close()">关闭</a>]
                        <script language="javascript" type="text/javascript" src="/JS/fontzoom.js"></script>
                    </div> 
                    <!-- art-info end --> 
                    <div class="art-content" id="art-content"> 
                        <p>主任：罗学葆</p>
                        <p>地址：天河区龙口东路139号后座四楼</p>                 
                        <p>邮编：510635</p>
                        <p>电话：(020)87563088</p>
                        <p>传真：(020)87597663</p>
                        <p>手机：13535379393</p>
                        <p>邮箱：luoxb_shs@163.com;gzthshaheshe@163.com</p>
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

