<%@ Page Language="c#" AutoEventWireup="false"  %>
<HTML>
	<HEAD>
		<title>�����ý���ļ�</title>
		<link rel="stylesheet" type="text/css" href="editor_dialog.css">
			<Script Language="JavaScript">
	function onButtoncancel()
	{		
		window.returnValue ='';
		window.close ();
	}
	function onButtonClick()
			{
	if( document.all.add1.style.display == "none" && document.mediamanage.url.value == "")
	{	
		if( document.mediamanage.File1.value == "")
		{
			alert("��ѡ��һ��ý���ļ���");return false;
		}
		document.mediamanage.submit();
		return false;
	}
				var Width = document.mediamanage.Width.value;
				var Height = document.mediamanage.Height.value;
				var url = document.mediamanage.url.value;
				var PlayRadio;
				for (i=0;i<document.mediamanage.PlayRadio.length;i++){
					if(document.mediamanage.PlayRadio[i].checked)
					{
					PlayRadio = document.mediamanage.PlayRadio[i].value;
					break;
					}
				}
				

				var _temp_return
				if(Width==""){
					Width = "500";
				} 
				if(Height==""){
					Height = "200"; 
				}
_temp_return=checkType(url,Width,Height,PlayRadio)  
  if (_temp_return == "flasea") {
alert("��������Ҫ���ŵ�ý���ļ���ϵͳ���Զ�ʶ���ļ����ͣ�"); 
return false;
}else if (_temp_return == "flaseb"){
alert("����ĵ�ַ��ʽ���ļ������ݲ�֧���Զ����ţ�");
return false;
}else {                                                                // valid color
    window.returnValue = _temp_return;           // set return value
    window.close();                       // close dialog
  }
			}
function checkType(url,Width,Height,PlayRadio){
	var afilename,bfilename,filetype,checkTyperesult;
	afilename=url.split("/");
	bfilename=afilename[afilename.length-1];
	filetype=bfilename.split(".");
	switch(filetype[filetype.length-1].toLowerCase()){
		case "":
			checkTyperesult="flasea";
			break;
		case "swf":
			checkTyperesult=inserObject('swf',url,Width,Height,PlayRadio)
			break;
		case "mov":
			checkTyperesult=inserObject('qt',url,Width,Height,PlayRadio)
			break;
		case "asf":
			checkTyperesult=inserObject('mp',url,Width,Height,PlayRadio)
			break;
		case "asx":
			checkTyperesult=inserObject('mp',url,Width,Height,PlayRadio)
			break;
		case "wmv":
			checkTyperesult=inserObject('mp',url,Width,Height,PlayRadio)
			break;
		case "wma":
			checkTyperesult=inserObject('mp',url,Width,Height,PlayRadio)
			break;
		case "wmf":
			checkTyperesult=inserObject('mp',url,Width,Height,PlayRadio)
			break;
		case "avi":
			checkTyperesult=inserObject('video',url,Width,Height,PlayRadio)
			break;
		case "mpeg":
			checkTyperesult=inserObject('video',url,Width,Height,PlayRadio)
			break;
		case "mpg":
			checkTyperesult=inserObject('video',url,Width,Height,PlayRadio)
			break;
		case "rm":
			checkTyperesult=inserObject('rm',url,Width,Height,PlayRadio)
			break;
		case "rmvb":
			checkTyperesult=inserObject('rm',url,Width,Height,PlayRadio)
			break;
		case "mp3":
			checkTyperesult=inserObject('music',url,Width,Height,PlayRadio)
			break;
		case "ra":
			checkTyperesult=inserObject('music',url,Width,Height,PlayRadio)
			break;
		case "wav":
			checkTyperesult=inserObject('music',url,Width,Height,PlayRadio)
			break;
		case "mid":
			checkTyperesult=inserObject('music',url,Width,Height,PlayRadio)
			break;
		case "midi":
			checkTyperesult=inserObject('music',url,Width,Height,PlayRadio)
			break;
		default:
			checkTyperesult="flaseb";
			break;
	}
	return checkTyperesult;
}

