/*===========funEqual======================

����˵��:����Ӧ�߶�
����˵��:
objid01  ��һ�������ID
objid02  �ڶ��������ID
���÷�����funEqual("objid01","objid02")

==================================================*/

function funEqual(objid01,objid02)
	{
		var h_obj01 = document.getElementById(objid01).scrollHeight;
		var h_obj02 = document.getElementById(objid02).scrollHeight;
		h_obj01<h_obj02?document.getElementById(objid01).style.height = document.getElementById(objid02).scrollHeight+"px":document.getElementById(objid02).style.height = document.getElementById(objid01).scrollHeight+"px";
	}