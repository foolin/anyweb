<%@ Page Title="" Language="C#" MasterPageFile="~/Inner.master" AutoEventWireup="true"
    CodeFile="Department.aspx.cs" Inherits="Department" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="ConBox detailTopBg column">
        <div class="DetTop">
            <h1>
                部门架构
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
                广州市天河区沙河供销合作社成立于一九五三年，是广州市天河区供销联社下属的分支机构之一。我社一直致力于为城乡企业、居民服务，诚信守法经营，拥有良好的社会信誉。我社现时的经营业务范围主要有：物业租赁及管理、龙口东市场经营及管理、广州市杰信人力资源有限公司经营及管理、商品经营等。我社的组织架构见下图：</p>
            <p>
                <img src="SiteData/Picture/department.jpg" alt="" />
            </p>
            <p>
                <a href="Company.aspx">详细职能请点击这里>></a>
            </p>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function() { selMenu("SY"); });
    </script>
</asp:Content>
