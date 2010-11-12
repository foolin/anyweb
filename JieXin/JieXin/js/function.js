//弹出页面背景半透明======================================================================
var isIe=(document.all)?true:false;

//设置select的可见状态
function setSelectState(state)
{
	var objl=document.getElementsByTagName('select');
	for(var i=0;i<objl.length;i++)
	{
		objl[i].style.visibility=state;
	}
}

//弹出方法
function showMsgBox(divID,wWidth,wHeight)
{
	//closeWindow();
	
	var bWidth= parseInt(document.documentElement.scrollWidth);
	var bHeight=parseInt(document.documentElement.scrollHeight);

	var scrollTop = document.documentElement.scrollTop || window.pageYOffset; 	//兼容chrome、safari : 20090708
	if (!scrollTop)
	    scrollTop = 0;
	var sWidth= parseInt((document.documentElement.scrollWidth - wWidth) / 2);
	var sHeight=parseInt(scrollTop + (document.documentElement.clientHeight-wHeight) / 2);
	if(isIe){
		setSelectState('hidden');
	}
	var back=document.createElement("div");
	back.id="back";
	var styleStr="top:0px;left:0px;position:absolute;z-index:999;background:#666;width:"+bWidth+"px;height:"+bHeight+"px;";
	styleStr+=(isIe)?"filter:alpha(opacity=70);":"opacity:0.70;";
	back.style.cssText=styleStr;
	back.innerHTML="<div style=width:"+bWidth+"px;height:"+bHeight+"px; onclick=closeWindow(\'"+divID+"\');></div>";
	document.body.appendChild(back);
	var mesW=document.getElementById(divID);
	styleStr="left:"+sWidth+"px;top:"+sHeight+"px;width:"+wWidth+"px;position:absolute;z-index:1000;display:block;";
	mesW.style.cssText=styleStr;
}

function showBackground(obj,endInt)
{
	obj.filters.alpha.opacity+=1;
	if(obj.filters.alpha.opacity<endInt)
	{
		setTimeout(function(){showBackground(obj,endInt)},8);
	}
}
//关闭窗口
function closeWindow(Obj)
{
	if(document.getElementById('back')!=null)
	{
		document.getElementById('back').parentNode.removeChild(document.getElementById('back'));
	}
	
	document.getElementById(Obj).style.display="none";
	
	if(isIe){
		setSelectState('');
	}
}


//====================================================================================================
//设置个人会员菜单选中状态
function setUserSidebar(id) {
    $("#UserSidebar li").each(function() {
        $(this).attr("class", "");
    });
    $("#" + id).attr("class", "cur");
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