<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="VenditionStat.aspx.cs" Inherits="VenditionStat" Title="销售统计" %>
<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
<div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                     销售统计</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                        <caption>
                            <asp:RadioButton ID="rdmo" GroupName="data" AutoPostBack="true" runat="server" Checked="true" Text="所有" OnCheckedChanged="rdmo_CheckedChanged" />
                            <asp:RadioButton ID="rd2D" GroupName="data" AutoPostBack="true" runat="server" Text="最近两周的" OnCheckedChanged="rdmo_CheckedChanged" />
                            <asp:RadioButton ID="rd1M" GroupName="data" runat="server" AutoPostBack="true" Text="最近一月" OnCheckedChanged="rdmo_CheckedChanged" />
                            <asp:RadioButton ID="rd3M" GroupName="data" runat="server" AutoPostBack="true" Text="最近三月的" OnCheckedChanged="rdmo_CheckedChanged" />
                            <asp:RadioButton ID="rdzdy" GroupName="data" runat="server" Text="自定义" OnCheckedChanged="rdmo_CheckedChanged" />
                            <span id="sp" style="display:none">
                                <br />
                                开始时间：<asp:TextBox ID="txtStart" MaxLength="30" Width="80px" onclick="setday(this);" CssClass="input" runat="server"></asp:TextBox>
                                结束时间：<asp:TextBox ID="txtEnd" runat="server" Width="80px" MaxLength="30" onclick="setday(this);" CssClass="input" ></asp:TextBox>
                                所属类别：<asp:DropDownList ID="ddlCategory" CssClass="text" DataValueField="ID" DataTextField="Name" runat="server">
                            </asp:DropDownList><asp:Button ID="btnSelect" runat="server" Text="查找" OnClick="btnSelect_Click" />
                            </span>
                        </caption>
                        <thead>
                            <tr>
                                 <th >
                                   商品编号</th>
                                <th>
                                    商品名称</th>
                                <th>
                                    已售出件数</th>
                                 <th>
                                    商品点击次数</th>
                                      <th>
                                        评论数
                                    </th>
                                    <th>
                                        所属类别
                                    </th>
                                    <th>
                                        是否为推荐商品
                                    </th>
                                    <th>
                                        出售金额
                                    </th>
                                  
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repGoods" runat="server" >
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                           <%#Eval("ID") %>
                                        </td>
                                        <td>
                                            <%#Eval("GoodsName") %>
                                        </td>
                                        <td>
                                            <%#Eval( "PayCount" )%>
                                        </td>
                                        <td>
                                            <%#Eval("Clicks")%>
                                        </td>
                                        <td>
                                            <%#Eval("Comments")%>
                                        </td>
                                        <td>
                                            <%#Eval("OfCategory.Name")%>
                                        </td>
                                        <td>
                                            <%# (bool)Eval("IsRecommend") == true ? "是":"否"%>
                                        </td>
                                        
                                        <td>
                                            <%#Eval("Price","{0:c}")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div class="iPagination">
                        <cc1:PageNaver ID="PN1" StyleID="2" runat="server" PageSize="18">
                        </cc1:PageNaver>
                    </div>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <script type="text/javascript" >
    
     var rdzdy = document.getElementById("<%= rdzdy.ClientID %>");
     var sp = document.getElementById("sp");
    function GetData()
    {
        if(rdzdy.checked)
        {
            sp.style.display = "";
        }
        else
        {
            sp.style.display = "none";
        }
    }
    
     if(rdzdy.checked)
        {
            sp.style.display = "";
        }
        else
        {
            sp.style.display = "none";
        }   
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph2" Runat="Server">

</asp:Content>

