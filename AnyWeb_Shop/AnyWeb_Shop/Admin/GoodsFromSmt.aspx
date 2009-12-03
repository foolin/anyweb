<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="GoodsFromSmt.aspx.cs" Inherits="GoodsFromSmt" Title="从商脉通导入商品" %>
<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">

   <li>选择左边商城所绑定的商脉通中的产品；</li>
   <li>选择右边导入产品的类别目标；</li>
   <li>导入后，请回到商品列表中检查导入的商品是否有图片。</li>
            
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
 <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                   导入商脉通产品</h2>
            </div>
            
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server" onsubmit="Choose();">
                    <table class="iList iArticle" id="tbGoods"> 
                        <caption>
                           商品名称：<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox><asp:Button ID="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click" /> 
                        </caption>
                        <thead>
                            <tr>
                                <th class="fst">商脉通产品</th>
                                <th class="end">您要导入到哪个商品类别</th>
                            </tr>
                        </thead>
                        <tbody>
                        
                        <tr>
                           <td width="50%"  valign="top" style="padding:0;">
                           <ul style="height:200px;overflow:auto;">
                                <asp:Repeater ID="repSmtGoods" runat="server">
                                    <ItemTemplate>
                                        <li style="margin:5px;"><input type="checkbox" id="chkPro" name ="chkPro"  value='<%#Eval("ProductID") %>' source='<%#Eval("Photo") %>' />
                                        <%#Eval("ProductName")%></li>
                                    </ItemTemplate>
                               </asp:Repeater>
                               </ul>
                            </td>
                             <td width="50%"  valign="top">
                             <ul style="height:200px;overflow:auto;">
                                 <asp:Repeater ID="repShopCategory" runat="server" DataSourceID="ods3">
                                 <ItemTemplate>
                                    <li style="margin:5px;"><input type="radio" value='<%#Eval("ID") %>' id="chkChoose"  name ="chkChoose" /><%#Eval("Name")%></li>
                                 </ItemTemplate>
                               </asp:Repeater>
                               </ul>
                            </td>
                            </tr>
                            <tr>
                            <td colspan="2">
                                <asp:RadioButton ID="rad1" GroupName="rad" runat="server"  Checked="true"/>导入后在首页不显示
                                <asp:RadioButton ID="rad2" GroupName="rad" runat="server"/>导入后在首页显示
                            </td>
                        </tr>
                        </tbody>
                        
                    </table>
                       <!--div class="iPagination" style="text-align:left;">
                        
                    </div-->
                     <div class="iSubmit"><div style="float:left;"><cc1:PageNaver ID="PN1" StyleID="2" runat="server" PageSize="26">
                        </cc1:PageNaver></div>
                            <div style="float:right;display:inline;margin-right:10px;"><asp:Button ID="btnSave" runat="server" Text="导入保存" CommandName="Insert" CssClass="submit" OnClick="btnSave_Click"></asp:Button>
                            <button id="btnBack" onclick="window.location='GoodsList.aspx';" type="button">取 消</button></div>
                        </div>
                     
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <script type="text/javascript">
            function Choose()
            {
                    var pros = document.getElementsByTagName("input");
               
                    var form1 = document.forms[0];
                    for(var i=0;i<pros.length;i++)
                    {  
                        if(pros[i].type=="checkbox")
                        {
                            if( pros[i].checked)
                            {
                                var input = document.createElement("input");
                                input.type = "hidden";
                                input.name = "image" ;
                                input.value = pros[i].source; 
                               
                                form1.appendChild(input); 
                              
                            }
                        }
                    }
            }
            </script>
    <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetCategoryNameByType" TypeName="Common.Agent.CategoryAgent"></asp:ObjectDataSource>
</asp:Content>
