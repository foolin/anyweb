﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleContent.ascx.cs"
    Inherits="Controls_ArticleContent" %>
<div class="article">
    <h3 class="art-title">
        <asp:Literal ID="litTitle" runat="server"></asp:Literal>
    </h3>
    <div class="art-info">
        点击次数：<asp:Literal ID="litClick" runat="server"></asp:Literal>
        时间：<asp:Literal ID="litCreateAt" runat="server"></asp:Literal>
        [字体：<a href="javascript:fontZoomMax()">大</a><a href="javascript:fontZoomMid()">中</a><a href="javascript:fontZoomMin()">小</a>] &nbsp;[<a href="javascript:window.print()">打印</a>] &nbsp;[<a href="javascript:window.close()">关闭</a>]
    </div>
    <!-- art-info end -->
    <div class="art-content" id="art-content">
        <asp:Literal ID="litContent" runat="server"></asp:Literal>
    </div>
    <!-- art-content end -->
</div>
<!-- article end -->
