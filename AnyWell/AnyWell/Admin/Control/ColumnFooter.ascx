﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ColumnFooter.ascx.cs"
    Inherits="Admin_Control_ColumnFooter" %>
<div class="guaid">
    <div>
        <ul>
            <li id="Article" class="selected"><a href="ArticleList.aspx?cid=<%=QS("cid") %>">文档</a></li>
            <li id="Column"><a href="ColumnList.aspx?cid=<%=QS("cid") %>">栏目</a></li>
            <li id="Search"><a href="ArticleSearch.aspx?cid=<%=QS("cid") %>">搜索</a></li>
            <li id="Recycle"><a href="ArticleRecycleList.aspx?cid=<%=QS("cid") %>">回收站</a></li>
        </ul>
    </div>
</div>
