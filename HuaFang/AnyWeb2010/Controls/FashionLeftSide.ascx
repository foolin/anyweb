<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FashionLeftSide.ascx.cs"
    Inherits="Controls_FashionLeftSide" %>
<div class="title-bar">
    <h2 class="cs-clear">
        <p class="title-ch cs-fl">
            <span>秀场追击</span></p>
    </h2>
</div>
<div class="ShowNav ShowNav_season">
    <h3>
        <strong>季节</strong></h3>
    <div class="SeasonList cs-clear">
        <a href="javascript:void(0);" class="SeaList-Up" id="btn2"></a><a href="javascript:void(0);"
            class="SeaList-Down" id="btn1"></a>
        <div class="SeasonList-con cs-fl" id="scrollDiv">
            <ul class="SeaList-main">
                <asp:Repeater ID="repColumn" runat="server">
                    <ItemTemplate>
                        <%#Container.ItemIndex % 2 == 0 ? "<li>" : ""%>
                        <span><a href="#">
                            <%#Eval("fdColuName") %></a></span>
                        <%#Container.ItemIndex % 2 == 1 || Container.ItemIndex == coluCount - 1 ? "</li>" : ""%>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <a href="#" class="ShowNav-all">全部</a>
</div>
<!-- -->
<!-- -->
<div class="ShowNav">
    <h3>
        <strong>产品类别</strong></h3>
    <div class="">
        <p>
            <span><a href="#">男装</a></span><span><a href="#" class="on">高级成衣</a></span><span><a
                href="#">高级定制</a></span><span><a href="#" class="ShowNav-all">全部</a></span></p>
    </div>
</div>
<!-- -->
<!-- -->
<div class="ShowNav">
    <h3>
        <strong>城市列表</strong></h3>
    <div class="">
        <p>
            <span><a href="#">巴黎</a></span><span><a href="#">米兰</a></span><span><a href="#" class="on">伦敦</a></span><span><a
                href="#">纽约</a></span><span><a href="#">米兰</a></span><span><a href="#" class="on">其他</a></span><span><a
                    href="#" class="ShowNav-all">全部</a></span></p>
    </div>
</div>
<!-- -->
<!-- -->
<div class="ShowNav">
    <h3>
        <strong>设计师/品牌</strong></h3>
    <div class="ShowNav-btn cs-clear">
        <a class="btn-simple" href="#">搜索</a></div>
    <div class="ShowNav-search">
        <input type="text" class="ipt-simple">
        <div class="ShowNav-list" style="display: none">
            <a href="#">Acne - Pre </a><a href="#">Amuse - Pre </a><a href="#">Burberry Prorsum
                Cruise </a><a href="#">Celine - Pre </a><a href="#">Danjyo Hiyoji - Pre </a>
            <a href="#">Acne - Pre </a><a href="#">Amuse - Pre </a><a href="#">Burberry Prorsum
                Cruise </a><a href="#">Celine - Pre </a><a href="#">Depression - Pre </a><a href="#">
                    Diane von Furstenberg...</a> <a href="#">Erdem - Pre</a> <a href="#">Ermenegildo Zegna
                    </a><a href="#">Etro </a><a href="#">Giorgio Armani </a>
        </div>
    </div>
</div>
<!-- -->
<!-- -->
<div class="Side_menu">
    <div class="common_menu">
        <a href="#"><strong>行业招聘</strong></a>
    </div>
    <div class="common_menu cs-nobor">
        <a href="#"><strong>行业人才</strong></a>
    </div>
</div>
