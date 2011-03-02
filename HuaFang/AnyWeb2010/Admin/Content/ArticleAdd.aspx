<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="ArticleAdd.aspx.cs" Inherits="Admin_ArticleAdd" %>

<%@ Register Src="~/Admin/Control/TagSelect.ascx" TagName="TagSelect" TagPrefix="uc1" %>
<%@ Register Src="~/Admin/Control/Uploader.ascx" TagName="Uploader" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <iframe style="width: 0px; height: 0px;" id="ifrSelf" name="ifrSelf"></iframe>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
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
    </style>

    <script type="text/javascript">
        var child = new Array;
        <asp:Literal ID="litJs" runat="server"></asp:Literal>
        function columnChange(){
            var i, index;
            index = document.getElementById("<%=drpColumn.ClientID %>").selectedIndex;
            var objChild = document.getElementById("drpChild");
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
         $(document).ready(function() {
            columnChange();
        });
        
        function typeChange(obj){
            switch(obj){
                case "0":
                    $("#div0").show();
                    $("#div1").hide();
                    $("#div2").hide();
                    break;
                case "1":
                    $("#div1").show();
                    $("#div0").hide();
                    $("#div2").hide();
                    break;
                case "2":
                    $("#div2").show();
                    $("#div0").hide();
                    $("#div1").hide();
                    break;
            }
        }
        
        function uploadPictures() {
            $("#divUpload").show(); 
        }
        
        function setPicture(path){
            if(path.length>0){
                $("#img").attr("src",path).parent("li").show();
                $("#imgPath").val(path);
            }
            $("#divUpload").hide(); 
        }
        
        function uploadPicList(obj){
            $("#"+obj).show();
        }
        
        function setPicList(path){
            if(path.length>0){
                var allPath=path.split(",");
                for(var i=0;i<allPath.length;i++){
                    $("#imgList_demo ul li").clone().insertAfter("#imgList ul li:last");
                    $("#imgList ul li:last img").attr("src", allPath[i]);
                    $("#imgList ul li:last input").attr("value", allPath[i]);
                }
            }
            $("#divList").hide();
        }
        
        function setCatWalk(path){
            if(path.length>0){
                var allPath=path.split(",");
                for(var i=0;i<allPath.length;i++){
                    $("#CatWalk_demo ul li").clone().insertAfter("#CatWalkList ul li:last");
                    $("#CatWalkList ul li:last img").attr("src", allPath[i]);
                    $("#CatWalkList ul li:last input").attr("value", allPath[i]);
                }
            }
            $("#divCatWalk").hide();
        }
        
        function setBackStage(path){
            if(path.length>0){
                var allPath=path.split(",");
                for(var i=0;i<allPath.length;i++){
                    $("#BackStage_demo ul li").clone().insertAfter("#BackStageList ul li:last");
                    $("#BackStageList ul li:last img").attr("src", allPath[i]);
                    $("#BackStageList ul li:last input").attr("value", allPath[i]);
                }
            }
            $("#divBackStage").hide();
        }
        
        function setCloseUp(path){
            if(path.length>0){
                var allPath=path.split(",");
                for(var i=0;i<allPath.length;i++){
                    $("#CloseUp_demo ul li").clone().insertAfter("#CloseUpList ul li:last");
                    $("#CloseUpList ul li:last img").attr("src", allPath[i]);
                    $("#CloseUpList ul li:last input").attr("value", allPath[i]);
                }
            }
            $("#divCloseUp").hide();
        }
        
        function delPicture(obj) {
            if(obj){
                $(obj).parent("li").remove();
            }else{
                $("#imgPath").val("");
                $("#img").attr("src","").parent("li").hide();
            }
        }
    </script>

    <div class="Mod Form MainForm" id="InfoEdit">
        <div class="mhd">
            <h3>
                添加文章</h3>
        </div>
        <div class="mbd">
            <div class="fi">
                <label>
                    所属栏目：</label>
                <asp:DropDownList ID="drpColumn" DataTextField="fdColuName" DataValueField="fdColuID"
                    runat="server" onchange="columnChange()">
                </asp:DropDownList>
                <select id="drpChild" name="drpChild">
                </select>
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
                    <a href="javascript:void(0);" onclick="uploadPictures();" class="choAreabtn" title="上传/修改图片">
                        上传/修改图片</a>
                    <div id="divUpload" style="display: none;">
                        <uc1:Uploader FilePath="/Files/Articles/" Multiselect="false" MaxNumberToUpload="1"
                            JavascriptReturnFunction="setPicture" runat="server" />
                    </div>
                    <span id="results"></span>
                    <div class="images">
                        <ul>
                            <li style="display: none;">
                                <img id="img" src="" alt="" />
                                <button type="button" onclick="delPicture();">
                                    删除</button>
                            </li>
                        </ul>
                        <input type="hidden" id="imgPath" name="imgPath" value="" />
                    </div>
                </div>
            </div>
            <div class="fi">
                <label>
                    文章摘要：</label>
                <div class="cont">
                    <asp:TextBox ID="txtDesc" TextMode="MultiLine" Width="400px" Height="150px" runat="server"></asp:TextBox>
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
                        图片列表：</label>
                    <div class="cont">
                        <a href="javascript:void(0);" id="A1" onclick="uploadPicList('divList');" class="choAreabtn"
                            title="上传/修改图片">上传/修改图片</a>
                        <div id="divList" style="display: none">
                            <uc1:Uploader ID="Uploader1" FilePath="/Files/Articles/" JavascriptReturnFunction="setPicList"
                                runat="server" />
                        </div>
                        <div id="imgList_demo" style="display: none;">
                            <ul>
                                <li>
                                    <img alt="" src="" /><input type="hidden" name="pics" value="" />
                                    <button onclick="delPicture(this);" type="button">
                                        删除</button></li>
                            </ul>
                        </div>
                        <div id="imgList" class="images">
                            <ul>
                                <li style="display: none;"></li>
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
                        CatWalk：</label>
                    <div class="cont">
                        <a href="javascript:void(0);" onclick="uploadPicList('divCatWalk');" class="choAreabtn"
                            title="上传/修改图片">上传/修改图片</a>
                        <div id="divCatWalk" style="display: none">
                            <uc1:Uploader ID="Uploader2" FilePath="/Files/Articles/" JavascriptReturnFunction="setCatWalk"
                                runat="server" />
                        </div>
                        <div id="CatWalk_demo" style="display: none;">
                            <ul>
                                <li>
                                    <img alt="" src="" /><input type="hidden" name="CatWalkPics" value="" />
                                    <button onclick="delPicture(this);" type="button">
                                        删除</button></li>
                            </ul>
                        </div>
                        <div id="CatWalkList" class="images">
                            <ul>
                                <li style="display: none;"></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="fi even">
                    <label>
                        BackStage：</label>
                    <div class="cont">
                        <a href="javascript:void(0);" onclick="uploadPicList('divBackStage');" class="choAreabtn"
                            title="上传/修改图片">上传/修改图片</a>
                        <div id="divBackStage" style="display: none">
                            <uc1:Uploader ID="Uploader3" FilePath="/Files/Articles/" JavascriptReturnFunction="setBackStage"
                                runat="server" />
                        </div>
                        <div id="BackStage_demo" style="display: none;">
                            <ul>
                                <li>
                                    <img alt="" src="" /><input type="hidden" name="BackStagePics" value="" />
                                    <button onclick="delPicture(this);" type="button">
                                        删除</button></li>
                            </ul>
                        </div>
                        <div id="BackStageList" class="images">
                            <ul>
                                <li style="display: none;"></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="fi">
                    <label>
                        Close-Up：</label>
                    <div class="cont">
                        <a href="javascript:void(0);" onclick="uploadPicList('divCloseUp');" class="choAreabtn"
                            title="上传/修改图片">上传/修改图片</a>
                        <div id="divCloseUp" style="display: none">
                            <uc1:Uploader ID="Uploader4" FilePath="/Files/Articles/" JavascriptReturnFunction="setCloseUp"
                                runat="server" />
                        </div>
                        <div id="CloseUp_demo" style="display: none;">
                            <ul>
                                <li>
                                    <img alt="" src="" /><input type="hidden" name="CloseUpPics" value="" />
                                    <button onclick="delPicture(this);" type="button">
                                        删除</button></li>
                            </ul>
                        </div>
                        <div id="CloseUpList" class="images">
                            <ul>
                                <li style="display: none;"></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div class="fi">
                <label>
                    文章标签：</label>
                <div class="cont">
                    <a href="javascript:void(0);" id="btnTag" onclick="ChooseTag();" class="choAreabtn"
                        title="选择/修改">选择/修改</a> <span>使用逗号分隔不同标签, 最多可输入5个。</span>
                    <input type="hidden" id="tags" name="tags" value="" />
                </div>
            </div>
            <div class="fi even">
                <label>
                    文章排序：</label>
                <asp:TextBox ID="txtSort" runat="server" Text="0" CssClass="text" Width="80"></asp:TextBox>
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
                <a href="ArticleList.aspx">返回列表</a>
            </div>
        </div>
        <div class="mft">
        </div>
    </div>
    <div>
        <ul class="Help">
            <li>文章排序为“0”时将由系统自动生成。</li>
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
    </script>

</asp:Content>
