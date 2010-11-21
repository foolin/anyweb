var curPlace = "AreaName";
var curObjId = "ChooseArea";
var curId = "areaId";
var curName = "area";
var curHtml = "选择地区";

var ulName = "";
var choosedName = ""
var bigListArray = null;
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
    //closeWindow();

    var bWidth = parseInt(document.documentElement.scrollWidth);
    var bHeight = parseInt(document.documentElement.scrollHeight);

    var scrollTop = document.documentElement.scrollTop || window.pageYOffset; 	//兼容chrome、safari : 20090708
    if (!scrollTop)
        scrollTop = 0;
    var sWidth = parseInt((document.documentElement.scrollWidth - wWidth) / 2);
    var sHeight = parseInt(scrollTop + (document.documentElement.clientHeight - wHeight) / 2);
    if (isIe) {
        setSelectState('hidden');
    }
    var back = document.createElement("div");
    back.id = "back";
    var styleStr = "top:0px;left:0px;position:absolute;z-index:999;background:#666;width:" + bWidth + "px;height:" + bHeight + "px;";
    styleStr += (isIe) ? "filter:alpha(opacity=70);" : "opacity:0.70;";
    back.style.cssText = styleStr;
    back.innerHTML = "<div style=width:" + bWidth + "px;height:" + bHeight + "px; onclick=closeWindow(\'" + divID + "\');></div>";
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

//地区选择
function ChooseArea(obj, objId, id, name, html) {
    curPlace = obj;
    curObjId = objId;
    curId = id;
    curName = name;
    curHtml = html;
    showMsgBox(curObjId, 538, 366);
}

//专业选择
function ChooseMajor(obj, objId, id, name, html) {
    curPlace = obj;
    curObjId = objId;
    curId = id;
    curName = name;
    curHtml = html;
    showMsgBox(curObjId, 538, 210);
}

//行业选择
function ChooseIndustry(obj, objId, id, name, html) {
    curPlace = obj;
    curObjId = objId;
    curId = id;
    curName = name;
    curHtml = html;
    showMsgBox(curObjId, 538, 475);
}

//职位选择
function ChoosePosition(obj, objId, id, name, html) {
    curPlace = obj;
    curObjId = objId;
    curId = id;
    curName = name;
    curHtml = html;
    showMsgBox(curObjId, 538, 495);
}

//求职意向 行业
function ChooseIndustry2(obj, objId, id, name) {
    showMsgBox('ChooseIndustry2', 538, 522);
    curPlace = obj;
    curObjId = objId;
    curId = id;
    curName = name;
    iniArray();
}

function myfun(objName, tagName, choosedObjName) {
    ulName = objName;
    choosedName = choosedObjName;
    overBgColor(objName, tagName);
}

