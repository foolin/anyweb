<%@ Page language="c#" %>
<HTML>
	<HEAD>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
		<title>����ͼƬ</title>
		
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
			alert("��ѡ��һ��ͼƬ�ļ���");return false;
		}
		document.all.btnOK.disabled = true;
		document.all.btnOK.value = "�����ϴ���...";
		document.FileManage.submit();
		return false;
	}
	document.all.btnOK.disabled = true;
	var url = document.FileManage.FileAdr.value;
	var Width = document.FileManage.FileSizeWidth.value;
	var Height = document.FileManage.FileSizeHeight.value;
	var Link = document.FileManage.FileLink.value;
	var index = document.FileManage.ddlAlign.selectedIndex;
	var Align = document.FileManage.ddlAlign.options[index].value;
	if( isNaN(Width) )
	{
		alert("ͼƬ������������֣�");
		return false;
	}
	if( isNaN(Height) )
	{
		alert("ͼƬ�߶����������֣�"); 		
		return false;
	}
	
	if( Width == "" || Height == "")
	{
		_temp_return=checkType1(url,Link, Align)
	}
	else
	{
		_temp_return=checkType(url,Width,Height,Link, Align) 
	}
		
		
	if (_temp_return == "flasea") {
		alert("������ͼƬ�������ַ��"); 
		return false;
		}else {                                                                // valid color
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
    return objvalue;
}
function inserObject1(objvalue,insertLink,Align) {
	
	return objvalue;
}

//-->
		</script>
		<LINK href="editor_dialog.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY bgColor="menu" leftMargin="15">
		<form name="FileManage" method="post" action="uploadimage.aspx?type=gif,jpg,png,bmp"
			enctype="multipart/form-data" target="innerF">
			<table cellSpacing="2" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td>
						<FIELDSET align="left">
							<LEGEND align="left">����ͼƬ</LEGEND>
							<table cellSpacing="0" cellPadding="0" align="center" border="0">
								<tr align="left">
									<td><input type="radio" name="method" value="1" checked onclick="javascript:changeMethod(this.value);"
											title="����������е�ͼƬ">����ͼƬ&nbsp;<input type="radio" name="method" value="2" onclick="javascript:changeMethod(this.value);"
											title="���Լ��������ϴ�ͼƬ">����ͼƬ</td>
								</tr>
								<tr align="left">
									<td colSpan="3">
										<div id="add1">�����ַ��<input id="FileAdr" type="text" name="FileAdr" size="36" title="����ͼƬ�������ַ" value="<%=Request["source"]%>"></div>
										<div id="add2" style="DISPLAY:none">����·����<input id="File1" type="file" name="File1" size="24" title="Ҫ�ϴ���ͼƬ�ڵ����ϵ�·��"></div>
									</td>
								</tr>
								<tr style="display:none;">
									<td align="left" width="100%" height="25" colspan="3">
										ͼƬ��С����<input type="text" id="FileSizeWidth" size="3" maxlength="3" title="ͼƬ���������780px֮���Ա���������Ч����">
										��<input type="text" id="FileSizeHeight" size="3" MaxLength="3">��������&lt;780px��
									</td>
								</tr>
								<tr style="display:none;">
									<td align="left" width="100%" height="25" colspan="3">
										ͼƬ���ӣ�<input type="text" id="FileLink" size="36" title="ҪΪͼƬ��ӳ������ӵĵ�ַ������������ӾͲ���">
									</td>
								</tr>
								<tr style="display:none;">
									<td height="25" colspan="3">���뷽ʽ��<SELECT name="ddlAlign">
											<OPTION selected value="absbottom">absbottom</OPTION>
											<OPTION value="absmiddle">absmiddle</OPTION>
											<OPTION value="baseline">baseline</OPTION>
											<OPTION value="bottom">bottom</OPTION>
											<OPTION value="left">left</OPTION>
											<OPTION value="middle">middle</OPTION>
											<OPTION value="right">right</OPTION>
											<OPTION value="texttop">texttop</OPTION>
											<OPTION value="top">top</OPTION>
										</SELECT></td>
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
	return path;
	//document.FileManage.FileAdr.value = path;
	//onButtonClick();
}
		</script>
	</BODY>
</HTML>
