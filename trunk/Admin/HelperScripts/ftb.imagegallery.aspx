<%@ Page Language="c#" %>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
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

    <link href="editor_dialog.css" type="text/css" rel="stylesheet" />
</head>
<body bgcolor="menu" leftmargin="15">
    <form name="FileManage" method="post" action="/uploadimage.aspx?type=gif,jpg,png,bmp"
        enctype="multipart/form-data" target="innerF">
        <table cellspacing="2" cellpadding="0" width="100%" align="center" border="0">
            <tr>
                <td>
                    <fieldset align="left">
                        <legend align="left">����ͼƬ</legend>
                        <table cellspacing="0" cellpadding="0" align="center" border="0">
                            <tr align="left">
                                <td>
                                    <input type="radio" name="method" value="1" checked="checked" onclick="javascript:changeMethod(this.value);"
                                        title="����������е�ͼƬ" />����ͼƬ&nbsp;<input type="radio" name="method" value="2" onclick="javascript:changeMethod(this.value);"
                                            title="���Լ��������ϴ�ͼƬ" />����ͼƬ</td>
                            </tr>
                            <tr align="left">
                                <td colspan="3">
                                    <div id="add1">
                                        �����ַ��<input id="FileAdr" type="text" name="FileAdr" size="36" title="����ͼƬ�������ַ" /></div>
                                    <div id="add2" style="display: none">
                                        ����·����<input id="File1" type="file" name="File1" size="24" title="Ҫ�ϴ���ͼƬ�ڵ����ϵ�·��" /></div>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="100%" height="25" colspan="3">
                                    ͼƬ��С����<input type="text" id="FileSizeWidth" size="3" maxlength="3" title="ͼƬ���������780px֮���Ա���������Ч����" />
                                    ��<input type="text" id="FileSizeHeight" size="3" maxlength="3" />��������&lt;780px��
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="100%" height="25" colspan="3">
                                    ͼƬ���ӣ�<input type="text" id="FileLink" size="36" title="ҪΪͼƬ��ӳ������ӵĵ�ַ������������ӾͲ���" />
                                </td>
                            </tr>
                            <tr>
                                <td height="25" colspan="3">
                                    ���뷽ʽ��<select name="ddlAlign">
                                        <option selected="selected" value="absbottom">absbottom</option>
                                        <option value="absmiddle">absmiddle</option>
                                        <option value="baseline">baseline</option>
                                        <option value="bottom">bottom</option>
                                        <option value="left">left</option>
                                        <option value="middle">middle</option>
                                        <option value="right">right</option>
                                        <option value="texttop">texttop</option>
                                        <option value="top">top</option>
                                    </select></td>
                            </tr>
                            <tr>
                                <td height="25" colspan="3" align="center">
                                    <input onclick="return onButtonClick();" id="btnOK" type="button" value="ȷ��" style="background-color: menu" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <input onclick="onButtoncancel();" type="button" value="ȡ��" style="background-color: menu" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
        <iframe id="innerF" name="innerF" style="width: 0px; height: 0px"></iframe>
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
	onButtonClick();
}
    </script>

</body>
</html>
