var curPlace = "AreaName";
var curObjId = "ChooseArea";
var curId = "areaId";
var curName = "area";
var curHtml = "选择地区";

var ulName = "";
var choosedName = ""
var bigListArray = null;

//调用弹出方法：
function ChooseArea() {
    showMsgBox('ChooseArea', 538, 366) //参数说明：层ID, 层宽度，层高度
}
function ResumeExport() {
    var list = document.getElementsByTagName("input");
    var ids = "";
    for (var i = 0; i < list.length; i++) {
        if (list[i].name == "ids" && list[i].type == "checkbox" && list[i].checked) {
            ids += "," + list[i].value;
        }
    }
    if (ids.length > 0) {
        ids = ids.substr(1);
    } else{
        alert("请选择简历");
        return;
    }
    showMsgBox('divExport', 538, 366);
    $.ajax({
        url: "MutiResuExport.aspx",
        data: "ids="+ids,
        cache: false,
        error: function() {
            alert("导出失败，请稍后再试！");
        },
        success: function(data) {
            if (data.substr(0, 1) == "0") {
                window.location = data.substr(1);
            } else {
                alert(data);
            }
        },
        complete: function() {
            closeWindow("divExport");
        }
    });
}
function AreaName(obj, areaid) {
    var AreaName = document.getElementById("AreaName");
    if (!AreaName) return false;
    AreaName.innerHTML = obj.innerHTML;
    document.getElementById("ctl00_cph1_txtAreaID").value = areaid;
    document.getElementById("ctl00_cph1_txtAreaName").value = obj.innerHTML;
    closeWindow("ChooseArea");
}
function ClearArea() {
    var AreaName = document.getElementById("AreaName");
    if (!AreaName) return false;
    AreaName.innerHTML = "选择地区";
    document.getElementById("ctl00_cph1_txtAreaID").value = "";
    document.getElementById("ctl00_cph1_txtAreaName").value = "";
    closeWindow("ChooseArea");
}
function overDetail(obj, num) {
    var strHtml = "";
    var objParent = obj.parentNode;
    var subArea = document.getElementById("subArea_" + num);
    if (!subArea) {
        subArea = document.createElement("div");
        subArea.id = "subArea_" + num;
        subArea.className = "subArea";
        if (!areas[num]) { return false; }
        strHtml += "<h4>" + obj.innerHTML + "</h4>"
        for (var i = 0; i < areas[num].length; i++) {
            var areaname = areas[num][i].substr(0, areas[num][i].indexOf('|'));
            var areaid = areas[num][i].substr(areas[num][i].indexOf('|') + 1, areas[num][i].length - areas[num][i].indexOf('|'));
            strHtml += "<span><a href='javascript:void(0);' onclick='AreaName(this," + areaid + ");'>" + areaname + "</a></span>";
        }
        subArea.innerHTML = strHtml;
        objParent.appendChild(subArea);

    }
    subArea.onmouseover = function() {
        this.parentNode.className = "relate cur";
        this.style.display = "block";
    }
    subArea.onmouseout = function() {
        this.parentNode.className = "";
        this.style.display = "none";
    }
    objParent.onmouseout = function() {
        this.className = "";
        subArea.style.display = "none";
    }
    objParent.className = "relate cur";
    subArea.style.display = "block";

}

//求职意向 地点
function ChooseArea2(obj, objId, id, name) {
    showMsgBox('ChooseArea2', 538, 522);
    curPlace = obj;
    curObjId = objId;
    curId = id;
    curName = name;
    ulName = "area2_ul";
    choosedName = "chooseArea";
    initArray("area_");
}

function ChooseMajor(obj, objId, id, name) {
    showMsgBox('ChooseMajor', 538, 522);
    curPlace = obj;
    curObjId = objId;
    curId = id;
    curName = name;
    ulName = "major2_ul";
    choosedName = "chooseMaj";
    initArray("chooseMaj_");
}

function initArray(preName) {
    $("#" + ulName).find("[id^='" + preName + "']").attr("checked", false);
    var idArray = document.getElementById(curId).value.split(";");
    var nameArray = document.getElementById(curName).value.split(";");
    var strHtml = "";
    for (var i = 0; i < idArray.length; i++) {
        if (idArray[i]) {
            strHtml += "<dd id='" + preName + idArray[i] + "'><input type='checkbox' checked='checked' value='" + nameArray[i] + "|" + idArray[i] + "' />" + nameArray[i] + "</dd>";
            $("#" + ulName).find("#" + preName + idArray[i]).attr("checked", true);
        }
    }
    $("#" + choosedName).html(strHtml);
    overBgColor(choosedName, "dd");
}

