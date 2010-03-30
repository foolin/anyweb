<%@ Page Title="������" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
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
                    ��ϵ��ʽ</div>
                <div class="ico">
                    <img src="Images/box1_title_rbg.gif" width="66" height="33" alt="��ϵ��ʽ" /></div>
            </div>
            <div class="contentB">
                <dl>
                    <dt>�̳Ƿ���ʱ��</dt>
                    <dd>
                        ��һ������</dd>
                    <dt>��ϵ��ʽ</dt>
                    <dd>
                        ��ϵ�绰��020-87590122</dd>
                    <dd>
                        Ͷ�ߵ绰��020-87590122
                    </dd>
                    <dd>
                        ���棺020-87597663
                    </dd>
                    <dd>
                        ���䣺 gzthshaheshe@163.com</dd>
                    <dd>
                        �ʱࣺ510635
                    </dd>
                    <dd>
                        ��ַ����������������ڶ�·139�ź���������¥
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
