<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ExhibitorRecycleOperation.ascx.cs" Inherits="Admin_Control_ExhibitorRecycleOperation" %>
<div class="operation"id="RecycleOpr">
    <h3 class="opr-mhd">
        <a href="javascript:showFolder('RecycleOpr')">
            <img src="../images/icons/arrow2.gif" /></a>展商操作任务</h3>
    <div class="opr-mbd">
        <ul>
            <li class="revFile"><a href="javascript:revokeExhibitor()">恢复展商</a></li>
            <li class="recFile"><a href="javascript:deleteExhibitor()">彻底删除展商</a></li>
            <li class="delFile"><a href="javascript:clearExhibitorRecycle(<%=CurrentColumn.fdColuID %>,<%=QS("getch")=="1"?"true":"false" %>)">
                清空回收站</a></li>
        </ul>
    </div>
</div>