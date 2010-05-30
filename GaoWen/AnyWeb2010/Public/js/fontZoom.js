var curFontSize = 12;				//当前字体大小
var fontAreaId = 'art-content';		//文字区域的ID
var defFontSize = curFontSize;	//默认字体

//大
function fontZoomMax(){
	if(curFontSize < 64){
		document.getElementById(fontAreaId).style.fontSize = (++curFontSize)+'px';
	}
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
		document.getElementById(fontAreaId).style.fontSize = curFontSize + 'px';
}
//小
function fontZoomMin(){
	if(curFontSize > 8){
		document.getElementById(fontAreaId).style.fontSize = (--curFontSize)+'px';
	}
}