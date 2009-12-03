<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="UserDirect.aspx.cs" Inherits="UserDirect" Title="商城新用户的使用指引" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <style>
    .part1 {width:auto;line-height:30px; margin:6px 20px;color:gray; }
     .part1 h2{font-size:14px;}
     .finish{width:auto;line-height:30px; margin:0px 20px;color:red; font-size:14px; border-top:dotted 1px #cccccc; margin-top:10px; padding-top:10px;}
</style>
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    商城新用户的使用指引</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <div class="part1">
                    <h2>
                        第一步：<a href="/GoodsCategoryList.aspx">添加商品分类</a>
                    </h2>
                    请根据您的需要设置商品的类别。商城目前支持两个层级的分类，让您的商品分类更细分。比如您可以设置“服装”类别后，在它的子栏目设置“衬衫”“休闲裤”的分类。 如果您的商脉通已经有产品列表和产品介绍，您可以选择“导入商脉通产品”，这样会加快您的商品录入。导入商脉通产品后，您只需要在具体商品上修改价格等销售信息，就能针对性的展示销售。
                </div>
                <div class="part1">
                    <h2>
                        第二步：<a href="/GoodsList.aspx">添加商品</a></h2>
                    在添加了商品分类后，您就可以把商品添加到具体的类别中。
                </div>
                <div class="part1">
                    <h2>
                        第三步：<a href="/SlideEidt.aspx">设置商城促销动画</a></h2>
                    商城促销动画出现在商城的首屏页面，是宣传商城重要信息的黄金位置。您可以把重要的促销信息或者服务通知放到促销动画里。
                </div>
                <div class="part1">
                    <h2>
                        第四步：<a href="/GoodsList.aspx">设置推荐商品</a></h2>
                    进入商品列表，在 “推荐”列里，选择在商品的方框里打勾，这些商品就成为了“推荐商品”。您还可以在添加商品时，就选择把商品设置为推荐商品。
                </div>
                <div class="part1">
                    <h2>
                        第五步：修改 <a href="/ArticleCategoryList.aspx">“购买必读”</a>栏目</h2>
                    “购买必读”是一个单篇文章的栏目，它在商城导航条上显现。您可以把商城重要的折扣优惠启示，物流配送信息，在线客户联系等与顾客购买直接相关的内容放进“购买必读”里。 如果您想把顾客服务做得更好，我们建议您在商城后台的“商城服务指南”中修改“购物指南”、“常见问题”、“帮助中心”这三个栏目的文章内容。当您把这些内容设置好后，在“商城指南设置”里选择“在首页显示”，您的顾客就会在商城首页看到这些服务信息。
                </div>
                <div class="part1">
                    <h2>
                        第六步：<a href="/User/Agreement.aspx">修改会员注册协议</a></h2>
                    这里的会员注册协议，是您与您的顾客订立的一份服务协议，它用来规范您与顾客之间的服务关系，保护您的权益。在商城开通时，我们提供了一份参考范本，您可以根据您的具体情况修改这个范本。
                </div>
                <div class="part1">
                    <h2>
                        第七步：<a href="/SetMailBox.aspx">修改邮件设置</a></h2>
                    这里的邮件，指的是当顾客下了一个订单之后，系统会自动给顾客发送一封邮件，告知顾客，他的订单商城已经收到，请顾客等待商城的确认与处理。 请您修改这个邮件的内容，使它符合您的具体需要。
                </div>
                <div class="finish">
                    恭喜您！当您完成这七步设置后，您的商城已经是一个初具规模的网上店铺！
                </div>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph2" runat="Server">
    <li>如果您想把商城变成一个受客户欢迎的网上商店，我们建议您进一步完善商城的内容和商品的展示，在商品促销方面多下一些功夫。例如，您可以“修改<a href="/AfficheList.aspx">商城公告</a>”，发布最新商城公告；通过“设置<a href="/AdvertisementList.aspx">商城广告</a>”，让您最想包装推荐的商品在首页充分展示；通过“<a href="/AdvertisementList.aspx">文章管理</a>”发布与商品相关的使用建议、顾客感受文章，让您的商品赢得顾客信赖！ </li>
</asp:Content>
