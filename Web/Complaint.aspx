﻿<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Complaint.aspx.cs" Inherits="Complaint" Title="投诉电话" %>

<%@ Register Src="Controls/CompanyNav.ascx" TagName="CompanyNav" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="location">您的位置： <a href="Index.aspx">首页</a> → 投诉电话</div>
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
                        
                        投诉电话
                    </h3> 
                    <div class="art-info"> 
                        [字体： <a href="javascript:fontZoomMax()">大</a> <a href="javascript:fontZoomMid()">中</a> <a href="javascript:fontZoomMin()">小</a> ] &nbsp;[<a href="javascript:window.print()">打印</a> ] &nbsp;[<a href="javascript:window.close()">关闭</a>]
                        <script language="javascript" type="text/javascript" src="/JS/fontzoom.js"></script>
                    </div> 
                    <!-- art-info end --> 
                    <div class="art-content" id="art-content"> 
                        <p>投诉电话：87590122 （人事行政科电话）</p>
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

