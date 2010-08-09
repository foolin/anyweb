var curFontSize = 12;				//当前字体大小
var fontAreaId = 'art-content';		//文字区域的ID
var defFontSize = curFontSize;	//默认字体

//大
function fontZoomMax() {
    curFontSize += 3;
    if (curFontSize > 64) {
        curFontSize = 64;
    }
    $("#" + fontAreaId).css("font-size", curFontSize);
}
//中
function fontZoomMid(fontSize){
	if(typeof(fontSize) == "undefined")
	{
		curFontSize = defFontSize;
	}
	else
	{
		curFontSize = fontSize;
	}
	$("#" + fontAreaId).css("font-size", curFontSize);
}
//小
function fontZoomMin() {
    curFontSize -= 3;
    if (curFontSize < 8) {
        curFontSize = 8;
    }
    $("#" + fontAreaId).css("font-size", curFontSize);
}