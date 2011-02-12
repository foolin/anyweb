var Validator = {
	Type : {
			userid	: "this.IsUserID(value)",
			account : /^[A-Za-z][A-Za-z0-9]{3,20}$/,
			comaccount : /^[A-Za-z0-9]{4,20}$/,
			adminpsw : /^[A-Za-z][A-Za-z0-9]{3,20}$/,
			domain2	: /^[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/,
			domain	: /^([a-zA-Z0-9]|[-]){4,16}$/,
			email	: /^\w+([-+.]\w+)*@\w+([-.]\\w+)*\.\w+([-.]\w+)*$/,
			phone	: /^((\(\d{3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}$/,
			mobile	: /^((\(\d{3}\))|(\d{3}\-))?1[3|5]\d{9}$/,
			url		: /^https?:\/\/[A-Za-z0-9\-]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/,
			idcard	: /^\d{15}(\d{2}[A-Za-z0-9])?$/,
			currency: /^\d+(\.\d+)?$/,
			number	: /^\d+$/,
			date	: "this.IsDate(value, getAttribute('format'))",
			//image	: "this.CheckImage(value,getAttribute('input'),getAttribute('img'))",
			len		: "value.length >= getAttribute('min') && value.length <= getAttribute('max')",
			custom	: "eval(getAttribute('exp'))",
			regexp	: "this.Exec(value, getAttribute('regexp'))",
			zip		: /^[1-9]\d{5}$/,
			qq		: /^[1-9]\d{4,8}$/,
			integer : /^[-\+]?\d+$/,
			double	: /^[-\+]?\d+(\.\d+)?$/,
			english : /^[A-Za-z]+$/,
			chinese : /^[\u0391-\uFFE5]+$/	
		},
		
	Style					: 1,
	ShowMsgAtOnce			: true,
	ErrorMsg				: '*',
	ErrorText				: '*',
	OkMsg					: '¡Ì',
	OkText                  : '¡Ì',
	RequireMsg				: '±ØÌî',
	FocusColor				: '#FBF9DB',
	BlurColor				: '#ffffff',
	
	Result : function (ctl, isok, msg, text){
			this.control	= ctl;
			this.isok		= isok;
			this.message	= msg;
			this.text       = text;
		},
		
	Results					: [],
		
	ValidateForm : function (form){
		this.Results = [];
		var frm = form || document.forms[0];
		var errs = "";
		
		if( frm == undefined){
			return;
		}
		var count = frm.elements.length;
		for( i = 0;i<count; i++){
			this.Validate(frm.elements[i]);
		}
	
		for( i=0; i< this.Results.length; i++){
			this.ShowMsg( this.Results[i]);
			if( this.Results[i].isok == false){
				errs += this.Results[i].message + "\n";
			}
		}
		
		if( errs != ""){
			alert(errs);
		}
		return errs == "";
	},
	
	
	ValidateForm2 : function (form){
		this.Results = [];
		var frm = form || document.forms[0];
		var errs = "";
		
		if( frm == undefined){
			return;
		}
		var count = frm.elements.length;
		for( i = 0;i<count; i++){
			this.Validate(frm.elements[i]);
		}
	
		for( i=0; i< this.Results.length; i++){
			this.ShowMsg( this.Results[i]);
			if( this.Results[i].isok == false){
				errs += this.Results[i].message + "\n";
			}
		}
		
		//if( errs != ""){
		//	alert(errs);
		//}
		return errs == "";
	},
	
	Validate : function(ctl, showmsg){
		var isok = true;
		var validated = false;
		var msg = "",text = "";
		
		with(ctl){
			if( value != ""){
				if( ctl.require){
					isok = true;
					validated = true;
				}
				if( ctl.datatype){
					var _type = getAttribute("datatype");
					if(typeof(_type) != "object" && this.Type[_type] != undefined){				
						switch( _type){
							case "userid":
							case "date":
							case "image":
							case "len":
							case "regexp":
							case "custom":{
								isok = eval(this.Type[_type]);
								validated = true;
								break;
							}
							default:{
								isok = this.Type[_type].test(value);
								if( isok && ctl.min){
									isok = new Number(value) >= new Number(getAttribute("min"));
								}
								if( isok && ctl.max){
									isok = new Number(value) <= new Number(getAttribute("max"));
								}
								validated = true;
								break;
							}
						}
					}
				}				
			}
			else{
				if(ctl.require == "1"){
					isok = false;
					msg = ctl.errmsg || this.RequireMsg;
					validated = true;
				}
			}
		}
		
		if( validated == true){
			var show = ctl.showmsg == undefined?this.ShowMsgAtOnce:ctl.showmsg == "1";
			if( msg == ""){
				msg = isok?(ctl.okmsg||this.OkMsg):(ctl.errmsg||this.ErrorMsg);
			}
			text = isok?(ctl.oktext||this.OkText):(ctl.errtext||this.ErrorText);
			var result = new Validator.Result(ctl, isok, msg, text);

			if( show){
				this.ShowMsg(result);
			}
			
			if( isok == false){
				ctl.error = (ctl.errmsg||this.ErrorMsg);
			}
			else{
				ctl.error = "";
			}
			
			this.Results[this.Results.length] = result;
		}
	},
	
	GetMsgBox : function (obj){
		if(obj.parentNode && obj.parentNode.childNodes[obj.parentNode.childNodes.length-1]){
			var lastNode = obj.parentNode.childNodes[obj.parentNode.childNodes.length-1];
		}
		
		if( lastNode && lastNode.tagName == "SPAN"){
			var span = lastNode;
		}
		else{
			if(obj.parentNode && obj.parentNode.childNodes[obj.parentNode.childNodes.length-2]){
				var lastNode = obj.parentNode.childNodes[obj.parentNode.childNodes.length-2];
			}
			if( lastNode && lastNode.tagName == "SPAN"){
				var span = lastNode;
			}
			else if( obj.nextSibling && obj.nextSibling.tagName == "SPAN" ){
				var span = obj.nextSibling;
			}
			else{
				var span = document.createElement("SPAN");
				obj.parentNode.appendChild(span);
			}
		}
				
		return span;
	},
	
	ShowMsg : function( msgobj){
		switch(this.Style){
			default:{
				var msgbox = this.GetMsgBox(msgobj.control);
				if( msgbox){
					msgbox.className = msgobj.isok?"okinfo":"errinfo";
					msgbox.innerText = msgobj.text;//.message;		
				}
				else{
					alert(msgobj.message);
				}
				break;
			}
		}
	},
	
	BoundControls : function(){
		var ctls = document.getElementsByTagName("input");
		this.BoundCtls( ctls);
		ctls = document.getElementsByTagName("select");
		this.BoundCtls( ctls);
		ctls = document.getElementsByTagName("textarea");
		this.BoundCtls( ctls);
	
	/*
		if( document.forms.length > 0){
			document.forms[0].onsubmit = function(){return Validator.ValidateForm(document.forms[0]);};
		}	
	*/
	},
	
	BoundCtls : function(ctls){
		for( i = 0; i<ctls.length; i++){
			if( ctls[i].datatype){
				ctls[i].onblur = function(){Validator.Validate(this, 1);};
			}
			
			if( (ctls[i].type == "submit" 
			|| ctls[i].type == "image")
			&& !ctls[i].nocheck){
				if( ctls[i].onclick){
					//ctls[i].onclick = eval("ctls[i].onclick + 'if(!Validator.ValidateForm(document.forms[0])){return false;}}";
				}
				else{
					ctls[i].onclick = function(){return Validator.ValidateForm(document.forms[0]);};
				}
			}
			
			this.BoundStyle(ctls[i]);
		}
	},
	
	BoundStyle : function(ctl)	{
		if( ctl.type == "text" 
			|| ctl.type == "password" 
			|| ctl.tagName == "TEXTAREA"){
			
			ctl.onfocus		= function(){this.style.backgroundColor = Validator.FocusColor;};
			if( ctl.nocheck == "1") {return;}
			if( ctl.datatype || ctl.require){
				ctl.onblur = function(){Validator.Validate(this, 1);this.style.backgroundColor = Validator.BlurColor;};
			}
			else{
				ctl.onblur = function(){this.style.backgroundColor = Validator.BlurColor;};
			}
		}
	},
	
	Exec : function(op, reg){
		return new RegExp(reg,"g").test(op);
	},
	
	IsDate : function(op, formatString){
		formatString = formatString || "ymd";
		var m, year, month, day;
		switch(formatString){
			case "ymd" :
				m = op.match(new RegExp("^\\s*((\\d{4})|(\\d{2}))([-./])(\\d{1,2})\\4(\\d{1,2})\\s*$"));
				if(m == null ) return false;
				day = m[6];
				month = parseInt(m[5])-1;
				year =  (m[2].length == 4) ? m[2] : GetFullYear(parseInt(m[3], 10));
				break;
			case "dmy" :
				m = op.match(new RegExp("^\\s*(\\d{1,2})([-./])(\\d{1,2})\\2((\\d{4})|(\\d{2}))\\s*$"));
				if(m == null ) return false;
				day = m[1];
				month = parseInt(m[3])-1;
				year = (m[5].length == 4) ? m[5] : GetFullYear(parseInt(m[6], 10));
				break;
			default :
				break;
		}
		var date = new Date(year, month, day);
        return (typeof(date) == "object" && year == date.getFullYear() && month == date.getMonth() && day == date.getDate());
		function GetFullYear(y){return ((y<30 ? "20" : "19") + y)|0;}
	},
	
	IsUserID : function(op){
		var isok = this.Type["integer"].test(op);
		var min = 100000,max = 99999999;
		
		if( isok == true){
			var userid = new Number(op);
			isok = userid >= min && userid <= max;
		}
		
		return isok;
	}
	/*
	CheckImage : function(value,input,msg)
	{
		img1 = document.getElementById(img);
		img1.attachEvent("onload", imgOK);
		img1.attachEvent("onerror", imgError);
		img1.src = value;

		function imgOK()
		{
			img1 = document.getElementById(img);
			img1.detachEvent("onload",imgOK);
			if( img1.fileSize > 20 * 1024)
			{
				document.getElementById(input).value = false;
			}
			else
			{
				if( img1.width > 100)
				{		
					document.getElementById(input).value = false;
				}
				if( img1.height > 150)
				{
					document.getElementById(input).value = false;
				}
				document.getElementById(input).value = true;
			}
		}
		
		function imgError(){document.getElementById(input).value = false;}
		
		return true;
	}*/
};

