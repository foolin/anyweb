<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Master/CenterPopup.master" AutoEventWireup="true" CodeFile="ProductMove.aspx.cs" Inherits="Admin_Product_ProductMove" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script type="text/javascript">
        var sites = new Array(), treetype = "radiobox", type = "<%=(AnyWell.AW_DL.ColumnType)type %>";
        $(function() {
            getPopupSites();
            $("form").submit(function() {
                if (checkTreeForm()) {
                    disableButton();
                } else {
                    return false;
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" Runat="Server">
    请选择产品移动的目标栏目：
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
        <button id="Saving" type="button" style="display:none;" disabled="disabled">正在保存</button>
        <button id="btnStart" type="submit">
            确定</button>
        <button type="button" onclick="parent.disablePopup()">
            取消</button>
    </div>
</asp:Content>

