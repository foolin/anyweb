/**********************************************/
/*  Purpose:        JavaScript for slide      */
/*  Author:         Foolin                    */
/*  E-mail:         Foolin@126.com            */
/*  Create on:      2009-7-16 13:14:33        */
/**********************************************/


//图片边框效果 : 在<img>中加入class='img'即可。
function imgEffect(){
		var nImg = document.getElementsByTagName("img");
		for(var i = 0; i < nImg.length && nImg[i].className == 'img'; i++){
				nImg[i].onmouseover = function(){ this.style.background = '#f00'}    
				nImg[i].onmouseout = function(){ this.style.background = '#FFF';} 
		}
}

//li滑动效果 : 在<ul>中加入class='li-slide'即可。
function liEffect(){
	var nUl = document.getElementsByTagName("ul");
	for(var i = 0; i < nUl.length; i++){
			if(nUl[i].className != 'li-slide') 	continue;
			var nLi = nUl[i].childNodes;
			for(var j = 0; j < nLi.length; j++){
					nLi[j].onmouseover = function(){ this.style.background = '#b5e28d'}    
					nLi[j].onmouseout = function(){ this.style.background = '#FFF';}
			}
	}
}

//初始化效果
function initEffect(){
		imgEffect();
		liEffect();
}

window.onload = initEffect; //网页载入运行