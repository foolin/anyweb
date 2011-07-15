<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="ArticleEdit.aspx.cs" Inherits="Admin_ArticleEdit" %>

<%@ Register Src="~/Admin/Control/TagSelect.ascx" TagName="TagSelect" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <iframe style="width: 0px; height: 0px;" id="ifrSelf" name="ifrSelf"></iframe>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">

    <script type="text/javascript" src="../js/jquery.ui.core.js"></script>

    <script type="text/javascript" src="../js/jquery.ui.widget.js"></script>

    <script type="text/javascript" src="../js/jquery.ui.mouse.js"></script>

    <script type="text/javascript" src="../js/jquery.ui.sortable.js"></script>

    <style type="text/css">
        .images li
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
        .images li.on
        {
            background: url(/admin/images/goods_lst_bg.jpg);
        }
        .images li img
        {
            width: 70px;
            height: 70px;
            border: 0px solid #ccc;
            margin-top: 5px;
            margin-bottom: 4px;
        }
        .images li button
        {
            border: 0;
            background: 0;
        }
        .imagelist li
        {
            height: 150px;
        }
    </style>

    <script type="text/javascript">
        var child = new Array;
        <asp:Literal ID="litJs" runat="server"></asp:Literal>
        function columnChange(){
            var i, index;
            index = document.getElementById("<%=drpColumn.ClientID %>").selectedIndex;
            var objChild = document.getElementById("<%=drpChild.ClientID %>");
            var iCount = child[index].length;
            for (i = objChild.options.length - 1; i >= 0; i--) {
                objChild.remove(i);
            }
            var option = document.createElement("OPTION");
            option.value = "0";
            option.text = "不选择二级栏目";
            objChild.options.add(option);
            for (i = 0; i <= iCount - 1; i++) {
                var option = document.createElement("OPTION");
                option.value = child[index][i].substring(0,child[index][i].indexOf(":"));
                option.text = child[index][i].substring(child[index][i].indexOf(":")+1,child[index][i].length);
                objChild.options.add(option);
            }
        }
        
        function typeChange(obj){
            switch(obj){
                case "0":
                    $("#div0").show();
                    $("#div1").hide();
                    $("#div2").hide();
                    $("#divTag").attr("class","fi");
                    $("#divSort").attr("class","fi even");
                    break;
                case "1":
                    $("#div1").show();
                    $("#div0").hide();
                    $("#div2").hide();
                    $("#divTag").attr("class","fi even");
                    $("#divSort").attr("class","fi");
                    break;
                case "2":
                    $("#div2").show();
                    $("#div0").hide();
                    $("#div1").hide();
                    $("#divTag").attr("class","fi even");
                    $("#divSort").attr("class","fi");
                    break;
            }
        }
        
        function setPicture(path){
            if(path.length>0){
                path = "/Files/Articles/" + path;
                $("#img").attr("src",path).parent("li").show();
                $("#imgPath").val(path);
            }
        }
        
        function setPicList(path){
            if(path.length>0){
                var allPath=path.split(",");
                for(var i=0;i<allPath.length;i++){
                    var iPath = "/Files/Articles/" + allPath[i];
                    $("#imgList_demo ul li").clone().insertAfter("#imgList ul li:last");
                    $("#imgList ul li:last img").attr("src", iPath);
                    $("#imgList ul li:last input").attr("value", iPath);
                }
                sortBind("imgList");
                setDesc($("#<%=chkDesc.ClientID %>").attr("checked"));
            }
        }
        
        function setCatWalk(path){
            if(path.length>0){
                var allPath=path.split(",");
                for(var i=0;i<allPath.length;i++){
                    var iPath = "/Files/Articles/" + allPath[i];
                    $("#CatWalk_demo ul li").clone().insertAfter("#CatWalkList ul li:last");
                    $("#CatWalkList ul li:last img").attr("src", iPath);
                    $("#CatWalkList ul li:last input").attr("value", iPath);
                }
                sortBind("CatWalkList");
            }
        }
        
        function setBackStage(path){
            if(path.length>0){
                var allPath=path.split(",");
                for(var i=0;i<allPath.length;i++){
                    var iPath = "/Files/Articles/" + allPath[i];
                    $("#BackStage_demo ul li").clone().insertAfter("#BackStageList ul li:last");
                    $("#BackStageList ul li:last img").attr("src", iPath);
                    $("#BackStageList ul li:last input").attr("value", iPath);
                }
                sortBind("BackStageList");
            }
        }
        
        function setCloseUp(path){
            if(path.length>0){
                var allPath=path.split(",");
                for(var i=0;i<allPath.length;i++){
                    var iPath = "/Files/Articles/" + allPath[i];
                    $("#CloseUp_demo ul li").clone().insertAfter("#CloseUpList ul li:last");
                    $("#CloseUpList ul li:last img").attr("src", iPath);
                    $("#CloseUpList ul li:last input").attr("value", iPath);
                }
                sortBind("CloseUpList");
            }
        }
        
        function setFrontRow(path){
            if(path.length>0){
                var allPath=path.split(",");
                for(var i=0;i<allPath.length;i++){
                    var iPath = "/Files/Articles/" + allPath[i];
                    $("#FrontRow_demo ul li").clone().insertAfter("#FrontRowList ul li:last");
                    $("#FrontRowList ul li:last img").attr("src", iPath);
                    $("#FrontRowList ul li:last input").attr("value", iPath);
                }
                sortBind("FrontRowList");
            }
        }
        
        function delPicture(obj) {
            if(confirm("确定要删除图片？")){
                if(obj){
                    $(obj).parent("li").remove();
                }else{
                    $("#imgPath").val("");
                    $("#img").attr("src","").parent("li").hide();
                }
            }
        }
        
        function sortBind(obj){
            $("#"+obj+" ul").sortable({
                items: '> li',
                handle: 'img.imglistmove',
                cursor: 'move',
                appendTo: 'body',
                start: function(e, ui) {
                    ui.helper.css("width", ui.item.width());
                },
                update: function(e, ui) {
                    if (ui.sender) {
                        var w = ui.element.width();
                        ui.placeholder.width(w);
                        ui.helper.css("width", ui.element.children().width());
                    }
                }
            });
        }
        
        function setDesc(checked){
            if(checked){
               $("#imgList textarea").hide();
               $("#imgList").removeClass("imagelist");
            }else{
                $("#imgList textarea").show();
                $("#imgList").addClass("imagelist");
            }
        }
        
        function setFlash(path) {
            if (path) {
                $("#flashLink").attr("href", "/Files/Articles/" + path);
                $("#txtflash").val("/Files/Articles/" + path);
                $("#flashLink").show();
            }
        }
        
        function delFlash(){
            if (confirm("确定删除该视频？")) {
                $("#flashLink").attr("href", "");
                $("#txtflash").val("");
                $("#flashLink").hide();
            }
            return false;
        }
    </script>

    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                修改文章</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    所属栏目：</label>
                <asp:DropDownList ID="drpColumn" DataTextField="fdColuName" DataValueField="fdColuID"
                    runat="server" onchange="columnChange()">
                </asp:DropDownList>
                <asp:DropDownList ID="drpChild" runat="server">
                </asp:DropDownList>
            </div>
            <div class="fi even">
                <label>
                    文章类型：</label>
                <asp:DropDownList ID="drpType" runat="server" onchange="typeChange(this.value)">
                    <asp:ListItem Value="0" Text="普通文章"></asp:ListItem>
                    <asp:ListItem Value="1" Text="图片文章"></asp:ListItem>
                    <asp:ListItem Value="2" Text="专题文章"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="fi">
                <label>
                    文章标题：</label>
                <asp:TextBox ID="txtTitle" MaxLength="100" Width="400px" runat="server" CssClass="text"></asp:TextBox>
                <span class="required">*</span>
                <sw:Validator ID="Validator1" ControlID="txtTitle" ValidateType="Required" ErrorText="请输入标题"
                    ErrorMessage="请输入标题" runat="server">
                </sw:Validator>
            </div>
            <div class="fi even">
                <label>
                    文章图片：</label>
                <div class="cont">
                    <sw:Uploader ID="PicUploader" UploadPage="/Admin/Ajax/ArticlePicUpload.ashx" FilePath="/Files/Articles/"
                        MaxSizeToUpload="2097152" Filter="Images (*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp)|*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp"
                        JavascriptCompleteFunction="setPicture" MultiSelect="false" runat="server">
                    </sw:Uploader>
                    <div id="divUpload">
                    </div>
                    <span id="results"></span>
                    <div class="images">
                        <ul>
                            <li <%=string.IsNullOrEmpty(article.fdArtiPic)?"style=\"display: none;\"":"" %>>
                                <img id="img" src="<%=article.fdArtiPic %>" alt="" />
                                <button type="button" onclick="delPicture();">
                                    删除</button>
                            </li>
                        </ul>
                        <input type="hidden" id="imgPath" name="imgPath" value="<%=article.fdArtiPic %>" />
                    </div>
                </div>
            </div>
            <div class="fi">
                <label>
                    文章摘要：</label>
                <div class="cont">
                    <asp:TextBox ID="txtDesc" TextMode="MultiLine" Width="400px" Height="150px" runat="server"
                        CssClass="textarea"></asp:TextBox>
                    <span>文章摘要不得超过1000字,如果留空，系统自动生成摘要。</span>
                    <sw:Validator ID="Validator2" ControlID="txtDesc" ValidateType="MaxLength" MaxLength="1000"
                        ErrorText="文章摘要不得超过1000字" ErrorMessage="文章摘要不得超过1000字" runat="server">
                    </sw:Validator>
                </div>
            </div>
            <div id="div0">
                <div class="fi even">
                    <label>
                        文章内容：</label>
                    <div class="cont">
                        <asp:TextBox ID="txtContent" TextMode="MultiLine" Width="100%" Height="300px" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div id="div1" style="display: none">
                <div class="fi even">
                    <label>
                        图片描述：</label>
                    <div class="cont">
                        <asp:CheckBox ID="chkDesc" runat="server" Text="使用文章描述" CssClass="checkbox" onclick="setDesc(this.checked);" />
                    </div>
                </div>
                <div class="fi">
                    <label>
                        图片列表：</label>
                    <div class="cont">
                        <sw:Uploader ID="Uploader1" UploadPage="/Admin/Ajax/ArticlePicListUpload.ashx" FilePath="/Files/Articles/"
                            Filter="Images (*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp)|*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp"
                            JavascriptCompleteFunction="setPicList" MultiSelect="true" runat="server">
                        </sw:Uploader>
                        <div id="divList">
                        </div>
                        <div id="imgList_demo" style="display: none;">
                            <ul>
                                <li>
                                    <img class="imglistmove" alt="" src="" /><input type="hidden" name="pics" value="" />
                                    <button onclick="delPicture(this);" type="button">
                                        删除</button>
                                    <textarea name="txtPicDesc" style="width: 99px; height: 50px;"></textarea>
                                </li>
                            </ul>
                        </div>
                        <div id="imgList" class="images">
                            <ul>
                                <li style="display: none;"></li>
                                <asp:Repeater ID="repImgList" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <img class="imglistmove" alt="" src="<%#Eval("fdArPiPath") %>" /><input type="hidden"
                                                name="pics" value="<%#Eval("fdArPiID") %>:<%#Eval("fdArPiPath") %>" />
                                            <button onclick="delPicture(this);" type="button">
                                                删除</button>
                                            <textarea name="txtPicDesc" style="width: 99px; height: 50px;"><%#Eval( "fdArPiDesc" )%></textarea>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div id="div2" style="display: none">
                <div class="fi even">
                    <label>
                        文章内容：</label>
                    <div class="cont">
                        <asp:TextBox ID="txtContent2" TextMode="MultiLine" Width="100%" Height="300px" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="fi">
                    <label>
                        T台风云：</label>
                    <div class="cont">
                        <sw:Uploader ID="Uploader2" UploadPage="/Admin/Ajax/ArticlePicListUpload.ashx" FilePath="/Files/Articles/"
                            Filter="Images (*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp)|*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp"
                            JavascriptCompleteFunction="setCatWalk" MultiSelect="true" runat="server">
                        </sw:Uploader>
                        <div id="divCatWalk">
                        </div>
                        <div id="CatWalk_demo" style="display: none;">
                            <ul>
                                <li>
                                    <img class="imglistmove" alt="" src="" /><input type="hidden" name="CatWalkPics"
                                        value="" />
                                    <button onclick="delPicture(this);" type="button">
                                        删除</button></li>
                            </ul>
                        </div>
                        <div id="CatWalkList" class="images">
                            <ul>
                                <li style="display: none;"></li>
                                <asp:Repeater ID="repCatWalk" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <img class="imglistmove" alt="" src="<%#Eval("fdArPiPath") %>" /><input type="hidden"
                                                name="CatWalkPics" value="<%#Eval("fdArPiID") %>:<%#Eval("fdArPiPath") %>" />
                                            <button onclick="delPicture(this);" type="button">
                                                删除</button></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="fi even">
                    <label>
                        细节鉴赏：</label>
                    <div class="cont">
                        <sw:Uploader ID="Uploader4" UploadPage="/Admin/Ajax/ArticlePicListUpload.ashx" FilePath="/Files/Articles/"
                            Filter="Images (*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp)|*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp"
                            JavascriptCompleteFunction="setCloseUp" MultiSelect="true" runat="server">
                        </sw:Uploader>
                        <div id="divCloseUp">
                        </div>
                        <div id="CloseUp_demo" style="display: none;">
                            <ul>
                                <li>
                                    <img class="imglistmove" alt="" src="" /><input type="hidden" name="CloseUpPics"
                                        value="" />
                                    <button onclick="delPicture(this);" type="button">
                                        删除</button></li>
                            </ul>
                        </div>
                        <div id="CloseUpList" class="images">
                            <ul>
                                <li style="display: none;"></li>
                                <asp:Repeater ID="repCloseUp" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <img class="imglistmove" alt="" src="<%#Eval("fdArPiPath") %>" /><input type="hidden"
                                                name="CloseUpPics" value="<%#Eval("fdArPiID") %>:<%#Eval("fdArPiPath") %>" />
                                            <button onclick="delPicture(this);" type="button">
                                                删除</button></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="fi">
                    <label>
                        幕后花絮：</label>
                    <div class="cont">
                        <sw:Uploader ID="Uploader3" UploadPage="/Admin/Ajax/ArticlePicListUpload.ashx" FilePath="/Files/Articles/"
                            Filter="Images (*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp)|*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp"
                            JavascriptCompleteFunction="setBackStage" MultiSelect="true" runat="server">
                        </sw:Uploader>
                        <div id="divBackStage">
                        </div>
                        <div id="BackStage_demo" style="display: none;">
                            <ul>
                                <li>
                                    <img class="imglistmove" alt="" src="" /><input type="hidden" name="BackStagePics"
                                        value="" />
                                    <button onclick="delPicture(this);" type="button">
                                        删除</button></li>
                            </ul>
                        </div>
                        <div id="BackStageList" class="images">
                            <ul>
                                <li style="display: none;"></li>
                                <asp:Repeater ID="repBackStage" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <img class="imglistmove" alt="" src="<%#Eval("fdArPiPath") %>" /><input type="hidden"
                                                name="BackStagePics" value="<%#Eval("fdArPiID") %>:<%#Eval("fdArPiPath") %>" />
                                            <button onclick="delPicture(this);" type="button">
                                                删除</button></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="fi even">
                    <label>
                        前排景观：</label>
                    <div class="cont">
                        <sw:Uploader ID="Uploader5" UploadPage="/Admin/Ajax/ArticlePicListUpload.ashx" FilePath="/Files/Articles/"
                            Filter="Images (*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp)|*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp"
                            JavascriptCompleteFunction="setFrontRow" MultiSelect="true" runat="server">
                        </sw:Uploader>
                        <div id="divFrontRow">
                        </div>
                        <div id="FrontRow_demo" style="display: none;">
                            <ul>
                                <li>
                                    <img class="imglistmove" alt="" src="" /><input type="hidden" name="FrontRowPics"
                                        value="" />
                                    <button onclick="delPicture(this);" type="button">
                                        删除</button></li>
                            </ul>
                        </div>
                        <div id="FrontRowList" class="images">
                            <ul>
                                <li style="display: none;"></li>
                                <asp:Repeater ID="repFrontRow" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <img class="imglistmove" alt="" src="<%#Eval("fdArPiPath") %>" /><input type="hidden"
                                                name="FrontRowPics" value="<%#Eval("fdArPiID") %>:<%#Eval("fdArPiPath") %>" />
                                            <button onclick="delPicture(this);" type="button">
                                                删除</button></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="fi">
                    <label>
                        视频直击：</label>
                    <div class="cont">
                        <sw:Uploader ID="Uploader6" UploadPage="/Admin/Ajax/ArticleFlashUpload.ashx" FilePath="/Files/Articles/"
                            Filter="Flash (*.swf;*.flv)|*.swf;*.flv;" JavascriptCompleteFunction="setFlash"
                            MultiSelect="false" runat="server" Style="margin-left: 6px">
                        </sw:Uploader>
                        <a id="flashLink" href="<%=article.fdArtiFlashPath %>" target="_blank" title="右键删除视频" style="<%=string.IsNullOrEmpty( article.fdArtiFlashPath )?"display:none;": ""%>" oncontextmenu="return delFlash();">
                            <img src="../images/rar.gif" alt="" /></a>
                        <input type="hidden" id="txtflash" name="txtflash" value="<%=article.fdArtiFlashPath %>" />
                    </div>
                </div>
                <div class="fi even">
                    <label>
                        视频描述：</label>
                    <div class="cont">
                        <asp:TextBox ID="txtFlashDesc" TextMode="MultiLine" Width="400px" Height="150px"
                            runat="server"></asp:TextBox>
                        <span>视频描述不得超过400字。</span>
                        <sw:Validator ID="Validator5" ControlID="txtDesc" ValidateType="MaxLength" MaxLength="400"
                            ErrorText="视频描述不得超过400字" ErrorMessage="视频描述不得超过400字" runat="server">
                        </sw:Validator>
                    </div>
                </div>
                <div class="fi">
                    <label>
                        类别：</label>
                    <div class="cont">
                        <asp:DropDownList ID="drpCategory" runat="server">
                            <asp:ListItem Value="1" Text="男装"></asp:ListItem>
                            <asp:ListItem Value="2" Text="高级成衣"></asp:ListItem>
                            <asp:ListItem Value="3" Text="高级定制"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="fi even">
                    <label>
                        城市：</label>
                    <div class="cont">
                        <asp:DropDownList ID="drpCity" runat="server">
                            <asp:ListItem Value="1" Text="巴黎"></asp:ListItem>
                            <asp:ListItem Value="2" Text="米兰"></asp:ListItem>
                            <asp:ListItem Value="3" Text="伦敦"></asp:ListItem>
                            <asp:ListItem Value="4" Text="纽约"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="fi">
                    <label>
                        是否推荐：</label>
                    <div class="cont">
                        <asp:CheckBox ID="chkRecommend" runat="server" Text="推荐" CssClass="checkbox" />
                    </div>
                </div>
            </div>
            <div class="fi">
                <label>
                    文章标签：</label>
                <div class="cont">
                    <a href="javascript:void(0);" id="btnTag" onclick="ChooseTag();" class="choAreabtn"
                        title="<%=GetTags("选择/修改")%>">
                        <%=GetTags( "选择/修改" )%></a> <span>使用逗号分隔不同标签, 最多可输入5个。</span>
                    <input type="hidden" id="tags" name="tags" value="<%=GetTags("")%>" />
                </div>
            </div>
            <div class="fi even">
                <label>
                    文章排序：</label>
                <asp:TextBox ID="txtSort" runat="server" Text="0"></asp:TextBox>
                <span class="required">*</span> <span>排序数字越大，呈现位置越靠前。</span>
                <sw:Validator ID="Validator3" ControlID="txtSort" ValidateType="Required" ErrorText="请输入文章排序"
                    ErrorMessage="请输入文章排序" runat="server">
                </sw:Validator>
                <sw:Validator ID="Validator4" ControlID="txtSort" ValidateType="DataType" DataType="Integer"
                    ErrorText="请输入正确的文章排序" ErrorMessage="请输入正确的文章排序" runat="server">
                </sw:Validator>
            </div>
            <div class="fi fiBtns">
                <asp:Button ID="btnOk" runat="server" Text="保存" CssClass="submit" OnClick="btnOk_Click">
                </asp:Button>
                <a href="javascript:history.back();">返回列表</a>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li></li>
        </ul>
    </div>
    <uc1:TagSelect ID="TagSelect1" runat="server" />

    <script type="text/javascript" src="/tiny_mce/tiny_mce.js"></script>

    <script type="text/javascript">
        tinyMCE.init({
            mode: "exact",
            verify_html: false,
            elements: "<%=txtContent.ClientID%>,<%=txtContent2.ClientID %>",
            theme: "advanced",
            language: "zh",
            plugins: "safari,pagebreak,style,layer,table,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,profile,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,pageseparator,iboximage",
            content_css: "/tiny_mce/css/content.css",
            template_external_list_url: "/tiny_mce/lists/template_list.js",
            external_link_list_url: "/tiny_mce/lists/link_list.js",
            external_image_list_url: "/tiny_mce/lists/image_list.js",
            media_external_list_url: "/tiny_mce/lists/media_list.js",
            template_replace_values: {
                username: "Some User",
                staffid: "991234"
            }
        });
        typeChange($("#<%=drpType.ClientID %>").val());
        if ($("#<%=drpType.ClientID %>").val() == "1") {
            sortBind("imgList");
            setDesc($("#<%=chkDesc.ClientID %>").attr("checked"));
        } else if ($("#<%=drpType.ClientID %>").val() == "2") {
            sortBind("CatWalkList");
            sortBind("CloseUpList");
            sortBind("BackStageList");
            sortBind("FrontRowList");
        }
    </script>

</asp:Content>
