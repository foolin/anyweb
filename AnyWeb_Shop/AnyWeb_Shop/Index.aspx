<%@ Page Title="基团网" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Index.aspx.cs" Inherits="Index" %>

<%@ Register Src="~/Controls/CategoryLeft.ascx" TagName="CategoryLeft" TagPrefix="uc" %>
<%@ Register Src="~/Controls/FlashList.ascx" TagName="FlashList" TagPrefix="uc" %>
<%@ Register Src="~/Controls/RecommdIndex.ascx" TagName="RecommdIndex" TagPrefix="uc" %>
<%@ Register Src="~/Controls/PromotionIndex.ascx" TagName="PromotionIndex" TagPrefix="uc" %>
<%@ Register Src="~/Controls/PromotionListIndex.ascx" TagName="PromotionList" TagPrefix="uc" %>
<%@ Register Src="~/Controls/LinkIndex.ascx" TagName="Link" TagPrefix="uc" %>
<%@ Register Src="Controls/HotSellRankList.ascx" TagName="HotSellRankList" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="indexMainCol1">
        <uc:CategoryLeft ID="CategoryLeft1" runat="server" />
        <div class="box">
            <div class="title">
                <div class="txt">
                    联系方式</div>
                <div class="ico">
                    <img src="Images/box1_title_rbg.gif" width="66" height="33" alt="联系方式" /></div>
            </div>
            <div class="contentB">
                <dl>
                    <dt>商城服务时间</dt>
                    <dd>
                        周一至周五</dd>
                    <dt>联系方式</dt>
                    <dd>
                        联系电话：020-87590122</dd>
                    <dd>
                        投诉电话：020-87590122
                    </dd>
                    <dd>
                        传真：020-87597663
                    </dd>
                    <dd>
                        邮箱： gzthshaheshe@163.com</dd>
                    <dd>
                        邮编：510635
                    </dd>
                    <dd>
                        地址：广州市天河区龙口东路139号后座二至四楼
                    </dd>
                </dl>
            </div>
        </div>
        
    </div>
    <div class="indexMainCol2">
    <div class="mainCol2Space">
        <uc:FlashList ID="Flash" runat="server" />
        <uc:RecommdIndex ID="rec" runat="server" />
        <uc:PromotionIndex ID="pro" runat="server" />
    </div>
    </div>
    <div class="indexMainCol3">
        <uc:PromotionList ID="PromotionList" runat="server" />
        <uc:HotSellRankList ID="HotSellRankList" runat="server" />
        <uc:Link ID="Link" runat="server" />
    </div>
    <div class="clear">
    </div>

    <script type="text/javascript">
        SetTitleCss(1);
    </script>

</asp:Content>
