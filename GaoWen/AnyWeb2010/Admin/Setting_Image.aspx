<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="Setting_Image.aspx.cs" Inherits="Admin_Setting_Image" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <script type="text/javascript" src="../public/js/ajaxfileupload.js"></script>
    <script type="text/javascript">
        function uploadPictures() {
            $.ajaxFileUpload(
                   {
                       url: "WaterPictureUpload.aspx",            //需要链接到服务器地址
                       secureuri: false,
                       fileElementId: "<%=fileWater.ClientID%>",                        //文件选择框的id属性
                       dataType: 'script',                                     //服务器返回的格式，可以是json
                       success: function(data, status)            //相当于java中try语句块的用法
                       {
                           var r = data.toString();
                           var msg = r.substring(2);
                           if (r.substr(0, 1) == "0") {
                               $("#imgWater").attr("src", msg);
                               $("#imgUrl").attr("value", msg);
                               $("#images").show();
                               $('#results').html("上传成功");
                               $('#results').css("color", "green");
                           }
                           else {
                               $('#results').html(r.substring(2));
                               $('#results').css("color", "red");
                           }
                       },
                       error: function(data, status, e)            //相当于java中catch语句块的用法
                       {
                           $('#results').html('上传失败');
                           $('#results').css("color", "red");
                       }
                   }

               );
        }
        function delPicture(lnk) {
            var url = "WaterPictureDel.aspx?path=" + $("#imgUrl").val();
            $.get(url, "", function(htm) { });

            $("#images").hide();
            $("#imgColumn").attr("src", "");
            $("#imgUrl").attr("value", "");
        }
    </script>
    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                图片设置</h3>
        </div>
        <div class="mbd">
        <%--
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
            </div>--%>
            <div class="fi">
                <label>
                    栏目图片：</label>
                <div class="cont">
                    宽<asp:TextBox ID="txtColumnWidth" runat="server" MaxLength="4" CssClass="text" Width="50px"></asp:TextBox>像素,高<asp:TextBox
                        ID="txtColumnHeight" runat="server" MaxLength="4" CssClass="text" Width="50px"></asp:TextBox>像素
                    <sw:Validator ID="Validator1" ControlID="txtColumnWidth" ValidateType="Required" ErrorText="请输入栏目图片宽度"
                        ErrorMessage="请输入栏目图片宽度" runat="server">
                    </sw:Validator>
                    <sw:Validator ID="Validator2" ControlID="txtColumnHeight" ValidateType="Required" ErrorText="请输入栏目图片高度"
                        ErrorMessage="请输入栏目图片高度" runat="server">
                    </sw:Validator>
                </div>
            </div>
            <div class="fi even">
                <label>
                    幻灯片：</label>
                <div class="cont">
                    宽<asp:TextBox ID="txtFlashWidth" runat="server" MaxLength="4" CssClass="text" Width="50px"></asp:TextBox>像素,高<asp:TextBox
                        ID="txtFlashHeight" runat="server" MaxLength="4" CssClass="text" Width="50px"></asp:TextBox>像素
                    <sw:Validator ID="Validator8" ControlID="txtFlashWidth" ValidateType="Required" ErrorText="请输入幻灯图片宽度"
                        ErrorMessage="请输入幻灯图片宽度" runat="server">
                    </sw:Validator>
                    <sw:Validator ID="Validator9" ControlID="txtFlashHeight" ValidateType="Required" ErrorText="请输入幻灯图片高度"
                        ErrorMessage="请输入幻灯图片高度" runat="server">
                    </sw:Validator>
                </div>
            </div>
            <div class="fi">
                <label>
                    水印类型：</label>
                <div class="cont">
                    <asp:RadioButtonList ID="radioWaterType" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Value="0" Text="未启用"></asp:ListItem>
                        <asp:ListItem Value="1" Text="文字"></asp:ListItem>
                        <asp:ListItem Value="2" Text="图片"></asp:ListItem>                        
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="fi even">
                <label>
                    水印图片：</label>
                <div class="cont">
                    <asp:FileUpload ID="fileWater" runat="server" CssClass="text" />
                    <button onclick="uploadPictures()" style="height: 20px;" type="button">
                        上传图片</button>
                    <span id="results"></span>
                    <style type="text/css">
                        #images li
                        {
                            float: left;
                            margin-right: 8px;
                            margin-top: 8px;
                            text-align: center;
                            width: 100px;
                            height: 100px;
                            cursor: pointer;
                            border: 1px #ccc solid;
                        }
                        #images li.on
                        {
                            background: url(../public/images/goods_lst_bg.jpg);
                        }
                        #images li img
                        {
                            width: 70px;
                            height: 70px;
                            border: 0px solid #ccc;
                            margin-top: 5px;
                            margin-bottom: 4px;
                        }
                        #images li button
                        {
                            border: 0;
                            background: 0;
                            cursor: pointer;
                        }
                    </style>
                    <div id="images" style="display: <%=hasPic?"":"none"%>">
                        <ul>
                            <li>
                                <img id="imgWater" alt="" src="<%=picUrl %>" />
                                <input id="imgUrl" type="hidden" name="pics" value="<%=picUrl %>" />
                                <button onclick="delPicture(this);" type="button">
                                    删除</button></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="fi">
                <label>
                    水印文字：</label>
                <div class="cont">
                    <asp:TextBox ID="txtWaterText" runat="server" CssClass="text" MaxLength="100"></asp:TextBox>                    
                </div>
            </div>
            <div class="fi even">
                <label>
                    水印字体：</label>
                <div class="cont">
                    <asp:DropDownList ID="drpWaterFontFamily" runat="server">
                    </asp:DropDownList>
                    大小<asp:TextBox ID="txtWaterFontSize" runat="server" MaxLength="3" CssClass="text"
                        Width="80px"></asp:TextBox>像素
                    <sw:Validator ID="Validator7" ControlID="txtWaterFontSize" ValidateType="Required" ErrorText="请输入水印字体大小"
                        ErrorMessage="请输入水印字体大小" runat="server">
                    </sw:Validator>
                </div>
            </div>
            <div class="fi">
                <label>
                    文字形状：</label>
                <asp:DropDownList ID="drpFontCss" runat="server">
                    <asp:ListItem Text="粗体" Value="Bold"></asp:ListItem>
                    <asp:ListItem Text="下划线" Value="Underline"></asp:ListItem>
                    <asp:ListItem Text="斜体" Value="Italic"></asp:ListItem>
                    <asp:ListItem Text="中划线" Value="Strikeout"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="fi even">
                <label>
                    文字颜色：</label>
                <div class="cont">
                    <asp:TextBox ID="txtFontColor" runat="server"  MaxLength="7" Style="cursor:default" Width="35px" CssClass="text"></asp:TextBox>
                    <img id="Img1" alt="选择颜色" src="/public/images/color1.gif" border="0" title="选择颜色" onmouseover="src='/public/images/color2.gif'" onmouseout="src='/public/images/color1.gif'" Style="cursor: default; position: absolute;" onClick='SelectColor(<%=txtFontColor.UniqueID %>)' />
                </div>
            </div>
            <div class="fi">
                <label>
                    阴影颜色：</label>
                <asp:TextBox ID="txtShadowColor" runat="server"  MaxLength="7" Style="cursor:default" Width="35px" CssClass="text"></asp:TextBox>
                <img id="Img2" alt="选择颜色" src="/public/images/color1.gif" border="0" title="选择颜色" onmouseover="src='/public/images/color2.gif'" onmouseout="src='/public/images/color1.gif'" Style="cursor: default; position: absolute;" onClick='SelectColor(<%=txtShadowColor.UniqueID %>)' />
            </div>
            <div class="fi even">
                <label>
                    水印透明度：</label>
                <div class="cont">
                    <asp:TextBox ID="txtTransparency" runat="server" MaxLength="3" CssClass="text" Width="35px"></asp:TextBox>%
                    <sw:Validator ID="Validator6" ControlID="txtTransparency" ValidateType="Required" ErrorText="请输入水印透明度"
                        ErrorMessage="请输入水印透明度" runat="server">
                    </sw:Validator>
                </div>
            </div>
            <div class="fi">
                <label>
                    旋转角度：</label>
                <div class="cont">
                    <asp:TextBox ID="txtAngle" runat="server" MaxLength="3" CssClass="text" Width="35px"></asp:TextBox>
                    <sw:Validator ID="Validator5" ControlID="txtAngle" ValidateType="Required" ErrorText="请输入旋转角度"
                        ErrorMessage="请输入旋转角度" runat="server">
                    </sw:Validator>
                </div>                
            </div>
            <div class="fi even">
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
    <script type="text/javascript">
        function SelectColor(form) {
            var url = 'selcolor.aspx';    
            var arr = showModalDialog(url, window, 'dialogWidth:280px;dialogHeight:250px;help:no;scroll:no;status:no');
            if (arr) {
                form.value = arr;
                form.style.backgroundColor = arr;
                form.style.color = arr;
            }
        }
    </script>
</asp:Content>
