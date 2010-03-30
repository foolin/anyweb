<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GoodDetail.ascx.cs" Inherits="Controls_GoodDetail" %>
<table class="mainContainer">
    <tr>
        <th colspan="2" class="title">
            <%=good.GoodsName %>
        </th>
    </tr>
    <tr>
        <td colspan="2" class="subTitle">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="tdColorM" width="45%" valign="top">
            <div class="goodsDetailsImage">
                <a href="<%=good.Image=="" ? "../images/wait.jpg":good.Image.Replace("S_","") %>"
                    target="_blank">
                    <img src="<%=good.Image=="" ? "../images/wait.jpg":good.Image.Replace("S_","") %>"
                        width="275" alt="<%=good.GoodsName %>" /></a>
                <hr />
                <a href="../images/wait.jpg" target="_blank" title="点击查看大图">
                    <img src="Images/view_image_btn.gif" border="0" /></a>
            </div>
        </td>
        <td valign="top">
            <dl class="goodsDetailsItems">
                <dt>
                    <%=good.GoodsName %></dt>
                <%if (good.MarketPrice != 0)
                  {%>
                <dd>
                    市场价：<span class="vlue"><s>￥<%=good.MarketPrice%>元</s></span></dd>
                <%} %>
                <%if (good.IsPromotions)
                  { %>
                <%if (good.Price != 0)
                  {%>
                <dd>
                    基团价：<span class="vlue"><s>￥<%=good.Price%>元</s></span></dd>
                <%} %>
                <dd>
                    促销价格：<span class="vlue">￥<%=good.PromotionsPrice%>元</span></dd>
                <%}
                  else
                  { %>
                <%if (good.Price != 0)
                  { %>
                <dd>
                    基团价：<span class="vlue">￥<%=good.Price%>元</span></dd>
                <%} %>
                <%} %>
                <%if (!string.IsNullOrEmpty(good.Factory))
                  { %>
                <dd>
                    产地/产商：<%=good.Factory %></dd>
                <%} %>
                <dd>
                    存货：<%=GetGoodCount(good.Status) %></dd>
                <dd>
                    <%=good.Service %>
                </dd>
            </dl>
        </td>
    </tr>
    <tr>
        <td colspan="2" class="word">
            <div class="word">
                <%=good.Description %>
            </div>
        </td>
    </tr>
</table>
