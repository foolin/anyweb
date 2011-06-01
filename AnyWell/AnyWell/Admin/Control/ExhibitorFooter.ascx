<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ExhibitorFooter.ascx.cs" Inherits="Admin_Control_ExhibitorFooter" %>
<div class="guaid">
    <div>
        <ul>
            <li id="Exhibitor" class="selected"><a href="../Exhibitor/ExhibitorList.aspx?cid=<%=QS("cid") %>">展商</a></li>
            <li id="Column"><a href="../Column/ColumnList.aspx?cid=<%=QS("cid") %>">栏目</a></li>
            <li id="Recycle"><a href="../Exhibitor/ExhibitorRecycleList.aspx?cid=<%=QS("cid") %>">回收站</a></li>
        </ul>
    </div>
</div>