function inserObject(obj,objvalue,inserWidth,inserHeight,insertPlayRadio) {
var mediafilereturn;

switch(obj){
case "swf":
	mediafilereturn="<OBJECT codeBase=http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,2,0 classid=clsid:D27CDB6E-AE6D-11cf-96B8-444553540000 width="+inserWidth+" height="+inserHeight+"><PARAM NAME=movie VALUE="+objvalue+"><PARAM NAME=quality VALUE=high><PARAM NAME=menu VALUE=false><embed src="+objvalue+" quality=high pluginspage="+"http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash" +" width="+inserWidth+" height="+inserHeight+">"+objvalue+"</embed></OBJECT>";
	break;
case "rm":
	if( insertPlayRadio == "1" )
		mediafilereturn="<OBJECT classid=CLSID:CFCDAA03-8BE4-11CF-B84B-0020AFBBCCFA class=OBJECT id=RAOCX width="+inserWidth+" height="+inserHeight+"><PARAM NAME=SRC VALUE="+objvalue+"><PARAM NAME=CONSOLE VALUE=Clip1><PARAM NAME=CONTROLS VALUE=imagewindow><PARAM NAME=AUTOSTART VALUE=true><PARAM NAME=loop VALUE=true></OBJECT><br><OBJECT classid=CLSID:CFCDAA03-8BE4-11CF-B84B-0020AFBBCCFA height=18 id=video2 width="+inserWidth+"><PARAM name=src value="+objvalue+"><PARAM NAME=AUTOSTART VALUE=-1><PARAM NAME=CONTROLS VALUE=controlpanel><PARAM NAME=CONSOLE VALUE=Clip1></OBJECT>";
	else
		mediafilereturn="<OBJECT classid=CLSID:CFCDAA03-8BE4-11CF-B84B-0020AFBBCCFA class=OBJECT id=RAOCX width="+inserWidth+" height="+inserHeight+"><PARAM NAME=SRC VALUE="+objvalue+"><PARAM NAME=CONSOLE VALUE=Clip1><PARAM NAME=CONTROLS VALUE=imagewindow><PARAM NAME=AUTOSTART VALUE=false><PARAM NAME=loop VALUE=true></OBJECT><br><OBJECT classid=CLSID:CFCDAA03-8BE4-11CF-B84B-0020AFBBCCFA height=18 id=video2 width="+inserWidth+"><PARAM name=src value="+objvalue+"><PARAM NAME=AUTOSTART VALUE=0><PARAM NAME=CONTROLS VALUE=controlpanel><PARAM NAME=CONSOLE VALUE=Clip1></OBJECT>";
	break;
case "music":
	if( insertPlayRadio == "1" )
		mediafilereturn="<EMBED src="+objvalue+" width="+inserWidth+" height="+inserHeight+" autostart=true loop=true>";
	else
		mediafilereturn="<EMBED src="+objvalue+" width="+inserWidth+" height="+inserHeight+" autostart=false loop=true>";
	break;
case "video":
	if( insertPlayRadio == "1" )
		mediafilereturn="<EMBED src="+objvalue+" width="+inserWidth+" height="+inserHeight+" autostart=true loop=true>";
	else
		mediafilereturn="<EMBED src="+objvalue+" width="+inserWidth+" height="+inserHeight+" autostart=false loop=true>";	
	break;
case "mp":
	if( insertPlayRadio == "1" )
		mediafilereturn='<OBJECT id="WMPlayer" style="LEFT: 0px; TOP: 0px" width="'+inserWidth+'" height="'+inserHeight+'" classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6"><PARAM NAME="URL" VALUE="'+objvalue+'"><PARAM NAME="autoStart" VALUE="1"><PARAM NAME="enabled" VALUE="-1"></OBJECT>';
	else
		if( insertPlayRadio == "0" )
		mediafilereturn='<OBJECT id="WMPlayer" style="LEFT: 0px; TOP: 0px" width="'+inserWidth+'" height="'+inserHeight+'" classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6"><PARAM NAME="URL" VALUE="'+objvalue+'"><PARAM NAME="autoStart" VALUE="0"><PARAM NAME="enabled" VALUE="-1"></OBJECT>';
	break;
case "qt":
	if( insertPlayRadio == 1 )
		mediafilereturn="<embed src="+objvalue+" width="+inserWidth+" height="+inserHeight+" autoplay=true loop=false controller=true playeveryframe=false cache=false scale=TOFIT bgcolor=#000000 kioskmode=false targetcache=false pluginspage=http://www.apple.com/quicktime/>";
	else
		mediafilereturn="<embed src="+objvalue+" width="+inserWidth+" height="+inserHeight+" autoplay=false loop=false controller=true playeveryframe=false cache=false scale=TOFIT bgcolor=#000000 kioskmode=false targetcache=false pluginspage=http://www.apple.com/quicktime/>";
	break;
default:
	mediafilereturn==null;
	break;
}
return mediafilereturn;
}

			</Script>
	</HEAD>
	<BODY bgColor="menu" topMargin="0" leftmargin="15">
		<form name="mediamanage" method="post" action="/Admin/uploadimage.aspx?type=swf,mov,asf,asx,wmv,wma,wmf,avi,mpeg,mpg,rm,rmvb,mp3,ra,wav,mid,midi" enctype="multipart/form-data"
			target="innerF">
			<table width="100%" border="0" align="center" cellpadding="0" cellspacing="2">
				<tr>
					<td>
						<FIELDSET align="left">
							<LEGEND align="left">��ý���ļ�������</LEGEND>
							<table border="0" align="center" cellpadding="0" cellspacing="0">
								<tr align="left">
									<td colspan="3"><input type="radio" name="method" value="1" checked onclick="javascript:changeMethod(this.value);"
											title="����������еĶ�ý���ļ���ϵͳ�Զ��ж�����">�����ļ�&nbsp;<input type="radio" name="method" value="2" onclick="javascript:changeMethod(this.value);"
											title="���Լ��������ϴ���ý���ļ���ϵͳ�Զ��ж�����">�����ļ�</td>
								</tr>
								<tr align="center">
									<td height="25" colspan="3">
										<div id="add1">�����ַ��<input id="url" type="text" name="url" size="30" title="���ж�ý���ļ��������ַ"></div>
										<div id="add2" style="DISPLAY:none">����·����<input id="File1" type="file" name="File1" size="25" title="Ҫ�ϴ��Ķ�ý���ļ��ڵ����ϵ�·��"></div>
									</td>
								</tr>
								<tr>
									<td width="25%" height="25" align="center">�� <input name="Width" type="text" id="Width" value="400" size="3" maxlength="3" title="��ý���ļ��Ŀ�ȣ����𳬹�500">&nbsp;
									</td>
									<td width="25%" height="25" align="center">�ߣ� <input name="Height" type="text" id="Height" value="300" size="3" maxlength="3" title="��ý���ļ��ĸ߶ȣ����𳬹�500">
									</td>
									<td width="50%" height="25" align="center">�Զ����ţ�<input type="radio" name="PlayRadio" value="1" checked title="�Զ�����">��<input type="radio" name="PlayRadio" value="0" title="���Զ�����">��
									</td>
								</tr>
								<tr>
									<td height="25" colspan="3" align="center">
										<input onclick="return onButtonClick();" type="button" value="ȷ��" style="BACKGROUND-COLOR:menu">
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
	document.mediamanage.url.value = document.mediamanage.File1.value = "";
}
function uploadOk(path)
{
	document.mediamanage.url.value = path;
	onButtonClick();
}
		</script>
	</BODY>
</HTML>
