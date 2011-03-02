<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="GoodsAdd.aspx.cs" Inherits="Admin_GoodsAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">

    <script type="text/javascript" src="/Admin/js/ajaxfileupload.js"></script>

    <script type="text/javascript">
        function uploadPictures() {
            $.ajaxFileUpload(
                   {
                       url: "GoodsPictureUpload.aspx",            //需要链接到服务器地址
                       secureuri: false,
                       fileElementId: "<%=fileImage.ClientID%>",                        //文件选择框的id属性
                       dataType: 'script',                                     //服务器返回的格式，可以是json
                       success: function(data, status)            //相当于java中try语句块的用法
                       {
                           var r = data.toString();
                           var msg = r.substring(2);
                           if (r.substr(0, 1) == "0") {
                               if ($("#images ul li").length == 1) {
                                   $("#images_demo ul li:last").clone().insertAfter("#images ul li:last");
                                   $("#listimg").val(msg);
                               }
                               else {
                                   $("#images_demo ul li:first").clone().insertAfter("#images ul li:last");
                               }
                               $("#images ul li:last img").attr("src", msg);
                               $("#images ul li:last input").attr("value", msg);
                               $('#results').html("上传成功");
                               $('#results').css("color", "green");
                           }
                           else {
                               $('#results').html(r.substring(2));
                               $('#results').css("color", "red");
                           }
                       },
                       error: function(data, status, e)            //相当于java中catch语句块的用法
                       {
                           //$('#results').html('上传失败');
                       }
                   }

               );
        }

        function delPicture(lnk) {
            var url = "GoodsPictureDel.aspx?path=" + $(lnk).parent("li").find("input").val();
            $.get(url, "", function(htm) { });

            $(lnk).parent("li").find("input").attr("disabled", true);
            if ($("#listimg").val() == $(lnk).parent("li").find("input").val())
                $("#listimg").val("");
            $(lnk).parent("li").remove();
        }

        function setListImage(img) {
            $(img).parent("li").parent("ul").find("li").each(function() { $(this).attr("class", "off"); });
            $(img).parent("li").attr("class", "on");
            $("#listimg").val($(img).attr("src"));
        }
    </script>

    <script type="text/javascript">
        function brandChange(v) {
            $("#<%=drpBrand2.ClientID%> option").remove();
            var drp = document.getElementById("<%=drpBrand2.ClientID%>");
            var url = "GoodsBrandGet.aspx?id=" + v;
            $.get(url, "", function(htm) {
                var arr = htm.split(',');
                for (var i = 0; i < arr.length; i++) {
                    if (arr[i].indexOf(":") == -1)
                        continue;
                    var lst = arr[i].split(':');
                    option = new Option(lst[1], lst[0]);
                    drp.options.add(option);
                }
                drp.style.display = drp.options.length > 0 ? "" : "none";
            }
            );
        }
        function cateChange(v) {
            $("#<%=drpCategory2.ClientID%> option").remove();
            var drp = document.getElementById("<%=drpCategory2.ClientID%>");
            var url = "GoodsCategoryGet.aspx?id=" + v;
            $.get(url, "", function(htm) {
                var arr = htm.split(',');
                for (var i = 0; i < arr.length; i++) {
                    if (arr[i].indexOf(":") == -1)
                        continue;
                    var lst = arr[i].split(':');
                    option = new Option(lst[1], lst[0]);
                    drp.options.add(option);
                }
                drp.style.display = drp.options.length > 0 ? "" : "none";
                cateChange2($("#<%=drpCategory2.ClientID%>").val());
            });
        }
        function cateChange2(v) {
            var drp = document.getElementById("<%=drpCategory3.ClientID%>");
            if (v) {
                $("#<%=drpCategory3.ClientID%> option").remove();
                var url = "GoodsCategoryGet.aspx?id=" + v;
                $.get(url, "", function(htm) {
                    var arr = htm.split(',');
                    for (var i = 0; i < arr.length; i++) {
                        if (arr[i].indexOf(":") == -1)
                            continue;
                        var lst = arr[i].split(':');
                        option = new Option(lst[1], lst[0]);
                        drp.options.add(option);
                    }
                    drp.style.display = drp.options.length > 0 ? "" : "none";
                }
            );
            } else {
                drp.style.display = "none";
            }
        }
    </script>

    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                添加商品</h3>
        </div>
        <div class="mbd">
            <div class="fi even">
                <label>
                    商品类别：</label>
                <div class="cont">
                    <asp:DropDownList ID="drpCategory" runat="server" DataTextField="fdCateName" DataValueField="fdCateID">
                        <asp:ListItem Value="">请选择</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="drpCategory2" runat="server" DataTextField="fdCateName" DataValueField="fdCateID"
                        Style="display: none;">
                    </asp:DropDownList>
                    <asp:DropDownList ID="drpCategory3" runat="server" DataTextField="fdCateName" DataValueField="fdCateID"
                        Style="display: none;">
                    </asp:DropDownList>
                    <span class="required">*</span>
                    <sw:Validator ID="Validator5" ControlID="drpCategory" ValidateType="Required" ErrorText="请选择商品类别"
                        ErrorMessage="请选择商品类别" runat="server">
                    </sw:Validator>
                </div>
            </div>
            <div class="fi">
                <label>
                    所属品牌：</label>
                <div class="cont">
                    <asp:DropDownList ID="drpBrand" runat="server" DataTextField="fdBranName" DataValueField="fdBranID">
                        <asp:ListItem Value="-1">不属于任何品牌</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="drpBrand2" runat="server" Style="display: none;" DataTextField="fdBranName"
                        DataValueField="fdBranID">
                    </asp:DropDownList>
                    <sw:Validator ID="Validator6" ControlID="drpBrand" ValidateType="Required" ErrorText="请选择所属品牌"
                        ErrorMessage="请选择所属品牌" runat="server">
                    </sw:Validator>
                </div>
            </div>
            <div class="fi even">
                <label>
                    商品名称：</label>
                <div class="cont">
                    <asp:TextBox ID="txtName" MaxLength="50" runat="server" CssClass="text"></asp:TextBox>
                    <span class="required">*</span>
                    <sw:Validator ID="Validator4" ControlID="txtName" ValidateType="Required" ErrorText="商品名称不能为空"
                        ErrorMessage="商品名称不能为空" runat="server">
                    </sw:Validator>
                </div>
            </div>
            <div class="fi">
                <label>
                    商品图片：</label>
                <div class="cont">
                    <asp:FileUpload ID="fileImage" runat="server" CssClass="text" />&nbsp;
                    <button onclick="uploadPictures()" style="height: 20px;" type="button">
                        上传图片</button>
                    <span id="results"></span>
                    <style type="text/css">
                        #images li
                        {
                            float: left;
                            margin-right: 8px;
                            margin-top: 8px;
                            text-align: center;
                            width: 100px;
                            height: 100px;
                            cursor: pointer;
                            border: 1px #ccc solid;
                        }
                        #images li.on
                        {
                            background: url(images/goods_lst_bg.jpg);
                        }
                        #images li img
                        {
                            width: 70px;
                            height: 70px;
                            border: 0px solid #ccc;
                            margin-top: 5px;
                            margin-bottom: 4px;
                        }
                        #images li button
                        {
                            border: 0;
                            background: 0;
                        }
                    </style>
                    <div id="images_demo" style="display: none;">
                        <ul>
                            <li>
                                <img alt="" title="点击设为列表图" onclick="setListImage(this)" src="" /><input type="hidden"
                                    name="pics" value="" />
                                <button onclick="delPicture(this);">
                                    删除</button></li>
                            <li class="on">
                                <img title="点击设为列表图" onclick="setListImage(this)" alt="" src="" /><input type="hidden"
                                    name="pics" value="" />
                                <button onclick="delPicture(this);">
                                    删除</button></li>
                        </ul>
                    </div>
                    <div id="images">
                        <ul>
                            <li style="display: none;"></li>
                        </ul>
                        <input type="hidden" id="listimg" name="listimg" value="" />
                    </div>
                </div>
            </div>
            <div class="fi even" style="display: none;">
                <label>
                    进货价(元)：</label>
                <div class="cont">
                    <asp:TextBox ID="txtStockPrice" MaxLength="20" runat="server" CssClass="text"></asp:TextBox>
                </div>
            </div>
            <div class="fi even">
                <label>
                    市场价(元)：</label>
                <div class="cont">
                    <asp:TextBox ID="txtMarketPrice" MaxLength="20" runat="server" CssClass="text"></asp:TextBox>
                    <span class="required">*</span>
                    <sw:Validator ID="Validator1" ControlID="txtMarketPrice" ValidateType="Required"
                        DataType="Double" ErrorText="商品市场价不能为空" ErrorMessage="商品市场价不能为空" runat="server">
                    </sw:Validator>
                </div>
            </div>
            <div class="fi">
                <label>
                    商城价(元)：</label>
                <div class="cont">
                    <asp:TextBox ID="txtSalePrice" MaxLength="20" runat="server" CssClass="text"></asp:TextBox>
                    <span class="required">*</span>
                    <sw:Validator ID="Validator2" ControlID="txtSalePrice" ValidateType="Required" ErrorText="商品销售价不能为空"
                        ErrorMessage="商品销售价不能为空" runat="server">
                    </sw:Validator>
                </div>
            </div>
            <div class="fi" style="display: none">
                <label>
                    库存数：</label>
                <div class="cont">
                    <asp:TextBox ID="txtStockNum" MaxLength="20" runat="server" CssClass="text">999999</asp:TextBox>
                    <span class="required">*</span>
                    <sw:Validator ID="Validator3" ControlID="txtStockNum" ValidateType="Required" DataType="Integer"
                        ErrorText="库存数不能为空" ErrorMessage="库存数不能为空" runat="server">
                    </sw:Validator>
                </div>
            </div>
            <div class="fi even">
                <label>
                    重量(KG)：</label>
                <asp:TextBox ID="txtWeight" MaxLength="20" runat="server" CssClass="text"></asp:TextBox>
                <sw:Validator ID="Validator7" ControlID="txtWeight" ValidateType="DataType" DataType="Number"
                    ErrorText="重量必须是数字" ErrorMessage="重量必须是数字" runat="server">
                </sw:Validator>
            </div>
            <div class="fi">
                <label>
                    商品介绍：</label>
                <div class="cont editor">
                    <asp:TextBox ID="txtIntro" runat="server" TextMode="MultiLine" CssClass="text" Width="100%"
                        Height="300px"></asp:TextBox>
                </div>
            </div>
            <div class="fi even">
                <label>
                    其他设置：</label>
                <div>
                    <asp:CheckBox ID="boxRecommend" runat="server" Text="推荐商品" CssClass="checkbox" Visible="false" />
                    <asp:CheckBox ID="boxHomeJinbao" runat="server" CssClass="checkbox" Text="劲爆推荐" />
                    <asp:CheckBox ID="boxHomeMeijiu" runat="server" CssClass="checkbox" Text="美酒推荐" />
                    <asp:CheckBox ID="boxHomeMingpai" runat="server" CssClass="checkbox" Text="名牌推荐" />
                    <asp:CheckBox ID="boxPromotion" runat="server" Text="促销商品" CssClass="checkbox" />
                </div>
            </div>
            <div class="fi">
                <label>
                    促销时间：</label>
                <div>
                    从<asp:TextBox ID="txtPromStartAt" MaxLength="20" runat="server" CssClass="text" Width="80px"></asp:TextBox>
                    到<asp:TextBox ID="txtPromEndAt" MaxLength="20" runat="server" CssClass="text" Width="80px"></asp:TextBox>
                </div>
            </div>
            <div class="fi even">
                <label>
                    促销价(元)：</label>
                <asp:TextBox ID="txtPromPrice" MaxLength="20" runat="server" CssClass="text"></asp:TextBox>
            </div>
            <div class="fi">
                <label>
                    积分：</label>
                <asp:TextBox ID="txtPoint" MaxLength="20" Text="0" runat="server" CssClass="text"></asp:TextBox>
            </div>
            <div class="fi even">
                <label>
                    商品状态：</label>
                <div class="cont">
                    <asp:RadioButtonList ID="radioStatus" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1" Selected="True">正常</asp:ListItem>
                        <asp:ListItem Value="2">下架</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnContine" runat="server" Text="保存继续" CssClass="submit" OnClick="btnContine_Click">
                </asp:Button>
                <asp:Button ID="btnOk" runat="server" Text="保存返回" OnClick="btnOk_Click" CssClass="">
                </asp:Button>
                <a href="goodslist.aspx">返回列表</a>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>图片应小于500k，jpg或gif格式。建议为<%=AnyWell.Configs.GeneralConfigs.GetConfig().GoodsImageWidth%>x<%=AnyWell.Configs.GeneralConfigs.GetConfig().GoodsImageHeight%>像素。</li>
            <li>一个商品可上传多张展示图片，并设置某一张图片为商品列表图片，在没有设置列表图的情况下，系统默认使用第一张图片。</li>
            <li>状态为“下架”的商品不会在商城前台显示。</li>
            <li>库存数量为“0”的商品买家不能提交到购物车。</li>
            <li>如商品为促销商品，必须设置商品的促销价和促销起始时间。</li>
            <li>可上传多个商品图片，建议不多于4个。打勾的图片为商品列表图片，可点击图片进行更换。</li>
        </ul>
    </div>

    <script type="text/javascript" src="../tiny_mce/tiny_mce.js"></script>

    <script type="text/javascript">
        tinyMCE.init({
            mode: "exact",
            elements: "<%=txtIntro.ClientID%>",
            theme: "advanced",
            language: "zh",
            plugins: "safari,pagebreak,style,layer,table,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,profile,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,pageseparator,iboximage",
            content_css: "/tiny_mce/css/content.css",
            template_external_list_url: "/tiny_mce/lists/template_list.js",
            external_link_list_url: "/tiny_mce/lists/link_list.js",
            external_image_list_url: "/tiny_mce/lists/image_list.js",
            media_external_list_url: "/tiny_mce/lists/media_list.js",
            template_replace_values: {
                username: "Some User",
                staffid: "991234"
            }
        });
    </script>

</asp:Content>
