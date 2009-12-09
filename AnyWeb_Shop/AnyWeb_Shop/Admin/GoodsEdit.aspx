<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="GoodsEdit.aspx.cs" Inherits="GoodsEdit" Title="商品管理" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <li>商品的描述建议控制在10000字之内。</li>
    <li>商品图片文件不得超过2M,且必须是gif或jpg格式。</li>
    <li>“积分”为你设置顾客购买该商品后，所获得的积分奖励，用于之后的优惠活动的依据。</li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    <asp:Literal ID="litTitle" runat="server"></asp:Literal></h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="Form1" method="post" runat="server" enctype="multipart/form-data">
                    <!--表单部分[[-->
                    <!--最后用label标签里的for属性和input里的id相对应-->
                    <asp:FormView ID="fv1" runat="server" DataKeyNames="ID" Width="100%" DataSourceID="ods3" OnDataBound="fv1_DataBound">
                        <ItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                                <tr>
                                    <th style="width: 110px;">
                                        商品名称：</th>
                                    <td colspan="2">
                                        <%#Eval("GoodsName") %>
                                        <img src="images/recommend.gif" style='display: <%#(bool)Eval( "IsRecommend" ) == true ? "" : "none"%>; margin-left: 10px;' />
                                        <span style="padding-left: 20px;">关注度：<%#Eval("Clicks")%></span> <span style="padding-left: 20px;">热评情况：
                                            <%#(bool)Eval( "Recommend" ) == true ? "" : "不允许评论"%>
                                            <span style="display: <%#(bool)Eval("Recommend")==true? "":"none"%>">共<%#"<span stype='color:red;font-size:14;font-family:Verdana;'>" + Eval( "Comments" )+"</span>"%>条评论</span></span>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        商品型号：
                                    </th>
                                    <td>
                                        <%#Eval( "Model" )%>
                                    </td>
                                    <td rowspan="8" style="text-align: center; width: 226px; background-color: White; border-left: solid 1px gray; border-right: solid 1px gray;">
                                        <img src='<%#(string)Eval("image")=="" ? "/images/wait.jpg":Eval("image").ToString().Replace("S_","")%>' alt="点击查看原图" onload="javascript:if(this.width>200)this.width=200" onclick="window.open(this.src);" style="cursor: hand;" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        市场价格：</th>
                                    <td>
                                        <%#Eval("MarketPrice","{0:c}")%>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        商城优惠价：</th>
                                    <td>
                                        <%#Eval("Price","{0:c}")%>
                                    </td>
                                </tr>
                                <tr style="display:<%#(bool)Eval("IsPromotions")==false?"none":"" %>">
                                    <th>
                                        促销价</th>
                                    <td>
                                        <%#Eval("PromotionsPrice", "{0:c}")%>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        生产产商/产地：
                                    </th>
                                    <td>
                                        <%#Eval("Factory")%>
                                    </td>
                                </tr>
                              
                                <tr>
                                    <th>
                                        所属类别：
                                    </th>
                                    <td>
                                        <%#Eval("OfCategory.Name") %>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        有效时间：
                                    </th>
                                    <td>
                                        <%#Eval("StartTime","{0:yyyy-MM-dd}") %>
                                        至
                                        <%#Eval("EndTime","{0:yyyy-MM-dd}") %>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        状态：
                                    </th>
                                    <td>
                                        <%# CheckStatus((int)Eval( "Status" )  ,(DateTime)Eval( "EndTime" ) )%>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        商品重量：
                                    </th>
                                    <td>
                                        <%#Eval( "Weight" )%>
                                        千克
                                    </td>
                                </tr>
                                  <tr>
                                    <th>
                                        售后服务：
                                    </th>
                                    <td>
                                        <%#Eval("Service")%>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        详细情况：
                                    </th>
                                    <td colspan="2" style="padding-right: 10px; line-height: 23px;">
                                        <%#Eval( "Description" )%>
                                    </td>
                                </tr>
                            </table>
                            <div class="iSubmit">
                                <button id="btnEdit" onclick="window.location='GoodsEdit.aspx?mode=update&gid=<%#Eval("ID")%>';" type="button" class="submit">
                                    编辑该商品</button>
                                <span style="display: <%#(bool)Eval("Recommend")==true? "":"none"%>">
                                    <button id="btnComment" onclick="window.location='CommentList.aspx?tid=2&sid=<%#Eval("ID") %>';" type="button" class="submit">
                                        查看该商品评论</button></span>
                                <asp:Button ID="btnDelete" runat="server" Text="删除该商品" CommandName="Delete" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='GoodsList.aspx';" type="button">
                                    返回商品列表</button>
                            </div>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                                <tr>
                                    <th style="width: 120px;">
                                        商品名称：</th>
                                    <td>
                                        <asp:TextBox ID="txtTitle" runat="server" CssClass="input" errmsg="请输入正确的商品名称" MaxLength="50" require="1" Width="308px" Text='<%#Bind("GoodsName") %>'></asp:TextBox>&nbsp;不超过50个汉字。</td>
                                </tr>
                                <tr class="name">
                                    <th>
                                        商品型号：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtMode" runat="server" Text='<%#Bind("Model")%>' CssClass="input" errmsg="请输入正确的商品型号" MaxLength="50" require="1" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        所属类别：
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpType" runat="server" DataSourceID="ods4" DataValueField="ID" DataTextField="Name">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        生产产商/产地：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtFactory" runat="server" Text='<%#Bind("Factory")%>' CssClass="input" errmsg="请输入生产产商" MaxLength="50" require="1" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        商品重量：
                                    </th>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtWeight" runat="server" CssClass="input" errmsg="请输入正确的商品重量" MaxLength="10" Width="100px" datatype="double"></asp:TextBox>千克
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        商品图片：
                                    </th>
                                    <td>
                                        <div style="margin: 10px 0px;">
                                            <asp:FileUpload ID="txtImage" runat="server" Width="280px" />不更改请留空.</div>
                                        <asp:HiddenField ID="hidimg" runat="server" Value='<%# Bind("Image") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        市场价格：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtMarkPrice" runat="server" Text='<%#Bind("MarketPrice")%>' CssClass="input" errmsg="请输入正确的市场价格" MaxLength="10" require="1" Width="100px" datatype="double"></asp:TextBox>RMB *该商品在市场上的流通价格，给顾客的参考价
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        商城优惠价：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtPrice" runat="server" Text='<%#Bind("Price")%>' CssClass="input" errmsg="请输入正确的商城优惠价" MaxLength="10" require="1" Width="100px" datatype="double"></asp:TextBox>RMB *该商品在本商城的价格
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        是否促销：</th>
                                    <td>
                                        <asp:CheckBox ID="chkPromotions" runat="server" Checked='<%#Bind("IsPromotions") %>' onclick="Promotions()" />促销
                                        <label id="lblPromotions" style="display:none;">价格：<asp:TextBox ID="txtProPrice" runat="server" Width="60" Text='<%#Bind("PromotionsPrice") %>'></asp:TextBox>元</label>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        有效时间：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtData" runat="server" MaxLength="30" Width="135px" onclick="setday(this);" Text='<%#Bind("StartTime") %>' CssClass="input" require="1" errmsg="请输入正确的有效日期"></asp:TextBox>
                                        至&nbsp;<asp:TextBox ID="txtDataEnd" runat="server" MaxLength="30" Width="127px" onclick="setday(this);" Text='<%#Bind("EndTime") %>' CssClass="input" require="1" errmsg="请输入正确的过期时间"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        计量单位：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtUnit" runat="server" CssClass="input" MaxLength="10" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr class="name">
                                    <th>
                                        商品状态：
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpStatus" runat="server">
                                            <asp:ListItem Value="1">有货</asp:ListItem>
                                            <asp:ListItem Value="2">缺货</asp:ListItem>
                                            <asp:ListItem Value="3">过期</asp:ListItem>
                                            <asp:ListItem Value="4">商品不显示在首页</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    </tr>                             
                                <tr>
                                    <th>
                                        售后服务：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtSale" runat="server" Text='<%#Bind("Service")%>' CssClass="input" TextMode="MultiLine" MaxLength="1000" Height="60px" Width="500px"></asp:TextBox>不超过1000个字。
                                    </td>
                                </tr>
                                 <tr>
                                    <th>
                                        其他设置：
                                    </th>
                                    <td>
                                        <asp:CheckBox ID="chkRecomm" runat="server" Checked='<%#Bind("IsRecommend")%>' />是否设置为推荐商品
                                        <asp:CheckBox ID="chkComm" runat="server" Checked='<%#Bind("Recommend")%>' />是否允许评论 【不允许请留空。】
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        商品描述：
                                    </th>
                                    <td>
                                        【请将字数控制在10000字以内。】
                                    </td>
                                </tr>
                                <tr class="edit odd" style="text-align: center;">
                                    <td colspan="2">
                                        <sw:TinyMce ID="txtDesc" runat="server" Height="500px" Text='<%# Bind("Description") %>'/>
                                    </td>
                                </tr>
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text="保存商品" CommandName="Update" CssClass="submit"></asp:Button>
                                <asp:Button ID="btnDelete" runat="server" Text="删除该商品" CommandName="Delete" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='GoodsList.aspx';">
                                    取 消</button>
                            </div>
                            <script type="text/javascript">
                                function Promotions() {
                                    var chk = document.getElementById('<%=fv1.FindControl("chkPromotions").ClientID %>');
                                    if (chk.checked) {
                                        document.getElementById("lblPromotions").style.display = "";
                                    }
                                    else {
                                        document.getElementById("lblPromotions").style.display = "none";
                                    }
                                }

                                Promotions();
                            </script>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <table class="iEditForm iEditBaseInf">
                                <tr>
                                    <th style="width: 120px;">
                                        商品名称：</th>
                                    <td>
                                        <asp:TextBox ID="txtTitle" runat="server" CssClass="input" errmsg="请输入正确的商品名称" MaxLength="50" require="1" Width="308px" Text='<%#Bind("GoodsName") %>'></asp:TextBox>&nbsp;不超过50个汉字。</td>
                                </tr>
                                <tr class="name">
                                    <th>
                                        商品型号：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtMode" runat="server" Text='<%#Bind("Model")%>' CssClass="input" errmsg="请输入正确的商品型号" MaxLength="50" require="1" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        所属类别：
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="drpType" runat="server" DataSourceID="ods4" DataValueField="ID" DataTextField="Name">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        生产产商/产地：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtFactory" runat="server" Text='<%#Bind("Factory")%>' CssClass="input" errmsg="请输入生产产商" MaxLength="50" require="1" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        商品重量：
                                    </th>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtWeight" runat="server" CssClass="input" errmsg="请输入正确的商品重量" MaxLength="10" Width="100px" datatype="double"></asp:TextBox>千克
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        商品图片：
                                    </th>
                                    <td>
                                        <div style="margin: 10px 0px;">
                                            <asp:FileUpload ID="txtImage" runat="server" Width="300px" /></div>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        市场价格：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtMarkPrice" runat="server" Text='<%#Bind("MarketPrice")%>' CssClass="input" errmsg="请输入正确的市场价格" MaxLength="10" require="1" Width="100px" datatype="double"></asp:TextBox>RMB *该商品在市场上的流通价格，给顾客的参考价
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        商城优惠价：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtPrice" runat="server" Text='<%#Bind("Price")%>' CssClass="input" errmsg="请输入正确的商城优惠价" MaxLength="10" require="1" Width="100px" datatype="double"></asp:TextBox>RMB *该商品在本商城的价格
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        是否促销：</th>
                                    <td>
                                        <asp:CheckBox ID="chkPromotions" runat="server" Checked='<%#Bind("IsPromotions") %>' onclick="Promotions()" />促销
                                        <label id="lblPromotions" style="display:none;">价格：<asp:TextBox ID="txtProPrice" runat="server" Width="60" Text='<%#Bind("PromotionsPrice") %>'></asp:TextBox>元</label>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        有效时间：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtData" runat="server" MaxLength="30" Width="135px" onclick="setday(this);" Text='<%#Bind("StartTime") %>' CssClass="input" require="1" errmsg="请输入正确的有效日期"></asp:TextBox>
                                        至&nbsp;<asp:TextBox ID="txtDataEnd" runat="server" MaxLength="30" Width="127px" onclick="setday(this);" Text='<%#Bind("EndTime") %>' CssClass="input" require="1" errmsg="请输入正确的过期时间"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        计量单位：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtUnit" runat="server" CssClass="input" MaxLength="10" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <th>设置：</th>
                                    <td>
                                         <asp:CheckBox ID="chkRecomm" runat="server" Checked='<%#Bind("IsRecommend")%>' />设置为推荐商品                                         <asp:CheckBox ID="chkComm" runat="server" Checked='<%#Bind("Recommend")%>' />是否允许评论 【不允许请留空。】
                                    </td>
                                </tr>
                                 <tr>
                                    <th>
                                        售后服务：
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtSale" runat="server" Text='<%#Bind("Service")%>' CssClass="input" TextMode="MultiLine" MaxLength="1000" Width="500px" Height="60px"></asp:TextBox>不超过1000个字。
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        商品描述：
                                    </th>
                                    <td>
                                        【请将字数控制在10000字以内。】
                                    </td>
                                </tr>
                                <tr class="edit odd" style="text-align: center;">
                                    <td colspan="2">
                                        <sw:TinyMce ID="txtContent" runat="server" Height="500px" Text='<%# Bind("Description") %>' />
                                    </td>
                                </tr>
                               
                            </table>
                            <div class="iSubmit">
                                <asp:Button ID="btnSave" runat="server" Text=" 保存商品" CommandName="Insert" CssClass="submit"></asp:Button>
                                <button id="btnBack" onclick="window.location='GoodsList.aspx';" type="button">
                                    取 消</button>
                            </div>
                            <script type="text/javascript">
                                function Promotions() {
                                    var chk = document.getElementById('<%=fv1.FindControl("chkPromotions").ClientID %>');
                                    if (chk.checked) {
                                        document.getElementById("lblPromotions").style.display = "";
                                    }
                                    else {
                                        document.getElementById("lblPromotions").style.display = "none";
                                    }
                                }

                                Promotions();
                            </script>
                        </InsertItemTemplate>
                    </asp:FormView>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>

    <script type="text/javascript">
        function showDesc() {
            document.getElementById("divDesc").style.display = document.getElementById("_ctl0_cph1_fv1_chkAutoDesc").checked ? 'none' : 'block';

        }
    </script>

    <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetGoodsByID" TypeName="Common.Agent.GoodsAgent" OnSelecting="ods3_Selecting" OnInserted="ods3_Inserted" OnInserting="ods3_Inserting" OnUpdated="ods3_Updated" OnUpdating="ods3_Updating" DataObjectTypeName="Common.Common.Goods" InsertMethod="AddGoods" UpdateMethod="UpdateGoods" DeleteMethod="GoodsDeletes" OnDeleted="ods3_Deleted">
        <SelectParameters>
            <asp:Parameter Name="gid" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ods4" runat="server" SelectMethod="GetCategoryNameByType" TypeName="Common.Agent.CategoryAgent"></asp:ObjectDataSource>
</asp:Content>
