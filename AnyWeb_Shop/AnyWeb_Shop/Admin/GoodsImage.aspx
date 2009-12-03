<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="GoodsImage.aspx.cs" Inherits="GoodsImage" Title="商品相关图片" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
 <li>建议上传图片控制在2M内。大于2M的图片系统将自动忽略。</li>
 <li>点击”批量上传图片“前端的小框，即可显示图片上传工具。</li>          
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">

    <script type="text/javascript">
	  function boxShowFile(checked)
	  {
	     if(checked == 0 )
	      {
	           document.getElementById("editarea").style.display="none";
	      }
	     else
	      {
	           document.getElementById("editarea").style.display=""; 
	      } 
	  }
    </script>
    <div class="mod mEdit">
        <div class="mhd">
            <div class="inner">
                <h2>
                    商品相关图片</h2>
            </div>
        </div>
        <div class="mbd">
            <div class="inner">
                <form id="form1" runat="server">
                 <asp:CheckBox ID="boxAll" runat="server" onclick="boxShowFile(this.checked)" />批量上传图片 [注意：图片大小不超过2M。]
                    <table id="editarea" class="iEditForm iEditBaseInf" style="display:none;">
                        <tr id="upload1" >
                            <th class="photos">
                                图片名称
                            </th>
                            <td>
                                <asp:TextBox ID="txtName1" runat="server" CssClass="input" Text="图片1" MaxLength="70" ></asp:TextBox>
                                &nbsp;图片
                                <asp:FileUpload ID="File1" CssClass="input" runat="server" Width="380px" />
                            </td>
                        </tr>
                        <tr id="upload2" >
                            <th  class="photos">
                                图片名称</th>
                            <td>
                                <asp:TextBox ID="txtName2" runat="server" CssClass="input" MaxLength="70"  Text="图片2" ></asp:TextBox>
                                &nbsp;图片
                                <asp:FileUpload ID="File2" CssClass="input" runat="server" Width="380px" /></td>
                        </tr>
                        <tr id="upload3" >
                            <th class="photos">
                                图片名称</th>
                            <td>
                                <asp:TextBox ID="txtName3" runat="server" CssClass="input" MaxLength="70"  Text="图片3" ></asp:TextBox>
                                &nbsp;图片
                                <asp:FileUpload ID="File3" CssClass="input" runat="server" Width="380px" /></td>
                        </tr>
                        <tr id="upload4" >
                            <th  class="photos">
                                图片名称</th>
                            <td>
                                <asp:TextBox ID="txtName4" runat="server" CssClass="input" MaxLength="70"  Text="图片4" ></asp:TextBox>
                                &nbsp;图片
                                <asp:FileUpload ID="File4" CssClass="input" runat="server" Width="380px" /></td>
                        </tr>
                        <tr id="upload5" >
                            <th class="photos">
                                图片名称</th>
                            <td>
                                <asp:TextBox ID="txtName5" runat="server" CssClass="input" MaxLength="70"  Text="图片5" ></asp:TextBox>
                                &nbsp;图片
                                <asp:FileUpload ID="File5" CssClass="input" runat="server" Width="380px" /></td>
                        </tr>
                    </table>
                    <table class="iEditForm iEditBaseInf">
                        <tbody>
                            <tr class="name odd">
                                <td>
                                    <div class="div_skinName">
                                        相关图片列表</div>
                                    <ul class="div_mode">
                                        <asp:Repeater ID="rep1" runat="server" DataSourceID="ods1">
                                            <ItemTemplate>
                                                <li class="div_mode_li" >
                                                 <span class="div_mode_img" ><a href='<%#Eval("ImageUrl").ToString().Replace("S_","")%>' target="_blank"><img src='<%#Eval("ImageUrl")%>' onload="javascript:if(this.width>120)this.width=120"  alt='<%#Eval("ImageName")%>'></a></span>
                                                    <span class="div_mode_name" title='<%# Eval("ImageName")%>'><input type="checkbox" name="ids" value='<%#Eval("ID")%>'  style='visibility:<%#(int)Eval("Type")==1? "hidden":"visible"%>'><%# Eval("ImageName")%></span>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div class="iSubmit">
                        <asp:Button ID="btnSave" CssClass="submit" runat="server" Text="上传图片 " OnClick="btnSave_Click" >
                        </asp:Button>
                          <asp:Button ID="btnDel" CssClass="submit" runat="server" Text="删除图片" OnClick="btnDel_Click" >
                        </asp:Button>
                        <input id="btnBack" class="button" onclick="window.location='GoodsList.aspx'" type="button" value="取 消" />
                    </div>
                </form>
                <asp:ObjectDataSource ID="ods1" runat="server" SelectMethod="GetGoodsImages" TypeName="Common.Agent.GoodsAgent" OnSelecting="ods1_Selecting">
                    <SelectParameters>
                        <asp:Parameter Name="goodsid" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
    </div>
</asp:Content>

