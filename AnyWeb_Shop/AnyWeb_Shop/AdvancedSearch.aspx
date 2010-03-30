<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AdvancedSearch.aspx.cs" Inherits="AdvancedSearch" Title="产品高级搜索" %>

<%@ Register Src="~/Controls/CategoryLeft.ascx" TagName="CategoryLeft" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="col2MainSider">
        <uc:CategoryLeft ID="CategoryLeft" runat="server" />
    </div>
    <div class="col2MainContent">
        <form id="advancedSearchForm" action="Search.aspx" method="get" onsubmit="return chkSearch();">
        <table class="mainContainer">
            <tr>
                <th colspan="2" class="title">
                    高级搜索
                </th>
            </tr>
            <tr class="subTitle">
                <td>
                    &nbsp;
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="tdColorR">
                    关键词
                </td>
                <td>
                    <input type="text" id="keywords" name="keywords" class="searchInput" onclick="if(this.value=='请输入关键词')this.value='';"
                        value="请输入关键词" /><span style="color: #F00">*必填</span> 多关键词用空格分开</span>
                </td>
            </tr>
            <tr>
                <td class="tdColorR">
                    分类
                </td>
                <td>
                    <select name="category">
                        <option value="0" selected="selected">全部</option>
                        <asp:Repeater ID="repCate" runat="server">
                            <ItemTemplate>
                                <option value="<%#Eval("ID") %>">
                                    <%#Eval("Name")%></option>
                            </ItemTemplate>
                        </asp:Repeater>
                    </select>
                </td>
            </tr>
            <tr>
                <td class="tdColorR">
                    价格范围
                </td>
                <td>
                    <input type="text" class="searchInput" style="width: 40px;" id="lowPrice" name="lowPrice" />~
                    <input type="text" class="searchInput" style="width: 40px;" id="highPrice" name="highPrice" />低价格
                    ~ 高价格（单位：元）
                </td>
            </tr>
            <tr>
                <td class="tdColorR">
                </td>
                <td>
                    <input type="submit" src="Images/advsearch_btn.gif" class="btn" value="高级搜索" />
                </td>
            </tr>
        </table>
        </form>
    </div>
    <div class="clear">
    </div>

    <script type="text/javascript" language="javascript">
        function chkSearch() {
            var form = document.forms["advancedSearchForm"];
            var keywords = form.keywords.value;
            var lowPrice = form.lowPrice.value;
            var highPrice = form.highPrice.value;

            if (keywords == '请输入关键词' || keywords == '') {
                alert('请输入关键词!');
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
