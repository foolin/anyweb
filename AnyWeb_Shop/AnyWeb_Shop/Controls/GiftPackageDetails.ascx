<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GiftPackageDetails.ascx.cs" Inherits="Controls_GiftPackageDetails" %>
        <table class="mainContainer">
        	<tr>
            	<th colspan="2" class="title"><%=giftPack.PackName %></th>
            </tr>
            <tr>
            	<td colspan="2" class="subTitle">&nbsp;</td>
           	</tr>
            <tr>
            	<td class="tdColorM" width="45%" valign="top">
                	<div class="goodsDetailsImage">
            			<a href="<%=giftPack.Image=="" ? "../images/wait.jpg":giftPack.Image.Replace("S_","") %>" target="_blank">
                		<img src="<%=giftPack.Image=="" ? "../images/wait.jpg":giftPack.Image.Replace("S_","") %>" width="275" alt="<%=giftPack.PackName %>" /></a>
                        <hr />
                        <a href="<%=giftPack.Image=="" ? "../images/wait.jpg":giftPack.Image.Replace("S_","") %>" target="_blank" title="点击查看大图"><img src="Images/view_image_btn.gif"  border="0"/></a>
                    </div>
                </td>
                <td valign="top">
                        <dl class="goodsDetailsItems">
                            <dt>
                                <%=giftPack.PackName %>
                            </dt>
                            
                            <dd>
                                编号：<span class="vlue"><s><%=giftPack.PackNo %></s></span></dd>
                                
                            <dd>
                                价格：<span class="vlue"><s>￥<%=giftPack.Price %></s></span></dd>
                                
                            <dd>
                                商品ID：<span class="vlue"><a href="#goodsView"><%=giftPack.GoodsIds %></a></span></dd>
                            
                            <dd>介绍：<span class="vlue"><%=giftPack.Intro %></span></dd>
                            <!--
                            <dd>
                                <input type="button" name="buy" value="购买" />
                                <input type="button" name="addToCart" value="加入购物车" /></dd>
                                -->
                        </dl>
                </td>
            </tr>
            <tr>
            	<td colspan="2" class="word">
                	<div  class="word">
                  
                    
                        <%=giftPack.Description %>
                        
                        
                        <a name="goodsView"></a>
                        <table class="goodsList mainContainer">
                        	<tr class="subTitle">
                            	<td width="50%">商品名称</td>
                                <td>商品编号</td>
                                <td class="10%">点击查看</td>
                            </tr>
                            <asp:Repeater ID="repList" runat="server">
                                <ItemTemplate>
                                <tr>
                                    <td><%#Eval("GoodsName") %></td>
                                    <td><%#Eval("ID") %></td>
                                    <td class="tdColorM"><a href="Good.aspx?gid=<%#Eval("ID") %>">查看详细</a></td>
                                </tr>
                                </ItemTemplate>
                        </asp:Repeater>
                        </table>
                        

                        
 
 					<!-- end word -->
                    </div>
                </td>
            </tr>
        </table>
