<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SingleArticleFooter.ascx.cs" Inherits="Admin_Control_SingleArticleFooter" %>
<div class="guaid">
    <div>
        <ul>
            <li id="Article" class="selected"><a href="../Content/SingleArticle.aspx?cid=<%=QS("cid") %>">文档</a></li>
            <li id="Column"><a href="../Column/ColumnList.aspx?cid=<%=QS("cid") %>">栏目</a></li>
        </ul>
    </div>
</div>