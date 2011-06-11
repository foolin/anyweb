<%@ Page Language="C#" MasterPageFile="~/Admin/Master/CenterPopup.master" 
AutoEventWireup="true" CodeFile="SubscribeExport.aspx.cs" Inherits="Admin_Plugins_Subscribe_SubscribeExport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" Runat="Server">
    正在导出订阅
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="popmbd">
        数据下载中，请稍候...
    </div>
    <script type="text/javascript">
        $(function() {
            $.get("/Admin/Ajax/SubscribeExport.aspx?sid=<%=QS("sid") %>",function(result){
                if(result.substr(0,6)=='error:'){
                    parent.showError("系统提示信息",result.substr(6),485,223);
                }else{
                    parent.exportSubscribeOK(result);
                }
            });
        });
    </script>
</asp:Content>
