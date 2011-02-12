<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="Desktop.aspx.cs" Inherits="Shop_Admin_Desktop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <style type="text/css">
    #userPointer .disdone a{color:#ccc;}
    #userPointer .done a img{margin-left:5px;}
#summary .mbd{padding-left:70px;background:url(../public/images/summary_leftbg.gif) 5px 20px no-repeat;}
#summary ul{padding-left:20px;padding-top:10px;}
#summary li{color:#777; list-style-type:disc;margin-bottom:10px;}
#summary li label{color:#000;}
#summary li.last span.tit{margin-left:20px;}
#summary li strong,
#summary li strong span{font-size:14px;color:#f60;margin:auto 3px;}

</style>
    <%--<%if (this.Page.MasterPageFile == ShopMasterPageFile.Replace("~", "") && Request.Cookies["ADMINUSER"] != null)
      {%>
    <script type="text/javascript">$("#NavLocation").html("<div class=\"welcome\">您好，<%= HttpUtility.UrlDecode(Request.Cookies["ADMINUSER"]["NAME"])%>，欢迎您使用商城后台管理系统</div>")</script>
    <%}%>--%>
    <div class="pbd">
        
        <div class="part pt1 ptSidebar">
            <ul class="Help">
                <li>如果您对后台操作有任何不明白的地方，点这里<a href="Help/" target="_blank">“进入操作指南”</a>获得帮助</li>
                <li>如果您有任何好的想法和改善建议，请点击这里<a href="http://www.fortuneage.com/mycore/myindex/fa/contact.aspx"
                    target="_blank">“联系我们”</a></li>
            </ul>
        </div>
        <div class="part pt3">
            <div class="Mod UserPointer" id="userPointer">
                <div class="mbd pubOutput">
                    <div class="info">
                        <strong>初次建立商城用户建议按下列顺序完成初始化工作</strong></div>
                    <ol>
                        <li class="<%=AnyWell.Configs.GeneralConfigs.GetConfig().SetupConfigGeneral ? "done" : "disdone"%>"><a href="Setting_General.aspx">完整设置商城基本配置<img alt="" src="../public/images/yes.gif" style="display:<%=AnyWell.Configs.GeneralConfigs.GetConfig().SetupConfigGeneral ? "" : "none"%>" /></a></li>
                        <li class="<%=AnyWell.Configs.GeneralConfigs.GetConfig().SetupConfigMember ? "done" : "disdone"%>"><a href="Setting_Register.aspx">设置用户注册协议<img alt="" src="../public/images/yes.gif" style="display:<%=AnyWell.Configs.GeneralConfigs.GetConfig().SetupConfigMember ? "" : "none"%>" /></a></li>
                        <li class="<%=AnyWell.Configs.GeneralConfigs.GetConfig().SetupConfigHelp ? "done" : "disdone"%>"><a href="HelpList.aspx">设置买家常见问题答案<img alt="" src="../public/images/yes.gif" style="display:<%=AnyWell.Configs.GeneralConfigs.GetConfig().SetupConfigHelp ? "" : "none"%>" /></a></li>
                        <li class="<%=AnyWell.Configs.GeneralConfigs.GetConfig().SetupConfigPayment ? "done" : "disdone"%>"><a href="Setting_Payment.aspx">设置商城支付方式<img alt="" src="../public/images/yes.gif" style="display:<%=AnyWell.Configs.GeneralConfigs.GetConfig().SetupConfigPayment ? "" : "none"%>" /></a></li>
                        <li class="<%=AnyWell.Configs.GeneralConfigs.GetConfig().SetupConfigImage ? "done" : "disdone"%>"><a href="Setting_Image.aspx">设置图片规格和水印<img alt="" src="../public/images/yes.gif" style="display:<%=AnyWell.Configs.GeneralConfigs.GetConfig().SetupConfigImage ? "" : "none"%>" /></a></li>
                        <li class="<%=AnyWell.Configs.GeneralConfigs.GetConfig().SetupCategory ? "done" : "disdone"%>"><a href="CategoryList.aspx">设置商品的分类数据<img alt="" src="../public/images/yes.gif" style="display:<%=AnyWell.Configs.GeneralConfigs.GetConfig().SetupCategory ? "" : "none"%>" /></a></li>
                        <li class="<%=AnyWell.Configs.GeneralConfigs.GetConfig().SetupBrand ? "done" : "disdone"%>"><a href="BrandList.aspx">设置商品的品牌数据<img alt="" src="../public/images/yes.gif" style="display:<%=AnyWell.Configs.GeneralConfigs.GetConfig().SetupBrand ? "" : "none"%>" /></a></li>
                    </ol>
                </div>
                <div class="mft">
                </div>
            </div>
            <div class="Mod" id="summary">
                <div class="mhd">
                    <h3>
                        我的商城</h3>
                </div>
                <div class="mbd">
                    <ul>
                        <li>共有<strong><asp:Literal ID="ltlNewOrderCount" Text="0" runat="server" /></strong>笔新订单，请到“<a href="orderlist.aspx">订单管理</a>”中确认发货。</li>
                        <li>在最近三个月内，您共有<strong><asp:Literal ID="ltlTop3MonthOrderCount" Text="0" runat="server" /></strong>笔买入交易记录，请到“<a href="orderlist.aspx">订单管理</a>”中查看。</li>
                        <li>有<strong><asp:Literal ID="ltlStockNotEnoughCount" Text="0" runat="server" /></strong>个商品库存不足，请到“<a href="goodslist.aspx">商品管理</a>”中查看。</li>
                        <li>有<strong><asp:Literal ID="ltlNoReplyCount" runat="server" /></strong>个商品评论未回复，请到“<a href="CommentList.aspx?reply=0">评论管理</a>”中查看。</li>
                        <li style="display:none">有<strong>3</strong>个买家留言未回复，请到“<a href="MessageList.aspx">留言管理</a>”中查看。</li>
                </div>
                <div class="mft">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