function confirmDate() {
    var strHtml = "", strId = "", strName = "";
    var obj = document.getElementById(choosedName);
    var inputArray = obj.getElementsByTagName("input");
    for (var i = 0, len = inputArray.length; i < len; i++) {
        strId += inputArray[i].value.substr(inputArray[i].value.indexOf('|') + 1) + ";";
        strName += inputArray[i].value.substr(0, inputArray[i].value.indexOf('|')) + ";";
        strHtml += inputArray[i].value.substr(0, inputArray[i].value.indexOf('|')) + "+";
    }
    if (strHtml.length > 0) {
        strId = strId.substr(0, strId.length - 1);
        strName = strName.substr(0, strName.length - 1);
        strHtml = strHtml.substring(0, strHtml.length - 1);
    }
    if (strHtml == "") { strHtml = "选择/修改" }
    curPlace.innerHTML = strHtml;
    curPlace.title = strHtml;
    document.getElementById(curId).value = strId;
    document.getElementById(curName).value = strName;
    closeWindow(curObjId);
}

function overAreaBgColor(objName, tagName) {
    var tagArray = $("#" + objName).find(tagName);
    for (var i = 0; i < tagArray.length; i++) {
        tagArray[i].order = i;
        tagArray[i].onmouseover = function() {
            changeCur(this.order, tagArray, true);
            overAreaBgColor(objName, tagName);
        }
        tagArray[i].onmouseout = function() {
            changeCur(this.order, tagArray, false);
            overAreaBgColor(objName, tagName);
        }
        tagArray[i].onclick = function() {
            chooseAreaInput(this, 1);
            overAreaBgColor(objName, tagName);
        }
    }
}

function changeCur(nowOrder, tagArray, bool) {
    if (bool) {
        tagArray[nowOrder].className = "cur";
    } else {
        tagArray[nowOrder].className = "";
    }
}

function delInput(tagId) {
    $("#" + ulName).find("#" + tagId).attr("checked", false);
    $("#" + choosedName).find("#" + tagId).remove();
}

function overDetail3(obj, num, subName, objArrays) {
    var strHtml = "";
    var isCheck = "";
    var objParent = obj.parentNode;
    if (!objArrays[num]) { return false; }
    isCheck = $("#" + choosedName).find("#area_" + num).length > 0 ? "checked=\"true\"" : "";
    strHtml += "<h4><a href='javascript:void(0)' title='点击为本类'  onclick=\"chooseAreaInput(this,1);\"><input type='checkbox' id='area_" + num + "' value='" + $.trim(obj.innerHTML) + "|" + num + "' " + isCheck + " onclick='this.checked=!this.checked;'/>" + $.trim(obj.innerHTML) + "</a></h4>";
    for (var i = 0; i < objArrays[num].length; i++) {
        var objname = objArrays[num][i].substr(0, objArrays[num][i].indexOf('|'));
        var objid = objArrays[num][i].substr(objArrays[num][i].indexOf('|') + 1, objArrays[num][i].length - objArrays[num][i].indexOf('|'));
        isCheck = $("#" + choosedName).find("#area_" + objid).length > 0 ? "checked=\"true\"" : "";
        strHtml += "<span><a href='javascript:void(0);' onclick=\"chooseAreaInput(this,1);\"><input type='checkbox' id='area_" + objid + "' value='" + objArrays[num][i] + "' " + isCheck + " onclick='this.checked=!this.checked;'/>" + objname + "</a></span>";
    }
    var subArea = document.getElementById(subName + num);
    if (!subArea) {
        subArea = document.createElement("div");
        subArea.id = subName + num;
        subArea.className = "subArea";
        subArea.innerHTML = strHtml;
        objParent.appendChild(subArea);

        subArea.onmouseover = function() {
            this.parentNode.className = "relate cur";
            this.style.display = "block";
        }
        subArea.onmouseout = function() {
            this.parentNode.className = "";
            this.style.display = "none";
        }
        objParent.onmouseout = function() {
            this.className = "";
            subArea.style.display = "none";
        }
    } else {
        subArea.innerHTML = strHtml;
    }

    objParent.className = "relate cur";
    subArea.style.display = "block";
}