function iniArray() {
    var idArray = document.getElementById(curId).value.split(";");
    var nameArray = document.getElementById(curName).value.split(";");
    var strHtml = "";
    for (var i = 0; i < idArray.length; i++) {
        if (idArray[i]) {
            strHtml += "<dd id='industry_" + idArray[i] + "'><input type='checkbox' checked='checked' value='" + nameArray[i] + "|" + idArray[i] + "' />" + nameArray[i] + "</dd>";
            $("#" + ulName).find("#industry_" + idArray[i]).attr("checked", true);
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
                if (ddArray.length < 5) {
                    strhtm = "<dd id='" + checkObj.id + "'><input type='checkbox' checked='checked' value='" + checkObj.value + "' />" + checkObj.value.substr(0, checkObj.value.indexOf("|")) + "</dd>";
                    choosedObj.append(strhtm);
                } else {
                    alert("您最多只能选五项！");
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

function AreaName(obj, num) {
    if (!curPlace) return false;
    $(curPlace).html($(obj).html());
    $(curPlace).parent().find("#" + curId).val(num);
    $(curPlace).parent().find("#" + curName).val($(obj).html());
    if ($(obj).parent().parent().attr("tagName") == "DIV") {
        $(obj).parent().parent().hide();
        $(obj).parent().parent().parent().attr("class", "");
    }
    closeWindow(curObjId);
}

function ClearArea() {
    if (!curPlace) return false;
    $(curPlace).html(curHtml);
    $(curPlace).parent().find("#" + curId).val("");
    $(curPlace).parent().find("#" + curName).val("");
    closeWindow(curObjId);
}

function overDetail(obj, num, subName, objArrays) {
    var strHtml = "";
    var objParent = obj.parentNode;
    var subArea = document.getElementById(subName + num);
    if (!subArea) {
        subArea = document.createElement("div");
        subArea.id = subName + num;
        subArea.className = "subArea";
        if (!objArrays[num]) { return false; }
        strHtml += "<h4><a href='javascript:void(0)' title='选择该大类' onclick='AreaName(this," + num + ");return false;'>" + obj.innerHTML + "</a></h4>";
        for (var i = 0; i < objArrays[num].length; i++) {
            var objname = objArrays[num][i].substr(0, objArrays[num][i].indexOf('|'));
            var objid = objArrays[num][i].substr(objArrays[num][i].indexOf('|') + 1, objArrays[num][i].length - objArrays[num][i].indexOf('|'));
            strHtml += "<span><a href='javascript:void(0);' onclick='AreaName(this," + objid + ");return false;'>" + objname + "</a></span>";
        }
        subArea.innerHTML = strHtml;
        objParent.appendChild(subArea);
    }
    objParent.className = "relate cur";
    subArea.style.display = "block";

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
}

function Changetag(num) {
    var topTabs = document.getElementById("topTabs");
    var tagName = document.getElementById("tagName");
    tagName.value = num;
    var aArray = topTabs.getElementsByTagName("a");
    for (var i = 0; i < aArray.length; i++) {
        if (i == aArray.length - 1) {
            aArray[i].className = "nobor";
        } else {
            aArray[i].className = "";
        }
    }
    aArray[num].className = "cur";
}

function searchName() {
    var tagName = document.getElementById("tagName").value;
    var keyword = $.trim(document.getElementById("keyword").value);
    if (keyword == "请输入关键字") { keyword = ""; }
    var AreaName = document.getElementById("area").value;
    var AreaId = document.getElementById("areaId").value;
    if (AreaName == "选择地区") { AreaName = ""; }
    window.location = "/RecruitList.aspx?tag=" + tagName + "&key=" + encodeURIComponent(keyword) + "&area=" + AreaName + "&areaid=" + AreaId;
}


//====================================================================================================
//设置个人会员菜单选中状态
function setUserSidebar(id) {
    $("#UserSidebar li").each(function() {
        $(this).attr("class", "");
    });
    $("#" + id).attr("class", "cur");
}

//收藏职位
function AddFavorite(obj) {
    var ids = "";
    if (obj) {
        ids = obj;
    } else {
        var list = $("#jobList input:checked");
        if (list.length == 0) {
            alert("请选择要收藏的职位！");
            return;
        }
        list.each(function() {
            if ($(this).attr("name") == "job" && $(this).attr("type") == "checkbox") {
                ids += "," + $(this).val();
            }
        });
        ids = ids.substr(1);
    }
    $("#favorite").html("正在收藏...");
    $.ajax({
        url: "/AddFavorite.aspx",
        data: "ids=" + ids,
        cache: false,
        success: function(data) {
            eval(data);
        },
        error: function() {
            alert("系统繁忙，请稍候再试！");
        },
        complete: function() {
            if (obj) {
                $("#favorite").html("立即收藏");
            }else {
                $("#favorite").html("收藏选中职位");
            }
        }
    });
}

//申请职位
function SelectResume(obj) {
    if (obj == 0) {
        var list = $("#jobList input:checked");
        var ids = "";
        if (list.length == 0) {
            alert("请选择要申请的职位！");
            return;
        }
    }
    showMsgBox('Apply_Resume', 538, 150);
    if ($("#drpResume").length > 0) {
        $("#drpResume").css("visibility", "");
    }
}

function ApplyResume(obj) {
    if (obj == 0) {
        $("#btn_apply").val("正在申请");
        var list = $("#jobList input:checked");
        var ids = "";
        list.each(function() {
            if ($(this).attr("name") == "job" && $(this).attr("type") == "checkbox") {
                ids += "," + $(this).val();
            }
        });
        $.ajax({
            url: "/ApplyResumes.aspx",
            data: "ids=" + ids.substr(1) + "&id=" + $("#drpResume").val(),
            cache: false,
            success: function(data) {
                eval(data);
                closeWindow("Apply_Resume");
            },
            error: function() {
                alert("系统繁忙，请稍候再试！");
            },
            complete: function() {
                $("#btn_apply").val("立即申请");
            }
        });
    } else {
        $("#btn_apply").val("正在申请");
        $.ajax({
            url: "/ApplyResume.aspx",
            data: "ids=" + obj + "&id=" + $("#drpResume").val(),
            cache: false,
            success: function(data) {
                eval(data);
                closeWindow("Apply_Resume");
            },
            error: function() {
                alert("系统繁忙，请稍候再试！");
            },
            complete: function() {
                $("#btn_apply").val("立即申请");
            }
        });
    }
}

//刷新简历
function RefurbishAll() {
    $("#btn_refurbish_all").html("正在刷新");
    $.ajax({
        url: "/RefurbishAll.aspx",
        cache: false,
        success: function(data) {
            eval(data);
        },
        error: function() {
            alert("系统繁忙，请稍候再试！");
        },
        complete: function() {
            $("#btn_refurbish_all").html("刷新简历");
        }
    });
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

//验证日期类型
function isValidDate(year, month, day) {
    year = parseInt(year, 10);
    month = parseInt(month, 10);
    day = parseInt(day, 10);

    if ((month == 4) || (month == 6) || (month == 9) || (month == 11)) {
        if ((day < 1) || (day > 30)) {
            return (false);
        }
    }
    else {
        if (month != 2) {
            if ((day < 1) || (day > 31)) {
                return (false);
            }
        }
        else { // month == 2
            if ((year % 100) != 0 && (year % 4 == 0) || (year % 100) == 0 && (year % 400) == 0) {
                if ((day < 1) || day > 29) {
                    return (false);
                }
            }
            else {
                if ((day < 1) || day > 28) {
                    return (false);
                }
            }
        }
    }
    return (true);
}

//日期比较
function DateCompare(YearFrom, MonthFrom, YearTo, MonthTo) {
    YearFrom = parseInt(YearFrom, 10);
    MonthFrom = parseInt(MonthFrom, 10);
    YearTo = parseInt(YearTo, 10);
    MonthTo = parseInt(MonthTo, 10);

    if (YearFrom > YearTo)
    { return false; }
    else {
        if (YearFrom == YearTo) {
            if (MonthFrom > MonthTo)
                return false;
        }
    }
    return true;
}

//字数统计
function str_limit(id, str, strid) {
    $("#" + id).find("#" + strid).html(str.length);
}