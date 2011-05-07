<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductFooter.ascx.cs" Inherits="Admin_Control_ProductFooter" %>
<div class="guaid">
    <div>
        <ul>
            <li id="Product" class="selected"><a href="../Product/ProductList.aspx?cid=<%=QS("cid") %>">产品</a></li>
            <li id="Column"><a href="../Column/ColumnList.aspx?cid=<%=QS("cid") %>">栏目</a></li>
            <li id="Search"><a href="../Product/ProductSearch.aspx?cid=<%=QS("cid") %>">搜索</a></li>
            <li id="Recycle"><a href="../Product/ProductRecycleList.aspx?cid=<%=QS("cid") %>">回收站</a></li>
        </ul>
    </div>
</div>