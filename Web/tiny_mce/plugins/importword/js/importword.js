var formAction = "/tiny_mce/uploadword.aspx?type=rar,xls,doc,ppt";

tinyMCEPopup.requireLangPack();

var oldWidth, oldHeight, ed, url;

function init() {
	var pl = "", f, val;
	var fe, i;
	ed = tinyMCEPopup.editor;
	
	tinyMCEPopup.resizeToInnerSize();
	f = document.forms[0]

	fe = ed.selection.getNode();

	TinyMCE_EditableSelects.init();
}

function uploadOk()
{
	var fe;
	tinyMCEPopup.restoreSelection();

	if(document.getElementById("replacesource").checked == true)
	{
		ed.setContent("");
	}

	ed.execCommand('Paste');

	tinyMCEPopup.close();
}

function insertWord() {
	var f = document.forms[0];

	if(f.localfile.value == "")
	{
		tinyMCEPopup.close();
		return;
	}
	f.action = formAction;
	f.submit();
}


tinyMCEPopup.onInit.add(init);
