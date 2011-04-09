<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ColumnFooter.ascx.cs"
    Inherits="Admin_Control_ColumnFooter" %>
<div class="guaid">
    <div>
        <ul>
            <li><a href="ArticleMain.aspx?cid=<%=QS("cid") %>">文档</a></li>
            <li class="selected"><a href="ColumnList.aspx?cid=<%=QS("cid") %>">栏目</a></li>
            <li><a href="ArticleSearch.aspx?cid=<%=QS("cid") %>">搜索</a></li>
            <li><a href="ArticleRecycle.aspx?cid=<%=QS("cid") %>">回收站</a></li>
        </ul>
    </div>
</div>
