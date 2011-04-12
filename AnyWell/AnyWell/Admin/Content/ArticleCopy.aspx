<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/CenterPopup.master" AutoEventWireup="true" CodeFile="ArticleCopy.aspx.cs" Inherits="Admin_Content_ArticleCopy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script type="text/javascript">
        var sites = new Array(), treetype = "checkbox", type = "<%=(AnyWell.AW_DL.ColumnType)type %>";
        $(function() {
            getPopupSites();
            $("form").submit(function() {
                return checkTreeForm();
            })
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" Runat="Server">
    请选择文档复制的目标栏目：
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="optionhead">
    </div>
    <div class="popmbd">
        <div class="tree">
            <table id="treemenu">
                <tbody>
                </tbody>
            </table>
        </div>
    </div>
    <div class="popmft">
        <button id="btnStart" type="submit">
            确定</button>
        <button type="button" onclick="parent.disablePopup()">
            取消</button>
    </div>
</asp:Content>

