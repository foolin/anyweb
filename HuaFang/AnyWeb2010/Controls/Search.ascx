<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search.ascx.cs" Inherits="Controls_Search" %>
<div class="search">
    <ul class="search-tab" id="stype">
        <span class="hover" value="1">资讯</span>|<span value="4">品牌</span>|<span value="5">名人</span>|<span
            value="2">刊物</span>|<span value="3">招聘</span>
    </ul>
    <div class="search-form cs-clear">
        <form id="formSearch">
        <p>
            <input class="ipt-simple" type="text" maxlength="100" id="skey" value="<%=Request.QueryString["k"]+"" %>" /></p>
        <p>
            <button class="btn-simple" type="submit">
                搜索</button></p>
        </form>
    </div>
</div>

<script type="text/javascript">
    function setSearchType() { 
        var t = "<%=Request.QueryString["t"]+"" %>";
        if(t){
            $("#stype span").removeClass("hover");
            $("#stype span[value='"+t+"']").addClass("hover");
        }
    }
    $(function() {
        $("#stype span").click(function() {
            $("#stype span").removeClass("hover");
            $(this).addClass("hover");
        });
        $("#formSearch").submit(function() {
            if ($.trim($("#skey").val()).length == 0) {
                alert("请输入搜索关键词！");
                return false;
            }
            var url = "";
            switch ($("#stype span[class='hover']").attr("value")) {
                case "1":
                    url = "/ArticleSearch.aspx?t=1";
                    break;
                case "4":
                    url = "/ls/2.aspx?t=4";
                    break;
                case "5":
                    url = "/ls/1.aspx?t=5";
                    break;
            }
            url += "&k=" + decodeURI($("#skey").val());
            window.location = url;
            return false;
        })
        setSearchType();
    });
</script>

