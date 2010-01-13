<%@ Page Title="ª˘Õ≈Õ¯" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
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
            <!-- ¿∏ƒø -->
            <cate:CategoryLeft runat="server" />
            <!-- category end -->
            <!-- ¿∏ƒø -->
            <div class="category">
                <div class="title">
                    …Ã∆∑∑÷¿‡</div>
                <div class="content">
                    <h3>
                        ÕºœÒ“ÙœÒ∑÷¿‡</h3>
                    <div class="line">
                        <span><a href="">DVD</a></span> <span><a href="">”∞ ”</a></span> <span><a href="">“Ù¿÷</a></span>
                        <span><a href="">“Ù¿÷</a></span> <span><a href="">“Ù¿÷</a></span> <span><a href="">“Ùs¿÷</a></span>
                        <span><a href="">“Ùs¿÷</a></span> <span><a href="">“Ùs¿÷</a></span> <span><a href="">DVD</a></span>
                        <span><a href="">”∞ ”</a></span> <span><a href="">“Ù¿÷</a></span> <span><a href="">“Ù¿÷</a></span>
                        <span><a href="">“Ù¿÷</a></span> <span><a href="">“Ùs¿÷</a></span> <span><a href="">“Ùs¿÷</a></span>
                        <span><a href="">“Ùs¿÷</a></span>
                        <div class="clear">
                        </div>
                    </div>
                    <h3>
                        ÕºœÒ“ÙœÒ∑÷¿‡</h3>
                    <div class="line">
                        <span><a href="">DVD</a></span> <span><a href="">”∞ ”</a></span> <span><a href="">“Ù¿÷</a></span>
                        <span><a href="">“Ù¿÷</a></span> <span><a href="">“Ù¿÷</a></span> <span><a href="">“Ùs¿÷</a></span>
                        <span><a href="">“Ùs¿÷</a></span> <span><a href="">“Ùs¿÷</a></span> <span><a href="">DVD</a></span>
                        <span><a href="">”∞ ”</a></span> <span><a href="">“Ù¿÷</a></span> <span><a href="">“Ù¿÷</a></span>
                        <span><a href="">“Ù¿÷</a></span> <span><a href="">“Ùs¿÷</a></span> <span><a href="">“Ùs¿÷</a></span>
                        <span><a href="">“Ùs¿÷</a></span>
                        <div class="clear">
                        </div>
                    </div>
                    <h3>
                        ÕºœÒ“ÙœÒ∑÷¿‡</h3>
                    <div class="line">
                        <span><a href="">DVD</a></span> <span><a href="">”∞ ”</a></span> <span><a href="">“Ù¿÷</a></span>
                        <span><a href="">“Ù¿÷</a></span> <span><a href="">“Ù¿÷</a></span> <span><a href="">“Ùs¿÷</a></span>
                        <span><a href="">“Ùs¿÷</a></span> <span><a href="">“Ùs¿÷</a></span> <span><a href="">DVD</a></span>
                        <span><a href="">”∞ ”</a></span> <span><a href="">“Ù¿÷</a></span> <span><a href="">“Ù¿÷</a></span>
                        <span><a href="">“Ù¿÷</a></span> <span><a href="">“Ùs¿÷</a></span> <span><a href="">“Ùs¿÷</a></span>
                        <span><a href="">“Ùs¿÷</a></span>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="clear">
                    </div>
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
                ¥Ÿœ˙◊®Ã‚</div>
                <div class="topic-box">
                    <promot:PromotionList runat="server" />
                    <div style="height: 10px;">
                        <!-- ∑÷∏Ó -->
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
