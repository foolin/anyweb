<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductInfo.ascx.cs" Inherits="Controls_ProductInfo" %>
<div class="box">
    <div class="title">
        <%=good.GoodsName %></div>
    <div class="gLeft">
        <div class="gImage">
            <a href="<%=good.Image=="" ? "../images/wait.jpg":good.Image.Replace("S_","") %>" target="_blank">
                <img src="<%=good.Image=="" ? "../images/wait.jpg":good.Image.Replace("S_","") %>"
                    width="300" height="300" alt="<%=good.GoodsName %>" /></a>
            <br />
            <a href="<%=good.Image=="" ? "../images/wait.jpg":good.Image.Replace("S_","") %>"
                target="_blank" title="点击查看大图">点击查看大图</a>            
        </div>
    </div>
    <!-- gLeft -->
    <div class="gRight">
        <dl class="gInfo">
            <dt>
                <%=good.GoodsName %>
            </dt>
            <%if (good.MarketPrice != 0)
              {%>
            <dd>
                市场价：<s>￥<%=good.MarketPrice%>元</s></dd>
                <%} %>
            <%if (good.IsPromotions)
              { %>
              <%if (good.Price != 0)
                {%>
            <dd>
                基团价：<s>￥<%=good.Price%>元</s></dd>
                <%} %>
            <dd>
                促销价格：￥<%=good.PromotionsPrice%>元</dd>
            <%}
              else
              { %>
              <%if (good.Price != 0)
                { %>
            <dd>
                基团价：￥<%=good.Price%>元</dd>
                <%} %>
            <%} %>            
            <%if (!string.IsNullOrEmpty(good.Factory))
              { %>
              <dd>产地/产商：<%=good.Factory %></dd>
            <%} %>
            <dd>
                存货：<%=GetGoodCount(good.Status) %></dd>
            <dd>
                <%=good.Service %>
            </dd>
            <!--
            <dd>
                <input type="button" name="buy" value="购买" />
                <input type="button" name="addToCart" value="加入购物车" /></dd>
                -->
        </dl>
    </div>
</div>
<!-- gRight -->
<div class="clear">
</div>
<div class="hr">
</div>
<div class="gDetails">
    <%=good.Description %>
</div>
