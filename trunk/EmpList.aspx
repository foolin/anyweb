<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EmpList.aspx.cs" Inherits="EmpList" Title="雇员列表" %>
<%@ Register TagPrefix="ctl" Namespace="Studio.Web" Assembly="Studio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content1" Runat="Server">
    <div id="childmenu">
        帐号
        <input type="text" id="txtKeyword" value="<%=Request["keyword"]%>" onkeydown="if(event.keyCode==13) return search();"/>
        <input type=button value="检索" onclick="search();" />
        <input type=button value="添加" onclick="window.navigate('empadd.aspx');" />
    </div>
    <table cellspacing=1 class="list" align=center>
	    <tr class="title" style="height: 25px">
		    <td>雇员编号</td>
		    <td>姓名</td>
		    <td>职位</td>
		    <td>入职时间</td>
		    <td width="*">操作</td>
	    </tr>
	    <asp:Repeater ID="rep1" Runat="server" EnableViewState="False" DataSourceID="Data1">
		    <ItemTemplate>
			    <tr class='<%# Container.ItemIndex%2==0?"item":"item2"%>'>
				    <td><%# Eval("ID")%></td>
				    <td><%# Eval("FirstName")%> <%# Eval("LastName")%></td>
				    <td><%# Eval("JobInfo.Name")%></td>
				    <td><%# Eval("HireDate","{0:yyyy-MM-dd}")%></td>
				    <td>
						<a href='EmpEdit.aspx?id=<%# Eval("ID")%>' class="button">修改</a>
						<a href='EmpDelete.aspx?id=<%# Eval("ID")%>' class="button">删除</a>
				    </td>
			    </tr>
		    </ItemTemplate>
	    </asp:Repeater>
    </table>
    <div id="Pager"><ctl:pagenaver id="PN1" PageSize="15" runat="Server" StyleID=2></ctl:pagenaver>
        共<Asp:Label id="lblRecords" runat="server">0</Asp:label>条记录
        <asp:ObjectDataSource ID="Data1" runat="server" SelectMethod="GetEmployeeList"
            TypeName="EmployeeAgent" OnSelected="Data1_Selected">
            <SelectParameters>
                <asp:ControlParameter ControlID="PN1" Name="pageNo" PropertyName="PageIndex" Type="Int32" ConvertEmptyStringToNull="False" />
                <asp:ControlParameter ControlID="PN1" Name="pageSize" PropertyName="PageSize" Type="Int32" ConvertEmptyStringToNull="False" />
                <asp:QueryStringParameter Name="keyword" DefaultValue="" QueryStringField="keyword" Type="String" ConvertEmptyStringToNull="False" />
                <asp:Parameter DefaultValue="0" Direction="Output" Name="recordCount" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
<script language=javascript>
    function search()
    {
		form1 = document.createElement('form');
		form1.method = 'GET';
		
		input1 = document.createElement('input');
		input1.type = 'text';
		input1.name = 'keyword';
		input1.value = document.getElementById("txtKeyword").value;
		form1.insertBefore(input1);
		
		document.body.insertBefore(form1);
		form1.submit();
		
        return false;
    }
</script>
</asp:Content>

