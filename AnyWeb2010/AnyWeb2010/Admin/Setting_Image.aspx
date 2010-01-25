<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="Setting_Image.aspx.cs" Inherits="Admin_Setting_Image" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                图片设置</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    商品列表图片：</label>
                <div class="cont">
                    宽<asp:TextBox ID="txtGoodsListWidth" runat="server" MaxLength="4" CssClass="text"
                        Width="50px"></asp:TextBox>像素,高<asp:TextBox ID="txtGoodsListHeight" runat="server"
                            MaxLength="4" CssClass="text" Width="50px"></asp:TextBox>像素</div>
            </div>
            <div class="fi even">
                <label>
                    商品图片：</label>
                <div class="cont">
                    宽<asp:TextBox ID="txtGoodsWidth" runat="server" MaxLength="4" CssClass="text" Width="50px"></asp:TextBox>像素,高<asp:TextBox
                        ID="txtGoodsHeight" runat="server" MaxLength="4" CssClass="text" Width="50px"></asp:TextBox>像素</div>
            </div>
            <div class="fi">
                <label>
                    品牌图片：</label>
                <div class="cont">
                    宽<asp:TextBox ID="txtBrandWdith" runat="server" MaxLength="4" CssClass="text" Width="50px"></asp:TextBox>像素,高<asp:TextBox
                        ID="txtBrandHeight" runat="server" MaxLength="4" CssClass="text" Width="50px"></asp:TextBox>像素</div>
            </div>
            <div class="fi even">
                <label>
                    会员头像：</label>
                <div class="cont">
                    宽<asp:TextBox ID="txtMemberImageWidth" runat="server" MaxLength="4" CssClass="text"
                        Width="50px"></asp:TextBox>像素,高<asp:TextBox ID="txtMemberImageHeight" runat="server"
                            MaxLength="4" CssClass="text" Width="50px"></asp:TextBox>像素</div>
            </div>
            <div class="fi">
                <label>
                    幻灯图片：</label>
                <div class="cont">
                    宽<asp:TextBox ID="txtFlashWidth" runat="server" MaxLength="4" CssClass="text" Width="50px"></asp:TextBox>像素,高<asp:TextBox
                        ID="txtFlashHeight" runat="server" MaxLength="4" CssClass="text" Width="50px"></asp:TextBox>像素</div>
            </div>
            <div class="fi even">
                <label>
                    水印类型：</label>
                <div class="cont">
                    <asp:RadioButtonList ID="radioWaterType" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Value="0" Text="未启用"></asp:ListItem>
                        <asp:ListItem Value="1" Text="图片"></asp:ListItem>
                        <asp:ListItem Value="2" Text="文字"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="fi">
                <label>
                    水印图片：</label>
                <div class="cont">
                    <asp:FileUpload ID="fileWater" runat="server" CssClass="text" /><br />
                    <asp:Image ID="imgWater" runat="server" Visible="false" />
                </div>
            </div>
            <div class="fi even">
                <label>
                    水印文字：</label>
                <div class="cont">
                    <asp:TextBox ID="txtWaterText" runat="server" CssClass="text" MaxLength="100"></asp:TextBox>
                </div>
            </div>
            <div class="fi">
                <label>
                    水印字体：</label>
                <div class="cont">
                    <asp:DropDownList ID="drpWaterFontFamily" runat="server">
                    </asp:DropDownList>
                    大小<asp:TextBox ID="txtWaterFontSize" runat="server" MaxLength="3" CssClass="text"
                        Width="80px"></asp:TextBox>像素
                </div>
            </div>
            <div class="fi even">
                <label>
                    水印透明度：</label>
                <div class="cont">
                    <asp:TextBox ID="txtTransparency" runat="server" MaxLength="3" CssClass="text" Width="80px"></asp:TextBox>
                </div>
            </div>
            <div class="fi">
                <label>
                    水印位置：</label>
                <div class="cont">
                    <asp:RadioButtonList ID="radioWaterPosition" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Value="1" Text="" title="左上"></asp:ListItem>
                        <asp:ListItem Value="2" Text="" title="上"></asp:ListItem>
                        <asp:ListItem Value="3" Text="" title="右上"></asp:ListItem>
                        <asp:ListItem Value="4" Text="" title="左"></asp:ListItem>
                        <asp:ListItem Value="5" Text="" title="中"></asp:ListItem>
                        <asp:ListItem Value="6" Text="" title="右"></asp:ListItem>
                        <asp:ListItem Value="7" Text="" title="左下"></asp:ListItem>
                        <asp:ListItem Value="8" Text="" title="下"></asp:ListItem>
                        <asp:ListItem Value="9" Text="" title="右下"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存配置" OnClick="btnOk_Click" CssClass="submit">
                </asp:Button>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>上传的图片如超出设置的宽/高度，系统将自动进行等比压缩。</li>
            <li>请按照水印的类型提交相应项目，例如选择“图片”，则必须上传图片文件，否则当“未启用设置”。</li>
        </ul>
    </div>
</asp:Content>
