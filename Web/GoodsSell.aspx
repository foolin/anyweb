<%@ Page Title="" Language="C#" MasterPageFile="~/Inner.master" AutoEventWireup="true"
    CodeFile="GoodsSell.aspx.cs" Inherits="GoodsSell" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="ConBox detailTopBg column">
        <div class="DetTop">
            <h1>
                商品销售
            </h1>
            <p class="subMark">
                [ 字体：<a href="javascript:void(0);" onclick="changeFontSize(this,'f14');">大</a> <a
                    href="javascript:void(0);" onclick="changeFontSize(this,'f13');">中</a> <a href="javascript:void(0);"
                        onclick="changeFontSize(this,'f12');" class="cur">小</a> ] [ <a href="javascript:window.print();">
                            打印</a> ] [ <a href="javascript:window.close();">关闭</a> ]
            </p>
        </div>
        <div class="DetCon" id="ConDetail">
            <p>
                我社充分发挥供销社渠道广，经销优质商品的优势，秉承“信誉立足、品质取胜、用心服务、创新致远”的宗旨，不断开拓商品经营模式、完善配送服务，竭诚为客户服务。</p>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function() { selMenu("SPXS"); });
    </script>
</asp:Content>
