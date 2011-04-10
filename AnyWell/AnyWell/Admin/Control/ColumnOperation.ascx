<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ColumnOperation.ascx.cs"
    Inherits="Admin_Control_ColumnOperation" %>
<div class="operation">
    <h3 class="opr-mhd">
        <a href="javascript:showFolder('folder1')">
            <img src="../images/icons/arrow2.gif" /></a>栏目操作任务</h3>
    <div class="opr-mbd">
        <ul>
            <li class="new"><a href="ArticleAdd.aspx?cid=<%=CurrentColumn.fdColuID %>" target="article">新建文档</a></li>
            <li class="new"><a href="javascript:parent.addColumn(<%=CurrentColumn.fdColuID %>);">新建栏目</a></li>
            <li class="perFile"><a href="javascript:parent.editColumn(<%=CurrentColumn.fdColuID %>)">修改栏目</a></li>
            <li class="copyFile"><a href="javascript:parent.CopyColumn(<%=CurrentColumn.fdColuID %>)">复制栏目到</a></li>
            <li class="moveFile"><a href="javascript:parent.MoveColumn(<%=CurrentColumn.fdColuID %>)">移动栏目到</a></li>
            <li class="delFile"><a href="javascript:parent.del()">删除栏目</a></li>
        </ul>
    </div>
</div>
