<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="OrderList.aspx.cs" Inherits="OrderList" Title="订单管理" %>
<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
     
<li>用列表上的搜索工具条可对列表中的订单进行过滤。  </li>
<li>点击“操作列”里的“订单明细”对订单进入状态处理、删除操作。  </li>
<li>选择编号前框框，可进入批量删除操作。</li>

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
 <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                     订单管理</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                        <caption>  
                            订单编号：<asp:TextBox ID="txtOrderID" runat="server" CssClass="input"  MaxLength="20"   Width="60px"></asp:TextBox>
                            用户名：<asp:TextBox ID="txtUserName" runat="server" CssClass="input"  MaxLength="50"  Width="100px"></asp:TextBox>
                               状态：<asp:DropDownList ID="drpStatus" runat="server"  >
                                       <asp:ListItem Value="0">所有订单</asp:ListItem>
                                        <asp:ListItem Value="1">未处理订单</asp:ListItem>
                                       <asp:ListItem Value="2">已发货订单</asp:ListItem>
                                       <asp:ListItem Value="3">取消发货订单</asp:ListItem>
                                    </asp:DropDownList><br />
                            下单时间：<asp:TextBox ID="txtorderdate" runat="server" MaxLength="30" Width="80px" onclick="setday(this);"  CssClass="input"></asp:TextBox>
                              至&nbsp;<asp:TextBox ID="txtorderdate2" runat="server" MaxLength="30" Width="80px" onclick="setday(this);" CssClass="input"></asp:TextBox>
                            发货时间：<asp:TextBox ID="txtData" runat="server" MaxLength="30" Width="80px" onclick="setday(this);"  CssClass="input"></asp:TextBox>
                              至&nbsp;<asp:TextBox ID="txtDataEnd" runat="server" MaxLength="30" Width="80px" onclick="setday(this);" CssClass="input"></asp:TextBox>
                            <asp:Button ID="btnSearch"  CssClass="button1" runat="server" Text="搜索"  OnClick="btnSearch_Click"/>
                        </caption>
                        <thead>
                            <tr>
                                <th class="fst">
                                   <input type="checkbox" onclick="SelectAll(this.checked)" title="点击全选" /></th>
                                <th >
                                   订单编号</th>
                                <th>
                                    用户名称</th>
                                    <th>
                                    下单时间</th>
                                <th>
                                    发货时间</th>
                                 <th>
                                    交易总额</th>
                                <th>
                                    状态</th>
                                <th class="end">
                                    操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repCategory" runat="server" DataSourceID="ods3">
                                <ItemTemplate>
                                    <tr>
                                    <td><input type="checkbox" name="ids" value='<%#Eval("ID")%>' /></td>
                                        <td>
                                           <%#Eval("ID") %>
                                        </td>
                                        <td>
                                            <%#Eval("UserName") %>
                                        </td>
                                        <td>
                                            <%#Eval( "CreateAt","{0:yyyy-MM-dd}" )%>
                                        </td>
                                        <td>
                                            <%#Eval( "DeliverTime","{0:yyyy-MM-dd}" )%>
                                        </td>
                                        <td>
                                            <%#Eval("Price","{0:c}") %>
                                        </td>
                                         <td>
                                            <%#GetStatus((int)Eval( "Status" ))%>
                                        </td>
                                        <td>
                                             <a href="OrderItem.aspx?oid=<%#Eval("ID")%>">订单明细</a>
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
                   <div class="iSubmit">
                     <asp:Button ID="btnDel" runat="server" CssClass="submit" Text="批量删除" OnClick="btnDel_Click" />
                    </div>
                    <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetOrderList"  TypeName="Common.Agent.OrderAgent" OnSelected="ods3_Selected" OnSelecting="ods3_Selecting">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="userid" Type="Int32"  DefaultValue="0"  QueryStringField="userid"/>
                            <asp:ControlParameter PropertyName="pagesize" ControlID="PN1" Name="pagesize" Type="Int32" />
                            <asp:ControlParameter PropertyName="pageindex" ControlID="PN1" Name="pageno" Type="Int32" />
                            <asp:QueryStringParameter Name="orderid" Type="Int32"  DefaultValue="0" QueryStringField="orderid" />
                           <asp:Parameter Name="username" Type="String" />
                            <asp:QueryStringParameter Name="status" Type="Int32"  DefaultValue="0"  QueryStringField="status"/>
                           <asp:QueryStringParameter Name="starttime" Type="DateTime" DefaultValue="1900-1-1" QueryStringField="starttime"/> 
                           <asp:QueryStringParameter Name="endtime" Type="DateTime" DefaultValue="9999-12-12" QueryStringField="endtime"/> 
                            <asp:QueryStringParameter Name="ordertime" Type="DateTime"  DefaultValue="1900-1-1" QueryStringField="orderdate"/> 
                           <asp:QueryStringParameter  Name="ordertime2" Type="DateTime" DefaultValue="9999-12-12" QueryStringField="orderdate2"/> 
                           <asp:Parameter Direction="Output" Name="record" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <script type="text/javascript">
function SelectAll(v)
{
	var e_all = document.all.tags('INPUT');
	for(var i=0;i<e_all.length;i++)
	{
		if (e_all[i].tagName=="INPUT")
		{
			if ((e_all[i].type) && (e_all[i].name))
			{
				if ((e_all[i].type=="checkbox") && (e_all[i].name!="boxAll"))
				{
					e_all[i].checked = v;
				}
			}
		}
	}
}
		
</script>
</asp:Content>

