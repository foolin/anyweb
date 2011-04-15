<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ColumnOperation.ascx.cs"
    Inherits="Admin_Control_ColumnOperation" %>
<div class="operation" id="ColumnOpr">
    <h3 class="opr-mhd">
        <a href="javascript:showFolder('ColumnOpr')">
            <img src="../images/icons/arrow2.gif" /></a>栏目操作任务</h3>
    <div class="opr-mbd">
        <ul>
            <li class="new"><a href="javascript:parent.addColumn(<%=CurrentColumn.fdColuID %>);">新建栏目</a></li>
            <li class="delFile"><a href="javascript:delColumns()">删除栏目</a></li>
        </ul>
    </div>
</div>
