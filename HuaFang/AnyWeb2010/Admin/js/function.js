//弹出页面背景半透明======================================================================
var isIe = (document.all) ? true : false;

//弹出方法
function showMsgBox(divID, wWidth, wHeight) {
    var bWidth = parseInt(document.documentElement.scrollWidth);
    var bHeight = parseInt(document.documentElement.scrollHeight);
    if (bHeight < document.documentElement.offsetHeight) {
        bHeight = document.documentElement.offsetHeight;
    }

    var scrollTop = document.documentElement.scrollTop || window.pageYOffset; 	//兼容chrome、safari : 20090708
    if (!scrollTop)
        scrollTop = 0;
    var sWidth = parseInt((document.documentElement.scrollWidth - wWidth) / 2);
    var sHeight = parseInt(scrollTop + (document.documentElement.clientHeight - wHeight) / 2);
    if (sHeight < 0) {
        sHeight = 0;
    }
    var back = document.createElement("div");
    back.id = "back";
    var styleStr = "top:0px;left:0px;position:absolute;z-index:999;background:#666;width:" + bWidth + "px;height:" + bHeight + "px;";
    styleStr += (isIe) ? "filter:alpha(opacity=70);" : "opacity:0.70;";
    back.style.cssText = styleStr;
    back.innerHTML = "<div style=width:" + bWidth + "px;height:" + bHeight + "px; ></div>";
    document.body.appendChild(back);
    var mesW = document.getElementById(divID);
    styleStr = "left:" + sWidth + "px;top:" + sHeight + "px;width:" + wWidth + "px;position:absolute;z-index:1000;display:block;";
    mesW.style.cssText = styleStr;
}

//关闭窗口
function CloseWindow(Obj) {
    if ($("#back").length) {
        $("#back").remove();
    }
    $("#" + Obj).hide();
}

//调用弹出方法：
function ChooseTag() {
    $("#txtTag").val($.trim($("#tags").val()));
    showMsgBox("ChooseTag", 538, 255);
}

//添加标签
function AddTag(obj) {
    if (!CheckTags()) {
        alert("最多只允许设置5个标签！");
        return;
    }
    if ($.trim($("#txtTag").val()).length == 0) {
        $("#txtTag").val($.trim($(obj).html()));
    } else {
        $("#txtTag").val($("#txtTag").val() + "," + $.trim($(obj).html()));
    }
}

//检查标签个数
function CheckTags() {
    var index = 0;
    var tag = $("#txtTag").val().split(" ");
    for (var i = 0; i < tag.length; i++) {
        if (tag[i].length > 0) {
            index++;
        }
    }
    if (index <= 5) {
        return true;
    }
}

//设置标签
function SetTags() {
    var tags = new Array();
    var tagsTemp = $("#txtTag").val().split(",");
    for (var i = 0; i < tagsTemp.length; i++) {
        if (tagsTemp[i].length == 0) {
            continue;
        }
        var isExist = false;
        for (var j = 0; j < tags.length; j++) {
            if (tags[j] == tagsTemp[i]) {
                isExist = true;
                break;
            }
        }
        if (!isExist) {
            tags[tags.length] = tagsTemp[i];
        }
    }
    if (tags.length > 5) {
        alert("最多只允许设置5个标签！");
        return;
    }
    if (tags.length > 0) {
        $("#btnTag").html(tags.toString()).attr("title", tags.toString());
        $("#tags").val(tags.toString());
    } else {
        $("#btnTag").html("选择/修改").attr("title", "选择/修改");
        $("#tags").val("");
    }
    CloseWindow("ChooseTag");
}

//显示上传控件
function ShowUploader(parent, FilePath, JavascriptReturnFunction, Multiselect, MaxNumberToUpload) {
    var param = "";
    if (FilePath)
        param += ",FilePath=" + FilePath;
    if (JavascriptReturnFunction)
        param += ",JavascriptReturnFunction=" + JavascriptReturnFunction;
    if (Multiselect)
        param += ",Multiselect=True";
    if (MaxNumberToUpload > -1)
        param += ",MaxNumberToUpload=" + MaxNumberToUpload;

    var html = "\
    <object data=\"data:application/x-silverlight-2,\" type=\"application/x-silverlight-2\" width=\"500\" height=\"300\">\
        <param name=\"source\" value=\"/ClientBin/FileUpload.xap\" />\
        <param name=\"background\" value=\"white\" />\
        <param name=\"minRuntimeVersion\" value=\"3.0.40624.0\" />\
        <param name=\"autoUpgrade\" value=\"true\" />\
        <param name=\"initParams\" value=\"UploadPage=/Admin/FileUpload.ashx,Filter=Images (*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp)|*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp" + param + ",UploadChunkSize=102400\" />\
        <a href=\"http://go.microsoft.com/fwlink/?LinkID=124807\" style=\"text-decoration: none;\">\
            <img src=\"http://go.microsoft.com/fwlink/?LinkId=108181\" alt=\"Get Microsoft Silverlight\" style=\"border-style: none\" />\
        </a>\
    </object>\
    <iframe style='visibility: hidden; height: 0; width: 0; border: 0px'></iframe>";
    $("#" + parent).html(html);
}

function HideUploader(parent) {
    $("#" + parent).html("");
}