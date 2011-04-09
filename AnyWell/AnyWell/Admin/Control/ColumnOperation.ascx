<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ColumnOperation.ascx.cs"
    Inherits="Admin_Control_ColumnOperation" %>
<div class="operation">
    <h3 class="opr-mhd">
        <a href="javascript:showFolder('folder1')">
            <img src="../images/icons/arrow2.gif"></a>栏目操作任务</h3>
    <div class="opr-mbd">
        <ul id="oprList">
            <li class="perFile" name="ColumnUpdate"><a href="javascript:parent.editColumn(<%=QS("cid") %>)">修改栏目</a></li>
            <li class="new" name="ColumnAdd"><a href="javascript:parent.addColumn(<%=QS("cid") %>);">新建栏目</a></li>
            <li class="copyFile" name="ColumnCopy"><a href="javascript:parent.CopyColumn(<%=QS("cid") %>)">复制栏目到</a></li>
            <li class="moveFile" name="ColumnMove"><a href="javascript:parent.MoveColumn(<%=QS("cid") %>)">移动栏目到</a></li>
            <li class="delFile" name="ColumnDelete"><a href="javascript:parent.del()">删除栏目</a></li>
        </ul>
    </div>
</div>
