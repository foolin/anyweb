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

