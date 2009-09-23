var curFontSize = 14;				//当前字体大小
var fontAreaId = 'art-content';		//文字区域的ID
//大
function fontZoomMax(){
	if(curFontSize < 64){
		document.getElementById(fontAreaId).style.fontSize = (++curFontSize)+'px';
	}
}
//中
function fontZoomMid(){
		curFontSize = 14;
		document.getElementById(fontAreaId).style.fontSize = curFontSize + 'px';
}
//小
function fontZoomMin(){
	if(curFontSize > 8){
		document.getElementById(fontAreaId).style.fontSize = (--curFontSize)+'px';
	}
}