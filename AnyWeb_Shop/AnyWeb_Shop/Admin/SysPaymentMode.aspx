<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="SysPaymentMode.aspx.cs" Inherits="SysPaymentMode" Title="系统支付管理" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph2" Runat="Server">
<li></li>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph1" runat="Server">
        <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    系统支付方式管理</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                        <thead>
                            <tr>
                                <th>
                                    支付方式名称</th>
                                   <%-- <th>
                                        最低收费
                                    </th>
                                 <th>
                                    手续费</th>--%>
                                <th class="end">
                                    操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repMode" runat="server" DataSourceID="ods3">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("Title") %>
                                        </td>
                                      <%--  <td>
                                           <%#Eval("MostPoundage") %>
                                        </td>
                                        <td>
                                            <%# Eval("Poundage").ToString() + "/1000 RMB"  %>
                                        </td>--%>
                                        <td>
                                        <%--<a href="javascript:" onclick='UseDeliver(<%#  Eval("ID") %>)'>使用</a>--%>
                                            <a href='UseDeliver.aspx?mid=<%#  Eval("ID") %>'>使用</a>
                                            <a href='SysPaymentModeParticular.aspx?mid=<%# Eval("ID").ToString() %>'>查看详细</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </form>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetModeByType" TypeName="Common.Agent.ModeAgent">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="type" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="shopid" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
<%--    <script type="text/javascript" >
    function UseDeliver(mid)
    {
        var req = GetRequest();
        
			var data = "mid=" + mid;
			req.onreadystatechange = function handler(){
              if (req.readyState == 4) {

                if( req.status == 200){
                  var result = req.responseText;
                  alert(result);
                  
                   
                if(result=="0"){
                  alert("使用成功");
                }
                if(result == "1")
                {
                  alert("操作失误,请重试");
                }
                if(result == "2")
                {
                  alert("错误操作,请重试");
                }
                }
             }
           }
			req.open("get","UseDeliver.aspx?"+data,true);
		    req.send();
    }
    
        function GetRequest(){
		var req = null;
		if( window.XMLHttpRequest){
			req = new XMLHttpRequest();
			if(req.overrideMimeType){
                 req.overrideMimeType("text/xml");
            }
		}
		else{
			if(window.ActiveXObject){
				try{
					req = new ActiveXObject("Msxml3.XMLHTTP");
				}
				catch(e){
					try{
						req = new ActiveXObject("Msxml2.XMLHTTP");
					}
					catch(e){
						try{
							req = new ActiveXObject("Microsoft.XMLHTTP");
						}
						catch(e){
						}
					}
				}				
			}
		}
		return req;
	}
    </script>--%>
</asp:Content>