function chooseAreaInput(obj, isfloat) {
    var checkObj = obj.getElementsByTagName("input")[0];
    var chooseObj = document.getElementById(choosedName);
    var objParent = obj.parentNode;
    var ddArray = chooseObj.getElementsByTagName("dd");
    var divObj = objParent.parentNode;
    bigList = divObj.parentNode.parentNode.getElementsByTagName("input");
    var spanArrays = divObj.getElementsByTagName("span");
    var h4Obj = divObj.getElementsByTagName("h4")[0];
    if (isfloat) {
        debugger;
        if (objParent.tagName == "H4") {//当地点为小类时
            checkObj.checked = checkObj.checked == true ? false : true;
            bigListArray = spanArrays;
            for (var q = 0, len = spanArrays.length; q < len; q++) {
                if (spanArrays[q].getElementsByTagName("input")[0].checked == true) {
                    delInput(spanArrays[q].getElementsByTagName("input")[0].id);
                    spanArrays[q].getElementsByTagName("input")[0].checked = false;
                }
            }
        } else if (objParent.tagName == "DL") {
            delInput(obj.id);
            overAreaBgColor(choosedName, "dd");
            return;
        } else {//当为具体地点时
            checkObj.checked = checkObj.checked == true ? false : true;
            if (objParent.tagName == "SPAN") {
                bigListArray = ddArray;
            } else {
                bigListArray = h4Obj;
            }
            if (h4Obj.getElementsByTagName("input")[0].checked == true) {
                delInput(h4Obj.getElementsByTagName("input")[0].id);
                h4Obj.getElementsByTagName("input")[0].checked = false;
            }
        }
    } else {
        checkObj.checked = checkObj.checked == true ? false : true;
        delInput("area_" + checkObj.value.split("|")[2]);
    }

    if (checkObj.checked) {
        if (ddArray.length < 3) {//当DD节点小于5时，增加DD
            var ddObj = document.createElement("dd");
            ddObj.id = checkObj.id;
            ddObj.innerHTML = checkObj.parentNode.innerHTML;
            ddObj.getElementsByTagName("input")[0].checked = true;
            if (!isfloat) {
                ddObj.getElementsByTagName("input")[0].value = checkObj.value.substr(0, checkObj.value.lastIndexOf("|"));
            }
            chooseObj.appendChild(ddObj);
            ddObj.style.cursor = "pointer";
            ddObj.style.overflow = "hidden";
            $("#" + ulName).find("#" + checkObj.id).attr("checked", true);
        } else {
            alert("您最多只能选三项！");
            checkObj.checked = false;
        }
    } else {
        delInput(checkObj.id);
    }
    overAreaBgColor(choosedName, "dd");
}

//求职意向 行业
function ChooseIndustry2(obj, objId, id, name) {
    showMsgBox('ChooseIndustry2', 538, 522);
    curPlace = obj;
    curObjId = objId;
    curId = id;
    curName = name;
    ulName = "industry2_ul";
    choosedName = "industry_choosed";
    initArray("industry_");
}

function myfun(objName, tagName) {
    overBgColor(objName, tagName);
}

function overBgColor(objName, tagName) {
    var tagArray = $("#" + objName).find(tagName);
    for (var i = 0; i < tagArray.length; i++) {
        tagArray[i].order = i;
        tagArray[i].onmouseover = function() {
            changeCur(this.order, tagArray, true);
            overBgColor(objName, tagName);
        }
        tagArray[i].onmouseout = function() {
            changeCur(this.order, tagArray, false);
            overBgColor(objName, tagName);
        }
        tagArray[i].onclick = function() {
            selectState(this.order, choosedName, tagArray)
            overBgColor(objName, tagName);
        }
    }
}

function selectState(nowOrder, choosedName, tagArray) {
    var choosedObj = $("#" + choosedName);
    var ddArray = choosedObj.find("dd");
    if (tagArray[nowOrder].tagName == "LI") {
        var checkObj = tagArray[nowOrder].getElementsByTagName("input")[0];
        if (checkObj.type == "checkbox") {
            checkObj.checked = checkObj.checked == true ? false : true;
            var strhtm = "";
            if (checkObj.checked) {
                if (ddArray.length < 3) {
                    strhtm = "<dd id='" + checkObj.id + "'><input type='checkbox' checked='checked' value='" + checkObj.value + "' />" + checkObj.value.substr(0, checkObj.value.indexOf("|")) + "</dd>";
                    choosedObj.append(strhtm);
                } else {
                    alert("您最多只能选三项！");
                    checkObj.checked = false;
                }
            } else {
                $("#" + choosedName).find("#" + checkObj.id).remove();
            }
            overBgColor(choosedName, "dd");
        }
    } else if (tagArray[nowOrder].tagName == "DD") {
        delInput(tagArray[nowOrder].id);
    } else {
        return false;
    }
}

