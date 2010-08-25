<%@ Page Title="" Language="C#" MasterPageFile="~/Inner.master" AutoEventWireup="true"
    CodeFile="LkdMarket.aspx.cs" Inherits="LkdMarket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="ConBox detailTopBg column">
        <div class="DetTop">
            <h1>
                网上菜篮子
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
                龙口东农贸市场位于龙口东路133号，占地面积1700平方米，于二○○一年一月起由我社自主经营。二○○四年九月，在市、区政府和上级领导的大力支持下，投入资金二百万元，完成了升级改造工作。场内有档口<span>70</span>个，场外铺位<span>10</span>个，场内各项设施基本配套齐全，设有六大安全出口，配备食品检验室，软、硬件设备全部按工商、公安、消防、环保等部门的要求，建立健全各项规章制度，以规范管理，提高经营效益。</p>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function() { selMenu("WSCLZ"); });
    </script>
</asp:Content>
