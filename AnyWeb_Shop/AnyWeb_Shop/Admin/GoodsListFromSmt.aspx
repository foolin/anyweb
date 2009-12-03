<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="GoodsListFromSmt.aspx.cs" Inherits="GoodsListFromSmt" Title="导入商脉通产品" %>
<%@ Register Assembly="Studio" Namespace="Studio.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">

    <li>选择左边商城所绑定的商脉通中的产品类别；</li>
    <li>选择右边导入产品的类别目标。</li>
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
                <form id="form2" runat="server" onsubmit="Choose();">
                    <table class="iList iArticle" id="tbGoods"> 
                        <thead>
                            <tr>
                                <th class="fst">商脉通产品类别</th>
                                <th class="end">您要导入到哪个商品类别</th>
                            </tr>
                        </thead>
                        <tbody>
                        
                        <tr>
                           <td width="50%"  valign="top" style="padding:0;">
                            <div style="height:200px;overflow:auto; padding-left:10px;">
                                <style type="text/css">
                                    .treeView td{border:0;padding:0px;height:auto;}
                                </style>
                                
                                <asp:TreeView ID="tvCategory" ShowLines="True" CssClass="treeView"  onclick='client_OnTreeNodeChecked()'  runat="server" ShowCheckBoxes="All"  >
                                </asp:TreeView>
                            </div>
                                
                            </td>
                             <td width="50%"  valign="top">
                                 <ul style="height:200px;overflow:auto;"><asp:Repeater ID="repShopCategory" runat="server" DataSourceID="ods3">
                                 <ItemTemplate>
                                    <li style="margin:5px;"><input type="radio" value='<%#Eval("ID") %>' id="chkChoose"  name ="chkChoose" /><%#Eval("Name")%></li>
                                 </ItemTemplate>
                               </asp:Repeater></ul>
                            </td>
                            </tr>
                            <tr>
                           <td colspan="2">
                                <asp:RadioButton ID="rad1" runat="server" GroupName="status" Checked="true"/>导入后在首页不显示
                                <asp:RadioButton ID="rad2" runat="server"  GroupName="status"/>导入后在首页显示
                            </td>
                        </tr>
                        </tbody>
                    </table>
                        <div class="iSubmit">
                            <asp:Button ID="btnSave" runat="server" Text="导入保存" CommandName="Insert" CssClass="submit" OnClick="btnSave_Click" ></asp:Button>
                            <button id="btnBack" onclick="window.location='GoodsList.aspx';" type="button">取 消</button>
                        </div>
                </form>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
   <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetCategoryNameByType" TypeName="Common.Agent.CategoryAgent"></asp:ObjectDataSource>

<script type="text/javascript" >
function client_OnTreeNodeChecked()
{
    var obj = window.event.srcElement;
    var treeNodeFound = false;
    var checkedState;
    if (obj.tagName == "INPUT" && obj.type == "checkbox")
    {
        var treeNode = obj;
        checkedState = treeNode.checked;
        do
        {
            obj = obj.parentElement;
        } while (obj.tagName != "TABLE")
        var parentTreeLevel = obj.rows[0].cells.length;
        var parentTreeNode = obj.rows[0].cells[0];
        var tables = obj.parentElement.getElementsByTagName("TABLE");
        var numTables = tables.length
        if (numTables >= 1)
        {
            for (i=0; i < numTables; i++)
            {
                if (tables[i] == obj)
                {
                    treeNodeFound = true;
                     i++;
                     if (i == numTables)
                    {
                        return;
                    }
            }
            if (treeNodeFound == true)
            {
                var childTreeLevel = tables[i].rows[0].cells.length;
                if (childTreeLevel > parentTreeLevel)
                {
                    var cell = tables[i].rows[0].cells[childTreeLevel - 1];
                    var inputs = cell.getElementsByTagName("INPUT");
                    inputs[0].checked = checkedState;
                }
                else
                {
                    return;
                }
            }
        }
    }
    }
}

</script>
</asp:Content>

