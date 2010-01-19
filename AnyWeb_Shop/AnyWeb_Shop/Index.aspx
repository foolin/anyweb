<%@ Page Title="������" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Index.aspx.cs" Inherits="Index" %>
<%@ Register Src="~/Controls/CategoryLeft.ascx" TagName="CategoryLeft" TagPrefix="cate" %>
<%@ Register Src="~/Controls/FlashList.ascx" TagName="FlashList" TagPrefix="flash" %>
<%@ Register Src="~/Controls/RecommdIndex.ascx" TagName="RecommdIndex" TagPrefix="recomment" %>
<%@ Register Src="~/Controls/PromotionIndex.ascx"TagName="PromotionIndex" TagPrefix="promot" %>
<%@ Register Src="~/Controls/PromotionListIndex.ascx"TagName="PromotionList" TagPrefix="promot" %>
<%@ Register Src="~/Controls/LinkIndex.ascx"TagName="Link" TagPrefix="link" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="Server">
    <link href="/public/index.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/public/slidetrans.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="main">
        <div class="col-left">
            <!-- ��Ŀ -->
            <cate:CategoryLeft runat="server" />
            <!-- category end -->
            
            
            <!-- ��Ŀ -->
            <div class="category">
                <div class="title">
                    ��ϵ��ʽ</div>
                <div class="content">
                    <h3>
                        �̳Ƿ���ʱ��:  </h3>
                    <div class="line">
                         ��һ������<br />
                        ����9:00������18:00<br />
                    </div>
                    <h3>
                        ��ϵ��ʽ</h3>
                    <div class="line">
                        ��ϵ�绰��020-87590122<br />
                        Ͷ�ߵ绰��020-87590122 <br />
                        ���棺020-87597663 <br />
                        ���䣺 gzthshaheshe@163.com <br />
                        �ʱࣺ510635 <br />
                        ��ַ����������������ڶ�·139�ź���������¥ <br />
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <!-- content end -->
            </div>
            <!-- category end -->
            
            
            <!-- ��Ŀ -->
            <div class="category">
                <link:Link runat="server" />
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
                ����ר��</div>
                <div class="topic-box">
                    <promot:PromotionList runat="server" />
                    <div style="height: 10px;">
                        <!-- �ָ� -->
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
