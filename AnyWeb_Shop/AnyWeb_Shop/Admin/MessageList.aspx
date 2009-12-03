<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="MessageList.aspx.cs" Inherits="MessageList" Title="留言薄" %>
<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
     
<li>对于商城的所有留言的管理。管理可对留言回复及删除操作。</li>
              
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
 <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    留言薄
                </h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                    <caption> <input id="chkchoose" type="checkbox" onclick="chooseAll();" />全选</caption>
                        <asp:Repeater ID="rep1" runat="server" DataSourceID="ods3">
                            <ItemTemplate>
                                <tbody>
                                <tr>
                                    <td >
                                      
                                        <div class="comment_container" >
                                            <h3><input type="checkbox" name="ids" value='<%#Eval("ID") %>'>
                                            发表人：<%# Eval ("UserName")%>
                                            发表时间：<%# Eval( "CreateAt" , "{0:yyyy-MM-dd HH:mm}" )%>
                                            IP：<%# Eval("IP")%>&nbsp;来源：<%# Eval("Area")%>
                                            <span style="float: right; margin-top: -16px; padding-right: 20px; ">
                                              <a href='MessageReplay.aspx?mid=<%# Eval("ID") %>' style=" color:black; font-weight:bold;">
                                                    <img src="images/mbi_004.gif" alt="回复评论" border="0" />回复留言</a></span></h3>
                                        <div class="comment_content">
                                            <%# Eval("Content")%> 
                                            <%#Eval("Replay").ToString() == "" ? "" :
																"<div class=message_reply style=margin:10px 0px 10px 0px;>" + "<strong>店长回复</strong>："+Eval("Replay").ToString().Replace("\r\n","") + "(" + Eval("ReplayAt").ToString() + ")</div>"
                                            %></div></div>
                                        </div>
                                    
                                    </td>
                                </tr>
                                </tbody>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <div class="iPagination">
                        <cc1:PageNaver ID="PN1" StyleID="2" runat="server" PageSize="12">
                        </cc1:PageNaver>
                    </div>
                    <div class="iSubmit">
                         <input id="chkChooseAll" type="checkbox" onclick="chooseAll();" />全选  <asp:Button ID="btnDel" runat="server" CssClass="submit" Text="批量删除" OnClick="btnDel_Click" />
                    </div>
                    <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetMessageList" TypeName="Common.Agent.MessageAgent" OnSelected="ods3_Selected">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="PN1" Name="pagesize" PropertyName="pagesize"  Type="int32"/>
                            <asp:ControlParameter ControlID="PN1" Name="pageno" PropertyName="pageindex"  Type="int32"/>
                            <asp:Parameter Direction="Output" Name="recordCount" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
     <script type="text/javascript">
        var choosed=false;
	    function chooseAll()
	    {
		    choosed=!choosed;
		    var chks = document.getElementsByName("ids");
		    for(i=0;i<chks.length;i++)
		    {
			    chks[i].checked=choosed;
		    }
	    }
    </script>
</asp:Content>

