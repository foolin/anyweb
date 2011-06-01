<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ExhibitorOperation.ascx.cs" Inherits="Admin_Control_ExhibitorOperation" %>
<div class="operation"id="ExhibitorOpr">
    <h3 class="opr-mhd">
        <a href="javascript:showFolder('ExhibitorOpr')">
            <img src="../images/icons/arrow2.gif" /></a>文档操作任务</h3>
    <div class="opr-mbd">
        <ul>
            <li class="new"><a href="ExhibitorAdd.aspx?cid=<%=CurrentColumn.fdColuID %>" target="exhibitor">新建展商</a></li>
            <li class="recFile"><a href="javascript:recycleExhibitor()">放入回收站</a></li>
        </ul>
    </div>
</div>