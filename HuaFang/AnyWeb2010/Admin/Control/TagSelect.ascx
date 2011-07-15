<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TagSelect.ascx.cs" Inherits="Admin_Control_TagSelect" %>
<div class="choArea" id="ChooseTag">
    <div class="top">
        <i class="iTit">请选择标签</i> <span class="topRight white">[<a href="javascript:void(0);"
            onclick="CloseWindow('ChooseTag')">关闭</a>] </span>
    </div>
    <div class="con gray">
        <dl>
            <dt>标签设置：</dt>
            <dd style="width: 300px;">
                <input id="txtTag" style="width: 200px" />
                <input type="button" value="确定" onclick="SetTags()" />
            </dd>
        </dl>
        <dl id="topTag">
            <dt>常用标签：</dt>
            <dd style="width: 100%">
                正在加载，请稍候。。。</dd>
        </dl>
        <dl>
            <dt>标签查找：</dt>
            <dd style="width: 100%">
                <input type="text" id="txtKey" style="width: 100px" />
                <select id="drpType">
                    <option value="0">按标签排序</option>
                    <option value="1">按标签倒序</option>
                    <option value="2">按时间排序</option>
                    <option value="3">按时间倒序</option>
                </select>
                <input type="button" id="btnSearch" value="查找" onclick="SearchTag(1);" />
            </dd>
        </dl>
        <div id="tagList">
            正在加载，请稍候。。。
        </div>
        <span class="blank5px"></span>
    </div>
    <div class="btm">
    </div>

    <script type="text/javascript">
        $(document).ready(function() {
            GetTopTag();
            SearchTag(1);
        });

        function GetTopTag() {
            $("#topTag dd").remove();
            $.ajax({
                type: "GET",
                url: "/Admin/Setting/TagTopGet.aspx",
                cache: false,
                success: function(data) {
                    if ($.trim(data).length > 0) {
                        $("#topTag").append(data);
                    } else {
                    $("#topTag").append("<dd style=\"width:100%\">常用标签不存在，请点击【<a href=\"javascript:GetTopTag();\" style=\"display:inline;\">刷新</a>】重试。。。</dd>");
                    }
                },
                error: function() {
                $("#topTag").append("<dd style=\"width:100%\">加载失败，请点击【<a href=\"javascript:GetTopTag();\" style=\"display:inline;\">刷新</a>】重试。。。</dd>");
                }
            });
        }

        function SearchTag(page) {
            $("#btnSearch").val("正在查找").attr("disabled", "disabled");
            var url = "/Admin/Setting/TagSearch.aspx?key=" + $("#txtKey").val() + "&type=" + $("#drpType").val() + "&pid1=" + page;
            $.ajax({
                type: "GET",
                url: url,
                cache: false,
                success: function(data) {
                    if ($.trim(data).length > 0) {
                        $("#tagList").html(data);
                    } else {
                        $("#tagList").html("标签不存在。。。");
                    }
                },
                error: function() {
                    $("#tagList").html("加载失败，请点击【<a href=\"javascript:SearchTag(" + page + ");\">刷新</a>】重试。。。");
                },
                complete: function() {
                    $("#btnSearch").val("查找").removeAttr("disabled");
                }
            });
        }
    </script>

</div>
