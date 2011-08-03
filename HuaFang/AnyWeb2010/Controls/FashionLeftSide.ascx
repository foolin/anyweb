<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FashionLeftSide.ascx.cs"
    Inherits="Controls_FashionLeftSide" %>
<div class="title-bar">
    <h2 class="cs-clear">
        <p class="title-ch cs-fl">
            <span>秀场追击</span></p>
    </h2>
</div>
<div class="ShowNav ShowNav_season" style="display: none;" id="condition">
    <h3>
        <strong>检索条件</strong></h3>
    <div class="Show_term">
        <p>
            <span id="condition_col"></span><span id="condition_cate"></span><span id="condition_city">
            </span>
        </p>
    </div>
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
                        <span><a id="col_<%#Eval("fdColuID") %>" href="javascript:setCol(<%#Eval("fdColuID") %>);">
                            <%#Eval("fdColuName") %></a></span>
                        <%#Container.ItemIndex % 2 == 1 || Container.ItemIndex == coluCount - 1 ? "</li>" : ""%>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <a id="col_0" href="javascript:setCol(0);" class="ShowNav-all on">全部</a>
</div>
<div class="ShowNav">
    <h3>
        <strong>产品类别</strong></h3>
    <div class="">
        <p>
            <span><a id="cate_1" href="javascript:setCate(1);">男装</a></span><span><a id="cate_2"
                href="javascript:setCate(2);">高级成衣</a></span><span><a id="cate_3" href="javascript:setCate(3);">高级定制</a></span><span><a
                    id="cate_0" href="javascript:setCate(0);" class="ShowNav-all on">全部</a></span></p>
    </div>
</div>
<div class="ShowNav">
    <h3>
        <strong>城市列表</strong></h3>
    <div class="">
        <p>
            <span><a id="city_1" href="javascript:setCity(1);">巴黎</a></span><span><a id="city_2"
                href="javascript:setCity(2);">米兰</a></span><span><a id="city_3" href="javascript:setCity(3);">伦敦</a></span><span><a
                    id="city_4" href="javascript:setCity(4);">纽约</a></span><span><a id="city_5" href="javascript:setCity(5);">其他</a></span><span><a
                        id="city_0" href="javascript:setCity(0);" class="ShowNav-all on">全部</a></span></p>
    </div>
</div>
<div class="ShowNav">
    <h3>
        <strong>设计师/品牌</strong></h3>
    <div class="ShowNav-btn cs-clear">
        <a class="btn-simple" href="javascript:search();">搜索</a></div>
    <div class="ShowNav-search">
        <input type="text" class="ipt-simple" id="txtKey" onkeyup="regex(this.value);" />
        <div class="ShowNav-list" id="searchList">
            <a href="javascript:void(0);">请选择季节、产品类别和城市</a>
        </div>
    </div>
</div>
<div class="Side_menu">
    <div class="common_menu">
        <a href="#"><strong>行业招聘</strong></a>
    </div>
    <div class="common_menu cs-nobor">
        <a href="#"><strong>行业人才</strong></a>
    </div>
</div>

<script type="text/javascript">
    var col = 0, cate = 0, city = 0;
    var articles;
    function article(id, name) {
        this.id = id;
        this.name = name;
        this.href = "/f/" + this.id + ".aspx";
    }
    function setCol(num) {
        col = num;
        $(".ShowNav a[id^='col_']").each(function() {
            if ($(this).attr("id") == "col_" + num) {
                $(this).addClass("on");
            } else {
                $(this).removeClass("on");
            }
        });
        if (num == 0) {
            $("#condition_col").html("");
        } else {
            $("#condition_col").html("<a href=\"javascript:delCol();\">" + $("#col_" + num).html() + "</a>");
        }
        setCondition();
    }
    function setCate(num) {
        cate = num;
        $(".ShowNav a[id^='cate_']").each(function() {
            if ($(this).attr("id") == "cate_" + num) {
                $(this).addClass("on");
            } else {
                $(this).removeClass("on");
            }
        });
        if (num == 0) {
            $("#condition_cate").html("");
        } else {
            $("#condition_cate").html("<a href=\"javascript:delCate();\">" + $("#cate_" + num).html() + "</a>");
        }
        setCondition();
    }
    function setCity(num) {
        city = num;
        $(".ShowNav a[id^='city_']").each(function() {
            if ($(this).attr("id") == "city_" + num) {
                $(this).addClass("on");
            } else {
                $(this).removeClass("on");
            }
        });
        if (num == 0) {
            $("#condition_city").html("");
        } else {
            $("#condition_city").html("<a href=\"javascript:delCity();\">" + $("#city_" + num).html() + "</a>");
        }
        setCondition();
    }
    function setCondition() {
        if (col == 0 && cate == 0 && city == 0) {
            $("#condition").hide();
            $("#condition").next().addClass("ShowNav_season");
        } else {
            $("#condition").show();
            $("#condition").next().removeClass("ShowNav_season");
        }

        if (col == 0 || cate == 0 || city == 0) {
            $("#searchList").html("<a href=\"javascript:void(0);\">请选择季节、产品类别和城市</a>");
        } else {
            articles = new Array();
            $("#txtKey").val("");
            $.ajax({
                url: "/GetFashionArticles.aspx?col=" + col + "&cate=" + cate + "&city=" + city,
                cache: false,
                success: function(result) {
                    articles = new Array();
                    if ($.trim(result).length > 0) {
                        eval(result);
                    }
                    $("#searchList").html("");
                    for (var i = 0; i < articles.length; i++) {
                        $("#searchList").append("<a href=\"" + articles[i].href + "\" target=\"_blank\">" + articles[i].name + "</a>");
                    }
                }
            });
        }
    }
    function delCol() {
        $("#condition_col").html("");
        setCol(0);
        setCondition();
    }
    function delCate() {
        $("#condition_cate").html("");
        setCate(0);
        setCondition();
    }
    function delCity() {
        $("#condition_city").html("");
        setCity(0);
        setCondition();
    }
    function search(){
        var url="/Fashion.aspx?col="+col+"&cate="+cate+"&city="+city;
        window.location=url;
    }
    function regex(value){
        if(col>0&&cate>0&&city>0){
            $("#searchList").html("");
            for(var i=0;i<articles.length;i++){
                if(articles[i].name.toLowerCase().indexOf(value.toLowerCase())>-1){
                    $("#searchList").append("<a href=\"" + articles[i].href + "\" target=\"_blank\">" + articles[i].name + "</a>");
                }
            }
        }
    }
    $(function(){
        setCol(<%=col %>);
        setCate(<%=cate %>);
        setCity(<%=city %>);
    });
</script>