function overDetail2(obj, num, subName, objArrays) {
    var strHtml = "";
    var isCheck = "";
    var objParent = obj.parentNode;
    if (!objArrays[num]) { return false; }
    isCheck = $("#" + choosedName).find("#chooseMaj_" + num).length > 0 ? "checked=\"true\"" : "";
    strHtml += "<h4><a href='javascript:void(0)' title='点击为本类'  onclick=\"chooseMaj(this,'chooseMaj');\"><input type='checkbox' name='chooseMaj_" + num + "' value='" + $.trim(obj.innerHTML) + "|" + num + "' " + isCheck + " onclick='this.checked=!this.checked;' />" + $.trim(obj.innerHTML) + "</a></h4>";
    for (var i = 0; i < objArrays[num].length; i++) {
        var objname = objArrays[num][i].substr(0, objArrays[num][i].indexOf('|'));
        var objid = objArrays[num][i].substr(objArrays[num][i].indexOf('|') + 1, objArrays[num][i].length - objArrays[num][i].indexOf('|'));
        isCheck = $("#" + choosedName).find("#chooseMaj_" + objid).length > 0 ? "checked=\"true\"" : "";
        strHtml += "<span><a href='javascript:void(0);' onclick=\"chooseMaj(this,'chooseMaj');\" title='" + objname + "'><input type='checkbox' name='chooseMaj_" + objid + "' value='" + objArrays[num][i] + "' " + isCheck + " onclick='this.checked=!this.checked;' />" + objname + "</a></span>";
    }
    var subArea = document.getElementById(subName + num);
    if (!subArea) {
        subArea = document.createElement("div");
        subArea.id = subName + num;
        subArea.className = "subArea";
        subArea.innerHTML = strHtml;
        objParent.appendChild(subArea);

        subArea.onmouseover = function() {
            this.parentNode.className = "relate cur";
            this.style.display = "block";
        }
        subArea.onmouseout = function() {
            this.parentNode.className = "";
            this.style.display = "none";
        }
        objParent.onmouseout = function() {
            this.className = "";
            subArea.style.display = "none";
        }
    } else {
        subArea.innerHTML = strHtml;
    }

    objParent.className = "relate cur";
    subArea.style.display = "block";
}

function chooseMaj(obj, chosedName) {
    var checkObj = obj.getElementsByTagName("input")[0];
    var choseObj = document.getElementById(chosedName);
    var objParent = obj.parentNode;
    var divObj = objParent.parentNode;

    bigList = divObj.parentNode.parentNode.getElementsByTagName("input");
    var spanArrays = divObj.getElementsByTagName("span");
    var h4Obj = divObj.getElementsByTagName("h4")[0];
    var ddArray = choseObj.getElementsByTagName("dd");
    if (objParent.tagName == "H4") {//当职能为小类时
        checkObj.checked = checkObj.checked == true ? false : true;
        bigListArray = spanArrays;
        for (var q = 0, len = spanArrays.length; q < len; q++) {
            if (spanArrays[q].getElementsByTagName("input")[0].checked == true) {
                delInput(spanArrays[q].getElementsByTagName("input")[0].name);
                spanArrays[q].getElementsByTagName("input")[0].checked = false;
            }
        }
    } else if (objParent.tagName == "DL") {
        delInput(obj.id);
        overMajorBgColor(choosedName, "dd");
        return;
    } else {//当职能为具体职位时
        checkObj.checked = checkObj.checked == true ? false : true;
        if (objParent.tagName == "SPAN") {
            bigListArray = ddArray;
        } else {
            bigListArray = h4Obj;
        }
        if (h4Obj.getElementsByTagName("input")[0].checked == true) {
            delInput(h4Obj.getElementsByTagName("input")[0].name);
            h4Obj.getElementsByTagName("input")[0].checked = false;
        }
    }

    if (checkObj.checked) {
        if (ddArray.length < 5) {//当DD节点小于5时，增加DD
            var ddObj = document.createElement("dd");
            ddObj.id = checkObj.name;
            ddObj.innerHTML = checkObj.parentNode.innerHTML;
            ddObj.getElementsByTagName("input")[0].checked = true;
            choseObj.appendChild(ddObj);
        } else {//大于5时提示最多只能选五项，并把勾取消
            alert("您最多只能选五项！");
            checkObj.checked = false;
        }
    } else {
        //删除DD节点
        var checkObj = document.getElementById(checkObj.name);
        if (checkObj) {
            choseObj.removeChild(checkObj);
        }
    }
    overMajorBgColor(choosedName, "dd");
}

