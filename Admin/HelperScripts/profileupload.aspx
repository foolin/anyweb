<%@ Page language="c#" %>
<HTML>
	<HEAD>
		<title>���븽��</title>
		<script language="javascript">
<!--
function onButtoncancel()
{		
	window.returnValue ='';
	window.close ();
}

function onButtonClick()
{
	if( document.all.add1.style.display == "none" && document.FileManage.FileAdr.value == "")
	{	
		if( document.FileManage.File1.value == "")
		{
			alert("��ѡ��һ���ļ���");return false;
		}
		document.all.btnOK.disabled = true;
		document.all.btnOK.value = "�����ϴ���...";
		document.FileManage.submit();
		return false;
	}
	document.all.btnOK.disabled = true;
	var url = document.FileManage.FileAdr.value;
	var name = document.FileManage.FileName.value;
	if( name == "") name = "�ϴ���������";
	
	_temp_return="<a target=_blank href='"+url+"'>"+name+"</a>";
		
	if (_temp_return == "flasea") 
	{
		alert("�������ļ��������ַ��"); 
		return false;
	}
	else 
	{                                                                // valid color
			window.returnValue = _temp_return;           // set return value
			window.close();                       // close dialog
	} 
				
}

function checkType1(url,Link,Align)
{
var afilename,bfilename,filetype,checkTyperesult;
	afilename=url.split("/");
	bfilename=afilename[afilename.length-1];
	filetype=bfilename.split(".");
	type = filetype[filetype.length-1].toLowerCase()
	switch(type){
		case "":
			checkTyperesult="flasea";
			break;
		default:
			checkTyperesult=inserObject1(url,Link,Align)
			break;
	}
	return checkTyperesult;
}

function checkType(url,Width,Height,Link,Align)
{
	var afilename,bfilename,filetype,checkTyperesult;
	afilename=url.split("/");
	bfilename=afilename[afilename.length-1];
	filetype=bfilename.split(".");
	type = filetype[filetype.length-1].toLowerCase()
	switch(type){
		case "":
			checkTyperesult="flasea";
			break;
		default:
			checkTyperesult=inserObject(url,Width,Height,Link,Align)
			break;
	}
	return checkTyperesult;
}

function inserObject(objvalue,inserWidth,inserHeight,insertLink,Align ) {
	var imgFileReturn;
	if(insertLink=="")
	{
		imgFileReturn="<img hspace=8 vspace=4 src="+objvalue+" width="+inserWidth+" height="+inserHeight+" border=0 align="+ Align + ">";
	}
	else
	{
		imgFileReturn="<a href="+insertLink+" target=_blank><img hspace=8 vspace=4 src="+objvalue+" width="+inserWidth+" height="+inserHeight+" border=0 align="+ Align + "></a>";
	}
	return imgFileReturn;
}
function inserObject1(objvalue,insertLink,Align) {
	var imgFileReturn;
	if(insertLink=="")
	{
		imgFileReturn="<img hspace=8 vspace=4 src="+objvalue+" border=0 align=" + Align +">";
	}
	else
	{
		imgFileReturn="<a href="+insertLink+" target=_blank><img hspace=8 vspace=4 src="+objvalue+" border=0 align=" + Align +"></a>";
	}
	return imgFileReturn;
}

//-->
		</script>
		<LINK href="editor_dialog.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY bgColor="menu" leftMargin="15">
		<form name="FileManage" method="post" action="/uploadprofile.aspx?type=zip,doc,txt,rar,pdf,ppt"
			enctype="multipart/form-data" target="innerF">
			<table cellSpacing="2" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td>
						<FIELDSET align="left">
							<LEGEND align="left">���븽��</LEGEND>
							<table cellSpacing="0" cellPadding="0" align="center" border="0">
								<tr align="left">
									<td><input type="radio" name="method" value="1" checked onclick="javascript:changeMethod(this.value);"
											title="����������е�ͼƬ">����ͼƬ&nbsp;<input type="radio" name="method" value="2" onclick="javascript:changeMethod(this.value);"
											title="���Լ��������ϴ�ͼƬ">�����ļ�</td>
								</tr>
								<tr align="left">
									<td colSpan="3">
										<div id="add1">�����ַ��<input id="FileAdr" type="text" name="FileAdr" size="36" title="����ͼƬ�������ַ"></div>
										<div id="add2" style="DISPLAY:none">����·����<input id="File1" type="file" name="File1" size="24" title="Ҫ�ϴ��ĸ����ڵ����ϵ�·��"></div>
									</td>
								</tr>
								<tr>
									<td align="left" width="100%" height="25" colspan="3">
										�������ƣ�<input type="text" id="FileName" size="36" maxlength="100">
									</td>
								</tr>
								<tr>
									<td height="25" colspan="3" align="center">
										<input onclick="return onButtonClick();" id="btnOK" type="button" value="ȷ��" style="BACKGROUND-COLOR:menu">
										&nbsp;&nbsp;&nbsp;&nbsp; <input onclick="onButtoncancel();" type="button" value="ȡ��" style="BACKGROUND-COLOR:menu">
									</td>
								</tr>
							</table>
						</FIELDSET>
					</td>
				</tr>
			</table>
			<iframe id="innerF" name="innerF" style="WIDTH:0px;HEIGHT:0px"></iframe>
		</form>
		<script language="javascript">
function changeMethod(m)
{
	document.all.add1.style.display=(m=="1"?"block":"none");
	document.all.add2.style.display=(m=="2"?"block":"none");
	document.FileManage.FileAdr.value = document.FileManage.File1.value = "";
}
function uploadOk(path)
{
	document.FileManage.FileAdr.value = path;
	if(document.FileManage.FileName.value=="") 
	{	
		var str1 = document.FileManage.File1.value;
		var str2 = "";
		for( var i = 0; i < str1.length; i ++)
		  str2 += str1.charAt(str1.length - i - 1);
		if( str2.indexOf("\\") > 0)
		{
			str1 = str1.substring( str1.length-str2.indexOf("\\") );
		}
		document.FileManage.FileName.value = str1;
	}
	onButtonClick();
}

		</script>
	</BODY>
</HTML>
