var curFontSize = 14;				//��ǰ�����С
var fontAreaId = 'art-content';		//���������ID
/* �� */
function fontZoomMax(){
	if(curFontSize < 64){
		document.getElementById(fontAreaId).style.fontSize = (++curFontSize)+'px';
	}
}
/* �� */
function fontZoomMid(){
		curFontSize = 14;
		document.getElementById(fontAreaId).style.fontSize = curFontSize + 'px';
}
/* С */
function fontZoomMin(){
	if(curFontSize > 8){
		document.getElementById(fontAreaId).style.fontSize = (--curFontSize)+'px';
	}
}