function overMajorBgColor(objName, tagName) {
    var tagArray = $("#" + objName).find(tagName);
    for (var i = 0; i < tagArray.length; i++) {
        tagArray[i].order = i;
        tagArray[i].onmouseover = function() {
            changeCur(this.order, tagArray, true);
            overPositionBgColor(objName, tagName);
        }
        tagArray[i].onmouseout = function() {
            changeCur(this.order, tagArray, false);
            overPositionBgColor(objName, tagName);
        }
        tagArray[i].onclick = function() {
            choosePos(this, choosedName);
            overPositionBgColor(objName, tagName);
        }
    }
}

//弹出页面背景半透明======================================================================
var isIe = (document.all) ? true : false;

//设置select的可见状态
function setSelectState(state) {
    var objl = document.getElementsByTagName('select');
    for (var i = 0; i < objl.length; i++) {
        objl[i].style.visibility = state;
    }
}

//弹出方法
function showMsgBox(divID, wWidth, wHeight) {
    var bWidth = parseInt(document.documentElement.scrollWidth);
    var bHeight = parseInt(document.documentElement.scrollHeight);

    var scrollTop = document.documentElement.scrollTop || window.pageYOffset; 	//兼容chrome、safari : 20090708
    if (!scrollTop)
        scrollTop = 0;
    var sWidth = parseInt((document.documentElement.scrollWidth - wWidth) / 2);
    var sHeight = parseInt(scrollTop + (document.documentElement.clientHeight - wHeight) / 2);
    if (sHeight < 0) {
        sHeight = 0;
    }
    if (isIe) {
        setSelectState('hidden');
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

function showBackground(obj, endInt) {
    obj.filters.alpha.opacity += 1;
    if (obj.filters.alpha.opacity < endInt) {
        setTimeout(function() { showBackground(obj, endInt) }, 8);
    }
}
//关闭窗口
function closeWindow(Obj) {
    if (document.getElementById('back') != null) {
        document.getElementById('back').parentNode.removeChild(document.getElementById('back'));
    }

    document.getElementById(Obj).style.display = "none";

    if (isIe) {
        setSelectState('');
    }
}

function checksearchform() {
    var error = true;
    $("[id^='Error_']").hide();
    var no = $.trim($("#no").val());
    var agefrom = $.trim($("#agefrom").val());
    var ageto = $.trim($("#ageto").val());
    var saleryfrom = $.trim($("#saleryfrom").val());
    var saleryto = $.trim($("#saleryto").val());
    if (no != "" && !isInt(no)) {
        $("#Error_no").show();
        error = false;
    }
    if (agefrom != "" && !isInt(agefrom)) {
        $("#Error_age").show();
        error = false;
    }
    if (ageto != "" && !isInt(ageto)) {
        $("#Error_age").show();
        error = false;
    }
    return error;
}

function resumesearch() {
    if (checksearchform()) {
        var url = "ResumeSearch.aspx";
        url += "?no=" + $.trim($("#no").val());
        url += "&type=" + $("#type").val();
        url += "&key=" + encodeURIComponent($.trim($("#key").val()));
        url += "&addressid=" + $.trim($("#addressid").val());
        url += "&address=" + encodeURIComponent($.trim($("#address").val()));
        url += "&industryid=" + $.trim($("#industryid").val());
        url += "&industry=" + encodeURIComponent($.trim($("#industry").val()));
        url += "&workfrom=" + $("#workfrom").val();
        url += "&workto=" + $("#workto").val();
        url += "&edufrom=" + $("#edufrom").val();
        url += "&eduto=" + $("#eduto").val();
        url += "&agefrom=" + $.trim($("#agefrom").val());
        url += "&ageto=" + $.trim($("#ageto").val());
        url += "&sex=" + $("#sex").val();
        url += "&saleryfrom=" + $("#saleryfrom").val();
        url += "&saleryto=" + $("#saleryto").val();
        url += "&majorid=" + $.trim($("#majorid").val());
        url += "&major=" + encodeURIComponent($.trim($("#major").val()));
        url += "&update=" + $("#update").val();
        window.location = url;
    } else {
        return false;
    }
}

//验证数字类型
function isInt(obj) {
    if (obj == "") {
        return false;
    }
    slen = obj.length;
    for (i = 0; i < slen; i++) {
        cc = obj.charAt(i);
        if (cc < "0" || cc > "9") {
            return false;
        }
    }
    return true;
}

