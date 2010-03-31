<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinkList.ascx.cs" Inherits="Controls_LinkList" %>
<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
       <table class="mainContainer">
        	<tr>
            	<th colspan="3" class="title">友情链接</th>
            </tr>
            <tr class="subTitle">
            	<td width="40%">链接图片</td>
                <td width="40%">链接名字</td>
                <td width="20%">浏览</td>
           	</tr>
            <asp:Repeater ID="repLinks" runat="server">
                <ItemTemplate>
                    <tr>
        	            <td class="tdColorM"><a href="<%#Eval("LinkUrl") %>" target="_blank"><img src="<%#(string)Eval( "Image" )=="" ? "../images/wait.jpg":(string)Eval( "Image" ) %>" class="img" onload="if(this.height>40)this.height=40;"/></a></td>
                        <td>
            	            <a href="<%#Eval("LinkUrl") %>" target="_blank"><%#Eval("Name")%></a>
                        </td>
                        <td class="tdColorM"><a href="<%#Eval("LinkUrl") %>" target="_blank">点击浏览</a></td>
       	            </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <div class="page">
        <cc1:PageNaver ID="PN1" StyleID="2" runat="server" PageSize="18">
        </cc1:PageNaver>
        </div>