<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true" CodeFile="GoodsPatch.aspx.cs" Inherits="Admin_GoodsPatch"%>


<asp:Content ID="Content1" ContentPlaceHolderID="cph2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" Runat="Server">
    
    <div class="pbd pEdit">
        <div class="part pt1 ptSidebar">
            <h2 class="PageTitle">
                批量添加商品</h2>
            <ul class="Help">
                <li>批量添加商品必须以Excel(2003)文件提交，且按照系统规定的格式编辑好。<a href="sample.xls" target="_blank" title="点击下载">下载Excel示例文件</a></li>
            </ul>
        </div>
        <div class="part pt2">
        </div>
        <div class="part pt3">
        
            <div class="Mod Form MainForm" id="step1" runat="server">
                <div class="mhd">
                    <h3>
                        批量添加商品</h3>
                </div>
                <div class="mbd">
                    <div class="fi even">
                        <label>
                            商品文件：</label>
                        <div class="cont">
                            <asp:FileUpload ID="file1" runat="server" CssClass="text" />
                            <sw:Validator ID="Validator5" ControlID="file1" ValidateType="Required" ErrorText="请上传商品文件" ErrorMessage="请上传商品文件" runat="server"> </sw:Validator>
                        </div>
                    </div>
                    <div class="fi fiBtns">
                        <asp:Button ID="btnOk" runat="server" Text="上传商品" OnClick="btnOk_Click"
                            CssClass=""></asp:Button>
                        <a href="goodslist.aspx">返回列表</a>
                    </div>
                </div>
                <div class="mft">
                </div>
            </div>
            
            
            <div class="Mod DataList" id="step2" runat="server" visible="false">
                <div class="mhd">
                    <h3>
                        批量添加商品结果</h3>
                </div>
                <div class="mbd">
                    <table>
                        <thead>
                            <tr>
                                <th>
                                    序号
                                </th>
                                <th>
                                    名称
                                </th>
                                <th>
                                    价格
                                </th>
                                <th>
                                    库存
                                </th>
                                <th>
                                    分类
                                </th>
                                <th>
                                    品牌
                                </th>
                                <th>
                                    状态
                                </th>
                                <th class="end">
                                    导入结果
                                </th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="repGoodses" runat="server" EnableViewState="False">
                            <ItemTemplate>
                                <tr align="center" class="editalt">
                                    <td style="width:30px;">
                                        <%# Eval("fdGoodID")%>
                                    </td>
                                    <td>
                                        <%# Eval("fdGoodName")%>
                                    </td>
                                    <td>
                                        <%# Eval("fdGoodSalePrice")%>
                                    </td>
                                    <td>
                                        <%# Eval("fdGoodStockNum")%>
                                    </td>
                                    <td>
                                        <%# Eval("Category.fdCateName")%>
                                    </td>
                                    <td>
                                        <%# Eval("Brand") == null ? "--" : Eval("Brand.fdBranName").ToString()%>
                                    </td>
                                    <td style="width:30px;">
                                        <%# Eval("fdGoodStatus").ToString() == "1" ? "正常" : "下架"%>
                                    </td>
                                    <td>
                                        成功
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <div class="fi fiBtns">
                        <a href="goodspatch.aspx">重新上传</a>
                        <a href="goodslist.aspx">返回列表</a>
                    </div>
                </div>
                <div class="mft">
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>