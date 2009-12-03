<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="SEO.aspx.cs" Inherits="SEO" Title=" SEO管理" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
  
               <li>  可在此了解SEO的概念和常用的参考工具。</li>
  <li>  标题设置，设置4-5个用户常在搜索引擎查找与商城商品相关的词语，将自动附加在网页标题中，对SEO起到最重要的优化作用。</li>
   <li> 关键字设置，设置1-12个用户搜索习惯使用的词语。会自动附加在页面代码的META-Keyword里面。</li>
  <li>  描述设置，关键商城的描述，可以是介绍商城经营范围及产品等等的一段话。会自动附加在页面代码的description里面.</li>
  <li>  请尽量不要设置虚词（如：的，和）、范围太广泛的（如：中国、销售）、太短的可能频繁出现的字母缩写（如：AB）等。</li>
              
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
 <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    SEO管理</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                <div style="padding-left:10px; padding-bottom:10px;">
                <span style="float:left; margin-right:10px;"><img src="images/hy.jpg" alt="什么是SEO？" /></span>
                <span style="line-height:25px; ">什么是SEO?<br />SEO工作是围绕关键词进行的，因此关键词的选取关系着整个SEO工作能否有效的开展。关键词选取在网站策划阶段就应该考虑进去，网站定位、栏目设置、产品所在行业的特点、目标群体所在区域等因素都或大或小影响关键词的选取。</span>
                </div>
                <div style="padding:10px 10px 0px; clear:both;">【SEO参考工具】：搜索词频工具：<a href="http://www2.baidu.com/inquire/rsquery.php" target="_blank">百度搜索词频</a>&nbsp;<a href="https://adwords.google.com/select/KeywordToolExternal" target="_blank">GOOGLE关键词工具</a>&nbsp;<a href="http://db.sohu.com/regurl/pv_price/query_consumer.asp" target="_blank">SOHU搜索词频</a>
                &nbsp;<a href="http://db.sohu.com/regurl/pv_price/query_consumer.asp" target="_blank">SOHU搜索词频</a></div>
                <div style="padding:10px 0px 10px 110px;">关键字竞争程度查询工具：<a href="https://adwords.google.com/select/KeywordToolExternal" target="_blank">Google提供的关键词扩展工具</a>&nbsp;<a href="http://www2.baidu.com/inquire/price.php" target="_blank">百度的关键词价格查询工具</a>&nbsp;<a href="http://db.sohu.com/regurl/pv_price/query_consumer.asp" target="_blank">SOHU的关键词价格查询工具</a></div>
            <asp:FormView ID="fv1" runat="server" DataSourceID="ods1"  DataKeyNames="ID"  DefaultMode="Edit" Width="100%" >
                <EditItemTemplate>
                    <table class="iEditForm iWelcome">
                        <tr class="name odd">
                            <th>
                                标题设置：</th>
                            <td >
                                <asp:TextBox ID="txtTitle" runat="server" Text='<%#Bind("TitleExt") %>' MaxLength="100"
                                     errmsg="标题最多100个字符。" TextMode="MultiLine" Height="69px" Width="398px" max="100" datatype="len" CssClass="text"></asp:TextBox>最多不超过100个汉字。</td>
                        </tr>
                        <tr class="keyword">
                            <th>
                                关键字设置：</th>
                            <td  >
                                <asp:TextBox ID="txtKey" runat="server" Text='<%#Bind("KeywordExt") %>' MaxLength="100"
                                   errmsg="关键字最多100个字符。" TextMode="MultiLine" Height="71px" Width="399px" max="100" datatype="len" CssClass="text"></asp:TextBox>最多不超过100个汉字。</td>
                        </tr>
                        <tr class="name odd">
                            <th >
                                描述设置：</th>
                            <td >
                                <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" MaxLength="150" errmsg="描述最多150个字符" datatype="len" max="150" Text='<%#Bind("DescriptionExt") %>' Height="85px" Width="399px" CssClass="text"></asp:TextBox>最多不超过150个汉字。</td>
                        </tr>
                    </table>
                    <div class="iSubmit">
                        <asp:Button ID="btnUpdate" runat="server" Text="提交保存"  CommandName="Update" CssClass="submit" />
                    </div>
                </EditItemTemplate>
            </asp:FormView>
           
        </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <asp:ObjectDataSource ID="ods1" runat="server" DataObjectTypeName="Common.Common.Shop" SelectMethod="GetShopInfo" TypeName="Common.Agent.ShopAgent" UpdateMethod="SeoEdit" OnSelecting="ods1_Selecting" OnUpdated="ods1_Updated"  >
        <SelectParameters>
            <asp:Parameter Name="shopid" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

