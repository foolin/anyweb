<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="AdvertisementList.aspx.cs" Inherits="AdvertisementList" Title="广告管理" %>
<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">

 <li>广告是增加您收入的一种方式。</li>
<li>适当的广告也能够使您的商店更有色彩</li>
          
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
 <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    广告管理 <span class="listadd"><a href="AdvertisementEdit.aspx?mode=insert">添加广告</a></span>
                </h2>
                  
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                    <table class="iList iArticle">
                        <thead>
                            <tr>
                                <th class="fst">
                                    广告标题</th>
                                      <th >
                                    创建日期</th>
                                <th class="end">
                                    操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rep1" runat="server" DataSourceID="ods3">
                                <ItemTemplate>
                                      <tr>
                                        <td>
                                           <%#Eval("AdTitle") %>
                                        </td>
                                         <td>
                                           <%#Eval("CreateAt","{0:yyyy-MM-dd}") %>
                                        </td>
                                        <td>
                                          <a href='AdvertisementEdit.aspx?adid=<%#Eval("ID") %>&mode=select'>查看内容</a> <a href='AdvertisementEdit.aspx?adid=<%#Eval("ID") %>&mode=update'>修改</a>  <a href='AdvertisementEdit.aspx?adid=<%#Eval("ID") %>&mode=delete' onclick="javascript:return confirm('确定删除？');">删除</a>
                                        </td>
                                      </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                   <div class="iPagination" >
                        <cc1:PageNaver ID="PN1" StyleID="2" runat="server" PageSize="18">
                        </cc1:PageNaver>
                    </div>
                </form>
            <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetAdList" TypeName="Common.Agent.AdvertisementAgent" OnSelected="ods3_Selected">
                    <SelectParameters>
                      <asp:ControlParameter ControlID="PN1" Type="int32" Name="pagesize" PropertyName="pagesize" />
                        <asp:ControlParameter ControlID="PN1" Type="int32" Name="pageno" PropertyName="pageindex" />
                        <asp:Parameter Direction="Output" Name="recordcount" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
</asp:Content>

