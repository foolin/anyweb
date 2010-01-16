<%@ Page Title="基团网" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Index.aspx.cs" Inherits="Index" %>
<%@ Register Src="~/Controls/CategoryLeft.ascx" TagName="CategoryLeft" TagPrefix="cate" %>
<%@ Register Src="~/Controls/FlashList.ascx" TagName="FlashList" TagPrefix="flash" %>
<%@ Register Src="~/Controls/RecommdIndex.ascx" TagName="RecommdIndex" TagPrefix="recomment" %>
<%@ Register Src="~/Controls/PromotionIndex.ascx"TagName="PromotionIndex" TagPrefix="promot" %>
<%@ Register Src="~/Controls/PromotionListIndex.ascx"TagName="PromotionList" TagPrefix="promot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="Server">
    <link href="/public/index.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/public/slidetrans.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="main">
        <div class="col-left">
            <!-- 栏目 -->
            <cate:CategoryLeft runat="server" />
            <!-- category end -->
            
            
            <!-- 栏目 -->
            <div class="category">
                <div class="title">
                    联系方式</div>
                <div class="content">
                    <h3>
                        商城服务时间:  </h3>
                    <div class="line">
                         周一至周五<br />
                        上午9:00至下午18:00<br />
                    </div>
                    <h3>
                        联系方式</h3>
                    <div class="line">
                        联系电话：020-87590122<br />
                        投诉电话：020-87590122 <br />
                        传真：020-87597663 <br />
                        邮箱： gzthshaheshe@163.com <br />
                        邮编：510635 <br />
                        地址：广州市天河区龙口东路139号后座二至四楼 <br />
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <!-- content end -->
            </div>
            <!-- category end -->
            
            
            <!-- 栏目 -->
            <div class="category">
                <div class="title">
                    友情链接</div>
                <div class="content">
                    <ul>
                        <li><a href="#">基团网</a></li>
                        <li><a href="http://www.thshcoop.com" target="_blank">沙河供销社</a></li>
                        <li><a href="http://www.amazon.cn/" target="_blank">卓越网</a></li>
                    </ul>
                </div>
               
                <!-- content end -->
            </div>
            <!-- category end -->
            
            
        </div>
        <!-- col-left -->
        <div class="col-main">
            <flash:FlashList runat="server" />
            <div class="container">
                <div class="goods-container">
                    <recomment:RecommdIndex runat="server" />
                </div>
                <!-- goods-container end -->
                <div class="goods-container">
                    <promot:PromotionIndex runat="server" />
                </div>
                <!-- goods-container end -->
            </div>
            <!-- container end -->
        </div>
        <!-- col-main -->
        <div class="col-right">
        
            <div class="box">
            <div class="title">
                促销专题</div>
                <div class="topic-box">
                    <promot:PromotionList runat="server" />
                    <div style="height: 10px;">
                        <!-- 分割 -->
                    </div>
                </div>
            <!-- topic-box end -->
            
            </div>
        </div>
        <!-- col-right -->
        <div class="clear">
        </div>
    </div>
    <!-- main end -->
    <script type="text/javascript">
        SetTitleCss(1);
    </script>
</asp:Content>
