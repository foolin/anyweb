/*===========funEqual======================

功能说明:自适应高度
参数说明:
objid01  第一个对象的ID
objid02  第二个对象的ID
调用方法：funEqual("objid01","objid02")

==================================================*/

function funEqual(objid01,objid02)
	{
		var h_obj01 = document.getElementById(objid01).scrollHeight;
		var h_obj02 = document.getElementById(objid02).scrollHeight;
		h_obj01<h_obj02?document.getElementById(objid01).style.height = document.getElementById(objid02).scrollHeight+"px":document.getElementById(objid02).style.height = document.getElementById(objid01).scrollHeight+"px";
	}