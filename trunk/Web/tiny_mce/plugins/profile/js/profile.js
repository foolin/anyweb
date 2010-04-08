var formAction = "/tiny_mce/uploadprofile.aspx?type=rar,xls,doc,ppt";

tinyMCEPopup.requireLangPack();

var oldWidth, oldHeight, ed, url;

function init() {
	var pl = "", f, val;
	var type = "flash", fe, i;

	ed = tinyMCEPopup.editor;

	tinyMCEPopup.resizeToInnerSize();
	f = document.forms[0]

	fe = ed.selection.getNode();

	TinyMCE_EditableSelects.init();
}

function changeSource(t) {
	if(t == "1")
	{
		document.getElementById('rowNetwork').style.display = "";
		document.getElementById('rowLocal').style.display = "none";
	}
	else
	{
		document.getElementById('rowNetwork').style.display = "none";
		document.getElementById('rowLocal').style.display = "";
	}
}

function uploadOk(url)
{
	document.getElementById("type1").checked = true;
	document.getElementById("src").value = url;
	insertProfile();
}

function insertProfile() {
	var fe, f = document.forms[0], h, link, text;

	if(document.getElementById("type2").checked == true)
	{
		f.action = formAction;
		f.submit();
		return;
	}

	tinyMCEPopup.restoreSelection();
    
	if (f.src.value === '') 
	{
		tinyMCEPopup.close();
		return;
	}

	fe = ed.selection.getNode();
	text = document.getElementById("profilename").value;
	link = document.getElementById("src").value;
	if( text == "") text = link;
	h = '<a target="_blank" href="' + link + '"> ' + text +'</a>'
	ed.execCommand('mceInsertContent', false, h);

	tinyMCEPopup.close();
}


tinyMCEPopup.onInit.add(init);
